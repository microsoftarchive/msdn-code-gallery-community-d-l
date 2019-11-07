# Linked List Implementation In C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
## Topics
- Data Structures
## Updated
- 02/09/2018
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In this article, I am going to discuss one of the most important Data Structure- Linked List.</span></p>
<p><span style="font-size:small"><strong>I will be explaining about</strong></span></p>
<ul>
<li><span style="font-size:small">Linked List</span> </li><li><span style="font-size:small">Advantage of Linked List</span> </li><li><span style="font-size:small">Types of Linked List</span> </li><li><span style="font-size:small">How to Create a Linked List</span> </li><li><span style="font-size:small">Various operations on Linked list.&nbsp;</span>
</li></ul>
<h1>What is a Linked List ?</h1>
<p><span style="font-size:small">Linked List is a linear data structure which consists of a group of nodes in a sequence. Each node contains two parts.</span></p>
<div>
<ul>
<li><span style="font-size:small">Data&minus; Each node of a linked list can store a data.</span>
</li><li><span style="font-size:small">Address &minus; Each node of a linked list contains an address to the next node, called &quot;Next&quot;.</span>
</li></ul>
</div>
<div><span style="font-size:small">The first node of a Linked List is referenced by a pointer called Head.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small"><span style="white-space:pre">&nbsp;</span><img id="187435" src="187435-ll_1.png" alt="" width="357" height="98"></span></div>
<div></div>
<h1>Advantages of Linked List<span style="font-size:small"><br>
</span></h1>
<p><span style="font-size:small">&nbsp;</span></p>
<div>
<ul>
<li>
<p><span style="font-size:small">They are dynamic in nature and allocate memory as and when required.
</span></p>
</li><li>
<p><span style="font-size:small">Insertion and deletion is easy to implement. </span>
</p>
</li><li>
<p><span style="font-size:small">Other data structures such as Stack and Queue can also be implemented easily using Linked List.
</span></p>
</li><li>
<p><span style="font-size:small">It has faster access time and can be expanded in constant time without memory overhead.
</span></p>
</li><li>
<p><span style="font-size:small">Since there is no need to define an initial size for a linked list, hence memory utilization is effective.
</span></p>
</li><li>
<p><span style="font-size:small"><a href="https://en.wikipedia.org/wiki/Backtracking" target="_blank">Backtracking</a> is possible in doubly linked lists.</span></p>
</li></ul>
</div>
<h1><strong>Types of Linked List</strong></h1>
<ul>
<li><span style="font-size:small"><strong>Singly Linked List</strong>: Singly linked lists contain nodes which have a data part and an address part, i.e., Next, which points to the next node in the sequence of nodes. The next pointer of the last node will point
 to null. It can be used to implement other data structures such as stack and queue.</span>
</li></ul>
<p><span style="white-space:pre">&nbsp;</span><span style="white-space:pre"> <span style="white-space:pre">
</span></span><span style="white-space:pre">&nbsp;</span><img id="187436" src="187436-ll_2.png" alt="" width="430" height="100"></p>
<ul>
<li><span style="font-size:small"><strong>Doubly Linked List:</strong>&nbsp;In a doubly linked list, each node contains two links - the&nbsp;first link points to the previous node and the next link points to the next node in the sequence.The&nbsp;prev pointer
 of the first node and next pointer of the last node will point to null.</span> </li></ul>
<p><span style="white-space:pre"><span style="white-space:pre">&nbsp;</span><span style="white-space:pre">
</span><span style="white-space:pre">&nbsp;</span><img id="187437" src="187437-ll_4.png" alt="" width="590" height="87"></span></p>
<p>&nbsp;</p>
<ul>
<li>
<p><span style="white-space:pre; font-size:small"><strong>Circular Linked List:&nbsp;</strong>In the circular linked list, the next of the last node will point to&nbsp;the first node,
</span><span style="white-space:pre">thus forming a circular chain</span><span style="font-size:small">.</span></p>
</li></ul>
<p><span style="white-space:pre">&nbsp;</span><span style="white-space:pre"> <span style="white-space:pre">
</span></span><span style="white-space:pre">&nbsp;</span><img id="187438" src="187438-ll3.png" alt="" width="363" height="108"></p>
<ul>
<li><span style="font-size:small"><strong>Doubly Circular Linked List:</strong>&nbsp;In this type of linked list, the next of the last node will point to the first node and the previous pointer of the first node will point to the last node.</span>
</li></ul>
<p><span style="white-space:pre">&nbsp;</span><span style="white-space:pre"> <span style="white-space:pre">
</span></span><span style="white-space:pre">&nbsp;</span><img id="187439" src="187439-doublycircular.png" alt="" width="464" height="171"></p>
<h1>Creating a Linked List</h1>
<p><span style="font-size:small">The node of a singly linked list contains a data part and a link part. The link will contain the address of next node and is initialized to null.&nbsp;So, we will create class definition of node for singly linked list as follows
 -</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal class Node {  
    internal int data;  
    internal Node next;  
    public Node(int d) {  
        data = d;  
        next = null;  
    }  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span><span class="cs__keyword">class</span>&nbsp;Node&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span><span class="cs__keyword">int</span>&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;Node&nbsp;next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Node(<span class="cs__keyword">int</span>&nbsp;d)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;d;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;next&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The node for a Doubly Linked list will contain one data part and two link parts - previous link and next link.&nbsp;Hence, we&nbsp; create a class definition of a node for the doubly linked list as shown below.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal class DNode {  
    internal int data;  
    internal DNode prev;  
    internal DNode next;  
    public DNode(int d) {  
        data = d;  
        prev = null;  
        next = null;  
    }  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DNode&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;DNode&nbsp;prev;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;DNode&nbsp;next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DNode(<span class="cs__keyword">int</span>&nbsp;d)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;d;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;next&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Now, our node has been created, so, we will create a linked list class now.&nbsp;When a new Linked List is instantiated, it just has the head, which is Null.The SinglyLinkedList class will contain nodes of type Node class. Hence,
 SinglyLinkedList class definition will look like below.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal class SingleLinkedList {  
    internal Node head;  
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SingleLinkedList&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;Node&nbsp;head;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The DoublyLinkedList class will contain nodes of type DNode class. Hence, DoublyLinkedList class will look like this.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal class DoubleLinkedList {  
    internal DNode head;  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DoubleLinkedList&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;DNode&nbsp;head;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong style="font-size:2em">Various operations on Linked list</strong></div>
<p>&nbsp;</p>
<h2>Insert data at front of the Linked List&nbsp;</h2>
<ul>
<li><span style="font-size:small">The first node, head, will be null when the linked list is instantiated. When we want to add any node at the front, we want the head to point to it.</span>
</li><li><span style="font-size:small">We will create a new node. The next of the new node will point to the head of the Linked list.</span>
</li><li><span style="font-size:small">The previous Head node is now the second node of Linked List because the new node is added at the front. So, we will assign head to the new node.</span>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertFront(SingleLinkedList singlyList, int new_data) {    
    Node new_node = new Node(new_data);    
    new_node.next = singlyList.head;    
    singlyList.head = new_node;    
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertFront(SingleLinkedList&nbsp;singlyList,&nbsp;<span class="cs__keyword">int</span>&nbsp;new_data)&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;new_node&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Node(new_data);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;new_node.next&nbsp;=&nbsp;singlyList.head;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;singlyList.head&nbsp;=&nbsp;new_node;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">To insert the data at front of the doubly linked list, we have to follow one extra step .i.e point the previous pointer of head node to the new node. So, the method will look like this.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertFront(DoubleLinkedList doubleLinkedList, int data) {  
    DNode newNode = new DNode(data);  
    newNode.next = doubleLinkedList.head;  
    newNode.prev = null;  
    if (doubleLinkedList.head != null) {  
        doubleLinkedList.head.prev = newNode;  
    }  
    doubleLinkedList.head = newNode;  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span><span class="cs__keyword">void</span>&nbsp;InsertFront(DoubleLinkedList&nbsp;doubleLinkedList,&nbsp;<span class="cs__keyword">int</span>&nbsp;data)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DNode&nbsp;newNode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DNode(data);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newNode.next&nbsp;=&nbsp;doubleLinkedList.head;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newNode.prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(doubleLinkedList.head&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doubleLinkedList.head.prev&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;doubleLinkedList.head&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<h2>Insert data at the end of Linked List</h2>
<div>
<ul>
<li><span style="font-size:small">If the Linked List is empty, then we simply add the new node as the Head of the Linked List.</span>
</li><li><span style="font-size:small">If the Linked List is not empty, then we find the last node and make next of the last node to the new node, hence the new node is the last node now.</span>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertLast(SingleLinkedList singlyList, int new_data)    
{    
    Node new_node = new Node(new_data);    
    if (singlyList.head == null) {    
        singlyList.head = new_node;    
        return;    
    }    
    Node lastNode = GetLastNode(singlyList);    
    lastNode.next = new_node;    
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertLast(SingleLinkedList&nbsp;singlyList,&nbsp;<span class="cs__keyword">int</span>&nbsp;new_data)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;new_node&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Node(new_data);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(singlyList.head&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;singlyList.head&nbsp;=&nbsp;new_node;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;lastNode&nbsp;=&nbsp;GetLastNode(singlyList);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lastNode.next&nbsp;=&nbsp;new_node;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">To insert the data at the end of a doubly linked list, we have to follow one extra step; .i.e., point previous pointer of new node to the last node.so the method will look like this.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertLast(DoubleLinkedList doubleLinkedList, int data) {  
    DNode newNode = new DNode(data);  
    if (doubleLinkedList.head == null) {  
        newNode.prev = null;  
        doubleLinkedList.head = newNode;  
        return;  
    }  
    DNode lastNode = GetLastNode(doubleLinkedList);  
    lastNode.next = newNode;  
    newNode.prev = lastNode;  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertLast(DoubleLinkedList&nbsp;doubleLinkedList,&nbsp;<span class="cs__keyword">int</span>&nbsp;data)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DNode&nbsp;newNode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DNode(data);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(doubleLinkedList.head&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newNode.prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doubleLinkedList.head&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DNode&nbsp;lastNode&nbsp;=&nbsp;GetLastNode(doubleLinkedList);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lastNode.next&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newNode.prev&nbsp;=&nbsp;lastNode;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
</div>
<p><span style="font-size:small">The last node will be the one with its next pointing to null. Hence we will traverse the list until we find the node with next as null and return that node as last node. Therefore the method to get the last node will be</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal Node GetLastNode(SingleLinkedList singlyList) {  
    Node temp = singlyList.head;  
    while (temp.next != null) {  
        temp = temp.next;  
    }  
    return temp;  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;Node&nbsp;GetLastNode(SingleLinkedList&nbsp;singlyList)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;temp&nbsp;=&nbsp;singlyList.head;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(temp.next&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;temp;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">In the above mentioned method, pass doubleLinkedList object to get last node for Doubly Linked List</span></p>
<h2>Insert data after a given node of Linked List</h2>
<div>
<ul>
<li><span style="font-size:small">We have to insert a new node after a given node.</span>
</li><li><span style="font-size:small">We will set the next of new node to the next of given node.</span>
</li><li><span style="font-size:small">Then we will set the next of given node to new node</span>
</li></ul>
<div><span style="font-size:small">So the method for singly Linked List will look like this,</span></div>
<div></div>
<div><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertAfter(Node prev_node, int new_data)  
{  
    if (prev_node == null) {  
        Console.WriteLine(&quot;The given previous node Cannot be null&quot;);  
        return;  
    }  
    Node new_node = new Node(new_data);  
    new_node.next = prev_node.next;  
    prev_node.next = new_node;  
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertAfter(Node&nbsp;prev_node,&nbsp;<span class="cs__keyword">int</span>&nbsp;new_data)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(prev_node&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;The&nbsp;given&nbsp;previous&nbsp;node&nbsp;Cannot&nbsp;be&nbsp;null&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;new_node&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Node(new_data);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;new_node.next&nbsp;=&nbsp;prev_node.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;prev_node.next&nbsp;=&nbsp;new_node;&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
</span></div>
<div></div>
<div><span style="font-size:small">To perform this operation on doubly linked list we need to follow two extra steps</span></div>
<ol>
<li>
<p><span style="font-size:small">Set the previous of new node to given node.</span></p>
</li><li>
<p><span style="font-size:small">Set the previous of&nbsp;the next node of given node to the new node.</span></p>
</li></ol>
<div><span style="font-size:small">
<p><span style="font-size:small">So, the method for Doubly Linked List will look like this.</span></p>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void InsertAfter(DNode prev_node, int data)  
{  
    if (prev_node == null) {  
        Console.WriteLine(&quot;The given prevoius node cannot be null&quot;);  
        return;  
    }  
    DNode newNode = new DNode(data);  
    newNode.next = prev_node.next;  
    prev_node.next = newNode;  
    newNode.prev = prev_node;  
    if (newNode.next != null) {  
        newNode.next.prev = newNode;  
    }  
} </pre>
<div class="preview">
<pre class="js">internal&nbsp;<span class="js__operator">void</span>&nbsp;InsertAfter(DNode&nbsp;prev_node,&nbsp;int&nbsp;data)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(prev_node&nbsp;==&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;The&nbsp;given&nbsp;prevoius&nbsp;node&nbsp;cannot&nbsp;be&nbsp;null&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DNode&nbsp;newNode&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DNode(data);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newNode.next&nbsp;=&nbsp;prev_node.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;prev_node.next&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newNode.prev&nbsp;=&nbsp;prev_node;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(newNode.next&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newNode.next.prev&nbsp;=&nbsp;newNode;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
</div>
</span>
<h2>Delete a node from Linked List using a given key value</h2>
<ul>
<li>
<p><span style="font-size:small">First step is to find the node having the key value.</span></p>
</li><li>
<p><span style="font-size:small">We will traverse through the Linked list, and use one extra pointer to keep track of the previous node while traversing the linked list.</span></p>
</li><li>
<p><span style="font-size:small">If the node to be deleted is the first node, then simply set the Next pointer of the Head to point to the next element from the Node to be deleted.</span></p>
</li><li>
<p><span style="font-size:small">If the node is in the middle somewhere, then find the node before it, and make the Node before it point to the Node next to it.</span></p>
</li><li>
<p><span style="font-size:small">If the node to be deleted is last node, then find the node before it, and set it to point to null.</span></p>
</li></ul>
<p><span style="font-size:small">So, the method for singly linked list will look like this,</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void DeleteNodebyKey(SingleLinkedList singlyList, int key)  
{  
    Node temp = singlyList.head;  
    Node prev = null;  
    if (temp != null &amp;&amp; temp.data == key) {  
        singlyList.head = temp.next;  
        return;  
    }  
    while (temp != null &amp;&amp; temp.data != key) {  
        prev = temp;  
        temp = temp.next;  
    }  
    if (temp == null) {  
        return;  
    }  
    prev.next = temp.next;  
}  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteNodebyKey(SingleLinkedList&nbsp;singlyList,&nbsp;<span class="cs__keyword">int</span>&nbsp;key)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;temp&nbsp;=&nbsp;singlyList.head;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;temp.data&nbsp;==&nbsp;key)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;singlyList.head&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(temp&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;temp.data&nbsp;!=&nbsp;key)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prev&nbsp;=&nbsp;temp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;prev.next&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">To perform this operation on doubly linked list we don't need any extra pointer for previous node as Doubly linked list already have a pointer to previous node.so the delete method will be,</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">internal void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)  
{  
    DNode temp = doubleLinkedList.head;  
    if (temp != null &amp;&amp; temp.data == key) {  
        doubleLinkedList.head = temp.next;  
        doubleLinkedList.head.prev = null;  
        return;  
    }  
    while (temp != null &amp;&amp; temp.data != key) {  
        temp = temp.next;  
    }  
    if (temp == null) {  
        return;  
    }  
    if (temp.next != null) {  
        temp.next.prev = temp.prev;  
    }  
    if (temp.prev != null) {  
        temp.prev.next = temp.next;  
    }  
}  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteNodebyKey(DoubleLinkedList&nbsp;doubleLinkedList,&nbsp;<span class="cs__keyword">int</span>&nbsp;key)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DNode&nbsp;temp&nbsp;=&nbsp;doubleLinkedList.head;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;temp.data&nbsp;==&nbsp;key)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doubleLinkedList.head&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doubleLinkedList.head.prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(temp&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;temp.data&nbsp;!=&nbsp;key)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp.next&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp.next.prev&nbsp;=&nbsp;temp.prev;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp.prev&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp.prev.next&nbsp;=&nbsp;temp.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</div>
<h2>Reverse a Singly Linked list</h2>
<div><span style="font-size:small">This is one of the most famous interview questions. We need to reverse the links of each node to point to its previous node, and the last node should be the head node.This can be achieved by iterative as well as recursive
 methods. Here I am explaining the iterative method.</span></div>
<div>
<ul>
<li><span style="font-size:small">We need two extra pointers to keep track of previous and next node, initialize them to null.</span>
</li><li><span style="font-size:small">Start traversing the list from head node to last node and reverse the pointer of one node in each iteration.</span>
</li><li><span style="font-size:small">Once the list is exhausted, set last node as head node.</span>
</li></ul>
<span style="font-size:small">The method will look like this,</span></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void ReverseLinkedList(SingleLinkedList singlyList)  
{  
    Node prev = null;  
    Node current = singlyList.head;  
    Node temp = null;  
    while (current != null) {  
        temp = current.next;  
        current.next = prev;  
        prev = current;  
        current = temp;  
    }  
    singlyList.head = prev;  
}  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;ReverseLinkedList(SingleLinkedList&nbsp;singlyList)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;prev&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;current&nbsp;=&nbsp;singlyList.head;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;temp&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(current&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp&nbsp;=&nbsp;current.next;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current.next&nbsp;=&nbsp;prev;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prev&nbsp;=&nbsp;current;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;temp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;singlyList.head&nbsp;=&nbsp;prev;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h1>Disadvantages of Linked List</h1>
<ul>
<li>
<p><span id="docs-internal-guid-e83fb453-7aec-9ad1-a320-fccdd5961f69" style="font-size:small">Linked List needs more memory because we need to store pointers to next/previous nodes.</span></p>
</li><li>
<p><span style="font-size:small"><span id="docs-internal-guid-e83fb453-7aec-b762-01fa-16c837f4b238">We cannot access a node randomly as in case with arrays. To access any node in a Linked list we must traverse sequentially from the head node.</span><br>
</span></p>
</li><li>
<p><span style="font-size:small"><span id="docs-internal-guid-e83fb453-7aec-d03e-308a-5636291e7026">Since the nodes are not stored in contiguous memory locations, it results in an increase in the time required to access any given node.</span><br>
</span></p>
</li><li>
<p><span style="font-size:small"><span id="docs-internal-guid-e83fb453-7aec-e718-0bc4-a6bcc7296411">Reverse traversing is only possible with a doubly linked list but it leads to an increase in the memory consumption because we need to store two pointers per
 node.</span></span></p>
</li></ul>
<h1><strong>Conclusion</strong></h1>
<p dir="ltr"><span style="font-size:small">We have implemented Singly Linked list and Doubly Linked list using C#. We have also performed various operations on them. Please refer to the attached code for better understanding. You will find a few more methods
 in the attached code such as finding middle element and searching a linked list.</span></p>
<h1>Source Code Files</h1>
<p>&nbsp;</p>
<ul>
<li>
<p><span style="font-size:small"><em>LinkedListImplementation.zip-&nbsp;</em>code&nbsp;attached for better understanding. Feel free to download and play with it.</span></p>
</li></ul>
<p dir="ltr"><span style="font-size:small"><br>
</span></p>
