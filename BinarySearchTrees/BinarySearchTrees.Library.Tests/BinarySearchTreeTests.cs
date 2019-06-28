using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTrees.Library.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void InsertIntTest()
        {
            var bst = new BinarySearchTree<int>();

            bst.Insert(14);
            var json = "{\"Value\":14,\"LeftChild\":null,\"RightChild\":null}";

            Assert.AreEqual(json, bst.GetJson());
        }

        [TestMethod]
        public void InsertDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            bst.Insert(14.99);
            var json = "{\"Value\":14.99,\"LeftChild\":null,\"RightChild\":null}";

            Assert.AreEqual(json, bst.GetJson());
        }

        [TestMethod]
        public void InsertStringTest()
        {
            var bst = new BinarySearchTree<string>();

            bst.Insert("A");
            var json = "{\"Value\":\"A\",\"LeftChild\":null,\"RightChild\":null}";

            Assert.AreEqual(json, bst.GetJson());
        }

        [TestMethod]
        public void TryInsertIntTest()
        {
            var bst = new BinarySearchTree<int>();

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.TryInsert(11, out Node<int> node));
            Assert.IsFalse(bst.TryInsert(11, out Node<int> node2));
        }

        [TestMethod]
        public void TryInsertDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i / 2.0);
            }

            Assert.IsTrue(bst.TryInsert(11, out Node<double> node));
            Assert.IsFalse(bst.TryInsert(11, out Node<double> node2));
        }

        [TestMethod]
        public void TryInsertStringTest()
        {
            var bst = new BinarySearchTree<string>();

            bst.Insert("A");
            bst.Insert("B");

            Assert.IsTrue(bst.TryInsert("C", out Node<string> node));
            Assert.IsFalse(bst.TryInsert("A", out Node<string> node2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Value already exists in the tree")]
        public void InsertSameValueIntTest()
        {
            var bst = new BinarySearchTree<int>();

            bst.Insert(2);
            bst.Insert(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Value already exists in the tree")]
        public void InsertSameValueDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            bst.Insert(2.0);
            bst.Insert(2.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Value already exists in the tree")]
        public void InsertSameValueStringTest()
        {
            var bst = new BinarySearchTree<string>();

            bst.Insert("A");
            bst.Insert("A");
        }

        [TestMethod]
        public void RemoveIntTest()
        {
            var bst = new BinarySearchTree<int>();

            Assert.IsFalse(bst.Remove(0));
            bst.Insert(11);
            Assert.IsTrue(bst.Remove(11));
            bst.Insert(11);
            Assert.IsFalse(bst.Remove(12));
           
            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.Remove(4));
            Assert.IsFalse(bst.Remove(4));
        }

        [TestMethod]
        public void RemoveDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            Assert.IsFalse(bst.Remove(1.0));
            bst.Insert(11.2);
            Assert.IsTrue(bst.Remove(11.2));
            bst.Insert(11.2);
            Assert.IsFalse(bst.Remove(12.4));

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i / 2.0);
            }

            Assert.IsTrue(bst.Remove(4.0));
            Assert.IsFalse(bst.Remove(4.0));
        }

        [TestMethod]
        public void RemoveStringTest()
        {
            var bst = new BinarySearchTree<string>();

            Assert.IsFalse(bst.Remove("A"));
            bst.Insert("A");
            Assert.IsTrue(bst.Remove("A"));
            bst.Insert("A");
            Assert.IsFalse(bst.Remove("B"));
        }

        [TestMethod]
        public void RemoveSubtreeIntTest()
        {
            var bst = new BinarySearchTree<int>();

            Assert.IsFalse(bst.RemoveSubtree(0));
            bst.Insert(11);
            Assert.IsTrue(bst.RemoveSubtree(11));
            bst.Insert(11);
            Assert.IsFalse(bst.RemoveSubtree(12));

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.RemoveSubtree(8));
            Assert.IsFalse(bst.RemoveSubtree(8));
        }

        [TestMethod]
        public void RemoveSubtreeDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            Assert.IsFalse(bst.RemoveSubtree(0.4));
            bst.Insert(11.8);
            Assert.IsTrue(bst.RemoveSubtree(11.8));
            bst.Insert(11.8);
            Assert.IsFalse(bst.RemoveSubtree(12.4));

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i / 2.0);
            }


            Assert.IsTrue(bst.RemoveSubtree(4.0));
            Assert.IsFalse(bst.RemoveSubtree(4.0));
        }

        [TestMethod]
        public void RemoveSubtreeStringTest()
        {
            var bst = new BinarySearchTree<string>();

            Assert.IsFalse(bst.RemoveSubtree("A"));
            bst.Insert("A");
            Assert.IsTrue(bst.RemoveSubtree("A"));
            bst.Insert("A");
            Assert.IsFalse(bst.RemoveSubtree("B"));
        }

        [TestMethod]
        public void SearchIntTest()
        {
            var bst = new BinarySearchTree<int>();

            Assert.IsFalse(bst.Search(0));

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.Search(5));
            Assert.IsFalse(bst.Search(11));
        }

        [TestMethod]
        public void SearchDoubleTest()
        {
            var bst = new BinarySearchTree<double>();

            Assert.IsFalse(bst.Search(0.3));

            for (var i = 0; i < 10; i++)
            {
                bst.Insert(i / 2.0);
            }


            Assert.IsTrue(bst.Search(4.0));
            Assert.IsFalse(bst.Search(11.4));
        }

        [TestMethod]
        public void SearchStringTest()
        {
            var bst = new BinarySearchTree<string>();

            Assert.IsFalse(bst.Search("A"));

            bst.Insert("A");
            bst.Insert("B");

            Assert.IsTrue(bst.Search("A"));
            Assert.IsFalse(bst.Search("C"));
        }
    }
}
