# Evaluador de expresiones matemáticas
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- .NET Framework
## Topics
- Calculator
- Mathematics
- Calculadora
## Updated
- 04/28/2015
## Description

<p>Implementar un evaluador de expresiones aritm&eacute;ticas puede resultar una tarea ardua. Sin embargo el Framework de .NET nos permite utilizar el motor de JScript para evaluar expresiones matem&aacute;ticas de forma sencilla.</p>
<p>Para crear el evaluador de expresiones voy crear un nuevo proyecto Windows Forms MathExpressionEvaluator.</p>
<p>Le he a&ntilde;adido al proyecto una referencia al ensamblado <a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/Microsoft.JScript.aspx" target="_blank" title="Auto generated link to Microsoft.JScript">Microsoft.JScript</a> para tener acceso a las clases que nos proporcionan la funcionalidad del motor de JScript.</p>
<p>En el formulario que Visual Studio crea por defecto he a&ntilde;adido un TextBox (con nombre txtExpression) que nos sirva para introducir las expresiones a evaluar, un Button (con nombre btnEvaluate) para realizar la evaluaci&oacute;n, y un Label (con nombre
 lblResultado) que utilizar&eacute; para mostrar el resultado de la evaluaci&oacute;n.</p>
<p>En el c&oacute;digo del formulario voy a crear el m&eacute;todo que eval&uacute;a las expresiones.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;EvalExpression(<span class="cs__keyword">string</span>&nbsp;expression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VsaEngine&nbsp;engine&nbsp;=&nbsp;VsaEngine.CreateEngine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;o&nbsp;=&nbsp;Eval.JScriptEvaluate(expression,&nbsp;engine);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Convert.ToDouble.aspx" target="_blank" title="Auto generated link to System.Convert.ToDouble">System.Convert.ToDouble</a>(o).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__string">&quot;No&nbsp;se&nbsp;puede&nbsp;evaluar&nbsp;la&nbsp;expresi&oacute;n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;engine.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>El c&oacute;digo es sencillo. Simplemente creo una instancia del motor JScript y paso al m&eacute;todo JScriptEvaluate de la clase Eval la expresi&oacute;n a evaluar. Si la evaluaci&oacute;n se realiza sin errores y devuelve un valor num&eacute;rico se devuelve
 el resultado. Si no devuelve un mensaje indicando que no se ha podido evaluar la expresi&oacute;n.</p>
<p>Para probar el m&eacute;todo he creado un controlador para el evento Click del bot&oacute;n btnEvaluate para evaluar el contenido del txtExpression y dejar el resultado en lblResultado.</p>
<p>Si arrancamos el proyecto podemos probar el evaluador de expresiones.</p>
<p>&nbsp;</p>
<p><img id="136950" src="136950-03formularioprueba.png" alt="" width="380" height="275"></p>
<p>&nbsp;</p>
<h1>&nbsp;M&aacute;s Informaci&oacute;n</h1>
<p>&nbsp;Se puede encontrar informaci&oacute;n ampliada del ejemplo en el art&iacute;culo:</p>
<p><a href="http://pildorasdotnet.blogspot.com/2015/04/net-framework-evaluar-expresiones.html">.NET Framework. Evaluar expresiones aritm&eacute;ticas</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
