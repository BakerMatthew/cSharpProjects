using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public abstract class Command
    {
        public Drawing TargetDrawing { get; set; }
        public abstract bool Execute();
        internal abstract void Undo();
        internal abstract void Redo();
    }
}
