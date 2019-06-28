using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTrees.Library.Tests
{
    [TestClass]
    public class DSWBalancedBinarySearchTreeTests
    {
        [TestMethod]
        public void InsertIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();
            var json = "{\"Value\":14,\"LeftChild\":null,\"RightChild\":null}";
            bst.Insert(14);

            Assert.AreEqual(json, bst.GetJson());

            bst.Insert(2);
            bst.Insert(16);
            var balanced = "{\"Value\":14,\"LeftChild\":{\"Value\":2,\"LeftChild\":null,\"RightChild\":null}," +
                "\"RightChild\":{\"Value\":16,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced,bst.GetJson());
        }

        [TestMethod]
        public void InsertDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();
            var json = "{\"Value\":14.7,\"LeftChild\":null,\"RightChild\":null}";
            bst.Insert(14.7);

            Assert.AreEqual(json, bst.GetJson());

            bst.Insert(2.3);
            bst.Insert(16.4);
            var balanced = "{\"Value\":14.7,\"LeftChild\":{\"Value\":2.3,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":16.4,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());
        }

        [TestMethod]
        public void InsertStringTest()
        {
            var bst = new DSWBalancedBinarySearchTree<string>();
            var json = "{\"Value\":\"B\",\"LeftChild\":null,\"RightChild\":null}";
            bst.Insert("B");

            Assert.AreEqual(json, bst.GetJson());

            bst.Insert("A");
            bst.Insert("C");
            var balanced = "{\"Value\":\"B\",\"LeftChild\":{\"Value\":\"A\",\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":\"C\",\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());
        }

        [TestMethod]
        public void TryInsertIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();
            var json = "{\"Value\":14,\"LeftChild\":null,\"RightChild\":null}";

            Assert.IsTrue(bst.TryInsert(14, out Node<int> node1));
            Assert.IsFalse(bst.TryInsert(14, out Node<int> node3));

            Assert.AreEqual(json, bst.GetJson());

            Assert.IsTrue(bst.TryInsert(2, out Node<int> node2));
            Assert.IsTrue(bst.TryInsert(16, out Node<int> node4));
            var balanced = "{\"Value\":14,\"LeftChild\":{\"Value\":2,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":16,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());
        }

        [TestMethod]
        public void TryInsertDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();
            var json = "{\"Value\":14.7,\"LeftChild\":null,\"RightChild\":null}";

            Assert.IsTrue(bst.TryInsert(14.7, out Node<double> node1));
            Assert.IsFalse(bst.TryInsert(14.7, out Node<double> node3));

            Assert.AreEqual(json, bst.GetJson());

            Assert.IsTrue(bst.TryInsert(2.7, out Node<double> node2));
            Assert.IsTrue(bst.TryInsert(16.7, out Node<double> node4));
            var balanced = "{\"Value\":14.7,\"LeftChild\":{\"Value\":2.7,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":16.7,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());
        }

        [TestMethod]
        public void TryInsertStringTest()
        {
            var bst = new DSWBalancedBinarySearchTree<string>();
            var json = "{\"Value\":\"B\",\"LeftChild\":null,\"RightChild\":null}";

            Assert.IsTrue(bst.TryInsert("B", out Node<string> node1));
            Assert.IsFalse(bst.TryInsert("B", out Node<string> node3));

            Assert.AreEqual(json, bst.GetJson());

            Assert.IsTrue(bst.TryInsert("A", out Node<string> node2));
            Assert.IsTrue(bst.TryInsert("C", out Node<string> node4));
            var balanced = "{\"Value\":\"B\",\"LeftChild\":{\"Value\":\"A\",\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":\"C\",\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());
        }

        [TestMethod]
        public void RemoveIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();

            Assert.IsFalse(bst.Remove(0));

            bst.Insert(11);

            Assert.IsTrue(bst.Remove(11));
            Assert.IsFalse(bst.Remove(11));

            for (var i = 0; i < 7; i++)
            {
                bst.Insert(i);
            }

            var balanced = "{\"Value\":3,\"LeftChild\":{\"Value\":1," +
                           "\"LeftChild\":{\"Value\":0,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":2,\"LeftChild\":null,\"RightChild\":null}}," +
                           "\"RightChild\":{\"Value\":5," +
                           "\"LeftChild\":{\"Value\":4,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":6,\"LeftChild\":null,\"RightChild\":null}}}";

            Assert.AreEqual(balanced,bst.GetJson());

            Assert.IsTrue(bst.Remove(1));
            Assert.IsFalse(bst.Remove(1));
        }

        [TestMethod]
        public void RemoveDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();

            Assert.IsFalse(bst.Remove(0.4));

            bst.Insert(11.3);

            Assert.IsTrue(bst.Remove(11.3));
            Assert.IsFalse(bst.Remove(11.3));

            bst.Insert(1.2);
            bst.Insert(2.8);
            bst.Insert(6.9);

            var balanced = "{\"Value\":2.8,\"LeftChild\":{\"Value\":1.2,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":6.9,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());

            Assert.IsTrue(bst.Remove(6.9));
            Assert.IsFalse(bst.Remove(6.9));
        }

        [TestMethod]
        public void RemoveStringTest()
        {
            var bst = new DSWBalancedBinarySearchTree<string>();

            Assert.IsFalse(bst.Remove("A"));

            bst.Insert("A");

            Assert.IsTrue(bst.Remove("A"));
            Assert.IsFalse(bst.Remove("A"));

            bst.Insert("A");
            bst.Insert("B");
            bst.Insert("C");

            var balanced = "{\"Value\":\"B\",\"LeftChild\":{\"Value\":\"A\",\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":\"C\",\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());

            Assert.IsTrue(bst.Remove("C"));
            Assert.IsFalse(bst.Remove("C"));
        }

        [TestMethod]
        public void RemoveSubtreeIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();

            Assert.IsFalse(bst.RemoveSubtree(0));

            bst.Insert(11);

            Assert.IsTrue(bst.RemoveSubtree(11));
            Assert.IsFalse(bst.RemoveSubtree(11));

            for (var i = 0; i < 7; i++)
            {
                bst.Insert(i);
            }

            var balanced = "{\"Value\":3,\"LeftChild\":{\"Value\":1," +
                           "\"LeftChild\":{\"Value\":0,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":2,\"LeftChild\":null,\"RightChild\":null}}," +
                           "\"RightChild\":{\"Value\":5," +
                           "\"LeftChild\":{\"Value\":4,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":6,\"LeftChild\":null,\"RightChild\":null}}}";

            Assert.AreEqual(balanced, bst.GetJson());
            Assert.IsTrue(bst.RemoveSubtree(5));

            var balanced2 = "{\"Value\":2,\"LeftChild\":{\"Value\":1," +
                            "\"LeftChild\":{\"Value\":0,\"LeftChild\":null,\"RightChild\":null}," +
                            "\"RightChild\":null}," +
                            "\"RightChild\":{\"Value\":3,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced2, bst.GetJson());
            Assert.IsTrue(bst.RemoveSubtree(2));
            Assert.IsFalse(bst.RemoveSubtree(2));
        }

        [TestMethod]
        public void RemoveSubtreeDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();

            Assert.IsFalse(bst.RemoveSubtree(0.3));

            bst.Insert(11.7);

            Assert.IsTrue(bst.RemoveSubtree(11.7));
            Assert.IsFalse(bst.RemoveSubtree(11.7));

            bst.Insert(2.7);
            bst.Insert(11.7);
            bst.Insert(16.7);

            var balanced = "{\"Value\":11.7,\"LeftChild\":{\"Value\":2.7,\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":16.7,\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());

            Assert.IsTrue(bst.RemoveSubtree(11.7));

            var balanced2 = "null";

            Assert.AreEqual(balanced2, bst.GetJson());
        }

        [TestMethod]
        public void RemoveSubtreeStringTest()
        {
            var bst = new DSWBalancedBinarySearchTree<string>();

            Assert.IsFalse(bst.RemoveSubtree("A"));

            bst.Insert("A");

            Assert.IsTrue(bst.RemoveSubtree("A"));
            Assert.IsFalse(bst.RemoveSubtree("A"));

            bst.Insert("A");
            bst.Insert("B");
            bst.Insert("C");

            var balanced = "{\"Value\":\"B\",\"LeftChild\":{\"Value\":\"A\",\"LeftChild\":null,\"RightChild\":null}," +
                           "\"RightChild\":{\"Value\":\"C\",\"LeftChild\":null,\"RightChild\":null}}";

            Assert.AreEqual(balanced, bst.GetJson());

            Assert.IsTrue(bst.RemoveSubtree("B"));

            var balanced2 = "null";

            Assert.AreEqual(balanced2, bst.GetJson());
        }

        [TestMethod]
        public void RemoveBigTreeIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();

            for (var i = 0; i < 50; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.Remove(20));
            Assert.IsTrue(bst.Remove(5));
            Assert.IsTrue(bst.Remove(45));
            Assert.IsFalse(bst.Remove(50));
            Assert.IsTrue(bst.RemoveSubtree(37));
            Assert.IsFalse(bst.RemoveSubtree(-1));
        }

        [TestMethod]
        public void RemoveBigTreeDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();

            for (var i = 0; i < 50; i++)
            {
                bst.Insert(i / 2.0);
            }

            Assert.IsTrue(bst.Remove(20.0));
            Assert.IsTrue(bst.Remove(5.0));
            Assert.IsTrue(bst.Remove(24.0));
            Assert.IsFalse(bst.Remove(50.5));
            Assert.IsTrue(bst.RemoveSubtree(23.0));
            Assert.IsFalse(bst.RemoveSubtree(-1.9));
        }

        [TestMethod]
        public void SearchIntTest()
        {
            var bst = new DSWBalancedBinarySearchTree<int>();

            Assert.IsFalse(bst.Search(0));

            for (var i = 0; i < 20; i++)
            {
                bst.Insert(i);
            }

            Assert.IsTrue(bst.Search(19));
            Assert.IsFalse(bst.Search(20));
            Assert.IsTrue(bst.Search(0));
        }

        [TestMethod]
        public void SearchDoubleTest()
        {
            var bst = new DSWBalancedBinarySearchTree<double>();

            Assert.IsFalse(bst.Search(0.4));

            for (var i = 0; i < 20; i++)
            {
                bst.Insert(i / 2.0);
            }

            Assert.IsTrue(bst.Search(8.0));
            Assert.IsFalse(bst.Search(20.4));
            Assert.IsTrue(bst.Search(0));
        }

        [TestMethod]
        public void SearchStringTest()
        {
            var bst = new DSWBalancedBinarySearchTree<string>();

            Assert.IsFalse(bst.Search("A"));

            bst.Insert("A");
            bst.Insert("B");
            bst.Insert("C");
            bst.Insert("D");
            bst.Insert("E");

            Assert.IsTrue(bst.Search("D"));
            Assert.IsFalse(bst.Search("F"));
            Assert.IsTrue(bst.Search("E"));
        }
    }
}
