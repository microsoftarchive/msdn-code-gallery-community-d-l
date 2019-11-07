# Gerando relatórios com Reportviewer na linguagem C# para aplicações Desktop
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Report Viewer
## Topics
- Reporting
## Updated
- 04/14/2014
## Description

<div class="separator" style="clear:both; text-align:center"></div>
<div style="text-align:center"><strong style="color:#0b5394; font-family:Times,'Times New Roman',serif; font-size:x-large">Gerando relat&oacute;rios com Reportviewer na linguagem C#</strong><br>
<span style="color:#0b5394; font-family:Times,'Times New Roman',serif; font-size:large"><strong><br>
</strong></span><br>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Para algumas vers&otilde;es do Visual Studio ser&aacute; necess&aacute;rio baixar o Package do ReportViewer</span></div>
<div style="text-align:left"><a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=3eb83c28-a79e-45ee-96d0-41bc42c70d5d&displayLang=pt-br" target="_blank" style="font-size:small"><span style="font-family:Verdana,sans-serif">Clique aqui para baixar</span></a></div>
<div style="text-align:left"></div>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Hoje irei mostrar como gerar relat&oacute;rios usando reportviewer em uma aplica&ccedil;&atilde;o
<strong>DESKTOP</strong>, o exemplo que irei motrar pode ser facilmente adaptado para Visual Basic.net, o c&oacute;digo ir&aacute; apenas sofrer algumas mudan&ccedil;as.</span></div>
</div>
<p><span style="font-family:Verdana,sans-serif"><br>
</span><br>
<a href="http://paulohdsousa.blogspot.com/2012/01/c-para-vbnet-vbnet-para-c.html" target="_blank"><span style="font-family:Verdana,sans-serif">Clique aqui para converter de C# para Visual Basic.net</span></a><br>
<span style="font-family:Verdana,sans-serif"><br>
</span></p>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif">Crie uma tabela no banco de dados chamada Produtos,
<a href="https://skydrive.live.com/view.aspx/Script%5E_Produtos.docx?cid=02450637ba34b369&app=Word" target="_blank">
clique aqui &nbsp;para ver o Script SQL </a></span><br>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif">Adicione alguns dados na tabela, eles ser&atilde;o mostrados no relat&oacute;rio posteriormente</span></div>
<div style="text-align:left"><span style="color:#0b5394; font-family:Verdana,sans-serif; font-size:large"><br>
</span><br>
<span style="color:#0b5394; font-family:Verdana,sans-serif; font-size:large">Crie um novo projeto</span></div>
<div style="text-align:left"><span style="color:#0b5394; font-family:Verdana,sans-serif; font-size:large"><br>
</span></div>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">No Visual Studio v&aacute; em:</span></div>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong>File &gt; New Project
</strong>ou aperte <strong>CTRL &#43; SHIFT &#43; N</strong></span></div>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Selecione
<strong>Visual&nbsp;C#&gt; Windows Form Application</strong>&nbsp;e crie um projeto com o nome de&nbsp;<strong>RelatorioReportViewer</strong></span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://4.bp.blogspot.com/-_ktnYM2FfjY/TxwVeulJvcI/AAAAAAAAAPw/KVdvKE8FjjU/s1600/RP0.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp0.jpg" border="0" alt="" width="320" height="194"></span></a></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Adicione um&nbsp;&nbsp;formul&aacute;rio&nbsp;no projeto&nbsp;e coloque o nome dele de&nbsp;<strong>FrmVisualizador</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">V&aacute; na Aba
<strong>Toolbox </strong>selecione e arraste o Componente <strong>Reportviewer </strong>
no&nbsp;formul&aacute;rio</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong><br>
</strong></span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://2.bp.blogspot.com/-ERPRg85B5sU/TxwYxvsvJtI/AAAAAAAAAP4/fq-VBFroLlk/s1600/RP1.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp1.jpg" border="0" alt="" width="320" height="170"></span></a></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Clique com o bot&atilde;o direito em cima do projeto&nbsp;<strong>RelatorioReportViewer &nbsp;</strong>v&aacute; em
<strong>ADD &gt; NEW ITEM</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">ou aperte
<strong>CTRL &#43; SHIFT &#43; A </strong>&nbsp;e adicione um relat&oacute;rio no projeto com o nome de&nbsp;<strong>Relatorio_Produtos</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong><br>
</strong></span></div>
<span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span><br>
<div class="separator" style="clear:both; text-align:center"><a href="http://2.bp.blogspot.com/-cs4F41H0TGA/TxwbRTZgCVI/AAAAAAAAAQA/4EKuPQ6V2zk/s1600/RP3.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp3.jpg" border="0" alt="" width="320" height="195"></span></a></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong><br>
</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong><br>
</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Dentro da aba Repot Data v&aacute; em NEW &gt; DATASET</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Caso n&atilde;o consiga visualizar a aba, clique dentro do relat&oacute;rio e aperte CTRL &#43; ALT &#43; D</span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://3.bp.blogspot.com/-gHTXSJng0AI/TxwxoKs8JWI/AAAAAAAAAQI/AHpG1_Z_Bu0/s1600/RP4.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp4.jpg" border="0" alt="" width="320" height="166"></span></a></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Automaticamente ser&aacute; aberto o
<strong>Data Source Configuration Wizard</strong>, ent&atilde;o siga esses passos.</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"></div>
<ol>
<li>&nbsp;
<ol>
<li><span style="font-family:Verdana,sans-serif; font-size:x-small">Database [Com LINQ teriamos que escolher
<strong>OBJECT,</strong>&nbsp;Afinal, a tabela vira um <strong>Objeto</strong>]</span>
</li><li><span style="font-family:Verdana,sans-serif; font-size:x-small">Dataset</span>
</li><li><span style="font-family:Verdana,sans-serif; font-size:x-small">Conecte ao seu banco de dados.</span>
</li></ol>
</li></ol>
<span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span><br>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="http://2.bp.blogspot.com/--qo8IpcOWXQ/Txwyy8wdjRI/AAAAAAAAAQQ/Fc-SCGaJ7tM/s1600/RP5.jpg" style="margin-left:1em; margin-right:1em; text-align:center"><img src="-rp5.jpg" border="0" alt="" width="320" height="247"></a></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 4. Clique em<strong> Next &gt;
</strong>duas vezes, uma <a href="http://msdn.microsoft.com/pt-br/library/system.data.common.dbconnectionstringbuilder.connectionstring(v=vs.90).aspx" target="_blank">
Connection String</a> ser&aacute; salva</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 5. Escolha a tabela que criamos no come&ccedil;o da explica&ccedil;&atilde;o</span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://4.bp.blogspot.com/-tOtZOdQK1uc/Txw1Tz6VMDI/AAAAAAAAAQY/iNxwqcz_Bs8/s1600/RP5.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp5.jpg" border="0" alt="" width="320" height="245"></span></a></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 6. Clique em
<strong>Finish</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Se tudo der certo teremos nosso Dataset para o reportviewer criado, renomeie ele para&nbsp;<strong>DataSet_Produtos
</strong>e clique em<strong> OK</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><strong><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></strong></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://3.bp.blogspot.com/-6J_sAiMbFvA/Txw2indvx6I/AAAAAAAAAQg/LqKc18jo5Nk/s1600/RP6.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp6.jpg" border="0" alt="" width="320" height="170"></span></a></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">O Dataset ir&aacute; aparecer no
<strong>Report Data.</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Clique com o bot&atilde;o direito
<strong>DENTRO </strong>do relat&oacute;rio v&aacute; em<strong> INSERT &gt; Table</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">V&aacute; nas propriedades da
<strong>Table </strong>que acabou de ser inserida e &nbsp;na propriedade <strong>
DataSetName</strong> defina como&nbsp;<strong>DataSet_Produtos</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Depois selecione as colunas que quer mostrar na Table.</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://1.bp.blogspot.com/-fDAvUD5Oa44/Txw4_c65DzI/AAAAAAAAAQo/lFRU9GSz_4g/s1600/RP7.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp7.jpg" border="0" alt="" width="320" height="171"></span></a></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Volte para o FrmVisualizador e defina o<strong>&nbsp;Relatorio_Produtos.rdlc
</strong>para ser exibido.</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Tamb&eacute;m defina a propriedade
<strong>Archor </strong>do ReportViewer para todos os lados :</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong>&nbsp;Top, Bottom, Left, Right</strong></span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Isso vai fazer com que quando o formul&aacute;rio for maximizado, o relat&oacute;rio tamb&eacute;m ser&aacute;</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://4.bp.blogspot.com/-HdRkMRarykI/Txw6-wpA4sI/AAAAAAAAAQw/kV0N71GAIA4/s1600/RP8.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp8.jpg" border="0" alt="" width="320" height="171"></span></a></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">No Form1 adicione um bot&atilde;o para chamar o
<strong>FrmVisualizador</strong></span></div>
<div class="separator" style="clear:both; text-align:left"></div>
<div class="separator" style="clear:both; font-weight:bold; text-align:center">
<span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><span style="color:#6fa8dc">FrmVisualizador
</span>oForm = <span style="color:blue">new </span><span style="color:#6fa8dc">FrmVisualizador</span>();</span></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small">&nbsp; oForm.Show();</span></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Executando o projeto e clicando no bot&atilde;o para abrir o Frm_Visualizador teremos</span></div>
<div class="separator" style="clear:both; text-align:center"><a href="http://3.bp.blogspot.com/-3kqGy_kyjXo/Txw82ZIs18I/AAAAAAAAAQ4/4maQjEFjiPw/s1600/RP9.jpg" style="margin-left:1em; margin-right:1em"><span style="font-family:Verdana,sans-serif; font-size:x-small"><img src="-rp9.jpg" border="0" alt="" width="320" height="171"></span></a></div>
<div class="separator" style="clear:both; text-align:center"><span style="font-family:Verdana,sans-serif; font-size:x-small"><br>
</span></div>
<div class="separator" style="clear:both; text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small">Al&eacute;m de ser f&aacute;cil de montar, com reportviewer temos a op&ccedil;&atilde;o de expotar os dados para:</span></div>
<div class="separator" style="clear:both; text-align:left"></div>
<ul>
<li><span style="font-family:Verdana,sans-serif; font-size:x-small">Excel</span> </li><li><span style="font-family:Verdana,sans-serif; font-size:x-small">PDF</span> </li><li><span style="font-family:Verdana,sans-serif; font-size:x-small">Word</span> </li></ul>
<div><span style="font-family:Verdana,sans-serif; font-size:x-small"><a href="http://dl.dropbox.com/u/58447781/RelatorioReportViewer.rar" target="_blank">Clique aqui
</a>para baixar o projeto terminado</span></div>
<div class="separator" style="clear:both; text-align:center"></div>
<div class="separator" style="clear:both; text-align:center"></div>
<div class="separator" style="clear:both; text-align:left"></div>
<div class="separator" style="clear:both; text-align:left"><strong>Outros artigos em:&nbsp;</strong><span style="color:#888888"><a href="http://paulohdsousa.blogspot.com.br" target="_blank">paulohdsousa.blogspot.com.br</a></span></div>
<div style="text-align:left"><span style="font-family:Verdana,sans-serif; font-size:x-small"><strong><br>
</strong></span></div>
<div>
<div class="spoiler">USE [Acoes_Coletivas]<br>
GO<br>
<br>
/****** Object: &nbsp;Table [dbo].[Produtos] &nbsp; &nbsp;Script Date: 01/22/2012 11:36:00 ******/<br>
SET ANSI_NULLS ON<br>
GO<br>
<br>
SET QUOTED_IDENTIFIER ON<br>
GO<br>
<br>
CREATE TABLE [dbo].[Produtos](<br>
<span style="white-space:pre">&nbsp;</span>[Id_Produto] [int] IDENTITY(1,1) NOT NULL,<br>
<span style="white-space:pre">&nbsp;</span>[Nome] [nvarchar](350) NULL,<br>
<span style="white-space:pre">&nbsp;</span>[Valor] [money] NULL,<br>
&nbsp;CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED<br>
(<br>
<span style="white-space:pre">&nbsp;</span>[Id_Produto] ASC<br>
)WITH (PAD_INDEX &nbsp;= OFF, STATISTICS_NORECOMPUTE &nbsp;= OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS &nbsp;= ON, ALLOW_PAGE_LOCKS &nbsp;= ON) ON [PRIMARY]<br>
) ON [PRIMARY]<br>
<br>
GO<br>
<br>
<br>
</div>
</div>
</div>
