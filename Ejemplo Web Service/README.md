# Ejemplo Web Service
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- WCF
- ASP.NET
- Web Services
## Topics
- C#
- ASP.NET
- Web Services
## Updated
- 06/04/2012
## Description

<h1>Introduction</h1>
<p><em>Ejemplo de codigo para crear y consumir un censillo Web Service en c#, el tipico hola mundo&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>El ejemplo contiene dos soluciones, el Web service y la Web Application que consume el web service</em></p>
<p>Para mas informacion :</p>
<p><strong><span style="font-size:medium"><a href="http://evoluciondotnet.blogspot.com/2012/06/crear-y-consumir-un-web-service-con.html">Crear y consumir un web service con visual studio 2010 (1ra Parte)</a></span></strong></p>
<div class="post-header">
<div class="post-header-line-1"></div>
</div>
<div class="post-body x_x_entry-content" id="post-body-6300061370019314003"><strong id="internal-source-marker_0.16307367430999875"><span>Introduccion a los Web Services:</span><br>
<span>Un </span><span>servicio web</span><span> (en ingl&eacute;s, </span><span>Web service</span><span>) es una pieza de software que utiliza un conjunto de protocolos y est&aacute;ndares que sirven para intercambiar datos entre aplicaciones. Distintas aplicaciones
 de software desarrolladas en lenguajes de programaci&oacute;n diferentes, y ejecutadas sobre cualquier plataforma, pueden utilizar los servicios web para intercambiar datos en
</span><a href="http://es.wikipedia.org/wiki/Red_de_ordenadores"><span>redes de ordenadores</span></a><span> como
</span><a href="http://es.wikipedia.org/wiki/Internet"><span>Internet</span></a><span>. La
</span><a href="http://es.wikipedia.org/wiki/Interoperabilidad"><span>interoperabilidad</span></a><span> se consigue mediante la adopci&oacute;n de
</span><a href="http://es.wikipedia.org/wiki/Est%C3%A1ndar_abierto"><span>est&aacute;ndares abiertos</span></a><span>. Las organizaciones
</span><a href="http://es.wikipedia.org/wiki/OASIS_(organizaci%C3%B3n)"><span>OASIS</span></a><span> y
</span><a href="http://es.wikipedia.org/wiki/World_Wide_Web_Consortium"><span>W3C</span></a><span> son los comit&eacute;s responsables de la arquitectura y reglamentaci&oacute;n de los servicios Web. Para mejorar la interoperabilidad entre distintas implementaciones
 de servicios Web se ha creado el organismo </span><a href="http://es.wikipedia.org/wiki/WS-I"><span>WS-I</span></a><span>, encargado de desarrollar diversos perfiles para definir de manera m&aacute;s exhaustiva estos est&aacute;ndares.</span><br>
<span>&nbsp;</span><br>
<span>Para m&aacute;s informaci&oacute;n (Wikipedia):</span></strong><br>
<ul>
<li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Est.C3.A1ndares_empleados"><span>1 Est&aacute;ndares empleados</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Ventajas_de_los_servicios_web"><span>2 Ventajas de los servicios web</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Inconvenientes_de_los_servicios_Web"><span>3 Inconvenientes de los servicios Web</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Razones_para_crear_servicios_Web"><span>4 Razones para crear servicios Web</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Plataformas"><span>5 Plataformas</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Temas_relacionados"><span>6 Temas relacionados</span></a></strong>
</li><li><strong id="internal-source-marker_0.16307367430999875"><a href="http://es.wikipedia.org/wiki/Web_Services#Enlaces_externos"><span>7 Enlaces externos</span></a></strong>
</li></ul>
</div>
<div class="post-body x_x_entry-content" id="post-body-6300061370019314003"><strong id="internal-source-marker_0.16307367430999875"><span>&nbsp;</span></strong></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"><strong id="internal-source-marker_0.16307367430999875"><br>
<br>
<br>
<span>Entrando en materia:</span><br>
<span>Primero creamos el web service en VS2010</span></strong></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"><strong><span><br>
</span></strong></div>
<div class="post-body x_x_entry-content"><strong id="internal-source-marker_0.16307367430999875"><span>&nbsp;</span><img src="https://lh4.googleusercontent.com/icZSslBcmUSS39CteVIDLnT-KP2e4i7vf0y0CQ0xnPLZav479ONfWBGdllLQddeoLlspT1c87F7No4Zr-SoKKhoZd6O9JLQ2a_fkDzP3-sKeADPI-lU" alt="" width="400" height="261"><br>
<br>
</strong></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"></div>
<div class="post-body x_x_entry-content"><strong id="internal-source-marker_0.16307367430999875"><br>
<br>
<br>
<span>Se genera un c&oacute;digo y una jerarqu&iacute;a de archivos como la de la izquierda (en la imagen de abajo), ya con esto tenemos un servicio muy b&aacute;sico del tipo Hola Mundo, que ser&aacute; suficiente por ahora, a este codigo generado por VS2010
 se le han hecho ligeros cambios, dejamos de la mano del lector descubrir cuales fueron.</span><br>
<br>
<strong id="internal-source-marker_0.16307367430999875"><img src="https://lh5.googleusercontent.com/Pg5np-QtHXK114OpgGg51fO8eXh0seNJeQGsfa9B0lGSqDA7TN_zu1TbKJTPbDpepQFX2gZs2G0Zg3OVICOEKMEkdw_ABdA-hDK4PMynqHESsD5gLco" alt="" width="489px;" height="242px;"></strong><br>
<br>
<br>
<span>Corremos el servicio con la tecla F5 y abrimos otra instancia del Visual Studio 2010 y creamos una ASP.NET Web Application</span></strong><br>
<strong><span><br>
</span></strong><br>
<strong id="internal-source-marker_0.16307367430999875"><img src="https://lh6.googleusercontent.com/eZG7VQ9sqty3-yQjj41UwfNXAsQ-d_KnogEm_j2d6GAzCezgMZi2JZlvw1kIQL_i_4fFSJ-V118cvIHFwG97LkmVfBHDwrD8ODRNxFXD-00CtX5ET_o" alt="" width="513px;" height="236px;"></strong>&nbsp;<strong><br>
<br>
<span><br>
</span></strong><br>
<strong><span>Agregamos un TextBox y un Button, en el evento click del button, ponemos el codigo como esta en la imagen anterior</span><br>
<br>
<br>
<span>Este es el resultado de la ejecuci&oacute;n de la aplicaci&oacute;n:</span><img src="https://lh3.googleusercontent.com/SUgCzRfPVBHcFUFYD3jLMxit9F9I-J_pqQKLC4jWJmlTFvyeSCCv8dvEVpmFpMjkS5IaFH4qBQt7UNq0_GWVOp9_T8QthNtO3-z2g-yGySUqrIVyaDY" alt="" width="518px;" height="282px;"><br>
<br>
</strong></div>
