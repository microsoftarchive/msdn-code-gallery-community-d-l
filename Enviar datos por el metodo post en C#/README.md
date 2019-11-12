# Enviar datos por el metodo post en C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- XML
## Topics
- XML
- Methods
## Updated
- 07/06/2012
## Description

<h3 class="post-title x_entry-title">Enviar datos por el metodo post en C#</h3>
<div class="post-header">
<div class="post-header-line-1"></div>
</div>
<div class="post-body x_entry-content" id="post-body-2305316850139679765"><span>En este tutorial veremos como enviar datos por el&nbsp;m&eacute;todo&nbsp;POST &nbsp;en C#, en este caso crearemos una&nbsp;aplicaci&oacute;n&nbsp;que lea un archivo xml y lo&nbsp;env&iacute;e&nbsp;a
 la pagina recive.aspx por el&nbsp;m&eacute;todo&nbsp;POST. Luego lo que recibimos por este&nbsp;m&eacute;todo&nbsp;lo guardamos en el objeto&nbsp;Application, para luego poder imprimirlo en la pagina recive.aspx.</span><br>
<br>
<span>Este es el&nbsp;c&oacute;digo&nbsp;fuente comentado de la pagina default.aspx:</span><br>
<br>
<span class="pun">
<pre class="prettyprint prettyprinted"><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Collections</span><span class="pun">.</span><span class="typ">Generic</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Linq</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">.</span><span class="typ">WebControls</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Net</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="pln">IO</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Text</span><span class="pun">;</span><span class="pln">

</span><span class="kwd">namespace</span><span class="pln"> </span><span class="typ">PostXML</span><span class="pln">
</span><span class="pun">{</span><span class="pln">
    </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">partial</span><span class="pln"> </span><span class="kwd">class</span><span class="pln"> </span><span class="typ">WebForm1</span><span class="pln"> </span><span class="pun">:</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">.</span><span class="typ">Page</span><span class="pln">
    </span><span class="pun">{</span><span class="pln">
        </span><span class="kwd">protected</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> </span><span class="typ">Page_Load</span><span class="pun">(</span><span class="kwd">object</span><span class="pln"> sender</span><span class="pun">,</span><span class="pln"> </span><span class="typ">EventArgs</span><span class="pln"> e</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">

        </span><span class="pun">}</span><span class="pln">

        </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> </span><span class="typ">PostXML</span><span class="pun">(</span><span class="kwd">string</span><span class="pln"> fileName</span><span class="pun">,</span><span class="pln"> </span><span class="kwd">string</span><span class="pln"> uri</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
           </span><span class="com">// Creamos un request usando una url que resibira el post. </span><span class="pln">
            </span><span class="typ">WebRequest</span><span class="pln"> request </span><span class="pun">=</span><span class="pln"> </span><span class="typ">WebRequest</span><span class="pun">.</span><span class="typ">Create</span><span class="pun">(</span><span class="pln">uri</span><span class="pun">);</span><span class="pln">
            </span><span class="com">// Seteamos la propiedad Method del request a POST.</span><span class="pln">
            request</span><span class="pun">.</span><span class="typ">Method</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> </span><span class="str">&quot;POST&quot;</span><span class="pun">;</span><span class="pln">
            </span><span class="com">// Creamos lo que se va a enviar por el metodo POST y lo convertimos a byte array.</span><span class="pln">
            </span><span class="kwd">string</span><span class="pln"> postData </span><span class="pun">=</span><span class="pln"> </span><span class="kwd">this</span><span class="pun">.</span><span class="typ">GetTextFromXMLFile</span><span class="pun">(</span><span class="pln">fileName</span><span class="pun">);</span><span class="pln">
            </span><span class="kwd">byte</span><span class="pun">[]</span><span class="pln"> byteArray </span><span class="pun">=</span><span class="pln"> </span><span class="typ">Encoding</span><span class="pun">.</span><span class="pln">UTF8</span><span class="pun">.</span><span class="typ">GetBytes</span><span class="pun">(</span><span class="pln">postData</span><span class="pun">);</span><span class="pln">
            </span><span class="com">// Seteamos el ContentType del WebRequest a xml.</span><span class="pln">
            request</span><span class="pun">.</span><span class="typ">ContentType</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> </span><span class="str">&quot;text/xml&quot;</span><span class="pun">;</span><span class="pln">
            </span><span class="com">// Seteamos el ContentLength del WebRequest.</span><span class="pln">
            request</span><span class="pun">.</span><span class="typ">ContentLength</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> byteArray</span><span class="pun">.</span><span class="typ">Length</span><span class="pun">;</span><span class="pln">
            </span><span class="com">// Obtenemos el request stream.</span><span class="pln">
            </span><span class="typ">Stream</span><span class="pln"> dataStream </span><span class="pun">=</span><span class="pln"> request</span><span class="pun">.</span><span class="typ">GetRequestStream</span><span class="pun">();</span><span class="pln">
            </span><span class="com">// escribimos la data en el request stream.</span><span class="pln">
            dataStream</span><span class="pun">.</span><span class="typ">Write</span><span class="pun">(</span><span class="pln">byteArray</span><span class="pun">,</span><span class="pln"> </span><span class="lit">0</span><span class="pun">,</span><span class="pln"> byteArray</span><span class="pun">.</span><span class="typ">Length</span><span class="pun">);</span><span class="pln">
            </span><span class="com">// Cerramos el Stream object.</span><span class="pln">
            dataStream</span><span class="pun">.</span><span class="typ">Close</span><span class="pun">();</span><span class="pln">
           
        </span><span class="pun">}</span><span class="pln">

        </span><span class="kwd">private</span><span class="pln"> </span><span class="kwd">string</span><span class="pln"> </span><span class="typ">GetTextFromXMLFile</span><span class="pun">(</span><span class="kwd">string</span><span class="pln"> file</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
            </span><span class="typ">StreamReader</span><span class="pln"> reader </span><span class="pun">=</span><span class="pln"> </span><span class="kwd">new</span><span class="pln"> </span><span class="typ">StreamReader</span><span class="pun">(</span><span class="pln">file</span><span class="pun">);</span><span class="pln">
            </span><span class="kwd">string</span><span class="pln"> ret </span><span class="pun">=</span><span class="pln"> reader</span><span class="pun">.</span><span class="typ">ReadToEnd</span><span class="pun">();</span><span class="pln">
            reader</span><span class="pun">.</span><span class="typ">Close</span><span class="pun">();</span><span class="pln">
            </span><span class="kwd">return</span><span class="pln"> ret</span><span class="pun">;</span><span class="pln">
        </span><span class="pun">}</span><span class="pln">

        </span><span class="kwd">protected</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> boton1_Click</span><span class="pun">(</span><span class="kwd">object</span><span class="pln"> sender</span><span class="pun">,</span><span class="pln"> </span><span class="typ">EventArgs</span><span class="pln"> e</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
            </span><span class="typ">PostXML</span><span class="pun">(</span><span class="typ">Server</span><span class="pun">.</span><span class="typ">MapPath</span><span class="pun">(</span><span class="str">&quot;~/test.xml&quot;</span><span class="pun">),</span><span class="pln"> </span><span class="str">&quot;http://localhost:5261/recive.aspx&quot;</span><span class="pun">);</span><span class="pln">
        </span><span class="pun">}</span><span class="pln">

        </span><span class="kwd">protected</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> boton2_Click</span><span class="pun">(</span><span class="kwd">object</span><span class="pln"> sender</span><span class="pun">,</span><span class="pln"> </span><span class="typ">EventArgs</span><span class="pln"> e</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
           </span><span class="typ">Response</span><span class="pun">.</span><span class="typ">Redirect</span><span class="pun">(</span><span class="str">&quot;~/recive.aspx&quot;</span><span class="pun">);</span><span class="pln">
        </span><span class="pun">}</span><span class="pln">
    </span><span class="pun">}</span><span class="pln">
</span><span class="pun">}</span></pre>
<br>
</span><br>
<div><span><span>Y este es el codigo fuente del archivo recive.aspx</span></span></div>
<div><span><span>
<pre class="prettyprint prettyprinted"><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Collections</span><span class="pun">.</span><span class="typ">Generic</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Linq</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">.</span><span class="typ">WebControls</span><span class="pun">;</span><span class="pln">
</span><span class="kwd">using</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="pln">IO</span><span class="pun">;</span><span class="pln">

</span><span class="kwd">namespace</span><span class="pln"> </span><span class="typ">PostXML</span><span class="pln">
</span><span class="pun">{</span><span class="pln">
    </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">partial</span><span class="pln"> </span><span class="kwd">class</span><span class="pln"> recive </span><span class="pun">:</span><span class="pln"> </span><span class="typ">System</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="pln">UI</span><span class="pun">.</span><span class="typ">Page</span><span class="pln">
    </span><span class="pun">{</span><span class="pln">
        </span><span class="kwd">protected</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> </span><span class="typ">Page_Load</span><span class="pun">(</span><span class="kwd">object</span><span class="pln"> sender</span><span class="pun">,</span><span class="pln"> </span><span class="typ">EventArgs</span><span class="pln"> e</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
            </span><span class="typ">Page</span><span class="pun">.</span><span class="typ">Response</span><span class="pun">.</span><span class="typ">ContentType</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> </span><span class="str">&quot;text/xml&quot;</span><span class="pun">;</span><span class="pln">
            </span><span class="com">// Read XML posted via HTTP</span><span class="pln">
            </span><span class="typ">StreamReader</span><span class="pln"> reader </span><span class="pun">=</span><span class="pln"> </span><span class="kwd">new</span><span class="pln"> </span><span class="typ">StreamReader</span><span class="pun">(</span><span class="typ">Page</span><span class="pun">.</span><span class="typ">Request</span><span class="pun">.</span><span class="typ">InputStream</span><span class="pun">);</span><span class="pln">
            </span><span class="typ">String</span><span class="pln"> xmlData </span><span class="pun">=</span><span class="pln"> reader</span><span class="pun">.</span><span class="typ">ReadToEnd</span><span class="pun">();</span><span class="pln">
            </span><span class="com">//aqui podemos hacer lo que se nos ocurra con xmlData, por ejemplo</span><span class="pln">
            </span><span class="com">//podemos parsear el codigo xml y guardarlo en una base de datos por ejemplo</span><span class="pln">

            </span><span class="kwd">if</span><span class="pln"> </span><span class="pun">(</span><span class="pln">xmlData </span><span class="pun">!=</span><span class="pln"> </span><span class="str">&quot;&quot;</span><span class="pln"> </span><span class="pun">&amp;&amp;</span><span class="pln"> </span><span class="typ">Request</span><span class="pun">.</span><span class="typ">Form</span><span class="pun">.</span><span class="typ">Count</span><span class="pln"> </span><span class="pun">==</span><span class="pln"> </span><span class="lit">0</span><span class="pun">)</span><span class="pln">
            </span><span class="pun">{</span><span class="pln">
                </span><span class="typ">Application</span><span class="pun">[</span><span class="str">&quot;xml&quot;</span><span class="pun">]</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> xmlData</span><span class="pun">;</span><span class="pln">
            </span><span class="pun">}</span><span class="pln">
            
        </span><span class="pun">}</span><span class="pln">

        </span><span class="kwd">protected</span><span class="pln"> </span><span class="kwd">void</span><span class="pln"> show_Click</span><span class="pun">(</span><span class="kwd">object</span><span class="pln"> sender</span><span class="pun">,</span><span class="pln"> </span><span class="typ">EventArgs</span><span class="pln"> e</span><span class="pun">)</span><span class="pln">
        </span><span class="pun">{</span><span class="pln">
            </span><span class="typ">Label1</span><span class="pun">.</span><span class="typ">Text</span><span class="pln"> </span><span class="pun">=</span><span class="typ">HttpUtility</span><span class="pun">.</span><span class="typ">HtmlEncode</span><span class="pun">(</span><span class="typ">Application</span><span class="pun">[</span><span class="str">&quot;xml&quot;</span><span class="pun">]==</span><span class="kwd">null</span><span class="pun">?</span><span class="pln"> </span><span class="str">&quot;&quot;</span><span class="pln"> </span><span class="pun">:</span><span class="pln"> </span><span class="typ">Application</span><span class="pun">[</span><span class="str">&quot;xml&quot;</span><span class="pun">].</span><span class="typ">ToString</span><span class="pun">());</span><span class="pln">
        </span><span class="pun">}</span><span class="pln">
    </span><span class="pun">}</span><span class="pln">
</span><span class="pun">}</span></pre>
<br>
</span></span></div>
<div></div>
</div>
