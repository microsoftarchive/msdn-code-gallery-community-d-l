# Esempio di autocompletamento textbox mediante un origine dati.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic .NET
## Topics
- SQL Server
- Windows Forms
- Windows Form Controls
- DataSet
- DataGridView
## Updated
- 06/18/2011
## Description

<h1>Introduction</h1>
<p><em>&nbsp;<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">This</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">code example</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">does</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">demonstrate</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">how to perform</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">autocompletamennto</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">TextBox control</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">by</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">loading</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">property</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">TextBox</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">AutoCompleteCustomSource</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">from</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">database table</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">dati.Verr&agrave;</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">first creates</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">local database.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">sdf</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">SqlCompact</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">where</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">there will be</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">table</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">called</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">words</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">then run</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Configuration</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Wizard</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">create</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">dataset</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">at the end</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">drag on the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">form</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">we will</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">FrmAutoComplete</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">DataGridView</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">so</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">all</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the commands</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">available through the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">BindingNavigator</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to run</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">insert</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">update</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">delete</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">data</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">form</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">we will have</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">more than</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">DataBase.Sul</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">DataGridView</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">generated using</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">DataSet</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">wizard</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a button and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">box</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">also</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">contains</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">a</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">variable</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">testo.Lesempio</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">tipoSystem.Windows.Form.AutoCompleteCustomSource</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">in the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">settings</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the example</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span class="hps" title="Fai clic per visualizzare le traduzioni alternative">To run the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">sample</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">target PC</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">must</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">have</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">most</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">net.Framework4</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">SQLCompact</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">3.5 or</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">higher</span><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>&nbsp; <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
Execution</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
of the application</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
are checked</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
on</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
AutoComplete</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
variable</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
as shown in</span> <span class="hps" title="Fai clic per visualizzare le traduzioni alternative">
next code</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">if</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">nothing</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of it is created</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">an</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">instance</span><span title="Fai clic per visualizzare le traduzioni alternative">, otherwise it</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">is</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">assigned to the property</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">of the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">TextBox</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">AutoCompleteSource</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">its value</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Using</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Upload button</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">perform</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">an</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">iteration</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">that</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">will be</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">possible</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to update</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">save</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">all</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">data</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">entered</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the variable</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">AutoComplete</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span><br>
<br>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Forms</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">are</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">available on</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">all components</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">to perform</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">insert</span><span title="Fai clic per visualizzare le traduzioni alternative">,</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">update</span><span title="Fai clic per visualizzare le traduzioni alternative">, and</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">delete</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">the</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">database table</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">Parole.sdf</span><span title="Fai clic per visualizzare le traduzioni alternative">.</span></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__com">'Classe&nbsp;FrmAutoComplete</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FrmAutoComplete&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;Pulsante&nbsp;TABELLAPAROLEBindingNavigatorSaveItem</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;TABELLAPAROLEBindingNavigatorSaveItem_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;TABELLAPAROLEBindingNavigatorSaveItem.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Verifica&nbsp;il&nbsp;valore&nbsp;del&nbsp;controllo&nbsp;che&nbsp;non&nbsp;&egrave;&nbsp;pi&ugrave;&nbsp;attivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Validate()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Appplica&nbsp;le&nbsp;modifiche&nbsp;all'origine&nbsp;dati&nbsp;sottostante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TABELLAPAROLEBindingSource.EndEdit()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiorna&nbsp;tutte&nbsp;le&nbsp;modifiche&nbsp;al&nbsp;dataset</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TableAdapterManager.UpdateAll(<span class="visualBasic__keyword">Me</span>.ParoleDataSet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;load&nbsp;del&nbsp;form&nbsp;FrmAutoComplete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;FrmAutoComplete_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TABELLAPAROLETableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.ParoleDataSet.TABELLAPAROLE)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Assegno&nbsp;alla&nbsp;propriet&agrave;&nbsp;AutoCompleteMode&nbsp;della&nbsp;TxtBox&nbsp;il&nbsp;valore&nbsp;AutoCompleteMode.Suggest,&nbsp;necessario</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'per&nbsp;eseguire&nbsp;l'autocompletamento&nbsp;e&nbsp;suggerire&nbsp;le&nbsp;parole&nbsp;con&nbsp;una&nbsp;specifica&nbsp;lettera&nbsp;iniziale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TxtAutoComplete.AutoCompleteMode&nbsp;=&nbsp;AutoCompleteMode.Suggest&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Assegno&nbsp;alla&nbsp;propriet&agrave;&nbsp;AutoCompleteSource&nbsp;il&nbsp;valore&nbsp;AutoCompleteSource.CustomSource&nbsp;per&nbsp;indicare&nbsp;che</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'la&nbsp;sorgente&nbsp;per&nbsp;l'autocompletemento&nbsp;e&nbsp;prsonalizzata.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TxtAutoComplete.AutoCompleteSource&nbsp;=&nbsp;AutoCompleteSource.CustomSource&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;la&nbsp;variabile&nbsp;AutoComplete&nbsp;non&nbsp;e&nbsp;nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.AutoComplete&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Assegna&nbsp;alla&nbsp;propriet&agrave;&nbsp;AutoCompleteCustomSource&nbsp;di&nbsp;TxtAutoCmplete&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Variabile&nbsp;AutoComplete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TxtAutoComplete.AutoCompleteCustomSource&nbsp;=&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.AutoComplete&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Altrimenti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Crea&nbsp;un&nbsp;istanza&nbsp;di&nbsp;AutoComplete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.AutoComplete&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;System.Windows.Forms.AutoCompleteStringCollection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Evento&nbsp;Click&nbsp;del&nbsp;Pulsante&nbsp;btnAutocomplete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnAutocomplete_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAutocomplete.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Ottiene&nbsp;il&nbsp;numero&nbsp;di&nbsp;righe&nbsp;che&nbsp;contiene&nbsp;la&nbsp;Tabella&nbsp;del&nbsp;DataGridView</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rows&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;AutoCompleteDataGridView.RowCount&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Dichiaro&nbsp;una&nbsp;variabile&nbsp;di&nbsp;tipo&nbsp;integer&nbsp;che&nbsp;servir&agrave;&nbsp;per&nbsp;scorrere&nbsp;tutte&nbsp;le&nbsp;righe&nbsp;del&nbsp;DataGridWiev&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;l'iterazione&nbsp;della&nbsp;variabile&nbsp;i</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;rows&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Aggiungo&nbsp;alla&nbsp;variabile&nbsp;AutoComplete&nbsp;tutti&nbsp;i&nbsp;valore&nbsp;dela&nbsp;cella&nbsp;PAROLE&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.AutoComplete.Add(AutoCompleteDataGridView.Rows(i).Cells(<span class="visualBasic__string">&quot;PAROLE&quot;</span>).Value.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Iterazione&nbsp;successiva</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Assegna&nbsp;alla&nbsp;propriet&agrave;&nbsp;AutoCompleteCustomSource&nbsp;di&nbsp;TxtAutoCmplete&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Variabile&nbsp;AutoComplete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TxtAutoComplete.AutoCompleteCustomSource&nbsp;=&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.AutoComplete&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Eseguo&nbsp;il&nbsp;salvataggio&nbsp;delle&nbsp;impostazioni&nbsp;dell'applicazione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.MySettings.<span class="visualBasic__keyword">Default</span>.Save()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>More Information</h1>
<p><em><span class="hps" title="Fai clic per visualizzare le traduzioni alternative">For more information contact</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">http://community.visual-basic.it/carmelolamonica/</span></em></p>
