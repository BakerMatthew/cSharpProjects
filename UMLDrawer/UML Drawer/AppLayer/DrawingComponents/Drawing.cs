using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace AppLayer.DrawingComponents
{
    public class Drawing
    {
        private static readonly DataContractJsonSerializer JsonSerializer =
                new DataContractJsonSerializer(
                    typeof(List<Element>),
                    new[] { typeof(Element),
                        typeof(Association),
                        typeof(AssociationWithAllState),
                        typeof(AssociationExtrinsicState)
                    });

        private readonly List<Element> elements = new List<Element>();
        private readonly object myLock = new object();

        public bool IsDirty { get; set; } = true;

        public List<Element> GetCloneOfElements()
        {
            var cloneList = new List<Element>();
            lock (myLock)
            {
                cloneList.AddRange(elements.Select(element => element.Clone()));
            }

            return cloneList;
        }

        public void Clear()
        {
            lock (myLock)
            {
                elements.Clear();
                IsDirty = true;
            }
        }

        public void LoadFromStream(Stream stream)
        {
            var loadedElements = JsonSerializer.ReadObject(stream) as List<Element>;

            if (loadedElements == null || loadedElements.Count == 0) return;

            lock (myLock)
            {
                foreach (var element in loadedElements)
                {
                    var tmpAssocation = element as AssociationWithAllState;
                    if (tmpAssocation != null)
                    {
                        Association fullAssociation = AssociationFactory.Instance.GetAssocation(tmpAssocation.ExtrinsicState);
                        elements.Add(fullAssociation);
                    }
                    else
                    {
                        elements.Add(element);
                    }
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            lock (myLock)
            {
                JsonSerializer.WriteObject(stream, elements);
            }
        }

        public void Add(Element element)
        {
            if (element == null) return;

            lock (myLock)
            {
                elements.Add(element);
                IsDirty = true;
            }
        }

        public List<Element> DeleteAllSelected()
        {
            List<Element> elementsToDelete;
            lock (myLock)
            {
                elementsToDelete = elements.FindAll(t => t.IsSelected);
                elements.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return elementsToDelete;
        }

        public void DeleteElement(Element element)
        {
            lock (myLock)
            {
                elements.Remove(element);
                IsDirty = true;
            }
        }

        public Element FindElementAtPosition(Point point)
        {
            Element result;
            lock (myLock)
            {
                result = elements.FindLast(t => t.ContainsPoint(point));
            }
            return result;
        }

        public List<Element> DeselectAll()
        {
            var selectedElements = new List<Element>();
            lock (myLock)
            {
                foreach (var t in elements)
                {
                    if (t.IsSelected)
                    {
                        selectedElements.Add(t);
                        t.IsSelected = false;
                    }
                }
                IsDirty = true;
            }
            return selectedElements;
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;

                graphics.Clear(Color.White);
                foreach (var t in elements)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

    }
}
