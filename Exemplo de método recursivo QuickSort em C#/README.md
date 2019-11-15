# Exemplo de método recursivo QuickSort em C#
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Visual Studio 2013
## Topics
- quicksort
- Ordering
- Estruturas de Dados
## Updated
- 04/18/2015
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><span style="font-size:small">O&nbsp;<a title="Algoritmo" href="http://pt.wikipedia.org/wiki/Algoritmo">algoritmo</a>&nbsp;<strong>Quicksort</strong>&nbsp;&eacute; um m&eacute;todo de ordena&ccedil;&atilde;o muito r&aacute;pido e eficiente, inventado por&nbsp;<a class="mw-redirect" title="C.A.R. Hoare" href="http://pt.wikipedia.org/wiki/C.A.R._Hoare">C.A.R.
 Hoare</a>&nbsp;em 1960<span id="cite_ref-1" class="reference"><a href="http://pt.wikipedia.org/wiki/Quicksort#cite_note-1">1</a></span>&nbsp;, quando visitou a&nbsp;<a class="mw-redirect" title="Universidade de Moscovo" href="http://pt.wikipedia.org/wiki/Universidade_de_Moscovo">Universidade
 de Moscovo</a>&nbsp;como estudante. Naquela &eacute;poca, Hoare trabalhou em um projeto de&nbsp;<a class="new" title="Tradução de máquina (página não existe)" href="http://pt.wikipedia.org/w/index.php?title=Tradu%C3%A7%C3%A3o_de_m%C3%A1quina&action=edit&redlink=1">tradu&ccedil;&atilde;o
 de m&aacute;quina</a>para o&nbsp;<a class="new" title="National Physical Laboratory, UK (página não existe)" href="http://pt.wikipedia.org/w/index.php?title=National_Physical_Laboratory,_UK&action=edit&redlink=1">National Physical Laboratory</a>. Ele criou
 o '<em>Quicksort</em>&nbsp;ao tentar traduzir um dicion&aacute;rio de ingl&ecirc;s para russo, ordenando as palavras, tendo como objetivo reduzir o problema original em subproblemas que possam ser resolvidos mais facil e rapidamente. Foi publicado em 1962
 ap&oacute;s uma s&eacute;rie de refinamentos.<span id="cite_ref-2" class="reference"><a href="http://pt.wikipedia.org/wiki/Quicksort#cite_note-2">2</a></span></span></p>
<p><span style="font-size:small">O Quicksort &eacute; um algoritmo de&nbsp;<a title="Ordenação por comparação" href="http://pt.wikipedia.org/wiki/Ordena%C3%A7%C3%A3o_por_compara%C3%A7%C3%A3o">ordena&ccedil;&atilde;o por compara&ccedil;&atilde;o</a>&nbsp;<a title="Ordenação estável" href="http://pt.wikipedia.org/wiki/Ordena%C3%A7%C3%A3o_est%C3%A1vel">n&atilde;o-est&aacute;vel</a>.</span><span style="font-size:small">&nbsp;-
 Wikip&eacute;dia</span></p>
<p><span style="font-size:small">Este exemplo mostra o algoritmo, mas, adotando um metodo recursivo para ordenar os dados e usando a linguagem c#.&nbsp;</span></p>
<h1>Descri&ccedil;&atilde;o</h1>
<p><span style="font-size:small">O Quicksort adota a estrat&eacute;gia de&nbsp;<a title="Divisão e conquista" href="http://pt.wikipedia.org/wiki/Divis%C3%A3o_e_conquista">divis&atilde;o e conquista</a>. A estrat&eacute;gia consiste em rearranjar as chaves de
 modo que as chaves &quot;menores&quot; precedam as chaves &quot;maiores&quot;. Em seguida o Quicksort ordena as duas sublistas de chaves menores e maiores recursivamente at&eacute; que a lista completa se encontre ordenada.&nbsp;<span id="cite_ref-3" class="reference"><a href="http://pt.wikipedia.org/wiki/Quicksort#cite_note-3">3</a></span>&nbsp;Os
 passos s&atilde;o:</span></p>
<ol>
<li><span style="font-size:small">Escolha um elemento da lista, denominado&nbsp;<em>piv&ocirc;</em>;</span>
</li><li><span style="font-size:small">Rearranje a lista de forma que todos os elementos anteriores ao piv&ocirc; sejam menores que ele, e todos os elementos posteriores ao piv&ocirc; sejam maiores que ele. Ao fim do processo o piv&ocirc; estar&aacute; em sua posi&ccedil;&atilde;o
 final e haver&aacute; duas sublistas n&atilde;o ordenadas. Essa opera&ccedil;&atilde;o &eacute; denominada&nbsp;<em>parti&ccedil;&atilde;o</em>;</span>
</li><li><span style="font-size:small"><a title="Recursividade (ciência da computação)" href="http://pt.wikipedia.org/wiki/Recursividade_(ci%C3%AAncia_da_computa%C3%A7%C3%A3o)">Recursivamente</a>&nbsp;ordene a sublista dos elementos menores e a sublista dos elementos
 maiores;</span> </li></ol>
<p><span style="font-size:small">A base da recurs&atilde;o s&atilde;o as listas de tamanho zero ou um, que est&atilde;o sempre ordenadas. O processo &eacute; finito, pois a cada itera&ccedil;&atilde;o pelo menos um elemento &eacute; posto em sua posi&ccedil;&atilde;o
 final e n&atilde;o ser&aacute; mais manipulado na itera&ccedil;&atilde;o seguinte.</span><span style="font-size:small">&nbsp;- Wikip&eacute;dia</span></p>
<p><span style="font-size:small">Esse programa mostrar os passos de como pode ser feito um met&oacute;do quicksort usando recurs&atilde;o usando a id&eacute;ia acima.</span></p>
<p><span style="font-size:small">Abaixo est&aacute; apresentado o codigo da fun&ccedil;&atilde;o recursiva para a realiza&ccedil;&atilde;o da ordena&ccedil;&atilde;o.&nbsp;</span></p>
<p><span style="font-size:small">Esse exemplo foi feito para demostrar usando somente dados intei</span><span style="font-size:small">ros, mas pode ser facilmente adaptado para</span><span style="font-size:small">&nbsp;ordenar outros dados</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:x-large">Exemplo de Funcionamento</span></strong></p>
<p><img id="136595" src="https://i1.code.msdn.s-msft.com/exemplo-de-mtodo-recursivo-1f51a7d8/image/file/136595/1/sorting_quicksort_anim.gif" alt="" width="280" height="214" style="line-height:15px; float:left"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em>Cr&eacute;ditos pelo anima&ccedil;&atilde;o:&nbsp;&quot;Sorting quicksort anim&quot; por en:User:RolandH. Licenciado sob CC BY-SA 3.0, via Wikimedia Commons - http://commons.wikimedia.org/wiki/File:Sorting_quicksort_anim.gif#/media/File:Sorting_quicksort_anim.gif</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;numeros&nbsp;=&nbsp;{&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">8</span>,&nbsp;<span class="cs__number">9</span>,&nbsp;<span class="cs__number">6</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">4</span>&nbsp;};&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Met&oacute;do&nbsp;recursivo&nbsp;QuickSort&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QuickSort_Recursive(numeros,&nbsp;<span class="cs__number">0</span>,&nbsp;numeros.Length&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">9</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(numeros[i]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;QuickSort_Recursive(<span class="cs__keyword">int</span>[]&nbsp;vetor,&nbsp;<span class="cs__keyword">int</span>&nbsp;primeiro,&nbsp;<span class="cs__keyword">int</span>&nbsp;ultimo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;baixo,&nbsp;alto,&nbsp;meio,&nbsp;pivo,&nbsp;repositorio;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baixo&nbsp;=&nbsp;primeiro;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alto&nbsp;=&nbsp;ultimo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;meio&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)((baixo&nbsp;&#43;&nbsp;alto)&nbsp;/&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pivo&nbsp;=&nbsp;vetor[meio];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(baixo&nbsp;&lt;=&nbsp;alto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(vetor[baixo]&nbsp;&lt;&nbsp;pivo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baixo&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(vetor[alto]&nbsp;&gt;&nbsp;pivo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alto--;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(baixo&nbsp;&lt;&nbsp;alto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;repositorio&nbsp;=&nbsp;vetor[baixo];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vetor[baixo&#43;&#43;]&nbsp;=&nbsp;vetor[alto];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vetor[alto--]&nbsp;=&nbsp;repositorio;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(baixo&nbsp;==&nbsp;alto)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baixo&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alto--;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(alto&nbsp;&gt;&nbsp;primeiro)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QuickSort_Recursive(vetor,&nbsp;primeiro,&nbsp;alto);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(baixo&nbsp;&lt;&nbsp;ultimo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QuickSort_Recursive(vetor,&nbsp;baixo,&nbsp;ultimo);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
