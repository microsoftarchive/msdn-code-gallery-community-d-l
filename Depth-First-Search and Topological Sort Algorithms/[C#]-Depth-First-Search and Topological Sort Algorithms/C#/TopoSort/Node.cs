using System;
using System.Collections.Generic;

namespace TopoSort
{
    public enum Colors {BLACK, GRAY, WHITE};

    class Node
    {
        private int discovery;
        private int finish;
        private int id;
        private string name;
        private Colors color;
        private List<Node> adjacency;

        public int Discovery
        {
            get
            {
                return discovery;
            }
            set
            {
                discovery = value;
            }
        }

        public int Finish
        {
            get
            {
                return finish;
            }
            set
            {
                finish = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Colors Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public List<Node> Adjacency
        {
            get
            {
                return adjacency;
            }
            set
            {
                adjacency = value;
            }
        }

        public Node(
            int discovery,
            int finish,
            int id,
            string name,
            List<Node> adjacency)
        {
            this.discovery = discovery;
            this.finish = finish;
            this.id = id;
            this.name = name;
            this.adjacency = adjacency;
        }
    }
}