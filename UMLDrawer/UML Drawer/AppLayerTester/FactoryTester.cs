using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents;
using AppLayer.Command;

namespace AppLayerTester
{
    [TestClass]
    public class FactoryTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Bad Association Type")]
        public void TheAssociationFactoryThrownTypeTest()
        {
            // Given
            AssociationFactory associationFactory = AssociationFactory.Instance;


            // When
            AssociationWithAllState association = associationFactory.GetAssocation(new AssociationExtrinsicState() { AssocationType = "association type" });

            // Then
            // ArgumentNullException thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Bad Association Resource Type")]
        public void TheAssociationFactoryThrownResourceTest()
        {
            // Given
            AssociationFactory associationFactory = AssociationFactory.Instance;

            // When
            AssociationWithAllState association = associationFactory.GetAssocation(new AssociationExtrinsicState() { AssocationType = "association" });

            // Then
            // ArgumentNullException thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid Command Type")]
        public void TheCommandFactoryThrownResourceTest()
        {
            // Given
            CommandFactory commandFactory = CommandFactory.Instance;

            // When
            commandFactory.CreateAndExecute("BAD COMMAND", new object[2]);
            commandFactory.Invoker.Start();

            // Then
            // NullReferenceException thrown
        }

        [TestMethod]
        public void TheCommandFactoryTest()
        {
            // Given
            CommandFactory commandFactory = CommandFactory.Instance;

            // When
            commandFactory.CreateAndExecute("NEW", new object[2]);

            // Then
            // No exception
        }
    }
}
