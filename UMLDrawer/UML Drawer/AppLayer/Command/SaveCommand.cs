using System.IO;

namespace AppLayer.Command
{
    public class SaveCommand : Command
    {
        private readonly string filename;
        internal SaveCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            StreamWriter writer = new StreamWriter(filename);
            TargetDrawing?.SaveToStream(writer.BaseStream);
            writer.Close();

            return true;
        }

        internal override void Undo() { }
        internal override void Redo() { Execute(); }
    }
}
