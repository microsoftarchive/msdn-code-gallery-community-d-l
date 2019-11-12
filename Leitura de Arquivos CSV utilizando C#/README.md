# Leitura de Arquivos CSV utilizando C#
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
- Console
## Topics
- C#
- .Net Programming
## Updated
- 07/06/2013
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><em>Realizar a leitura de arquivos CSV, pode ser um tanto tediosa, ou at&eacute; mesmo complicada por entrar no esquecimento de muitas pessoas pelo desuso. Mas realizar tal ato, &eacute; muito simples, e &eacute; oque mostrarei no exemplo a seguir.</em></p>
<h1><span>Referencias Necess&aacute;rias</span></h1>
<p><em>Para que voc&ecirc; possa utilizar as classes de leitura de texto, &eacute; necess&aacute;rio utilizar a seguinte refer&ecirc;ncia:</em></p>
<p>using <a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;</p>
<p>Esta refer&ecirc;ncia, &eacute; utilizada para muitas coisas, inclusive a parte de leitura e escrita de arquivos.</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Descri&ccedil;&atilde;o</span></p>
<p><em>Realizar a leitura de arquivos, &eacute; uma coisa um tanto simples, e para isso, se faz necess&aacute;rio instanciar a classe StreamReader. Ao instanciar essa classe, &eacute; necess&aacute;rio que voc&ecirc; passe por parametro o nome do arquivo que
 ser&aacute; lido, a instancia dever&aacute; ficar da seguinte maneira:&nbsp;</em></p>
<p><em>StreamReader rd = new StreamReader(@&quot;c:\txt\produtos.csv&quot;);</em></p>
<p><em>Existem dois parametros do StreamReader que vou focar para a leitura do arquivo, os demais, deixo para um post futuro, pois ao meu ver, n&atilde;o se encaixa na ideia proposta neste momento.</em></p>
<p><em>Os parametros s&atilde;o:</em></p>
<p><em>ReadLine = Realiza a leitura de uma linha do arquivo</em></p>
<p><em>ReadToEnd = Realiza a leitura de Todo arquivo de uma vez s&oacute;.</em></p>
<p><em>Neste exemplo, utilizo apenas o ReadLine, pois &eacute; oque mais se encaixa com a necessidade deste modelo.</em></p>
<p><em>Para armazenar os valores do arquivo, estou utilizando neste exemplo um array de string, mais nada impede de voc&ecirc;, meu amiigo(a) programador(a), utilizar uma lista ou qualquer outra coisa.</em></p>
<p><em>Ap&oacute;s declarar o array de strings, eu utilizo um while para realizar a leitura de todas as linhas, a sintaxe do while deve ficar mais ou menos assim:&nbsp;while ((linha = rd.ReadLine()) != null).</em></p>
<p><em>Para armazenar os valores individuais da linha no array, &eacute; necess&aacute;rio a utiliza&ccedil;&atilde;o da propriedade string.Split(), sendo utilizado da seguinte maneira:&nbsp;linha.Split(';');</em></p>
<p><em>e ao terminar a leitura do arquivo, n&atilde;o esque&ccedil;a de incluir o Close();</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Referencia&nbsp;Necess&aacute;ria&nbsp;para&nbsp;realizar&nbsp;a&nbsp;leitura&nbsp;do&nbsp;arquivo</span>&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ReadCsvFiles&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;___________________________________________&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Aplica&ccedil;&atilde;o&nbsp;de&nbsp;Exemplo&nbsp;MSDN&nbsp;-&nbsp;Ler&nbsp;Arquivo&nbsp;CSV&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;___________________________________________&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Declaro&nbsp;o&nbsp;StreamReader&nbsp;para&nbsp;o&nbsp;caminho&nbsp;onde&nbsp;se&nbsp;encontra&nbsp;o&nbsp;arquivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;rd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(@<span class="cs__string">&quot;e:\file.csv&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Declaro&nbsp;uma&nbsp;string&nbsp;que&nbsp;ser&aacute;&nbsp;utilizada&nbsp;para&nbsp;receber&nbsp;a&nbsp;linha&nbsp;completa&nbsp;do&nbsp;arquivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;linha&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Declaro&nbsp;um&nbsp;array&nbsp;do&nbsp;tipo&nbsp;string&nbsp;que&nbsp;ser&aacute;&nbsp;utilizado&nbsp;para&nbsp;adicionar&nbsp;o&nbsp;conteudo&nbsp;da&nbsp;linha&nbsp;separado</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;linhaseparada&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//realizo&nbsp;o&nbsp;while&nbsp;para&nbsp;ler&nbsp;o&nbsp;conteudo&nbsp;da&nbsp;linha</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;((linha&nbsp;=&nbsp;rd.ReadLine())&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//com&nbsp;o&nbsp;split&nbsp;adiciono&nbsp;a&nbsp;string&nbsp;'quebrada'&nbsp;dentro&nbsp;do&nbsp;array</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;linhaseparada&nbsp;=&nbsp;linha.Split(<span class="cs__string">';'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//aqui&nbsp;incluo&nbsp;o&nbsp;m&eacute;todo&nbsp;necess&aacute;rio&nbsp;para&nbsp;continuar&nbsp;o&nbsp;trabalho</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rd.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Erro&nbsp;ao&nbsp;executar&nbsp;Leitura&nbsp;do&nbsp;Arquivo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ReadCsvFiles #1 - Aplica&ccedil;&atilde;o de Exemplo</em> </li></ul>
<h1>Mais Informa&ccedil;&otilde;es</h1>
<p><em>Para maiores informa&ccedil;&otilde;es, verifique os link's</em></p>
<p><em><a href="http://msdn.microsoft.com/en-us/library/system.string.split(v=vs.71).aspx">http://msdn.microsoft.com/en-us/library/system.string.split(v=vs.71).aspx</a></em></p>
<p><a href="http://msdn.microsoft.com/pt-br/library/system.io.stream.read.aspx">http://msdn.microsoft.com/pt-br/library/system.io.stream.read.aspx</a></p>
<p><em><br>
</em></p>
