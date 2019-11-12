# Introduction to Entity Framework with C#, part I
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ADO.NET Entity Framework
- Entity Framework
## Topics
- C#
- SQL Server
- ADO.NET Entity Framework
- LINQ
- Entity Framework
## Updated
- 05/27/2016
## Description

<h1>Introduzione</h1>
<p><br>
<span>In questo articolo, primo di una breve serie, vedremo come poter utilizzare&nbsp;</span><strong>Entity Framework</strong><span>&nbsp;nelle nostre applicazioni, sviluppate mediante i vari linguaggi che Visual Studio ci consente di utilizzare. Negli esempi
 riportati in questo articolo, e probabilmente nei successivi, verr&agrave; fatto uso di&nbsp;</span><strong>C#</strong><span>&nbsp;in ambito WinForms, ma - come detto - questa scelta non andr&agrave; ad inficiare una diversa destinazione d'utilizzo che lo
 sviluppatore potr&agrave; ritenere opportuna.</span><br>
<br>
</p>
<h1><a name="Cos_è_Entity_Framework"></a><a name="Cos_è_Entity_Framework"></a><a name="Cos_è_Entity_Framework"></a><a name="Cos_è_Entity_Framework"></a>Cos'&egrave; Entity Framework</h1>
<p><br>
<span>Entity Framework (da qui in poi, EF) &egrave; il framework ORM (object-relational mapping) che Microsoft ci mette a disposizione nell'ambito dello sviluppo .NET (dalla versione 3.5 SP1 in poi). La sua finalit&agrave; &egrave; quella di astrarre i legami
 ad un database relazionale, facendo in modo che lo sviluppatore possa rapportarsi alle entit&agrave; di database come ad un insieme di oggetti, e quindi a classi e loro propriet&agrave;. Vengono rese trasparenti le fasi di connessione al database, come anche
 le istruzioni che la nostra applicazione dovr&agrave; inviare in linguaggio nativo al database stesso. In sostanza, parliamo di un disaccoppiamento tra le nostre applicazioni e la logica di accesso ai dati: questo si rivela un plus importante, per esempio,
 se dovessimo aver necessit&agrave; di passare - nell'ambito di uno stesso programma - a database di produttori differenti, in quanto non sarebbe richiesto di rivedere il modo e le istruzioni con cui ci interfacciamo al gestore dati di turno.</span><br>
<br>
</p>
<h1><a name="Approcci_di_utilizzo_di_Entity_Framework"></a>Approcci di utilizzo di Entity Framework</h1>
<p><br>
<span>Allo stato attuale, EF permette principalmente due tipi di approccio legati al suo impiego. Essi sono Database-First e Code-First (il primo dei quali assente a partire da EF7, ma ancora valido fino alla versione 6.1.3). La differenza tra i due approcci
 &egrave; evidente fin dal loro nome: con Database-First, ci troviamo nella condizione in cui dobbiamo modellare un database pre-esistente (e quindi, partire da esso per derivare i nostri oggetti), mentre nella modalit&agrave; Code-First, saranno le nostre
 classi - che dovremo redigere assegnando loro le propriet&agrave; rappresentanti i campi di tabella - a determinare la struttura della base dati. Un punto importante da notare su quest'ultima osservazione, &egrave; che Code-First non ci obbliga necessariamente
 a lavorare inizialmente in assenza di database: potremo infatti modellare le classi di un database esistente, e connetterci ad esso per effettuare le consuete operazioni di I/O. Possiamo affermare che i due approcci, al di l&agrave; di alcune particolarit&agrave;
 strumentali che vedremo, rappresentino una sorta di indice di priorit&agrave; rispetto a chi comanda nel determinare la struttura dei dati con cui l'applicazione avr&agrave; a che fare: &quot;prima il database&quot; (da cui derivano le classi) o &quot;prima il codice&quot; (da
 cui pu&ograve; essere strutturato un modello di base dati)<br>
<br>
<br>
<span style="font-size:small">Continua la lettura dell'articolo qui:&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/34420.introduzione-ad-entity-framework-con-c-parte-i.aspx" target="_blank">http://social.technet.microsoft.com/wiki/contents/articles/34420.introduzione-ad-entity-framework-con-c-parte-i.aspx&nbsp;</a></span></span></p>
