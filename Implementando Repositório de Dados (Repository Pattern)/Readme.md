# Implementando Repositório de Dados (Repository Pattern)
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- Entity Framework
- good programming practices
## Topics
- C#
- Entity Framework
- good programming practices
## Updated
- 01/16/2015
## Description

<p>&nbsp;</p>
<h1><span>Introdu&ccedil;&atilde;o</span></h1>
<p><span style="font-size:small">Estaremos aprendendo atrav&eacute;s deste post como implementar uma camada de acesso a dados usando o Padr&atilde;o de Reposit&oacute;rio de Dados Gen&eacute;ricos ou Repository Pattern no ingl&ecirc;s. Esse padr&atilde;o &eacute;
 muito utilizado hoje no dia-a-dia das f&aacute;bricas de softwares para uma maior:</span></p>
<ul>
<li><span style="font-size:small">Organiza&ccedil;&atilde;o do projeto;</span> </li><li><span style="font-size:small">Auxiliando a centralizar o c&oacute;digo j&aacute; desenvolvido evitando duplicidade;</span>
</li><li><span style="font-size:small">Melhor facilidade na manuten&ccedil;&atilde;o e implementa&ccedil;&atilde;o funcionalidades;</span>
</li><li><span style="font-size:small">Facilidade de elaborar testes unit&aacute;rios (unit tests);</span>
</li><li><span style="font-size:small">Melhor defini&ccedil;&atilde;o de tarefas entre a equipe do projeto;</span>
</li></ul>
<p><span style="font-size:small">Os contras ou seja ao n&atilde;o adquar o projeto a esse padr&atilde;o seria:&nbsp;</span></p>
<ul>
<li><span style="font-size:small">C&oacute;digo duplicado.</span> </li><li><span style="font-size:small">Dificil entendimento do codigo e manuten&ccedil;&atilde;o ou implementa&ccedil;&atilde;o demorada;</span>
</li><li><span style="font-size:small">Elabora&ccedil;&atilde;o de testes unitarios erroneamente ou &nbsp;a nao implementa&ccedil;&atilde;o.</span>
</li><li><span style="font-size:small">Projeto chegaria ao termino mas todo estruturado erroneamente e de dificil compreens&atilde;o pela equipe do projeto;</span>
</li><li><span style="font-size:small">Ultimo e primordial o tempo do projeto podera estourar o escopo do especificado;</span>
</li></ul>
<h1><span>Requisitos</span></h1>
<p><span style="font-size:small">Visual Studio 2012 ou 2013, servi&ccedil;o de banco de dados MySQL no meu caso esta instalado localmente, para manipula&ccedil;&atilde;o da base de dados utilizarei o software MySQL- WorkBench que &eacute; gratuito.</span></p>
<h1><span>Criando a base de dados</span></h1>
<p><span style="font-size:small">Vamos criar uma base de dados ou tamb&eacute;m schema denominado pelo MySQL chamada &ldquo;estudo&rdquo; dentro desta base teremos a tabela chamada &ldquo;cliente&rdquo; segue baixo o script para melhor compreens&atilde;o:</span><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE DATABASE estudo DEFAULT CHARACTER SET utf8;

CREATE TABLE CLIENTE
(
    COD_CLIENTE  		      INT NOT NULL AUTO_INCREMENT,
	CLI_NOME    		       VARCHAR(100) NOT NULL,
    CLI_EMAIL    		      VARCHAR(100) NOT NULL,
    CLI_ENDERECO   		    VARCHAR(100) NOT NULL,
    CLI_BAIRRO   		      VARCHAR(100) NOT NULL,
    CLI_CIDADE   		      VARCHAR(100) NOT NULL,
    CLI_ESTADO                 VARCHAR(2) NOT NULL,   
    PRIMARY KEY (COD_CLIENTE)
);

ALTER TABLE CLIENTE AUTO_INCREMENT = 1000;</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;<span class="sql__id">estudo</span>&nbsp;<span class="sql__keyword">DEFAULT</span>&nbsp;<span class="sql__keyword">CHARACTER</span>&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">utf8</span>;&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;<span class="sql__id">CLIENTE</span>&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">COD_CLIENTE</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;<span class="sql__keyword">AUTO_INCREMENT</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_NOME</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_EMAIL</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_ENDERECO</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_BAIRRO</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_CIDADE</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CLI_ESTADO</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">2</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;(<span class="sql__id">COD_CLIENTE</span>)&nbsp;
);&nbsp;
&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;<span class="sql__id">CLIENTE</span>&nbsp;<span class="sql__keyword">AUTO_INCREMENT</span>&nbsp;=&nbsp;<span class="sql__number">1000</span>;</pre>
</div>
</div>
</div>
<h1>Criando a Solution</h1>
<p><span style="font-size:small">Vamos criar uma nova solution no Visual Studio no meu caso &eacute; o 2012 e dentro dela criar uma pasta chamada &quot;<em>1 - Data</em>&quot; e dentro desta pasta criaremos um novo projeto do tipo &quot;<em>Class Library</em>&quot; onde ter&aacute;
 nossos objetos de trabalho bem como entidades de dominio, classe de configura&ccedil;&atilde;o das entidades, classe de contexto etc. Criem o projeto com a mesma estrutura de pasta demostrada aqui ok. Vejamos:&nbsp;</span></p>
<p><span style="font-size:small"><img id="132595" src="132595-1.jpg" alt="" width="276" height="171"></span></p>
<p><span style="font-size:small">Vamos criar uma classe Base.cs que servira de base em comum dentre todas as entidades do projeto, as entidades herdar&atilde;o dela o campo &quot;id&quot; pois todos as entidades ter&atilde;o c&oacute;digos para representa-las visto que
 as entidades seram copias fieis das tabelas do nosso banco de dados. Vejamos:&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public class Base
    {
        public int id { get; set; }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository.Domain&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Base&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Vamos agora implementar a entidade Cliente.cs dentro da pasta &quot;</span><em style="font-size:small">Domain</em><span style="font-size:small">&quot; e ClienteConfiguration.cs dentro da pasta &quot;</span><em style="font-size:small">Configuration</em><span style="font-size:small">&quot;,
 essa entidade ser&aacute; a copia da tabela do nosso banco de dados e sua configura&ccedil;&atilde;o ou seja as especifica&ccedil;&otilde;es das colunas das tabela do que &eacute; obrigat&oacute;rio ou opcional, qual coluna &eacute; varchar e qual &eacute;
 numeric etc. Esta entidade tera que ter a heran&ccedil;a de nossa entidade base.</span></div>
<p><span style="font-size:small">Cliente.cs (Classe) dentro da pasta Domain</span><span style="font-size:x-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public class Cliente : Base
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository.Domain&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Cliente&nbsp;:&nbsp;Base&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;nome&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;endereco&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;bairro&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;cidade&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;uf&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;ClienteConfiguration.cs (Classe) dentro da pasta Configuration</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Repository.Domain;

namespace Repository.Configuration
{
    public class ClienteConfiguration : EntityTypeConfiguration&lt;Cliente&gt;
    {
        public ClienteConfiguration()
        {
            // chave primaria
            this.HasKey(t =&gt; t.id);

            // propriedades
            this.Property(t =&gt; t.nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t =&gt; t.email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t =&gt; t.endereco)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t =&gt; t.bairro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t =&gt; t.cidade)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t =&gt; t.uf)
                .IsRequired()
                .HasMaxLength(2);

            // tabela e mapeamentos
            this.ToTable(&quot;cliente&quot;, &quot;estudo&quot;);
            this.Property(t =&gt; t.id).HasColumnName(&quot;COD_CLIENTE&quot;);
            this.Property(t =&gt; t.nome).HasColumnName(&quot;CLI_NOME&quot;);
            this.Property(t =&gt; t.email).HasColumnName(&quot;CLI_EMAIL&quot;);
            this.Property(t =&gt; t.endereco).HasColumnName(&quot;CLI_ENDERECO&quot;);
            this.Property(t =&gt; t.bairro).HasColumnName(&quot;CLI_BAIRRO&quot;);
            this.Property(t =&gt; t.cidade).HasColumnName(&quot;CLI_CIDADE&quot;);
            this.Property(t =&gt; t.uf).HasColumnName(&quot;CLI_ESTADO&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel.DataAnnotations.Schema;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.ModelConfiguration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Domain;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository.Configuration&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ClienteConfiguration&nbsp;:&nbsp;EntityTypeConfiguration&lt;Cliente&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ClienteConfiguration()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;chave&nbsp;primaria</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.HasKey(t&nbsp;=&gt;&nbsp;t.id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;propriedades</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.nome)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">100</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.email)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">100</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.endereco)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">100</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.bairro)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">100</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.cidade)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">100</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.uf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.IsRequired()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasMaxLength(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;tabela&nbsp;e&nbsp;mapeamentos</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ToTable(<span class="cs__string">&quot;cliente&quot;</span>,&nbsp;<span class="cs__string">&quot;estudo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.id).HasColumnName(<span class="cs__string">&quot;COD_CLIENTE&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.nome).HasColumnName(<span class="cs__string">&quot;CLI_NOME&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.email).HasColumnName(<span class="cs__string">&quot;CLI_EMAIL&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.endereco).HasColumnName(<span class="cs__string">&quot;CLI_ENDERECO&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.bairro).HasColumnName(<span class="cs__string">&quot;CLI_BAIRRO&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.cidade).HasColumnName(<span class="cs__string">&quot;CLI_CIDADE&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Property(t&nbsp;=&gt;&nbsp;t.uf).HasColumnName(<span class="cs__string">&quot;CLI_ESTADO&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Vamos agora criar a classe de contexto &eacute; nela que adicionaremos todas as entidades que desejamos manipular em nosso projeto, desde que tenhamos a entidade implementada como descrito at&eacute; agora:</div>
</span></div>
<div class="endscriptcode">
<ul>
<li><span style="font-size:small">Implementamos a entidade na pasta Domain;</span>
</li><li><span style="font-size:small">Implementamos a classe de configura&ccedil;&atilde;o na pasta Configuration;</span>
</li><li><span style="font-size:small">Implementamos a chamada da enteidade na classe contexto;</span>
</li></ul>
<p><span style="font-size:small">No modelo de contexto abaixo temos implementado somente a entidade cliente ate o presente momento. Vejamos abaixo:</span></p>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Transactions;
using Repository.Domain;
using Repository.Configuration;

namespace Repository.Context
{
    public class Contexto : DbContext
    {
        static Contexto()
        {
            Database.SetInitializer&lt;Contexto&gt;(null);
        }

        public Contexto() : base(&quot;Name=estudoContext&quot;)
        {
        }

        public DbSet&lt;Cliente&gt; Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }

    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel.DataAnnotations.Schema;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.Infrastructure;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.ModelConfiguration.Conventions;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Objects;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Configuration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Transactions;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Domain;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Configuration;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository.Context&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Contexto&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;Contexto()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Database.SetInitializer&lt;Contexto&gt;(<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Contexto()&nbsp;:&nbsp;<span class="cs__keyword">base</span>(<span class="cs__string">&quot;Name=estudoContext&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DbSet&lt;Cliente&gt;&nbsp;Cliente&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnModelCreating(DbModelBuilder&nbsp;modelBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Configurations.Add(<span class="cs__keyword">new</span>&nbsp;ClienteConfiguration());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Feito isso vamos agora implementar os principais objetos na minha opni&atilde;o da camada de dados com padr&atilde;o resposit&oacute;rio que &eacute; a interface &quot;IRespositoryBase.cs&quot; e a classe &quot;RepositoryBase.cs&quot;
 a interface tera as assinaturas padr&otilde;es dos m&eacute;todos e a classe ter&aacute; o c&oacute;digo das mesmas.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">IRespositoryBase.cs (Interface) dentro da pasta Repository</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepositoryBase&lt;TEntity&gt; where TEntity : class
    {
        void Add(TEntity entity);

        void AddAll(List&lt;TEntity&gt; entity);

        void Edit(TEntity entity);

        void Delete(TEntity entity);

        void DeleteAll(Expression&lt;Func&lt;TEntity, bool&gt;&gt; filter = null);

        List&lt;TEntity&gt; Get(Expression&lt;Func&lt;TEntity, bool&gt;&gt; filter = null, Func&lt;IQueryable&lt;TEntity&gt;, IOrderedQueryable&lt;TEntity&gt;&gt; orderBy = null);
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq.Expressions;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IRepositoryBase&lt;TEntity&gt;&nbsp;where&nbsp;TEntity&nbsp;:&nbsp;<span class="cs__keyword">class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Add(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;AddAll(List&lt;TEntity&gt;&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Edit(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(TEntity&nbsp;entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteAll(Expression&lt;Func&lt;TEntity,&nbsp;<span class="cs__keyword">bool</span>&gt;&gt;&nbsp;filter&nbsp;=&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TEntity&gt;&nbsp;Get(Expression&lt;Func&lt;TEntity,&nbsp;<span class="cs__keyword">bool</span>&gt;&gt;&nbsp;filter&nbsp;=&nbsp;<span class="cs__keyword">null</span>,&nbsp;Func&lt;IQueryable&lt;TEntity&gt;,&nbsp;IOrderedQueryable&lt;TEntity&gt;&gt;&nbsp;orderBy&nbsp;=&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;RespositoryBase.cs (Classe) dentro da pasta Repository</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;

namespace Repository
{
    public class RepositoryBase&lt;TEntity&gt; : IDisposable, IRepositoryBase&lt;TEntity&gt; where TEntity : class
    {
        internal Contexto _context;
        internal DbSet&lt;TEntity&gt; _dbSet;

        public RepositoryBase(Contexto context)
        {
            this._context = context;
            this._dbSet = context.Set&lt;TEntity&gt;();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(TEntity entity)
        {
            var entry = _context.Entry&lt;TEntity&gt;(entity);
            var pkey = _dbSet.Create().GetType().GetProperty(&quot;id&quot;).GetValue(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = _context.Set&lt;TEntity&gt;();
                TEntity attachedEntity = set.Find(pkey);  // access the key
                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // attach the entity
                }
            }

            _context.SaveChanges();
        }

        /// &lt;summary&gt;
        /// M&eacute;todo que deleta um objeto no banco de dados da aplica&ccedil;&atilde;o.
        /// &lt;/summary&gt;
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        /// &lt;summary&gt;
        /// M&eacute;todo que deleta um ou varios objetos no banco de dados da aplica&ccedil;&atilde;o, mediante uma express&atilde;o LINQ.
        /// &lt;/summary&gt;
        public void DeleteAll(Expression&lt;Func&lt;TEntity, bool&gt;&gt; filter = null)
        {
            IQueryable&lt;TEntity&gt; query = _dbSet;
            List&lt;TEntity&gt; listDelete = query.Where(filter).ToList();

            foreach (var item in listDelete)
            {
                _dbSet.Remove(item);
            }
            _context.SaveChanges();
        }

        /// &lt;summary&gt;
        /// M&eacute;todo que adiciona uma lista de novos objetos ao banco de dados da aplica&ccedil;&atilde;o.
        /// &lt;/summary&gt;
        public void AddAll(List&lt;TEntity&gt; entity)
        {
            foreach (var item in entity)
            {
                _dbSet.Add(item);
            }
            _context.SaveChanges();
        }

        /// &lt;summary&gt;
        /// M&eacute;todo que busca uma lista de objetos no banco de dados da aplica&ccedil;&atilde;o e retorna-a no tipo IEnumerable&lt;TEntity&gt;.
        /// &lt;/summary&gt;
        public virtual List&lt;TEntity&gt; Get(Expression&lt;Func&lt;TEntity, bool&gt;&gt; filter = null, Func&lt;IQueryable&lt;TEntity&gt;, IOrderedQueryable&lt;TEntity&gt;&gt; orderBy = null)
        {
            IQueryable&lt;TEntity&gt; query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Dispose()
        {
            _dbSet = null;
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.Infrastructure;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Objects;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq.Expressions;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Context;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RepositoryBase&lt;TEntity&gt;&nbsp;:&nbsp;IDisposable,&nbsp;IRepositoryBase&lt;TEntity&gt;&nbsp;where&nbsp;TEntity&nbsp;:&nbsp;<span class="cs__keyword">class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;Contexto&nbsp;_context;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;DbSet&lt;TEntity&gt;&nbsp;_dbSet;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RepositoryBase(Contexto&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>._context&nbsp;=&nbsp;context;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>._dbSet&nbsp;=&nbsp;context.Set&lt;TEntity&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Add(TEntity&nbsp;entity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet.Add(entity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Edit(TEntity&nbsp;entity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;entry&nbsp;=&nbsp;_context.Entry&lt;TEntity&gt;(entity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pkey&nbsp;=&nbsp;_dbSet.Create().GetType().GetProperty(<span class="cs__string">&quot;id&quot;</span>).GetValue(entity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(entry.State&nbsp;==&nbsp;EntityState.Detached)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">set</span>&nbsp;=&nbsp;_context.Set&lt;TEntity&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TEntity&nbsp;attachedEntity&nbsp;=&nbsp;<span class="cs__keyword">set</span>.Find(pkey);&nbsp;&nbsp;<span class="cs__com">//&nbsp;access&nbsp;the&nbsp;key</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(attachedEntity&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;attachedEntry&nbsp;=&nbsp;_context.Entry(attachedEntity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;attachedEntry.CurrentValues.SetValues(entity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entry.State&nbsp;=&nbsp;EntityState.Modified;&nbsp;<span class="cs__com">//&nbsp;attach&nbsp;the&nbsp;entity</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;M&eacute;todo&nbsp;que&nbsp;deleta&nbsp;um&nbsp;objeto&nbsp;no&nbsp;banco&nbsp;de&nbsp;dados&nbsp;da&nbsp;aplica&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(TEntity&nbsp;entity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_context.Entry(entity).State&nbsp;==&nbsp;EntityState.Detached)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet.Attach(entity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet.Remove(entity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;M&eacute;todo&nbsp;que&nbsp;deleta&nbsp;um&nbsp;ou&nbsp;varios&nbsp;objetos&nbsp;no&nbsp;banco&nbsp;de&nbsp;dados&nbsp;da&nbsp;aplica&ccedil;&atilde;o,&nbsp;mediante&nbsp;uma&nbsp;express&atilde;o&nbsp;LINQ.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteAll(Expression&lt;Func&lt;TEntity,&nbsp;<span class="cs__keyword">bool</span>&gt;&gt;&nbsp;filter&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IQueryable&lt;TEntity&gt;&nbsp;query&nbsp;=&nbsp;_dbSet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TEntity&gt;&nbsp;listDelete&nbsp;=&nbsp;query.Where(filter).ToList();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;listDelete)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet.Remove(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;M&eacute;todo&nbsp;que&nbsp;adiciona&nbsp;uma&nbsp;lista&nbsp;de&nbsp;novos&nbsp;objetos&nbsp;ao&nbsp;banco&nbsp;de&nbsp;dados&nbsp;da&nbsp;aplica&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddAll(List&lt;TEntity&gt;&nbsp;entity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;entity)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;M&eacute;todo&nbsp;que&nbsp;busca&nbsp;uma&nbsp;lista&nbsp;de&nbsp;objetos&nbsp;no&nbsp;banco&nbsp;de&nbsp;dados&nbsp;da&nbsp;aplica&ccedil;&atilde;o&nbsp;e&nbsp;retorna-a&nbsp;no&nbsp;tipo&nbsp;IEnumerable&lt;TEntity&gt;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;List&lt;TEntity&gt;&nbsp;Get(Expression&lt;Func&lt;TEntity,&nbsp;<span class="cs__keyword">bool</span>&gt;&gt;&nbsp;filter&nbsp;=&nbsp;<span class="cs__keyword">null</span>,&nbsp;Func&lt;IQueryable&lt;TEntity&gt;,&nbsp;IOrderedQueryable&lt;TEntity&gt;&gt;&nbsp;orderBy&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IQueryable&lt;TEntity&gt;&nbsp;query&nbsp;=&nbsp;_dbSet;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(filter&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(filter);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(orderBy&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;orderBy(query).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;query.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dbSet&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GC.SuppressFinalize(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Adicionaremos por ultimo agora o objeto que utilizaremos em outras camadas, de nosso projeto chamado de &quot;UnitOfWork.cs&quot;. Vejamos o codigo do mesmo:&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;
using Repository.Domain;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private Contexto _context = new Contexto();

        private RepositoryBase&lt;Cliente&gt; _clienteRepository;

        public RepositoryBase&lt;Cliente&gt; ClienteRepository
        {
            get
            {
                if (this._clienteRepository == null)
                {
                    this._clienteRepository = new RepositoryBase&lt;Cliente&gt;(_context);
                }

                return _clienteRepository;
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        private void Clear(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }

    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Context;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Domain;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UnitOfWork&nbsp;:&nbsp;IDisposable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Contexto&nbsp;_context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Contexto();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;RepositoryBase&lt;Cliente&gt;&nbsp;_clienteRepository;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RepositoryBase&lt;Cliente&gt;&nbsp;ClienteRepository&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>._clienteRepository&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>._clienteRepository&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RepositoryBase&lt;Cliente&gt;(_context);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_clienteRepository;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;_disposed&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clear(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GC.SuppressFinalize(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Clear(<span class="cs__keyword">bool</span>&nbsp;disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">this</span>._disposed)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_disposed&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~UnitOfWork()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clear(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Por ultimo adicionaremos ao projeto um arquivo de configura&ccedil;&atilde;o chamado &quot;App.config&quot; que tera nossa connectionstring. Vejamos o exemplo abaixo:</span></div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;</span></div>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;configuration&gt;
    &lt;connectionStrings&gt;
        &lt;add name=&quot;estudoContext&quot; connectionString=&quot;persistsecurityinfo=True;server=localhost;user id=root;password=SUASENHA;database=estudo&quot; providerName=&quot;MySql.Data.MySqlClient&quot; /&gt;
    &lt;/connectionStrings&gt;
&lt;/configuration&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;configuration</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;estudoContext&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;persistsecurityinfo=True;server=localhost;user&nbsp;id=root;password=SUASENHA;database=estudo&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;MySql.Data.MySqlClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/configuration&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Ap&oacute;s isso adicionaremos um novo projeto do tipo &quot;Unit Teste Project&quot; nomeando-o de &quot;Respository.UnitTest&quot; ficando nosso projeto como na imagem abaixo:&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><img id="132604" src="132604-2.jpg" alt="" width="277" height="338"></span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
</div>
</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Dentro da classe &quot;ClienteUnitTest.cs&quot; teremos nossos m&eacute;todos de teste como no c&oacute;digo abaixo:</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using Repository.Domain;
using Repository.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repository.UnitTest
{
    [TestClass]
    public class ClienteUnitTest
    {
        UnitOfWork _unitOfWork = new UnitOfWork();   

        [TestMethod]
        public void Adicionar()
        {
            Cliente novoCliente = new Cliente();

            novoCliente.nome = &quot;John Doel&quot;;
            novoCliente.email = &quot;john.doel@hotmail.com&quot;;
            novoCliente.endereco = &quot;Avenue: 7th Rummel Pax 289&quot;;
            novoCliente.bairro = &quot;St Pitsburg&quot;;
            novoCliente.cidade = &quot;Austin&quot;;
            novoCliente.uf = &quot;TX&quot;;

            _unitOfWork.ClienteRepository.Add(novoCliente);
        }

        [TestMethod]
        public void Editar()
        {
            Cliente editarCliente = _unitOfWork.ClienteRepository.Get(x =&gt; x.id == 1000)[0];

            editarCliente.nome = &quot;John Doel Gates&quot;;
            editarCliente.email = &quot;john.doel.gates@msn.com&quot;;
            editarCliente.endereco = &quot;Street: Philadelph 289&quot;;

            _unitOfWork.ClienteRepository.Add(editarCliente);
        }

        [TestMethod]
        public void Deletar()
        {
            Cliente deletarCliente = _unitOfWork.ClienteRepository.Get(x =&gt; x.id == 1000)[0];
            _unitOfWork.ClienteRepository.Delete(deletarCliente);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Domain;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Repository.Context;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Repository.UnitTest&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestClass]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ClienteUnitTest&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UnitOfWork&nbsp;_unitOfWork&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnitOfWork();&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Adicionar()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cliente&nbsp;novoCliente&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Cliente();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.nome&nbsp;=&nbsp;<span class="cs__string">&quot;John&nbsp;Doel&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.email&nbsp;=&nbsp;<span class="cs__string">&quot;john.doel@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.endereco&nbsp;=&nbsp;<span class="cs__string">&quot;Avenue:&nbsp;7th&nbsp;Rummel&nbsp;Pax&nbsp;289&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.bairro&nbsp;=&nbsp;<span class="cs__string">&quot;St&nbsp;Pitsburg&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.cidade&nbsp;=&nbsp;<span class="cs__string">&quot;Austin&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;novoCliente.uf&nbsp;=&nbsp;<span class="cs__string">&quot;TX&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_unitOfWork.ClienteRepository.Add(novoCliente);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Editar()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cliente&nbsp;editarCliente&nbsp;=&nbsp;_unitOfWork.ClienteRepository.Get(x&nbsp;=&gt;&nbsp;x.id&nbsp;==&nbsp;<span class="cs__number">1000</span>)[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;editarCliente.nome&nbsp;=&nbsp;<span class="cs__string">&quot;John&nbsp;Doel&nbsp;Gates&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;editarCliente.email&nbsp;=&nbsp;<span class="cs__string">&quot;john.doel.gates@msn.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;editarCliente.endereco&nbsp;=&nbsp;<span class="cs__string">&quot;Street:&nbsp;Philadelph&nbsp;289&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_unitOfWork.ClienteRepository.Add(editarCliente);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Deletar()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cliente&nbsp;deletarCliente&nbsp;=&nbsp;_unitOfWork.ClienteRepository.Get(x&nbsp;=&gt;&nbsp;x.id&nbsp;==&nbsp;<span class="cs__number">1000</span>)[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_unitOfWork.ClienteRepository.Delete(deletarCliente);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Se tudo der certo em nossos testes estaremos ent&atilde;o finalizado e implementado uma camada de dados com suas entidades e configura&ccedil;&otilde;es, independentemente das outras camadas, podemos
 observar que n&atilde;o utilizamos em nenhum momento arquivos .edmx</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="132605" src="132605-3.jpg" alt="" width="273" height="341"></div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">Altera&ccedil;&atilde;o executada no banco de dados :</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><img id="132606" src="132606-4.jpg" alt="" width="733" height="202"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
