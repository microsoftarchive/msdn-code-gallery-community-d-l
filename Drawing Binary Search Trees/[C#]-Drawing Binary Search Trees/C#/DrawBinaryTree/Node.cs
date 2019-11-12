// code by Scott Mitchell

using System;

namespace DrawBinaryTree
{
    public class Node<T>
    {
        // Private member-variables
        private int xpos, ypos;
        private T data;
        private NodeList<T> neighbors = null;

        public int Xpos
        {
            get
            {
                return xpos;
            }
            set
            {
                xpos = value;
            }
        }

        public int Ypos
        {
            get
            {
                return ypos;
            }
            set
            {
                ypos = value;
            }
        }

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
}
