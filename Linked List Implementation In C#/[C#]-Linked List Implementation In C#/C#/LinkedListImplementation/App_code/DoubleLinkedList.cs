using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    internal class DoubleLinkedList
    {
        internal DNode head;
    }

    internal class DNode
    {
        internal int data;
        internal DNode prev;
        internal DNode next;

        // Constructor to create a new node
        // next and prev is by default initialized as null
        public DNode(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }
    internal class HelperDLL
    {
        #region Insert_into_DoubleLinkedList
        public void InsertFront(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);

            newNode.next = doubleLinkedList.head;
            newNode.prev = null;

            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }

        internal void InsertAfter(DNode prev_node, int data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);

            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;

            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }

        internal void InsertBefore(DNode next_node, int data)
        {
            if (next_node == null)
            {
                Console.WriteLine("The given next node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);

            newNode.prev = next_node.prev;
            next_node.prev = newNode;
            newNode.next = next_node;

            if (newNode.prev != null)
            {
                newNode.prev.next = newNode;
            }
        }

        internal void InsertLast(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            DNode lastNode = GetLastNode(doubleLinkedList);

            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        #endregion Insert_into_DoubleLinkedList

        internal DNode GetLastNode(DoubleLinkedList doubleLinkedList)
        {
            DNode temp = doubleLinkedList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        internal void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)
        {
            DNode temp = doubleLinkedList.head;

            if (temp != null && temp.data == key)
            {
                doubleLinkedList.head = temp.next;
                doubleLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.data != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }
        public void ReverseLinkedList(DoubleLinkedList doubleLinkedList)
        {
            DNode temp = null;
            DNode current = doubleLinkedList.head;

            /* swap next and prev for all nodes of doubly linked list */
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            if (temp != null)
            {
                doubleLinkedList.head = temp.prev;
            }
        }

        public void PrintList(DoubleLinkedList doubleLinkedList)
        {
            DNode n = doubleLinkedList.head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
        }
    }
}