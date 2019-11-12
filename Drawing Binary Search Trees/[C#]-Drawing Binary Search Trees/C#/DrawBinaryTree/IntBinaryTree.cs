using System;
using System.Collections.Generic;

namespace DrawBinaryTree
{
    public class IntBinaryTree
    {
        private BinaryTreeNode<int> intRoot;

        public BinaryTreeNode<int> IntRoot
        {
            get
            {
                return intRoot;
            }
        }

        public IntBinaryTree(List<int> data)
        {
            intRoot = new BinaryTreeNode<int>(data[0]);

            for (int i = 1; i < data.Count; i++)
                InsertInTree(data[i]);
        }

        private void InsertInTree(int number)
        {
            bool inserted = false;
            BinaryTreeNode<int> newNode = new BinaryTreeNode<int>();
            BinaryTreeNode<int> oneNode = intRoot;

            while (!inserted)
            {
                if (number <= oneNode.Value)
                {
                    if (oneNode.Left != null)
                        oneNode = oneNode.Left;
                    else
                    {
                        oneNode.Left = newNode;
                        inserted = true;
                    }
                }
                else
                {
                    if (oneNode.Right != null)
                        oneNode = oneNode.Right;
                    else
                    {
                        oneNode.Right = newNode;
                        inserted = true;
                    }
                }
            }

            newNode.Value = number;
        }
    }
}
