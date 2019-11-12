# Enumerate top level windows fast in C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows SDK
- Windows General
## Topics
- Delegates
- Platform Invoke
## Updated
- 10/05/2011
## Description

<h1>Introducci&oacute;n</h1>
<p>Un usuario en los foros de MSDN solicit&oacute; (eventualmente) una forma de enumerar las ventanas de primer nivel en C#. &nbsp;Entonces cre&eacute; este peque&ntilde;o ejemplo para proveer una soluci&oacute;n sencilla al problema. &nbsp;Espero que le sea
 de utilidad a m&aacute;s de uno.</p>
<h1>Descripci&oacute;n</h1>
<p>El problema de enumerar las ventanas de primer nivel no es realmente mayor problema. &nbsp;La funci&oacute;n de Windows llamada
<strong>EnumWindows()</strong> justamente hace esto. &nbsp;Pero para algunas personas es dif&iacute;cil entender P/Invoke y les es dif&iacute;cil traducir la declaraci&oacute;n de la funci&oacute;n en C a una declaraci&oacute;n &uacute;til en .Net/C#, especialmente
 si involucra punteros a funciones de devoluci&oacute;n de llamada como en este caso.</p>
<p>El ejemplo muestra el uso de un delegado (pues sirven como punteros a funciones) para enumerar todas las ventanas de primer nivel que tienen alg&uacute;n t&iacute;tulo y que est&aacute;n visibles. &nbsp;La visibilidad se determina con un llamado a la funci&oacute;n
 de Windows <strong>IsWindowVisible()</strong> y no considera en lo absoluto si la ventana est&aacute; de hecho siendo mostrada en pantalla, ya que podr&iacute;a estar detr&aacute;s de otra ventana.</p>
<h1>El C&oacute;digo</h1>
<p>La funcionalidad primaria realmente est&aacute; provista por Windows en sus funciones. &nbsp;Esta es la forma de traerlas al juego en el mundo de C#. &nbsp;N&oacute;tese el primer item: &nbsp;Es la
<em>declaraci&oacute;n del delegado</em> para la funci&oacute;n de devoluci&oacute;n de llamada que
<strong>EnumWindows()</strong> requiere para proveer su funcionalidad. &nbsp;El resto son simples declaraciones de las funciones de Windows requeridas en el ejemplo.</p>
<p>El ejemplo utiliza las funciones <strong>GetWindowTextLength()</strong> y <strong>
GetWindowText()</strong> para leer los t&iacute;tulos de las ventanas.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">delegate</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;EnumWindowsProc(IntPtr&nbsp;hWnd,&nbsp;IntPtr&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Unicode)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;GetWindowText(IntPtr&nbsp;hWnd,&nbsp;StringBuilder&nbsp;strText,&nbsp;<span class="cs__keyword">int</span>&nbsp;maxCount);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Unicode)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;GetWindowTextLength(IntPtr&nbsp;hWnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;EnumWindows(EnumWindowsProc&nbsp;enumProc,&nbsp;IntPtr&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsWindowVisible(IntPtr&nbsp;hWnd);&nbsp;
</pre>
</div>
</div>
</div>
<p>El siguiente extracto de c&oacute;digo muestra el coraz&oacute;n de la enumeraci&oacute;n: &nbsp;La funci&oacute;n de devoluci&oacute;n de llamada. &nbsp;La funci&oacute;n
<strong>EnumWindows()</strong> llama a esta funci&oacute;n una vez por cada ventana de primer nivel.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;EnumTheWindows(IntPtr&nbsp;hWnd,&nbsp;IntPtr&nbsp;lParam)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;size&nbsp;=&nbsp;GetWindowTextLength(hWnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(size&#43;&#43;&nbsp;&gt;&nbsp;<span class="cs__number">0</span>&nbsp;&amp;&amp;&nbsp;IsWindowVisible(hWnd))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;sb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetWindowText(hWnd,&nbsp;sb,&nbsp;size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(sb.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:20px; font-weight:bold">Archivos de C&oacute;digo Fuente</span></div>
<ul>
<li><em>Program.cs:</em>&nbsp; Es el &uacute;nico archivo de c&oacute;digo fuente en el proyecto. &nbsp;Contiene todo lo necesario para la enumeraci&oacute;n.
</li></ul>
