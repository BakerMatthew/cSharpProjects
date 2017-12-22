using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents;

namespace AppLayerTester
{
    [TestClass]
    public class DrawingTester
    {
        [TestMethod]
        public void TheAddElementTest()
        {
            // Given
            Drawing drawing = new Drawing();

            // When
            drawing.Add(new UmlClass());
            drawing.Add(new UmlClass());

            // Then
            Assert.AreEqual(2, drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TheClearElementsTest()
        {
            // Given
            Drawing drawing = new Drawing();
            drawing.Add(new UmlClass());
            drawing.Add(new UmlClass());

            // When
            drawing.Clear();

            // Then
            Assert.AreEqual(0, drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TheDeleteSelectedElementsTest()
        {
            // Given
            Drawing drawing = new Drawing();
            drawing.Add(new UmlClass() { IsSelected = true });
            drawing.Add(new UmlClass() { IsSelected = true });
            drawing.Add(new UmlClass() { IsSelected = false });

            // When
            drawing.DeleteAllSelected();

            // Then
            Assert.AreEqual(1, drawing.GetCloneOfElements().Count);
        }

        [TestMethod]
        public void TheDeleteElementTest()
        {
            // Given
            Element element = new UmlClass();
            Drawing drawing = new Drawing();
            drawing.Add(element);

            // When
            drawing.DeleteElement(element);

            // Then
            Assert.AreEqual(0, drawing.GetCloneOfElements().Count);
        }
    }
}
