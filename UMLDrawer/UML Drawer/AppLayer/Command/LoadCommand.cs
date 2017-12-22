using System.Collections.Generic;
using System.IO;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class LoadCommand : Command
    {
        private readonly string filename;
        private List<Element> previousElements;

        internal LoadCommand() { }
        internal LoadCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            previousElements = TargetDrawing.GetCloneOfElements();
            TargetDrawing?.Clear();

            StreamReader reader = new StreamReader(filename);
            TargetDrawing?.LoadFromStream(reader.BaseStream);
            reader.Close();

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.Clear();

            if (previousElements == null || previousElements.Count == 0) return;

            foreach (var element in previousElements)
                TargetDrawing?.Add(element);
        }

        internal override void Redo() { Execute(); }
    }
}
