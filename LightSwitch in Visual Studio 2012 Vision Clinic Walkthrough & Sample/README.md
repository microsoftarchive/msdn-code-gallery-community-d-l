# LightSwitch in Visual Studio 2012 Vision Clinic Walkthrough & Sample
## Requires
- Visual Studio LightSwitch
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio LightSwitch
- Visual Studio 11 Beta
## Topics
- Rapid Application Development
- Silverlight Business Application
## Updated
- 11/26/2013
## Description

<p>Obtenga informaci&oacute;n acerca de c&oacute;mo empezar a crear aplicaciones de negocio con LightSwitch en Visual Studio 2012.</p>
<p>Esta descarga contiene la aplicaci&oacute;n de ejemplo y la base de datos para el tema
<a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx">&quot;Tutorial: crear la aplicaci&oacute;n de Vision Clinic&quot;</a> en la documentaci&oacute;n del producto. Hay ejemplos disponibles de Visual Basic y C#.</p>
<p>En este ejemplo est&aacute; pensado para su uso con LightSwitch en Visual Studio 2012. Para obtener m&aacute;s informaci&oacute;n acerca de Visual Studio LightSwitch y descargar la versi&oacute;n de prueba, visite el
<a href="http://msdn.microsoft.com/es-es/lightswitch/default.aspx">Centro de desarrollo de LightSwitch</a>. Si tiene preguntas, visite los foros de
<a href="http://social.msdn.microsoft.com/Forums/es-es/LightSwitchDev11Beta/threads">
LightSwitch</a>.</p>
<p><strong><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx">Tutorial: crear la aplicaci&oacute;n de Vision Clinic</a></strong></p>
<div class="lw_vs">Este tutorial muestra todo el proceso de creaci&oacute;n de una aplicaci&oacute;n en Visual Studio LightSwitch. Usar&aacute; muchas de las caracter&iacute;sticas de LightSwitch para crear una aplicaci&oacute;n para una aplicaci&oacute;n
 de Vision Clinic no real. La aplicaci&oacute;n incluye capacidades para programar citas y la creaci&oacute;n de facturas.</div>
<div class="lw_vs"></div>
<div id="mainSection">
<div id="mainBody">
<div>
<div class="LW_CollapsibleArea_TitleDiv">
<div><strong>&nbsp;</strong></div>
<div><strong>Pasos:</strong></div>
<div>
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
</div>
<div>
<div class="sectionblock" id="dc166a7a-abfe-4861-86e9-ede8ab878563_c"><a id="sectionToggle0"></a>
<ul>
<li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#project">Crear un proyecto</a></p>
<p>Cree el proyecto de la aplicaci&oacute;n.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#entities">Definir tablas</a></p>
<p>Agregue entidades Patient, Invoice e Invoice Detail.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#ChoiceList">Crear una lista de opciones</a></p>
<p>Cree una lista de valores.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#Relationship">Definir una relaci&oacute;n</a></p>
<p>Vincule tablas relacionadas.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#appointment">Agregar otra entidad</a></p>
<p>Agregue la entidad Appointment.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#screen">Crear una pantalla</a></p>
<p>Crear una pantalla para mostrar a los pacientes.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#run">Ejecutar la aplicaci&oacute;n</a></p>
<p>Ejecute la aplicaci&oacute;n y escriba datos.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#data">Conectar a una base de datos</a></p>
<p>Conectarse a una base de datos externa.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#product">Realizar cambios en las entidades</a></p>
<p>Modifique las entidades Products y Product Rebate.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#productlist">Crear una lista y una pantalla de detalles</a></p>
<p>Cree una pantalla para mostrar los productos.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#layout">Cambiar el dise&ntilde;o de pantalla</a></p>
<p>Modifique el dise&ntilde;o de la pantalla de la lista de productos.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#running">Realizar cambios en tiempo de ejecuci&oacute;n</a></p>
<p>Realice cambios en la aplicaci&oacute;n en ejecuci&oacute;n.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#query">Crear una consulta</a></p>
<p>Cree una consulta parametrizada y enl&aacute;cela a una pantalla.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#computed">Agregar un campo calculado</a></p>
<p>Cree un campo calculado y agr&eacute;guelo a una pantalla.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#cross">Crear una relaci&oacute;n entre bases de datos</a></p>
<p>Cree una relaci&oacute;n virtual entre entidades en distintas bases de datos.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#invoices">Crear la pantalla de facturas</a></p>
<p>Cree una pantalla para mostrar las facturas.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#running2">Modificar la pantalla de facturas</a></p>
<p>Cambie el dise&ntilde;o de la pantalla de facturas en la aplicaci&oacute;n en ejecuci&oacute;n.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#logic">Agregar l&oacute;gica de pantalla</a></p>
<p>Escriba c&oacute;digo para calcular las fechas.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#computed2">Agregar m&aacute;s campos calculados</a></p>
<p>Cree m&aacute;s campos calculados y agr&eacute;guelos a la pantalla de facturas.</p>
</li><li>
<p><a href="http://msdn.microsoft.com/es-es/library/ee256749.aspx#deploy">Implementar la aplicaci&oacute;n</a></p>
<p>Publique la aplicaci&oacute;n como una aplicaci&oacute;n de escritorio de nivel 2.</p>
</li></ul>
</div>
</div>
</div>
</div>
