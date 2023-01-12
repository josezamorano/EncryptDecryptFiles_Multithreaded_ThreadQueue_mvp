using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileEncryptDecrypt.Utils.MultithreadingHelper
{
    public class ThreadQueue: IDisposable
    {
        private static int TOTAL_WORKER_THREADS = 10;

        //readonly object _locker1 = new object();
        //readonly object _locker2 = new object();
        //readonly object _locker3 = new object();

        private readonly List<Thread> _workers; //queue of worker threads ready to process actions/tasks
    
        private readonly ConcurrentQueue<Action> _taskQueue = new ConcurrentQueue<Action>(); // actions to be processed by worker threads
        private bool _disallowAdd; // set to true when disposing queue but there are still tasks pending
        private bool _disposed; // set to true when disposing queue and no more tasks are pending

        public ThreadQueue()
        {
            int totalWorkerThreads = getAvailableWorkerThreads();
            _workers = new List<Thread>(totalWorkerThreads);
            // Create and start a separate thread for each worker
            for (int i = 0; i < totalWorkerThreads; i++)
            {
                Thread threadWorker = new Thread(Consume);
                threadWorker.IsBackground = true;
                threadWorker.Name = string.Format("ThreadQueue_worker {0}", i);
                _workers.Add(threadWorker);
                threadWorker.Start();
            }
        }

        private int getAvailableWorkerThreads()
        {            
            int workerThread = 0;
            int asyncIOThread = 0;
            ThreadPool.GetAvailableThreads(out workerThread, out asyncIOThread);
            int availableWorkerThreads = (TOTAL_WORKER_THREADS > workerThread) ? workerThread : TOTAL_WORKER_THREADS;
            return availableWorkerThreads;
        }


        public void EnqueueTask(Action task)
        {
            lock (_taskQueue)
            {
                if (this._disallowAdd) { throw new InvalidOperationException("This Pool instance is in the process of being disposed, can't add anymore"); }
                if (this._disposed) { throw new ObjectDisposedException("This Pool instance has already been disposed"); }

                _taskQueue.Enqueue(task);
                Monitor.PulseAll(_taskQueue);
            }
        }


        void Consume()
        {
            Action? task = null;
            while (true)
            {
                lock (this._taskQueue)
                {
                    while (true)
                    {
                        if (_disposed)
                        {
                            return;
                        }
                        var currentWorker = this._workers.Select(a => a).FirstOrDefault();
                        var currentThread = Thread.CurrentThread;

                        // we can only claim a task if its our turn (this worker thread is the first entry in _worker queue) and there is a task available
                        if (null != currentWorker &&
                            object.ReferenceEquals(Thread.CurrentThread, currentWorker) && 
                            this._taskQueue.Count > 0)   
                        {
                            Action? queueElement;
                            bool gotElement = this._taskQueue.TryDequeue(out queueElement);
                            if (gotElement)
                            {
                                task = queueElement;
                            } 
                            if(task ==null)
                            {
                                return;
                            }
                            task();
                            Monitor.PulseAll(this._taskQueue); // pulse because current (First) worker changed (so that next available sleeping worker will pick up its task)
                            break; // we found a task to process, break out from the above 'while (true)' loop
                        }
                        Monitor.Wait(this._taskQueue); // go to sleep, either not our turn or no task to process
                    }
                }
            }
        }

        public void Dispose()
        {            
            bool waitForThreads = false;
            lock (this._taskQueue)
            {
                if (!this._disposed)
                {
                    GC.SuppressFinalize(this);

                    this._disallowAdd = true; // wait for all tasks to finish processing while not allowing any more new tasks
                    while (this._taskQueue.Count > 0)
                    {
                        Monitor.Wait(this._taskQueue);
                    }

                    this._disposed = true;
                    Monitor.PulseAll(this._taskQueue); // wake all workers (none of them will be active at this point; disposed flag will cause then to finish so that we can join them)
                    waitForThreads = true;
                }
                if (waitForThreads)
                {
                    foreach (var worker in this._workers)
                    {
                        if(Thread.CurrentThread != worker)
                        {
                            worker.Join();
                        }                           
                    }
                }
            }            
        }
    }
}
