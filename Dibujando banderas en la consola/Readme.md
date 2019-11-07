# Dibujando banderas en la consola
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- Console Window
## Updated
- 02/13/2012
## Description

<h1>Introducci&oacute;n</h1>
<p style="text-align:justify">En ciertas ocasiones nos vemos en la necesidad de realizar aplicaciones de consola. Bien sea porque es un aplicativo &quot;demonio&quot; que no necesita interfaz gr&aacute;fica m&aacute;s all&aacute; de imprimir las acciones del momento
 en la consola, bien por ser una aplicaci&oacute;n de c&aacute;lculo extensivo o cient&iacute;fica, o bien por ser una aplicaci&oacute;n acad&eacute;mica, siempre encontraremos ocasiones para utilizar la consola.&nbsp;</p>
<p style="text-align:justify">Ahora bien, esto no significa que dichos programas carezcan de interfaz gr&aacute;fica. Es decir, en ocasiones querremos que las aplicaciones digan algo m&aacute;s que la impresi&oacute;n de puro texto: un mensaje de error pintado
 en rojo para que resalte, o colocar un mensaje en la parte superior derecha para que se note. Si bien los elementos de interfaz gr&aacute;fica son limitados, podemos sacarle provecho a lo que .NET nos ofrece.&nbsp;</p>
<p style="text-align:justify">Para demostrar lo anterior, y mostrar algunos m&eacute;todos que .NET pone a nuestra disposici&oacute;n es que he creado este programa que lo que hace es &iexcl;dibujar banderas! Unas cuantas, solamente, tratando de ser lo m&aacute;s
 precisas posible.</p>
<h1><span>Construyendo el ejemplo</span></h1>
<p style="text-align:justify">&iexcl;S&oacute;lo compila y listo! Nota, sin embargo, que la aplicaci&oacute;n est&aacute; localizada y soporta dos idiomas: ingl&eacute;s de E.E.U.U. (por defecto) y espa&ntilde;ol de M&eacute;xico.&nbsp;</p>
<p><img src="49356-flag.png" alt="" width="533" height="265" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p style="text-align:justify">La aplicaci&oacute;n tiene una serie de clases: una abstracta y varias que heredan de &eacute;sta. El m&eacute;todo que emplean para pintar la bandera es dividirla en sectores iguales (tanto horizontal como verticalmente), determinados
 por las propiedades WidthSectors y HeightSectors. Las clases hijas sobreescriben estas propiedades dependiendo de sus necesidades.&nbsp;</p>
<p style="text-align:justify">Por otra parte, el m&eacute;todo SetupSquare, igualmente sobrescrito por las clases derivadas, indica el color del bloque en cuesti&oacute;n, dependiendo de su posici&oacute;n/coordenada.</p>
<p style="text-align:justify">Nota el c&oacute;digo que regresa los colores de la bandera alemana:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected override void SetupSquare(int x, int y)
{
    if (IsHeightSector(1, y))
        Console.BackgroundColor = ConsoleColor.Black;
    else if (IsHeightSector(2, y))
        Console.BackgroundColor = ConsoleColor.Red;
    else if (IsHeightSector(3, y))
        Console.BackgroundColor = ConsoleColor.Yellow;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetupSquare(<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;y)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(IsHeightSector(<span class="cs__number">1</span>,&nbsp;y))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.BackgroundColor&nbsp;=&nbsp;ConsoleColor.Black;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(IsHeightSector(<span class="cs__number">2</span>,&nbsp;y))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.BackgroundColor&nbsp;=&nbsp;ConsoleColor.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(IsHeightSector(<span class="cs__number">3</span>,&nbsp;y))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.BackgroundColor&nbsp;=&nbsp;ConsoleColor.Yellow;&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify">Como puedes observar, hemos dividido en sectores horizontales la bandera: si est&aacute; en el primer sector, pintamos de negro; en el segundo va el rojo y en el &uacute;ltimo va el amarillo. En este caso no nos importa la coordenada
 y, pero en banderas como la italiana s&iacute; que nos importar&aacute;.</p>
<p style="text-align:justify">Por &uacute;ltimo, comentar que todo lo necesario para este programa se encuentra en la clase est&aacute;tica Console, desde miembros comunes como WriteLine, ReadLine hasta otros no tan usados como BackgroundColor. Por lo que es
 muy recomendable que revises la documentaci&oacute;n de dicha clase.&nbsp;</p>
<p style="text-align:justify">Espero que veas que es sencillo dibujar sobre la consola, y m&aacute;s all&aacute; de que este programa es un ejemplo ilustrativo, piensa lo que podr&iacute;as hacer con una aplicaci&oacute;n profesional. &iexcl;No s&oacute;lo
 porque sea consola debe quedar fuera del juego! Y mientras tanto, espero que disfrutes de esta aplicaci&oacute;n y crees la tuya propia con m&aacute;s banderas todav&iacute;a. &iquest;Alguien se apunta para hacer la de M&eacute;xico, con todo y su escudo?</p>
<h1><span>Archivos</span></h1>
<ul>
<li><em>Program.cs - contiene todo el programa.</em> </li><li><em><em>Resources.resx - contiene los recursos por defecto del programa.</em></em>
</li><li><em><em>Resources.es-MX.resx - contiene los recursos en espa&ntilde;ol del programa.</em></em>
</li></ul>
