using System;
using System.Collections.Generic;

namespace Task2
{
    public class BinaryTree<T>
    {
        private class Node
        {
            public Node Left;
            public Node Right;
            public readonly T Value;

            public Node(T value)
            {
                Value = value;
            }
        }

        private readonly IComparer<T> comparer;

        private Node root; 
         
        public BinaryTree (IComparer<T> comparer = null )
        {
            if (comparer == null)
            {
                if (typeof (T).GetInterface("IComparable") == null && typeof (T).GetInterface("IComparable`1") == null)
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
                this.comparer = Comparer<T>.Default;
            }
            else
            {
                this.comparer = comparer;
            }
        }

        #region Public methods
        public void Add(T value )
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Add(ref root, new Node(value));
        }

        public IEnumerable<T> Preorder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty!");
            }
            return Preorder(root);
        }

        public IEnumerable<T> Inorder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty!");
            }
            return Inorder(root);
        }

        public IEnumerable<T> Postorder()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty!");
            }
            return Postorder(root);
        }
        #endregion


        #region Private methods
        private void Add(ref Node currentRoot, Node node)
        {
            if (currentRoot == null  || comparer.Compare(currentRoot.Value, node.Value ) == 0)
            {
                currentRoot = node;
            }
            else
            {
                if (comparer.Compare(currentRoot.Value, node.Value) < 0)
                {
                    Add(ref currentRoot.Right, node);
                }
                else if (comparer.Compare(currentRoot.Value, node.Value) > 0)
                {
                    Add(ref currentRoot.Left, node);
                }
            }
        }

        private IEnumerable<T> Preorder(Node node )
        {
            if (node == null) yield break;

            yield return node.Value;

            foreach (T value in Preorder(node.Left))
            {
                yield return value;
            }

            foreach (T value in Preorder(node.Right))
            {
                yield return value;
            }
        }

        private IEnumerable<T> Inorder(Node node)
        {
            if (node == null) yield break;

            foreach (T value in Inorder(node.Left))
            {
                yield return value;
            }

            yield return node.Value;

            foreach (T value in Inorder(node.Right))
            {
                yield return value;
            }

        }

        private IEnumerable<T> Postorder(Node node)
        {
            if (node == null) yield break;

            foreach (T value in Postorder(node.Left))
            {
                yield return value;
            }

            foreach (T value in Postorder(node.Right))
            {
                yield return value;
            }

            yield return node.Value;
        }
        #endregion

    }
}
