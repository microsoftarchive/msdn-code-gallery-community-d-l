# Expandable and Collapsible Grid using WebGrid and MVC4 Razor
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Razor
- ASP.NET MVC 4
## Topics
- collapsible grid
## Updated
- 07/06/2013
## Description

<h1>Expandable Grid</h1>
<p><em>It shows data in expendable form. I have used nested webgrid to toggle details data. in case if javascript is disabled this will work smoothly and also cross browsers.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>In my project I had to show details data like expendable and collapsable form. earlier approch was using jquery but there was a lot of issue of formatting among different browser. IE7 was not supported. I thought to create grid using webgrid.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">this will expand grid at <strong>2 levels</strong>.</span><span style="font-size:20px; font-weight:bold"><br>
</span></p>
<p><em>This </em>collapsible grid will show details data. user can toggle data between group data. I have used webgrid. for expendable section I had to use nested webgrid. you can apply css to make this grid customized as per your requirements. Technologies
 which have been used: MVC4, Razor,C#. I load all the data one time and then toggle using css and jquery.</p>
<pre>@{  
    <span style="color:blue">var</span> db = Database.Open(<span style="color:#a31515">&quot;SmallBakery&quot;</span>); 
    <span style="color:blue">var</span> selectQueryString = <span style="color:#a31515">&quot;SELECT * FROM Product ORDER BY Id&quot;</span>; 
    <span style="color:blue">var</span> data = db.Query(selectQueryString); 
    <span style="color:blue">var</span> grid = <span style="color:blue">new</span> WebGrid(source: data, 
                           defaultSort: <span style="color:#a31515">&quot;Name&quot;</span>,  
                           rowsPerPage: 3); 
    grid.SortDirection = SortDirection.Ascending;
}
&lt;!DOCTYPE html&gt; 
&lt;html&gt; 
    &lt;head&gt; 
        &lt;title&gt;Displaying Data Using the WebGrid Helper (with Paging)&lt;/title&gt; 
        &lt;style type=<span style="color:#a31515">&quot;text/css&quot;</span>&gt; 
            .grid { margin: 4px; border-collapse: collapse; width: 600px; } 
            .head { background-color: #E8E8E8; font-weight: bold; color: #FFF; } 
            .grid th, .grid td { border: 1px solid #C0C0C0; padding: 5px; } 
            .alt { background-color: #E8E8E8; color: #000; } 
            .product { width: 200px; font-weight:bold;} 
        &lt;/style&gt; 
    &lt;/head&gt; 
    &lt;body&gt; 
        &lt;h1&gt;Small Bakery Products&lt;/h1&gt; 
        &lt;div id=<span style="color:#a31515">&quot;grid&quot;</span>&gt; 
            @grid.GetHtml( 
                tableStyle: <span style="color:#a31515">&quot;grid&quot;</span>, 
                headerStyle: <span style="color:#a31515">&quot;head&quot;</span>, 
                alternatingRowStyle: <span style="color:#a31515">&quot;alt&quot;</span>, 
                columns: grid.Columns( 
                    grid.Column(<span style="color:#a31515">&quot;Name&quot;</span>, <span style="color:#a31515">&quot;Product&quot;</span>, style: <span style="color:#a31515">&quot;product&quot;</span>), 
                    grid.Column(<span style="color:#a31515">&quot;Description&quot;</span>, format:@&lt;i&gt;@item.Description&lt;/i&gt;), 
                    grid.Column(<span style="color:#a31515">&quot;Price&quot;</span>, format:@&lt;text&gt;$@item.Price&lt;/text&gt;) 
                ) 
            ) 
        &lt;/div&gt; 
    &lt;/body&gt; 
&lt;/html&gt;</pre>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">-- View Code--------

&lt;script language=&quot;javascript&quot;&gt;
    function detailSection(id,count) {
        for (i = 1; i &lt;= count; i&#43;&#43;) {
            if ($('#details1' &#43; id &#43; '_' &#43; (2 * i - 1)).is(':visible')) {
                $('#details1' &#43; id &#43; '_' &#43; (2 * i - 1)).css('display', 'none');
                $('#details2' &#43; id &#43; '_' &#43; (2 * i)).css('display', 'none');
                //            $('#details1' &#43; id&#43;'_3').css('display', 'none');
                //            $('#details2' &#43; id&#43;'_4').css('display', 'none');
            } else {
                $('#details1' &#43; id &#43; '_' &#43; (2 * i - 1)).css('display', 'block');
                $('#details2' &#43; id &#43; '_' &#43; (2 * i)).css('display', 'block');
                // $('#details1' &#43; id&#43;'_3').css('display', 'block');
                //$('#details2' &#43; id&#43;'_4').css('display', 'block');
            }
        }
    }
    function detailSection1(id, count) {
        for (i = 1; i &lt;= count; i&#43;&#43;) {
            if ($('#details3' &#43; id &#43; '_' &#43; ( i )).is(':visible')) {
                $('#details3' &#43; id &#43; '_' &#43; ( i)).css('display', 'none');
                $('#details4' &#43; id &#43; '_' &#43; (i&#43;1)).css('display', 'none');
                $('#details5' &#43; id &#43; '_' &#43; (i&#43;2)).css('display', 'none');
                //            $('#details1' &#43; id&#43;'_3').css('display', 'none');
                //            $('#details2' &#43; id&#43;'_4').css('display', 'none');
            } else {
                $('#details3' &#43; id &#43; '_' &#43; ( i )).css('display', 'block');
                $('#details4' &#43; id &#43; '_' &#43; (i&#43;1)).css('display', 'block');
                $('#details5' &#43; id &#43; '_' &#43; ( i&#43;2)).css('display', 'block');
                // $('#details1' &#43; id&#43;'_3').css('display', 'block');
                //$('#details2' &#43; id&#43;'_4').css('display', 'block');
            }
        }
    }
&lt;/script&gt;
@model IEnumerable&lt;ExpendableWebGrid.Models.Order&gt;
@{
    ViewBag.Title = &quot;NestedGrid&quot;;
}
@{
    var Orders = new List&lt;ExpendableWebGrid.Models.Order&gt;();
    var products1 = new List&lt;ExpendableWebGrid.Models.Product&gt;();
    var productsDetails1 = new List&lt;ExpendableWebGrid.Models.ProductDetails&gt;();
    productsDetails1.Add(new ExpendableWebGrid.Models.ProductDetails { ProductDetailsId = 1, Cost = &quot;$ 345&quot;, Color=&quot;Black&quot; });
    products1.Add(new ExpendableWebGrid.Models.Product { ProductId = 1,  ProductDetailsList=productsDetails1,Name = &quot;laptop&quot; });
    products1.Add(new ExpendableWebGrid.Models.Product { ProductId = 5, ProductDetailsList = productsDetails1, Name = &quot;pen drive&quot; });
    products1.Add(new ExpendableWebGrid.Models.Product { ProductId = 7, ProductDetailsList = productsDetails1, Name = &quot;Mobile&quot; });
    Orders.Add(new ExpendableWebGrid.Models.Order { OrderId = 1, ProductList = products1, OrderDate = DateTime.Now });
    var products2 = new List&lt;ExpendableWebGrid.Models.Product&gt;();
    products2.Add(new ExpendableWebGrid.Models.Product { ProductId = 3, ProductDetailsList = productsDetails1, Name = &quot;Hard disk&quot; });
    products2.Add(new ExpendableWebGrid.Models.Product { ProductId = 4, ProductDetailsList = productsDetails1, Name = &quot;Mouse&quot; });
    Orders.Add(new ExpendableWebGrid.Models.Order { OrderId = 2, ProductList = products2, OrderDate = DateTime.Now });
    var products3 = new List&lt;ExpendableWebGrid.Models.Product&gt;();
    products3.Add(new ExpendableWebGrid.Models.Product { ProductId = 2, ProductDetailsList = productsDetails1, Name = &quot;CD&quot; });
    products3.Add(new ExpendableWebGrid.Models.Product { ProductId = 6, ProductDetailsList = productsDetails1, Name = &quot;Speaker&quot; });
    Orders.Add(new ExpendableWebGrid.Models.Order { OrderId = 3, ProductList = products3, OrderDate = DateTime.Now });
    
    
        WebGrid topGrid = new WebGrid(Orders);
        
}

&lt;!DOCTYPE html&gt;

&lt;html&gt;
&lt;head&gt;
    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width&quot; /&gt;
    &lt;title&gt;&lt;/title&gt;
&lt;/head&gt;
&lt;body&gt;
   
                                                                                                                                       
 
     &lt;div id=&quot;grid&quot;&gt;
@topGrid.GetHtml(columns:
    topGrid.Columns(
                                topGrid.Column(&quot;OrderId&quot;, &quot;Order&quot;, format: (item) =&gt; { return new HtmlString(&quot;&lt;a href='#' onclick='detailSection(&quot;&#43; item.WebGrid.Rows.IndexOf(item)&#43;&quot;,&quot;&#43;item.WebGrid.Rows.Count&#43;&quot;)' style='width: 10em'&gt;&quot; &#43; item.OrderId &#43; &quot;&lt;/a&gt;&quot;); }),
            topGrid.Column(&quot;ProductList&quot;, format: (item1) =&gt;
        {
           
            WebGrid subGrid = new WebGrid(item1.ProductList);
            var pIndex = item1.WebGrid.Rows.IndexOf(item1);
            var counter = 0;
            return subGrid.GetHtml( 
         columns: subGrid.Columns(
             subGrid.Column(&quot;ProductId&quot;, &quot;ProductId&quot;, format: (subitem) =&gt; { return new HtmlString(&quot;&lt;a href='#' id='details1&quot; &#43; pIndex &#43; &quot;_&quot; &#43; &#43;&#43;counter &#43; &quot;' onclick='detailSection1(&quot; &#43; subitem.WebGrid.Rows.IndexOf(subitem) &#43; &quot;,&quot; &#43; subitem.WebGrid.Rows.Count &#43; &quot;)'style='text-align: left;color: red;height:120px; width: 175px; padding-right: 1em; display:none;'&gt;&quot; &#43; subitem.ProductId &#43; &quot;&lt;/a&gt;&quot;); }),
             subGrid.Column(&quot;Name&quot;, &quot;Name&quot;, format: (subitem) =&gt; { return new HtmlString(&quot;&lt;div id='details2&quot;&#43;pIndex&#43; &quot;_&quot;&#43; &#43;&#43;counter&#43;&quot;' style='text-align: left;color: red;height:120px; width: 175px; padding-right: 1em; display:none;'&gt;&quot; &#43; subitem.Name &#43; &quot;&lt;/div&gt;&quot;); }),
              topGrid.Column(&quot;ProductDetailsList&quot;, format: (item2) =&gt;
        {

            WebGrid subGrid1 = new WebGrid(item2.ProductDetailsList);
            var pIndex1 = item2.WebGrid.Rows.IndexOf(item2);
            var counter1 = 0;
            return subGrid1.GetHtml(
         columns: subGrid1.Columns(
             subGrid1.Column(&quot;ProductDetailsId&quot;, &quot;ProductDetailsId&quot;, format: (subitem1) =&gt; { return new HtmlString(&quot;&lt;div id='details3&quot; &#43; pIndex1 &#43; &quot;_&quot; &#43; &#43;&#43;counter1 &#43; &quot;' style='text-align: left;color: red;height:120px; width: 175px; padding-right: 1em; display:none;'&gt;&quot; &#43; subitem1.ProductDetailsId &#43; &quot;&lt;/div&gt;&quot;); }),
             subGrid1.Column(&quot;Cost&quot;, &quot;Cost&quot;, format: (subitem1) =&gt; { return new HtmlString(&quot;&lt;div id='details4&quot; &#43; pIndex1 &#43; &quot;_&quot; &#43; &#43;&#43;counter1 &#43; &quot;' style='text-align: left;color: red;height:120px; width: 175px; padding-right: 1em; display:none;'&gt;&quot; &#43; subitem1.Cost &#43; &quot;&lt;/div&gt;&quot;); }),
             subGrid1.Column(&quot;Color&quot;, &quot;Color&quot;, format: (subitem1) =&gt; { return new HtmlString(&quot;&lt;div id='details5&quot; &#43; pIndex1 &#43; &quot;_&quot; &#43; &#43;&#43;counter1 &#43; &quot;' style='text-align: left;color: red;height:120px; width: 175px; padding-right: 1em; display:none;'&gt;&quot; &#43; subitem1.Color &#43; &quot;&lt;/div&gt;&quot;); })


        ));
        }
            )));
        })
        
        
         ,topGrid.Column(&quot;OrderDate&quot;)
    
))
&lt;/div&gt; 

&lt;/body&gt;
&lt;/html&gt;

-- Model code------
 public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public List&lt;Product&gt; ProductList { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public List&lt;ProductDetails&gt; ProductDetailsList { get; set; }
    }
    public class ProductDetails
    {
        public int ProductDetailsId { get; set; }
        public string Cost { get; set; }
        public string Color { get; set; }
        
    }</pre>
<div class="preview">
<pre class="csharp">--&nbsp;View&nbsp;Code--------&nbsp;
&nbsp;
&lt;script&nbsp;language=<span class="cs__string">&quot;javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;function&nbsp;detailSection(id,count)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;count;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;($(<span class="cs__string">'#details1'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(<span class="cs__number">2</span>&nbsp;*&nbsp;i&nbsp;-&nbsp;<span class="cs__number">1</span>)).<span class="cs__keyword">is</span>(<span class="cs__string">':visible'</span>))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details1'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(<span class="cs__number">2</span>&nbsp;*&nbsp;i&nbsp;-&nbsp;<span class="cs__number">1</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'none'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details2'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(<span class="cs__number">2</span>&nbsp;*&nbsp;i)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'none'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$('#details1'&nbsp;&#43;&nbsp;id&#43;'_3').css('display',&nbsp;'none');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$('#details2'&nbsp;&#43;&nbsp;id&#43;'_4').css('display',&nbsp;'none');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">else</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details1'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(<span class="cs__number">2</span>&nbsp;*&nbsp;i&nbsp;-&nbsp;<span class="cs__number">1</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'block'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details2'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(<span class="cs__number">2</span>&nbsp;*&nbsp;i)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'block'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;$('#details1'&nbsp;&#43;&nbsp;id&#43;'_3').css('display',&nbsp;'block');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//$('#details2'&nbsp;&#43;&nbsp;id&#43;'_4').css('display',&nbsp;'block');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;function&nbsp;detailSection1(id,&nbsp;count)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;count;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;($(<span class="cs__string">'#details3'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(&nbsp;i&nbsp;)).<span class="cs__keyword">is</span>(<span class="cs__string">':visible'</span>))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details3'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(&nbsp;i)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'none'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details4'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(i<span class="cs__number">&#43;1</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'none'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details5'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(i<span class="cs__number">&#43;2</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'none'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$('#details1'&nbsp;&#43;&nbsp;id&#43;'_3').css('display',&nbsp;'none');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$('#details2'&nbsp;&#43;&nbsp;id&#43;'_4').css('display',&nbsp;'none');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">else</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details3'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(&nbsp;i&nbsp;)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'block'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details4'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(i<span class="cs__number">&#43;1</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'block'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#details5'</span>&nbsp;&#43;&nbsp;id&nbsp;&#43;&nbsp;<span class="cs__string">'_'</span>&nbsp;&#43;&nbsp;(&nbsp;i<span class="cs__number">&#43;2</span>)).css(<span class="cs__string">'display'</span>,&nbsp;<span class="cs__string">'block'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;$('#details1'&nbsp;&#43;&nbsp;id&#43;'_3').css('display',&nbsp;'block');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//$('#details2'&nbsp;&#43;&nbsp;id&#43;'_4').css('display',&nbsp;'block');</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&lt;/script&gt;&nbsp;
@model&nbsp;IEnumerable&lt;ExpendableWebGrid.Models.Order&gt;&nbsp;
@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="cs__string">&quot;NestedGrid&quot;</span>;&nbsp;
}&nbsp;
@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Orders&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ExpendableWebGrid.Models.Order&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;products1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ExpendableWebGrid.Models.Product&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;productsDetails1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ExpendableWebGrid.Models.ProductDetails&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;productsDetails1.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.ProductDetails&nbsp;{&nbsp;ProductDetailsId&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;Cost&nbsp;=&nbsp;<span class="cs__string">&quot;$&nbsp;345&quot;</span>,&nbsp;Color=<span class="cs__string">&quot;Black&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products1.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;ProductDetailsList=productsDetails1,Name&nbsp;=&nbsp;<span class="cs__string">&quot;laptop&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products1.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">5</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;pen&nbsp;drive&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products1.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">7</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Mobile&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Orders.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Order&nbsp;{&nbsp;OrderId&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;ProductList&nbsp;=&nbsp;products1,&nbsp;OrderDate&nbsp;=&nbsp;DateTime.Now&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;products2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ExpendableWebGrid.Models.Product&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products2.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">3</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Hard&nbsp;disk&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products2.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">4</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Mouse&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Orders.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Order&nbsp;{&nbsp;OrderId&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;ProductList&nbsp;=&nbsp;products2,&nbsp;OrderDate&nbsp;=&nbsp;DateTime.Now&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;products3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ExpendableWebGrid.Models.Product&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products3.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;CD&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;products3.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Product&nbsp;{&nbsp;ProductId&nbsp;=&nbsp;<span class="cs__number">6</span>,&nbsp;ProductDetailsList&nbsp;=&nbsp;productsDetails1,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Speaker&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Orders.Add(<span class="cs__keyword">new</span>&nbsp;ExpendableWebGrid.Models.Order&nbsp;{&nbsp;OrderId&nbsp;=&nbsp;<span class="cs__number">3</span>,&nbsp;ProductList&nbsp;=&nbsp;products3,&nbsp;OrderDate&nbsp;=&nbsp;DateTime.Now&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebGrid&nbsp;topGrid&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebGrid(Orders);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;name=<span class="cs__string">&quot;viewport&quot;</span>&nbsp;content=<span class="cs__string">&quot;width=device-width&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;&lt;/title&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;grid&quot;</span>&gt;&nbsp;
@topGrid.GetHtml(columns:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;topGrid.Columns(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;topGrid.Column(<span class="cs__string">&quot;OrderId&quot;</span>,&nbsp;<span class="cs__string">&quot;Order&quot;</span>,&nbsp;format:&nbsp;(item)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;a&nbsp;href='#'&nbsp;onclick='detailSection(&quot;</span>&#43;&nbsp;item.WebGrid.Rows.IndexOf(item)&#43;<span class="cs__string">&quot;,&quot;</span>&#43;item.WebGrid.Rows.Count&#43;<span class="cs__string">&quot;)'&nbsp;style='width:&nbsp;10em'&gt;&quot;</span>&nbsp;&#43;&nbsp;item.OrderId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/a&gt;&quot;</span>);&nbsp;}),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;topGrid.Column(<span class="cs__string">&quot;ProductList&quot;</span>,&nbsp;format:&nbsp;(item1)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebGrid&nbsp;subGrid&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebGrid(item1.ProductList);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pIndex&nbsp;=&nbsp;item1.WebGrid.Rows.IndexOf(item1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;counter&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;subGrid.GetHtml(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;subGrid.Columns(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subGrid.Column(<span class="cs__string">&quot;ProductId&quot;</span>,&nbsp;<span class="cs__string">&quot;ProductId&quot;</span>,&nbsp;format:&nbsp;(subitem)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;a&nbsp;href='#'&nbsp;id='details1&quot;</span>&nbsp;&#43;&nbsp;pIndex&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;counter&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&nbsp;onclick='detailSection1(&quot;</span>&nbsp;&#43;&nbsp;subitem.WebGrid.Rows.IndexOf(subitem)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;,&quot;</span>&nbsp;&#43;&nbsp;subitem.WebGrid.Rows.Count&nbsp;&#43;&nbsp;<span class="cs__string">&quot;)'style='text-align:&nbsp;left;color:&nbsp;red;height:120px;&nbsp;width:&nbsp;175px;&nbsp;padding-right:&nbsp;1em;&nbsp;display:none;'&gt;&quot;</span>&nbsp;&#43;&nbsp;subitem.ProductId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/a&gt;&quot;</span>);&nbsp;}),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subGrid.Column(<span class="cs__string">&quot;Name&quot;</span>,&nbsp;<span class="cs__string">&quot;Name&quot;</span>,&nbsp;format:&nbsp;(subitem)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;div&nbsp;id='details2&quot;</span>&#43;pIndex&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>&#43;&nbsp;&#43;&#43;counter&#43;<span class="cs__string">&quot;'&nbsp;style='text-align:&nbsp;left;color:&nbsp;red;height:120px;&nbsp;width:&nbsp;175px;&nbsp;padding-right:&nbsp;1em;&nbsp;display:none;'&gt;&quot;</span>&nbsp;&#43;&nbsp;subitem.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/div&gt;&quot;</span>);&nbsp;}),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;topGrid.Column(<span class="cs__string">&quot;ProductDetailsList&quot;</span>,&nbsp;format:&nbsp;(item2)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebGrid&nbsp;subGrid1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebGrid(item2.ProductDetailsList);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pIndex1&nbsp;=&nbsp;item2.WebGrid.Rows.IndexOf(item2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;counter1&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;subGrid1.GetHtml(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;subGrid1.Columns(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subGrid1.Column(<span class="cs__string">&quot;ProductDetailsId&quot;</span>,&nbsp;<span class="cs__string">&quot;ProductDetailsId&quot;</span>,&nbsp;format:&nbsp;(subitem1)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;div&nbsp;id='details3&quot;</span>&nbsp;&#43;&nbsp;pIndex1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;counter1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&nbsp;style='text-align:&nbsp;left;color:&nbsp;red;height:120px;&nbsp;width:&nbsp;175px;&nbsp;padding-right:&nbsp;1em;&nbsp;display:none;'&gt;&quot;</span>&nbsp;&#43;&nbsp;subitem1.ProductDetailsId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/div&gt;&quot;</span>);&nbsp;}),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subGrid1.Column(<span class="cs__string">&quot;Cost&quot;</span>,&nbsp;<span class="cs__string">&quot;Cost&quot;</span>,&nbsp;format:&nbsp;(subitem1)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;div&nbsp;id='details4&quot;</span>&nbsp;&#43;&nbsp;pIndex1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;counter1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&nbsp;style='text-align:&nbsp;left;color:&nbsp;red;height:120px;&nbsp;width:&nbsp;175px;&nbsp;padding-right:&nbsp;1em;&nbsp;display:none;'&gt;&quot;</span>&nbsp;&#43;&nbsp;subitem1.Cost&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/div&gt;&quot;</span>);&nbsp;}),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subGrid1.Column(<span class="cs__string">&quot;Color&quot;</span>,&nbsp;<span class="cs__string">&quot;Color&quot;</span>,&nbsp;format:&nbsp;(subitem1)&nbsp;=&gt;&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlString(<span class="cs__string">&quot;&lt;div&nbsp;id='details5&quot;</span>&nbsp;&#43;&nbsp;pIndex1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;counter1&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&nbsp;style='text-align:&nbsp;left;color:&nbsp;red;height:120px;&nbsp;width:&nbsp;175px;&nbsp;padding-right:&nbsp;1em;&nbsp;display:none;'&gt;&quot;</span>&nbsp;&#43;&nbsp;subitem1.Color&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;/div&gt;&quot;</span>);&nbsp;})&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,topGrid.Column(<span class="cs__string">&quot;OrderDate&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
))&nbsp;
&lt;/div&gt;&nbsp;&nbsp;
&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;&nbsp;
&nbsp;
--&nbsp;Model&nbsp;code------&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Order&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;OrderId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;OrderDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;Product&gt;&nbsp;ProductList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Product&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ProductId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;OrderId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;ProductDetails&gt;&nbsp;ProductDetailsList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ProductDetails&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ProductDetailsId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Cost&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Color&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
