using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            SLLCaller();
            Console.ReadLine();
        }
        static void DLLCaller()
        {
            HelperDLL objHelper = new HelperDLL();
            DoubleLinkedList myLinkedList = new DoubleLinkedList();

            objHelper.InsertFront(myLinkedList, 10);
            objHelper.InsertFront(myLinkedList, 20);
            objHelper.InsertLast(myLinkedList, 100);
            objHelper.InsertBefore(myLinkedList.head.next.next, 30);
            objHelper.InsertAfter(myLinkedList.head.next.next, 40);
            objHelper.PrintList(myLinkedList);
            Console.WriteLine();
            objHelper.ReverseLinkedList(myLinkedList);
            objHelper.PrintList(myLinkedList);
            Console.WriteLine();
        }

        static void SLLCaller()
        {
            HelperSLL objHelper = new HelperSLL();
            SingleLinkedList myLinkedList = new SingleLinkedList();

            objHelper.InsertFront(myLinkedList, 2);
            objHelper.InsertLast(myLinkedList, 3);
            objHelper.InsertLast(myLinkedList, 4);
            objHelper.InsertLast(myLinkedList, 5);
            objHelper.InsertLast(myLinkedList, 6);
            objHelper.FindMiddle(myLinkedList);
            objHelper.InsertLast(myLinkedList, 25);
            objHelper.InsertAfter(myLinkedList.head.next.next, 30);
            objHelper.PrintList(myLinkedList);
            objHelper.ReverseLinkedList(myLinkedList);
            objHelper.DeleteNodebyKey(myLinkedList, 3);
            Console.WriteLine();
            objHelper.PrintList(myLinkedList);
            Console.WriteLine();
            objHelper.SearchLinkedList(myLinkedList, 25);
            objHelper.SearchLinkedList(myLinkedList, 40);
            objHelper.DeleteNodebyPosition(myLinkedList, 3);
            Console.WriteLine();
            objHelper.PrintList(myLinkedList);
            Console.ReadLine();
        }

    }
}
