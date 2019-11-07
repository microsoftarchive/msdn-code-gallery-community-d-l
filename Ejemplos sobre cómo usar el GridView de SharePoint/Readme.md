# Ejemplos sobre cómo usar el GridView de SharePoint.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- SharePoint 2010
- SharePoint Foundation 2010
## Topics
- SharePoint Controls
## Updated
- 07/04/2011
## Description

<h1>Introducci&oacute;n</h1>
<div><em>La interfaz gr&aacute;fica de SharePoint contiene diversos controles, los cuales est&aacute;n disponibles para ser usados mediante las librer&iacute;as de SharePoint como Microsoft.SharePoint.dll.</em></div>
<div><em>En diversas ocasiones, al construir&nbsp;WebParts o p&aacute;ginas de aplicaciones, necesitamos mostrar datos de una u otra forma. Una particularmente &uacute;til es el empleo de vistas de reja (GridView). Por supuesto, podemos emplear el control GridView
 nativo de ASP.NET. Afortunadamente, sin embargo, SharePoint cuenta con su propia implementaci&oacute;n de este control: SPGridView. Este control cuenta con ciertas configuraciones avanzadas, pero sobre todo, incorpora los estilos nativos de SharePoint, as&iacute;
 como un poco de funcionalidad extra. </em></div>
<div><em>El c&oacute;digo aqu&iacute; contenido muestra cinco ejemplos sobre c&oacute;mo utilizar este control:</em></div>
<div><em>1.- C&oacute;mo utilizarlo dentro de un WebPart. </em></div>
<div><em>2.- C&oacute;mo utilizarlo de forma declarativa en una p&aacute;gina de aplicaci&oacute;n.
</em></div>
<div><em>3.- C&oacute;mo a&ntilde;adir un Edit Box Control</em>&nbsp;a una columna del SPGridView.</div>
<div>4.- C&oacute;mo a&ntilde;adir paginadores, filtros y ordenamiento.</div>
<div>5.- C&oacute;mo usar el control en conjunto con un SPDataSource.</div>
<h1><span>Construyendo el ejemplo</span></h1>
<div><em>La soluci&oacute;n de ejemplo cuenta con una soluci&oacute;n para Visual Studio 2010. Al ser para SharePoint 2010, deber&aacute; abrirse en una m&aacute;quina (virtual, por ejemplo) con SharePoint 2010 (Foundation, al menos) instalado. Compilar y desplegar
 la soluci&oacute;n, sin embargo, es tan sencillo como seleccionar las opciones del Visual Studio 2010 y ya.</em></div>
<div><em>Ahora bien, dentro del directorio \Fermasmas.Labs.SPGridViewExample\bin\Debug&nbsp;est&aacute; el archivo Fermasmas.Labs.SPGridViewExample.wsp. Para instalar la soluci&oacute;n sin usar el Visual Studio 2010, basta instalar este WSP y luego hacer el
 deploy. Ejecutar las siguientes l&iacute;neas de comando con los valores apropiados debe ser suficiente.
</em></div>
<div><em>stsadm -o addsolution -filename &quot;directorio-al-archivo\archivo.wsp&quot;<br>
stsadm&quot; -o execadmsvcjobs<br>
stsadm&quot; -o deploysolution -name archivo.wsp -url <a href="http://tusitio">http://tusitio</a> -allowgacdeployment -immediate -force</em></div>
<div><em>Posteriormente, s&oacute;lo ser&aacute; cuesti&oacute;n de activar el feature contenido en el WSP. Al hacerlo, se crear&aacute;n las listas y p&aacute;ginas necesarias para mostrar los ejemplos, sobre el sitio seleccionado. Tambi&eacute;n aparecer&aacute;n,
 en el men&uacute; de Acciones del Sitio, cinco entradas, cada una direccionando a la p&aacute;gina que contiene el ejemplo.
</em></div>
<div><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></div>
<div><em>Todos los ejemplos hacen uso de la lista &quot;Asgard List&quot;, la cual contiene cierta informaci&oacute;n pre-cargada.
</em></div>
<div><em>El primero de ellos muestra c&oacute;mo crear el SPGridView dentro de un WebPart, llamado GridViewWebPart. El c&oacute;digo dentro del m&eacute;todo&nbsp;CreateChildControls muestra c&oacute;mo se crea. Podr&aacute;s observar que es muy similar a utilizar
 en GridView. Las diferencias en la interfaz gr&aacute;fica, sin embargo, son notables. He aqu&iacute; un fragmento del c&oacute;digo.
</em></div>
<div><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">DataTable table = GetSource();
table.DefaultView.Sort = &quot;Gender&quot;;

_gridView = new SPGridView();
_gridView.ID = &quot;_gridView&quot;;
_gridView.AutoGenerateColumns = false;
_gridView.Width = new Unit(100, UnitType.Pixel);
_gridView.DataSource = table.DefaultView;
_gridView.AllowGrouping = true;

// le quitamos el view state
_gridView.EnableViewState = false;
// agrupamos por el campo &quot;Gender&quot; del DataSource
_gridView.GroupField = &quot;Gender&quot;;
// un nombre bonito para el campo
_gridView.GroupFieldDisplayName = &quot;Gender&quot;;
// permitimos que los grupos generados colapsen
_gridView.AllowGroupCollapse = true;
// adicionalmente, podemos a&ntilde;adir alg&uacute;n campo descriptivo o una imagen
// _gridView.GroupDescriptionField = &quot;Mi Campo Descriptivo&quot;;
// _gridView.GroupImageUrlField = &quot;Mi campo con imagen&quot;;

_gridView.Columns.Add(new CommandField {
    ButtonType = ButtonType.Image,
    ShowSelectButton = true,
    SelectImageUrl = string.Format(&quot;{0}/asgard/_layouts/images/arrowright_light.gif&quot;, SPContext.Current.Web.Url)
}); 
_gridView.Columns.Add(new SPBoundField { DataField = &quot;Name&quot;, HeaderText = &quot;Nombre&quot; });
_gridView.Columns.Add(new SPBoundField { DataField = &quot;Influence&quot;, HeaderText = &quot;Influencia&quot; });
_gridView.Columns.Add(new SPBoundField { DataField = &quot;Comments&quot;, HeaderText = &quot;Comentarios&quot; });
_gridView.DataBind();

Controls.Add(_gridView);
Controls.Add(new Literal { Text = &quot;&lt;hr/&gt;&quot; });</pre>
<div class="preview">
<pre class="csharp">DataTable&nbsp;table&nbsp;=&nbsp;GetSource();&nbsp;
table.DefaultView.Sort&nbsp;=&nbsp;<span class="cs__string">&quot;Gender&quot;</span>;&nbsp;
&nbsp;
_gridView&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SPGridView();&nbsp;
_gridView.ID&nbsp;=&nbsp;<span class="cs__string">&quot;_gridView&quot;</span>;&nbsp;
_gridView.AutoGenerateColumns&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
_gridView.Width&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Unit(<span class="cs__number">100</span>,&nbsp;UnitType.Pixel);&nbsp;
_gridView.DataSource&nbsp;=&nbsp;table.DefaultView;&nbsp;
_gridView.AllowGrouping&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;le&nbsp;quitamos&nbsp;el&nbsp;view&nbsp;state</span>&nbsp;
_gridView.EnableViewState&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
<span class="cs__com">//&nbsp;agrupamos&nbsp;por&nbsp;el&nbsp;campo&nbsp;&quot;Gender&quot;&nbsp;del&nbsp;DataSource</span>&nbsp;
_gridView.GroupField&nbsp;=&nbsp;<span class="cs__string">&quot;Gender&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;un&nbsp;nombre&nbsp;bonito&nbsp;para&nbsp;el&nbsp;campo</span>&nbsp;
_gridView.GroupFieldDisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Gender&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;permitimos&nbsp;que&nbsp;los&nbsp;grupos&nbsp;generados&nbsp;colapsen</span>&nbsp;
_gridView.AllowGroupCollapse&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
<span class="cs__com">//&nbsp;adicionalmente,&nbsp;podemos&nbsp;a&ntilde;adir&nbsp;alg&uacute;n&nbsp;campo&nbsp;descriptivo&nbsp;o&nbsp;una&nbsp;imagen</span>&nbsp;
<span class="cs__com">//&nbsp;_gridView.GroupDescriptionField&nbsp;=&nbsp;&quot;Mi&nbsp;Campo&nbsp;Descriptivo&quot;;</span>&nbsp;
<span class="cs__com">//&nbsp;_gridView.GroupImageUrlField&nbsp;=&nbsp;&quot;Mi&nbsp;campo&nbsp;con&nbsp;imagen&quot;;</span>&nbsp;
&nbsp;
_gridView.Columns.Add(<span class="cs__keyword">new</span>&nbsp;CommandField&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ButtonType&nbsp;=&nbsp;ButtonType.Image,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ShowSelectButton&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SelectImageUrl&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}/asgard/_layouts/images/arrowright_light.gif&quot;</span>,&nbsp;SPContext.Current.Web.Url)&nbsp;
});&nbsp;&nbsp;
_gridView.Columns.Add(<span class="cs__keyword">new</span>&nbsp;SPBoundField&nbsp;{&nbsp;DataField&nbsp;=&nbsp;<span class="cs__string">&quot;Name&quot;</span>,&nbsp;HeaderText&nbsp;=&nbsp;<span class="cs__string">&quot;Nombre&quot;</span>&nbsp;});&nbsp;
_gridView.Columns.Add(<span class="cs__keyword">new</span>&nbsp;SPBoundField&nbsp;{&nbsp;DataField&nbsp;=&nbsp;<span class="cs__string">&quot;Influence&quot;</span>,&nbsp;HeaderText&nbsp;=&nbsp;<span class="cs__string">&quot;Influencia&quot;</span>&nbsp;});&nbsp;
_gridView.Columns.Add(<span class="cs__keyword">new</span>&nbsp;SPBoundField&nbsp;{&nbsp;DataField&nbsp;=&nbsp;<span class="cs__string">&quot;Comments&quot;</span>,&nbsp;HeaderText&nbsp;=&nbsp;<span class="cs__string">&quot;Comentarios&quot;</span>&nbsp;});&nbsp;
_gridView.DataBind();&nbsp;
&nbsp;
Controls.Add(_gridView);&nbsp;
Controls.Add(<span class="cs__keyword">new</span>&nbsp;Literal&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;hr/&gt;&quot;</span>&nbsp;});</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Y as&iacute; es como luce dentro de una p&aacute;gina de WebParts. :</div>
</em></div>
<div><em>
<div></div>
</em></div>
<div><img src="24140-spgv1.png" alt="" width="597" height="361"></div>
<div>Notar&aacute;s que los campos se encuentran agrupados, y que a&ntilde;adimos un campo con una imagen, una flecha, la cual permite seleccionar una fila. La agrupaci&oacute;n est&aacute; habilitada y permite expander y contraer los elementos.</div>
<div>El segundo ejemplo muestra un SPGridView, pero &eacute;ste se encuentra dentro de una p&aacute;gina de aplicaci&oacute;n, y como tal, est&aacute; declarado solamente con marcas de ASP.NET. Para variar un poco respecto al anterior, este control permite
 editar los elementos al hacer clic en el bot&oacute;n de edici&oacute;n (los cambios se ver&aacute;n reflejados en la lista, por cierto).</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;SharePoint:SPGridView ID=&quot;_grid&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;false&quot; DataSourceID=&quot;_mainSource&quot;&gt;
    &lt;Columns&gt;
        &lt;asp:CommandField ButtonType=&quot;Image&quot; ShowEditButton=&quot;true&quot; EditImageUrl=&quot;/_layouts/images/edit.gif&quot; UpdateImageUrl=&quot;/_layouts/images/save.gif&quot; CancelImageUrl=&quot;/_layouts/images/delete.gif&quot; /&gt;
        &lt;asp:TemplateField HeaderText=&quot;&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:HiddenField ID=&quot;_idHiddenField&quot; runat=&quot;server&quot; Value='&lt;%# Bind(&quot;ID&quot;) %&gt;' /&gt;
            &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        &lt;asp:TemplateField HeaderText=&quot;Nombre&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:Label ID=&quot;_nameLabel&quot; runat=&quot;server&quot; Text='&lt;%# Bind(&quot;Name&quot;) %&gt;' /&gt;
            &lt;/ItemTemplate&gt;
            &lt;EditItemTemplate&gt;
                &lt;asp:TextBox ID=&quot;_nameText&quot; runat=&quot;server&quot; Width=&quot;100%&quot; Text='&lt;%# Bind(&quot;Name&quot;) %&gt;' /&gt;
            &lt;/EditItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        &lt;asp:TemplateField HeaderText=&quot;Influencia&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:Label ID=&quot;_influenceLabel&quot; runat=&quot;server&quot; Text='&lt;%# Bind(&quot;Influence&quot;) %&gt;' /&gt;
            &lt;/ItemTemplate&gt;
            &lt;EditItemTemplate&gt;
                &lt;asp:TextBox ID=&quot;_influenceText&quot; runat=&quot;server&quot; Width=&quot;100%&quot; Text='&lt;%# Bind(&quot;Influence&quot;) %&gt;' /&gt;
            &lt;/EditItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        &lt;asp:TemplateField HeaderText=&quot;G&eacute;nero&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:Label ID=&quot;_genderLabel&quot; runat=&quot;server&quot; Text='&lt;%# Bind(&quot;Gender&quot;) %&gt;' /&gt;
            &lt;/ItemTemplate&gt;
            &lt;EditItemTemplate&gt;
                &lt;asp:DropDownList ID=&quot;_genderList&quot; runat=&quot;server&quot; Width=&quot;100%&quot; SelectedValue='&lt;%# Bind(&quot;Gender&quot;) %&gt;' &gt;
                    &lt;asp:ListItem Text=&quot;&AElig;sir&quot; Value=&quot;&AElig;sir&quot; /&gt;
                    &lt;asp:ListItem Text=&quot;&Aacute;synjur&quot; Value=&quot;&Aacute;synjur&quot; /&gt;
                &lt;/asp:DropDownList&gt;
            &lt;/EditItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        &lt;asp:TemplateField HeaderText=&quot;Comentarios&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:Label ID=&quot;_commentLabel&quot; runat=&quot;server&quot; Text='&lt;%# Bind(&quot;Comments&quot;) %&gt;' /&gt;
            &lt;/ItemTemplate&gt;
            &lt;EditItemTemplate&gt;
                &lt;asp:TextBox ID=&quot;_commentText&quot; runat=&quot;server&quot; Width=&quot;100%&quot; Text='&lt;%# Bind(&quot;Comments&quot;) %&gt;' TextMode=&quot;MultiLine&quot; /&gt;
            &lt;/EditItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
    &lt;/Columns&gt;
&lt;/SharePoint:SPGridView&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;SharePoint</span>:SPGridView&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_grid&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;<span class="xml__attr_name">AutoGenerateColumns</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;<span class="xml__attr_name">DataSourceID</span>=<span class="xml__attr_value">&quot;_mainSource&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Columns</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:CommandField&nbsp;<span class="xml__attr_name">ButtonType</span>=<span class="xml__attr_value">&quot;Image&quot;</span>&nbsp;<span class="xml__attr_name">ShowEditButton</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">EditImageUrl</span>=<span class="xml__attr_value">&quot;/_layouts/images/edit.gif&quot;</span>&nbsp;<span class="xml__attr_name">UpdateImageUrl</span>=<span class="xml__attr_value">&quot;/_layouts/images/save.gif&quot;</span>&nbsp;<span class="xml__attr_name">CancelImageUrl</span>=<span class="xml__attr_value">&quot;/_layouts/images/delete.gif&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TemplateField&nbsp;<span class="xml__attr_name">HeaderText</span>=<span class="xml__attr_value">&quot;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:HiddenField&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_idHiddenField&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;Value='&lt;%#&nbsp;Bind(&quot;ID&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:TemplateField&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TemplateField&nbsp;<span class="xml__attr_name">HeaderText</span>=<span class="xml__attr_value">&quot;Nombre&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:Label&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_nameLabel&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Name&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;EditItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_nameText&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;<span class="xml__attr_name">Width</span>=<span class="xml__attr_value">&quot;100%&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Name&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/EditItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:TemplateField&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TemplateField&nbsp;<span class="xml__attr_name">HeaderText</span>=<span class="xml__attr_value">&quot;Influencia&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:Label&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_influenceLabel&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Influence&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;EditItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_influenceText&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;<span class="xml__attr_name">Width</span>=<span class="xml__attr_value">&quot;100%&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Influence&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/EditItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:TemplateField&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TemplateField&nbsp;<span class="xml__attr_name">HeaderText</span>=<span class="xml__attr_value">&quot;G&eacute;nero&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:Label&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_genderLabel&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Gender&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;EditItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:DropDownList&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_genderList&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;<span class="xml__attr_name">Width</span>=<span class="xml__attr_value">&quot;100%&quot;</span>&nbsp;SelectedValue='&lt;%#&nbsp;Bind(&quot;Gender&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="xml__attr_name">Text</span>=<span class="xml__attr_value">&quot;&AElig;sir&quot;</span>&nbsp;<span class="xml__attr_name">Value</span>=<span class="xml__attr_value">&quot;&AElig;sir&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:ListItem&nbsp;<span class="xml__attr_name">Text</span>=<span class="xml__attr_value">&quot;&Aacute;synjur&quot;</span>&nbsp;<span class="xml__attr_name">Value</span>=<span class="xml__attr_value">&quot;&Aacute;synjur&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:DropDownList&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/EditItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:TemplateField&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TemplateField&nbsp;<span class="xml__attr_name">HeaderText</span>=<span class="xml__attr_value">&quot;Comentarios&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:Label&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_commentLabel&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Comments&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;EditItemTemplate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;asp</span>:TextBox&nbsp;<span class="xml__attr_name">ID</span>=<span class="xml__attr_value">&quot;_commentText&quot;</span>&nbsp;<span class="xml__attr_name">runat</span>=<span class="xml__attr_value">&quot;server&quot;</span>&nbsp;<span class="xml__attr_name">Width</span>=<span class="xml__attr_value">&quot;100%&quot;</span>&nbsp;Text='&lt;%#&nbsp;Bind(&quot;Comments&quot;)&nbsp;<span class="xml__tag_start">%&gt;</span>'&nbsp;TextMode=&quot;MultiLine&quot;&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/EditItemTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/asp:TemplateField&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Columns&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/SharePoint:SPGridView&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Ese es el c&oacute;digo, y as&iacute; es como luce, en modo de edici&oacute;n.</div>
<div><img src="24141-spgv2.png" alt="" width="637" height="386"></div>
<div>&nbsp;</div>
<div>El tercer ejemplo muestra el GridView, pero ahora a&ntilde;adimos una columna con un control EBC (Edit Box Control), que es un men&uacute; desplegable con diversas acciones. Es un control caracter&iacute;stico de SharePoint, y todas las listas personalizadas
 lo muestran en su campo Title. Adicionalmente, la columna de comentarios tiene un cambio. En lugar de mostrar simplemente el texto, ponemos un enlace, el cual al hacer clic abrir&aacute; una ventana desplegable (pop-up) donde se muestra el texto del comentario.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;SharePoint:MenuTemplate ID=&quot;_menu&quot; runat=&quot;server&quot; &gt;
    &lt;SharePoint:MenuItemTemplate ID=&quot;_commentsMenu&quot; runat=&quot;server&quot; Text=&quot;Ir a comentarios&quot; ClientOnClickNavigateUrl=&quot;ViewComments.aspx?Name=%NAME%&amp;Comments=%COMMENTS%&quot; /&gt;
    &lt;SharePoint:MenuItemTemplate ID=&quot;_goToListMenu&quot; runat=&quot;server&quot; Text=&quot;Ir a lista&quot; ClientOnClickNavigateUrl=&quot;../../Lists/AsgardList/AllItems.aspx&quot; /&gt;
    &lt;SharePoint:MenuItemTemplate ID=&quot;_seeItemMenu&quot; runat=&quot;server&quot; Text=&quot;Propiedades&quot; ClientOnClickNavigateUrl=&quot;../../Lists/AsgardList/DispForm.aspx?ID=%EDIT%&quot; /&gt;
    &lt;SharePoint:MenuItemTemplate ID=&quot;_editMenu&quot; runat=&quot;server&quot; Text=&quot;Editar&quot; ClientOnClickNavigateUrl=&quot;../../Lists/AsgardList/EditForm.aspx?ID=%EDIT%&quot; /&gt;
&lt;/SharePoint:MenuTemplate&gt;
&lt;SharePoint:SPGridView ID=&quot;_grid&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;false&quot; DataSourceID=&quot;_mainSource&quot; AllowGrouping=&quot;true&quot; GroupField=&quot;Gender&quot; GroupFieldDisplayName=&quot;G&eacute;nero&quot; AllowGroupCollapse=&quot;true&quot;&gt;
    &lt;Columns&gt;
        &lt;SharePoint:SPMenuField HeaderText=&quot;Nombre&quot; TextFields=&quot;Name&quot; MenuTemplateId=&quot;_menu&quot;
            NavigateUrlFields=&quot;ID,Name,Comments&quot;
            NavigateUrlFormat=&quot;do.aspx?ID={0}&amp;Name={1}&amp;Comments={2}&quot;
            TokenNameAndValueFields=&quot;EDIT=ID,NAME=Name,COMMENTS=Comments&quot;
            /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;Influencia&quot; DataField=&quot;Influence&quot; /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;G&eacute;nero&quot; DataField=&quot;Gender&quot; /&gt;
        &lt;asp:TemplateField HeaderText=&quot;Comentarios&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:LinkButton ID=&quot;_link&quot; runat=&quot;server&quot; 
                    OnClientClick='&lt;%# &quot;javascript:openCommentsDialog(\&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Name&quot;) as string) &#43; &quot;\&quot;, \&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Comments&quot;) as string) &#43; &quot;\&quot;); return false;&quot; %&gt;' Text=&quot;Comentarios&quot; /&gt;
            &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
    &lt;/Columns&gt;
&lt;/SharePoint:SPGridView&gt;</pre>
<div class="preview">
<pre class="js">&lt;SharePoint:MenuTemplate&nbsp;ID=<span class="js__string">&quot;_menu&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:MenuItemTemplate&nbsp;ID=<span class="js__string">&quot;_commentsMenu&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;Text=<span class="js__string">&quot;Ir&nbsp;a&nbsp;comentarios&quot;</span>&nbsp;ClientOnClickNavigateUrl=<span class="js__string">&quot;ViewComments.aspx?Name=%NAME%&amp;Comments=%COMMENTS%&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:MenuItemTemplate&nbsp;ID=<span class="js__string">&quot;_goToListMenu&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;Text=<span class="js__string">&quot;Ir&nbsp;a&nbsp;lista&quot;</span>&nbsp;ClientOnClickNavigateUrl=<span class="js__string">&quot;../../Lists/AsgardList/AllItems.aspx&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:MenuItemTemplate&nbsp;ID=<span class="js__string">&quot;_seeItemMenu&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;Text=<span class="js__string">&quot;Propiedades&quot;</span>&nbsp;ClientOnClickNavigateUrl=<span class="js__string">&quot;../../Lists/AsgardList/DispForm.aspx?ID=%EDIT%&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:MenuItemTemplate&nbsp;ID=<span class="js__string">&quot;_editMenu&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;Text=<span class="js__string">&quot;Editar&quot;</span>&nbsp;ClientOnClickNavigateUrl=<span class="js__string">&quot;../../Lists/AsgardList/EditForm.aspx?ID=%EDIT%&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/SharePoint:MenuTemplate&gt;&nbsp;
&lt;SharePoint:SPGridView&nbsp;ID=<span class="js__string">&quot;_grid&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;AutoGenerateColumns=<span class="js__string">&quot;false&quot;</span>&nbsp;DataSourceID=<span class="js__string">&quot;_mainSource&quot;</span>&nbsp;AllowGrouping=<span class="js__string">&quot;true&quot;</span>&nbsp;GroupField=<span class="js__string">&quot;Gender&quot;</span>&nbsp;GroupFieldDisplayName=<span class="js__string">&quot;G&eacute;nero&quot;</span>&nbsp;AllowGroupCollapse=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPMenuField&nbsp;HeaderText=<span class="js__string">&quot;Nombre&quot;</span>&nbsp;TextFields=<span class="js__string">&quot;Name&quot;</span>&nbsp;MenuTemplateId=<span class="js__string">&quot;_menu&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigateUrlFields=<span class="js__string">&quot;ID,Name,Comments&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigateUrlFormat=<span class="js__string">&quot;do.aspx?ID={0}&amp;Name={1}&amp;Comments={2}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TokenNameAndValueFields=<span class="js__string">&quot;EDIT=ID,NAME=Name,COMMENTS=Comments&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;Influencia&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Influence&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;G&eacute;nero&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Gender&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="js__string">&quot;Comentarios&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:LinkButton&nbsp;ID=<span class="js__string">&quot;_link&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnClientClick=<span class="js__string">'&lt;%#&nbsp;&quot;javascript:openCommentsDialog(\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Name&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;,&nbsp;\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Comments&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;);&nbsp;return&nbsp;false;&quot;&nbsp;%&gt;'</span>&nbsp;Text=<span class="js__string">&quot;Comentarios&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&lt;/SharePoint:SPGridView&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Este es el c&oacute;digo del ASPX. Nota que para la columna de comentarios, mandamos llamar la funci&oacute;n openCommentsDialog desde el c&oacute;digo del cliente. Este es el script de dicha funci&oacute;n.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">js</span>
<pre class="hidden">function openCommentsDialog(name, comments) {
    var options = SP.UI.$create_DialogOptions();
    options.url = &quot;ViewComments.aspx?name=&quot; &#43; name &#43; &quot;&amp;comments=&quot; &#43; comments;
    options.height = 600;
    options.width = 800;

    SP.UI.ModalDialog.showModalDialog(options);
}</pre>
<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;openCommentsDialog(name,&nbsp;comments)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;options&nbsp;=&nbsp;SP.UI.$create_DialogOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;options.url&nbsp;=&nbsp;<span class="js__string">&quot;ViewComments.aspx?name=&quot;</span>&nbsp;&#43;&nbsp;name&nbsp;&#43;&nbsp;<span class="js__string">&quot;&amp;comments=&quot;</span>&nbsp;&#43;&nbsp;comments;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;options.height&nbsp;=&nbsp;<span class="js__num">600</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;options.width&nbsp;=&nbsp;<span class="js__num">800</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.ModalDialog.showModalDialog(options);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Y as&iacute; es c&oacute;mo luce el GridView con el EBC, y c&oacute;mo luce al hacer clic sobre el enlace de comentarios.</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;<img src="24142-spgv3.png" alt="" width="649" height="338"></div>
</div>
<div><img src="24143-spgv4.png" alt="" width="652" height="347"></div>
<div>En el cuarto ejemplo, la cosa se pone interesante: a&ntilde;adimos paginaci&oacute;n, as&iacute; como la capacidad de filtrar y ordenar, muy &agrave; la SharePoint.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;SharePoint:SPGridView ID=&quot;_grid&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;false&quot; DataSourceID=&quot;_mainSource&quot; 
    AllowFiltering=&quot;true&quot; AllowSorting=&quot;true&quot; AllowPaging=&quot;true&quot; PageSize=&quot;3&quot; FilterDataFields=&quot;Name,Influence,Gender,Comments&quot;
    FilteredDataSourcePropertyName=&quot;FilterExpression&quot; FilteredDataSourcePropertyFormat=&quot;{1} LIKE '{0}'&quot; &gt;
    &lt;Columns&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;Nombre&quot; DataField=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;Influencia&quot; DataField=&quot;Influence&quot; SortExpression=&quot;Influence&quot; /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;G&eacute;nero&quot; DataField=&quot;Gender&quot; SortExpression=&quot;Gender&quot; /&gt;
        &lt;asp:TemplateField HeaderText=&quot;Comentarios&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:LinkButton ID=&quot;_link&quot; runat=&quot;server&quot; 
                    OnClientClick='&lt;%# &quot;javascript:openCommentsDialog(\&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Name&quot;) as string) &#43; &quot;\&quot;, \&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Comments&quot;) as string) &#43; &quot;\&quot;); return false;&quot; %&gt;' Text=&quot;Comentarios&quot; /&gt;
            &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
    &lt;/Columns&gt;
    &lt;PagerSettings Mode=&quot;NextPreviousFirstLast&quot; Visible=&quot;true&quot; NextPageText=&quot;Siguiente |&quot; PreviousPageText=&quot;Anterior |&quot; FirstPageText=&quot;Inicio |&quot; LastPageText=&quot;Fin&quot; /&gt;
&lt;/SharePoint:SPGridView&gt;
&lt;asp:ObjectDataSource ID=&quot;_mainSource&quot; runat=&quot;server&quot; EnablePaging=&quot;true&quot; EnableCaching=&quot;true&quot;
                        TypeName=&quot;Fermasmas.Labs.SPGridViewExample.Model.AsgardSource, $SharePoint.Project.AssemblyFullName$&quot;
                        SelectMethod=&quot;SelectAdvanced&quot; SelectCountMethod=&quot;CountSelectAdvanced&quot; &gt;
&lt;/asp:ObjectDataSource&gt;</pre>
<div class="preview">
<pre class="js">&lt;SharePoint:SPGridView&nbsp;ID=<span class="js__string">&quot;_grid&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;AutoGenerateColumns=<span class="js__string">&quot;false&quot;</span>&nbsp;DataSourceID=<span class="js__string">&quot;_mainSource&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AllowFiltering=<span class="js__string">&quot;true&quot;</span>&nbsp;AllowSorting=<span class="js__string">&quot;true&quot;</span>&nbsp;AllowPaging=<span class="js__string">&quot;true&quot;</span>&nbsp;PageSize=<span class="js__string">&quot;3&quot;</span>&nbsp;FilterDataFields=<span class="js__string">&quot;Name,Influence,Gender,Comments&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FilteredDataSourcePropertyName=<span class="js__string">&quot;FilterExpression&quot;</span>&nbsp;FilteredDataSourcePropertyFormat=<span class="js__string">&quot;{1}&nbsp;LIKE&nbsp;'{0}'&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;Nombre&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Name&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Name&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;Influencia&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Influence&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Influence&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;G&eacute;nero&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Gender&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Gender&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="js__string">&quot;Comentarios&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:LinkButton&nbsp;ID=<span class="js__string">&quot;_link&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnClientClick=<span class="js__string">'&lt;%#&nbsp;&quot;javascript:openCommentsDialog(\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Name&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;,&nbsp;\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Comments&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;);&nbsp;return&nbsp;false;&quot;&nbsp;%&gt;'</span>&nbsp;Text=<span class="js__string">&quot;Comentarios&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerSettings&nbsp;Mode=<span class="js__string">&quot;NextPreviousFirstLast&quot;</span>&nbsp;Visible=<span class="js__string">&quot;true&quot;</span>&nbsp;NextPageText=<span class="js__string">&quot;Siguiente&nbsp;|&quot;</span>&nbsp;PreviousPageText=<span class="js__string">&quot;Anterior&nbsp;|&quot;</span>&nbsp;FirstPageText=<span class="js__string">&quot;Inicio&nbsp;|&quot;</span>&nbsp;LastPageText=<span class="js__string">&quot;Fin&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/SharePoint:SPGridView&gt;&nbsp;
&lt;asp:ObjectDataSource&nbsp;ID=<span class="js__string">&quot;_mainSource&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;EnablePaging=<span class="js__string">&quot;true&quot;</span>&nbsp;EnableCaching=<span class="js__string">&quot;true&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TypeName=<span class="js__string">&quot;Fermasmas.Labs.SPGridViewExample.Model.AsgardSource,&nbsp;$SharePoint.Project.AssemblyFullName$&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectMethod=<span class="js__string">&quot;SelectAdvanced&quot;</span>&nbsp;SelectCountMethod=<span class="js__string">&quot;CountSelectAdvanced&quot;</span>&nbsp;&gt;&nbsp;
&lt;/asp:ObjectDataSource&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Y he aqu&iacute; la imagen.</div>
<div><img src="24144-spgv5.png" alt="" width="647" height="354"></div>
<div>&nbsp;</div>
<div>Ya por &uacute;ltimo, comentar que hasta el momento todos los ejemplos han hecho uso del ObjectDataSource para hacer el enlazado de los datos (quiz&aacute;s quieras revisar la clase AsgardSource, pero ah&iacute; no hay m&aacute;s que abrir la lista y obtener
 el DataTable de los elementos). En este &uacute;ltimo ejemplo mostramos c&oacute;mo usar el SPGridView en conjunto con SPDataSource, un control que nos permite enlazar de manera f&aacute;cil contra listas y otros elementos de SharePoint. No hay imagen, porque
 la vista es similar a las anteriores, pero s&iacute; hay fragmento de c&oacute;digo a continuaci&oacute;n.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;SharePoint:SPGridView ID=&quot;_grid&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;false&quot; DataSourceID=&quot;_source&quot; &gt;
    &lt;Columns&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;Nombre&quot; DataField=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;Influencia&quot; DataField=&quot;Influence&quot; SortExpression=&quot;Influence&quot; /&gt;
        &lt;SharePoint:SPBoundField HeaderText=&quot;G&eacute;nero&quot; DataField=&quot;Gender&quot; SortExpression=&quot;Gender&quot; /&gt;
        &lt;asp:TemplateField HeaderText=&quot;Comentarios&quot;&gt;
            &lt;ItemTemplate&gt;
                &lt;asp:LinkButton ID=&quot;_link&quot; runat=&quot;server&quot; 
                    OnClientClick='&lt;%# &quot;javascript:openCommentsDialog(\&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Name&quot;) as string) &#43; &quot;\&quot;, \&quot;&quot; &#43; SPEncode.HtmlEncode(Eval(&quot;Comments&quot;) as string) &#43; &quot;\&quot;); return false;&quot; %&gt;' Text=&quot;Comentarios&quot; /&gt;
            &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
    &lt;/Columns&gt;
    &lt;PagerSettings Mode=&quot;NextPreviousFirstLast&quot; Visible=&quot;true&quot; NextPageText=&quot;Siguiente |&quot; PreviousPageText=&quot;Anterior |&quot; FirstPageText=&quot;Inicio |&quot; LastPageText=&quot;Fin&quot; /&gt;
&lt;/SharePoint:SPGridView&gt;

&lt;SharePoint:SPDataSource ID=&quot;_source&quot; runat=&quot;server&quot; DataSourceMode=&quot;List&quot; SelectCommand=&quot;&lt;View&gt;&lt;/View&gt;&quot; UseInternalName=&quot;true&quot;&gt;
    &lt;SelectParameters&gt;
        &lt;asp:Parameter Name=&quot;WebUrl&quot; DefaultValue=&quot;/asgard/&quot; /&gt;
    &lt;asp:Parameter Name=&quot;ListName&quot; DefaultValue=&quot;Asgard List&quot; /&gt;
    &lt;/SelectParameters&gt;
&lt;/SharePoint:SPDataSource&gt;</pre>
<div class="preview">
<pre class="js">&lt;SharePoint:SPGridView&nbsp;ID=<span class="js__string">&quot;_grid&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;AutoGenerateColumns=<span class="js__string">&quot;false&quot;</span>&nbsp;DataSourceID=<span class="js__string">&quot;_source&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;Nombre&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Name&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Name&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;Influencia&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Influence&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Influence&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SharePoint:SPBoundField&nbsp;HeaderText=<span class="js__string">&quot;G&eacute;nero&quot;</span>&nbsp;DataField=<span class="js__string">&quot;Gender&quot;</span>&nbsp;SortExpression=<span class="js__string">&quot;Gender&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="js__string">&quot;Comentarios&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:LinkButton&nbsp;ID=<span class="js__string">&quot;_link&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnClientClick=<span class="js__string">'&lt;%#&nbsp;&quot;javascript:openCommentsDialog(\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Name&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;,&nbsp;\&quot;&quot;&nbsp;&#43;&nbsp;SPEncode.HtmlEncode(Eval(&quot;Comments&quot;)&nbsp;as&nbsp;string)&nbsp;&#43;&nbsp;&quot;\&quot;);&nbsp;return&nbsp;false;&quot;&nbsp;%&gt;'</span>&nbsp;Text=<span class="js__string">&quot;Comentarios&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerSettings&nbsp;Mode=<span class="js__string">&quot;NextPreviousFirstLast&quot;</span>&nbsp;Visible=<span class="js__string">&quot;true&quot;</span>&nbsp;NextPageText=<span class="js__string">&quot;Siguiente&nbsp;|&quot;</span>&nbsp;PreviousPageText=<span class="js__string">&quot;Anterior&nbsp;|&quot;</span>&nbsp;FirstPageText=<span class="js__string">&quot;Inicio&nbsp;|&quot;</span>&nbsp;LastPageText=<span class="js__string">&quot;Fin&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/SharePoint:SPGridView&gt;&nbsp;
&nbsp;
&lt;SharePoint:SPDataSource&nbsp;ID=<span class="js__string">&quot;_source&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&nbsp;DataSourceMode=<span class="js__string">&quot;List&quot;</span>&nbsp;SelectCommand=<span class="js__string">&quot;&lt;View&gt;&lt;/View&gt;&quot;</span>&nbsp;UseInternalName=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;SelectParameters&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Parameter&nbsp;Name=<span class="js__string">&quot;WebUrl&quot;</span>&nbsp;DefaultValue=<span class="js__string">&quot;/asgard/&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Parameter&nbsp;Name=<span class="js__string">&quot;ListName&quot;</span>&nbsp;DefaultValue=<span class="js__string">&quot;Asgard&nbsp;List&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/SelectParameters&gt;&nbsp;
&lt;/SharePoint:SPDataSource&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Y eso es todo por el momento. No dudes en comentar y hacer preguntas, si surge alguna duda.</div>
<h1><span>C&oacute;digo fuente</span></h1>
<ul>
</ul>
<p><em>Hay bastantitos archivos, como cabr&iacute;a esperar en una soluci&oacute;n para SharePoint. Veamos algunos de los importantes.
</em></p>
<ul>
<li><em>AsgardContentType\Elements.xml - define el tipo de contenido para la lista que usamos como fuente de datos.
</em></li><li><em>AsgardList\Elements.xml - define la lista que usamos como fuente de datos.
</em></li><li><em>AsgardList\Schema.xml - define la vista de la lista y su asociaci&oacute;n con el content-type del primer punto.
</em></li><li><em>AsgardList\ListInstance1\Elements.xml - define una instancia de la lista definida en el punto anterior y a&ntilde;ade informaci&oacute;n pre-cargada.
</em></li><li><em>AsgardPagesLibrary\Elements.xml - define una biblioteca de documentos donde podemos guardar p&aacute;ginas web. Aqu&iacute; estar&aacute; contenida la p&aacute;gina de WebParts donde se muestra el ejemplo 1.
</em></li><li><em>GridViewWebPart\Elements.xml - define un WebPart a utilizar en el ejemplo 1.
</em></li><li><em>GridViewWebPart\GridViewWebPart.webpart - declara las propiedades iniciales del WebPart del punto anterior.
</em></li><li><em>GridViewWebPart\GridViewWebPart.cs - el c&oacute;digo C# del WebPart. </em>
</li><li><em>Layouts\Fermasmas.Labs.SPGridViewExample\GridPageFilterSortExample.aspx y GridPageFilterSortExample.cs&nbsp; - p&aacute;gina ASPX con su archivo de c&oacute;digo para el ejemplo 4.
</em></li><li><em>Layouts\Fermasmas.Labs.SPGridViewExample\GridPageSimpleExample.aspx y GridPageSimpleExample.cs&nbsp; - p&aacute;gina ASPX con su archivo de c&oacute;digo para el ejemplo 2.</em>
</li><li><em>Layouts\Fermasmas.Labs.SPGridViewExample\GridPageWithDataSource.aspx y GridPageWithDataSource.cs&nbsp; - p&aacute;gina ASPX con su archivo de c&oacute;digo para el ejemplo 5.</em>
</li><li><em>Layouts\Fermasmas.Labs.SPGridViewExample\GridPageWithEbcExample.aspx y GridPageWithEbcExample.cs&nbsp; - p&aacute;gina ASPX con su archivo de c&oacute;digo para el ejemplo 3.</em>
</li><li><em>Layouts\Fermasmas.Labs.SPGridViewExample\ViewComments.aspx y ViewComments.cs - p&aacute;gina que muestra un comentario pasado por par&aacute;metro de p&aacute;gina.
</em></li><li><em>Model\AsgardSource.cs - archivo C# que contiene una clase usada en los ObjectDataSource de diversos ejemplos.
</em></li><li><em>Pages\AsgardWebPartPage.aspx - define una p&aacute;gina de WebParts y carga de forma predeterminada el WebPart del ejemplo 1.
</em></li><li><em>Pages\Elements.xml - define un m&oacute;dulo, el cual contiene la p&aacute;gina de WebParts del punto anterior.
</em></li><li><em>SiteActionMenu\Elements.xml - define los elementos a&ntilde;adidos al bot&oacute;n Acciones del Sitio, lo cual mejora la navegaci&oacute;n.
</em></li></ul>
<h1>M&aacute;s informaci&oacute;n</h1>
<div><em>Para mayor informaci&oacute;n, revisa estos enlaces:</em></div>
<div><em><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spgridview.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spgridview.aspx</a>&nbsp;</em></div>
<div><em><a href="http://msdn.microsoft.com/en-us/library/bb466219.aspx">http://msdn.microsoft.com/en-us/library/bb466219.aspx</a></em></div>
