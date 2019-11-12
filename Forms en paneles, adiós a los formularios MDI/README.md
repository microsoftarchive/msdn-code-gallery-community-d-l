# Forms en paneles, adiós a los formularios MDI
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Controls
- User Interface
- Windows Forms
- Windows Form Controls
- How to
## Updated
- 10/14/2011
## Description

<h1>Introduccion</h1>
<p>En ocasiones cuando necesitamos trabajar m&uacute;ltiples &ldquo;vistas&rdquo; dentro de nuestros formularios, por lo general recurrimos al control TabControl, pero cuando necesitamos ya una<br>
funcionalidad muy compleja o simplemente queremos separar estas funcionalidades en interfaces diferentes e integrarlas en un solo formulario, recurrimos a los formularios MDI, en estos podemos trabajar con formularios padres (contenedor) y sus formularios hijos(contenidos),
 personalmente no tengo nada en contra de estos, pero me parecen un tanto tediosos de trabajar y algo estrictos en su personalizaci&oacute;n.</p>
<h1><span>Building the Sample</span></h1>
<p>Manos al teclado, lo primero que vamos a hacer es crear un proyecto de tipo Windows Forms, a este le vamos a agregar tres Forms (Padre, Hijo1, Hijo2).</p>
<p>Al formulario Padre, le vamos a agregar dos botones (btMostrarHijo1, btMostrarHijo2) y un panel (panelContenedor).</p>
<p>En los forms hijos agregamos etiquetas grandes y distintivas (o lo que quieras agregar).</p>
<p>Ahora, en el lado que nos gusta (el lado del c&oacute;digo) veamos como implementar estos formularios en el panel, en el evento click del bot&oacute;n btMostrarHijo1 agregamos el siguiente c&oacute;digo:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btMostrarHijo1_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__operator">this</span>.panelContenedor.Controls.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.panelContenedor.Controls.RemoveAt(<span class="js__num">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hijo1&nbsp;hijo1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Hijo1();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hijo1.TopLevel&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hijo1.FormBorderStyle&nbsp;=&nbsp;FormBorderStyle.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hijo1.Dock&nbsp;=&nbsp;DockStyle.Fill;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.panelContenedor.Controls.Add(hijo1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.panelContenedor.Tag&nbsp;=&nbsp;hijo1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hijo1.Show();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">La explicaci&oacute;n de c&oacute;mo funciona este c&oacute;digo es muy simple, primero preguntamos si existe alg&uacute;n control en el interior del panel, de ser verdadero lo eliminamos. Luego creamos una nueva instancia del formulario
 a agregar y sobre este objeto reescribimos algunas de sus propiedades, TopLevel establece si el formulario debe mostrarse como ventana nivel superior, FormBorderStyle define el estilo de los bordes de nuestro formulario (en nuestro caso no queremos mostrarlos),
 Dock establece como se acoplara el control a su contenedor principal (en nuestro caso queremos que rellene todo el panel), Por ultimo lo agregamos al panel, establecemos la instancia como contenedor de datos de nuestro panel y lo mostramos.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>La funcion que nos permitira lograr esto de una forma facil y sin tener que hacer una por cada boton es la siguiente:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddFormInPanel(<span class="cs__keyword">object</span>&nbsp;formHijo)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.panelContenedor.Controls.Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.panelContenedor.Controls.RemoveAt(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Form&nbsp;fh&nbsp;=&nbsp;formHijo&nbsp;<span class="cs__keyword">as</span>&nbsp;Form;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fh.TopLevel&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fh.FormBorderStyle&nbsp;=&nbsp;FormBorderStyle.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fh.Dock&nbsp;=&nbsp;DockStyle.Fill;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.panelContenedor.Controls.Add(fh);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>}&nbsp;</pre>
</div>
</div>
</div>
<p>Y para consumir esta funcion, desde el evento click de un boton:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btMostrarHijo2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddFormInPanel(<span class="cs__keyword">new</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>Mas Informacion</h1>
<p><em>Para mas informacion consulta esta <a href="http://nicolocodev.wordpress.com/2011/07/24/forms-en-paneles/">
entrada </a>de mi <a href="http://nicolocodev.wordpress.com/">blog</a><br>
</em></p>
