# Dijkstra's Single-Soruce Shortest-Paths Algorithm
## Requires
- Visual Studio 2008
## License
- MIT
## Technologies
- C#
- Visual Studio 2008
- Visual C#
## Topics
- C#
- Numerical Computing
## Updated
- 04/02/2015
## Description

<h1>Introduction</h1>
<p><em>This application solves the shortest-paths problem for a connected and directed graph. The method used is called Dijkstra's algorithm.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This project should build using Visual Studio 2008 and perhaps later versions of Visual Studio.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This version of Dijkstra's algorithm is from <strong>Introduction to Algorithms</strong> by Cormen, Leiserson, and Rivest and its discussion is found on pages 527-531. Like Prim's Minimum Spanning Tree algorithm this variant of Dijkstra's algorithm uses
 a priority queue. The running time of the algortihm is calculated in the previously mentioned textbook and is found to be O(V^2). The shortest-paths problem became especially important with the advent of the Internet. Its solutions are utilized by routing
 protocols.<br>
</em></p>
<p><em><img id="135764" src="135764-dij.jpg" alt="" width="800" height="800">&nbsp;</em></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Algorithm
    {
        public List&lt;int&gt; Dijkstra(ref int[] pi, ref List&lt;Node&gt; G, int s)
        {
            InitializeSingleSource(ref pi, ref G, s); 

            List&lt;int&gt; S = new List&lt;int&gt;();
            PriorityQueue Q = new PriorityQueue(G);

            Q.buildHeap();

            while (Q.size() != 0)
            {
                Node u = Q.extractMin();

                S.Add(u.Id);

                for (int i = 0; i &lt; u.Adjacency.Count; i&#43;&#43;)
                {
                    Node v = u.Adjacency[i];
                    int w = u.Weights[i];

                    Relax(ref pi, u, ref v, w);
                }
            }

            return S;
        }

        void InitializeSingleSource(ref int[] pi, ref List&lt;Node&gt; nodeList, int s)
        {
            pi = new int[nodeList.Count];

            for (int i = 0; i &lt; pi.Length; i&#43;&#43;)
                pi[i] = -1;

            nodeList[s].Distance = 0;
        }

        void Relax(ref int[] pi, Node u, ref Node v, int w)
        {
            if (v.Distance &gt; u.Distance &#43; w)
            {
                v.Distance = u.Distance &#43; w;
                pi[v.Id] = u.Id;
            }
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Dijkstra&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Algorithm&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;&nbsp;Dijkstra(<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;pi,&nbsp;<span class="cs__keyword">ref</span>&nbsp;List&lt;Node&gt;&nbsp;G,&nbsp;<span class="cs__keyword">int</span>&nbsp;s)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeSingleSource(<span class="cs__keyword">ref</span>&nbsp;pi,&nbsp;<span class="cs__keyword">ref</span>&nbsp;G,&nbsp;s);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;&nbsp;S&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PriorityQueue&nbsp;Q&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PriorityQueue(G);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Q.buildHeap();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(Q.size()&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;u&nbsp;=&nbsp;Q.extractMin();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;S.Add(u.Id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;u.Adjacency.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Node&nbsp;v&nbsp;=&nbsp;u.Adjacency[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;w&nbsp;=&nbsp;u.Weights[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Relax(<span class="cs__keyword">ref</span>&nbsp;pi,&nbsp;u,&nbsp;<span class="cs__keyword">ref</span>&nbsp;v,&nbsp;w);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;S;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;InitializeSingleSource(<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;pi,&nbsp;<span class="cs__keyword">ref</span>&nbsp;List&lt;Node&gt;&nbsp;nodeList,&nbsp;<span class="cs__keyword">int</span>&nbsp;s)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pi&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[nodeList.Count];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;pi.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pi[i]&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nodeList[s].Distance&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Relax(<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;pi,&nbsp;Node&nbsp;u,&nbsp;<span class="cs__keyword">ref</span>&nbsp;Node&nbsp;v,&nbsp;<span class="cs__keyword">int</span>&nbsp;w)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(v.Distance&nbsp;&gt;&nbsp;u.Distance&nbsp;&#43;&nbsp;w)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.Distance&nbsp;=&nbsp;u.Distance&nbsp;&#43;&nbsp;w;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pi[v.Id]&nbsp;=&nbsp;u.Id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Algorithm.cs - the class with the algorithm.</em> </li><li><em><em>MainForm.cs - the main and only form of the application.</em></em> </li><li><em>Node.cs - graph vertex expressed as a node.</em> </li><li><em>PriorityQueue.cs - the priority queue class with the all important Extract-Min method.</em>
</li><li><em>Program.cs - the Visual Studio 2008 generated application source code file.</em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on Dijkstra's algorthm, see the textbook mentioned in the Description section or any decent algorithms or computer networking textbook. You can also search online.<br>
</em></p>
