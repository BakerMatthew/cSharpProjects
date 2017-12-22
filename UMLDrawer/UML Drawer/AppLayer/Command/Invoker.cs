using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace AppLayer.Command
{
    public class Invoker
    {
        private Thread worker;
        private bool keepGoing;

        private readonly ConcurrentQueue<Command> todoQueue = new ConcurrentQueue<Command>();
        private readonly AutoResetEvent enqueueOccurred = new AutoResetEvent(false);

        private readonly Stack<Command> undoStack = new Stack<Command>();
        private readonly Stack<Command> redoStack = new Stack<Command>();

        public void Start()
        {
            keepGoing = true;
            worker = new Thread(Run);
            worker.Start();
        }

        public void Stop()
        {
            keepGoing = false;
        }

        public void EnqueueCommandForExecution(Command cmd)
        {
            if (cmd != null)
            {
                todoQueue.Enqueue(cmd);
                enqueueOccurred.Set();
            }
        }

        public void Undo()
        {
            EnqueueCommandForExecution(new UndoCommand());
        }

        public void Redo()
        {
            EnqueueCommandForExecution(new RedoCommand());
        }

        private void Run()
        {
            while (keepGoing)
            {
                Command cmd;
                if (todoQueue.TryDequeue(out cmd))
                {
                    if (cmd is UndoCommand)
                        ExecuteUndo();
                    else if (cmd is RedoCommand)
                        ExecuteRedo();
                    else
                    {
                        if (cmd.Execute())
                            undoStack.Push(cmd);
                    }
                }
                else
                    enqueueOccurred.WaitOne(100);
            }
        }

        private void ExecuteUndo()
        {
            if (undoStack.Count <= 0) return;

            var cmd = undoStack.Pop();
            cmd.Undo();
            redoStack.Push(cmd);
        }

        private void ExecuteRedo()
        {
            if (redoStack.Count <= 0) return;

            var cmd = redoStack.Pop();
            cmd.Redo();
            undoStack.Push(cmd);
        }

    }
}
