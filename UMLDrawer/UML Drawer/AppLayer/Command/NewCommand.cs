using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class NewCommand : Command
    {
        private List<Element> previousElements;
        internal NewCommand() { }

        public override bool Execute()
        {
            previousElements = TargetDrawing.GetCloneOfElements();
            TargetDrawing?.Clear();
            return previousElements != null && previousElements.Count > 0;
        }

        internal override void Undo()
        {
            if (previousElements == null || previousElements.Count == 0) return;

            foreach (var element in previousElements)
                TargetDrawing?.Add(element);
        }

        internal override void Redo() { Execute(); }
    }
}
