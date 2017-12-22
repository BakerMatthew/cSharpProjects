using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        private List<Element> deletedElements;
        internal RemoveSelectedCommand() { }

        public override bool Execute()
        {
            deletedElements = TargetDrawing?.DeleteAllSelected();
            return deletedElements != null && deletedElements.Count > 0;
        }

        internal override void Undo()
        {
            if (deletedElements == null || deletedElements.Count == 0) return;

            foreach (var element in deletedElements)
                TargetDrawing?.Add(element);
        }

        internal override void Redo()
        {
            if (deletedElements == null || deletedElements.Count == 0) return;

            foreach (var association in deletedElements)
                TargetDrawing?.DeleteElement(association);
        }
    }
}
