namespace AppLayer.Command
{
    public class RedoCommand : Command
    {
        public override bool Execute() { return false; }
        internal override void Undo() { }
        internal override void Redo() { }
    }
}
