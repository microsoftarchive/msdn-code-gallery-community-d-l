# Data Analysis Sample - Visual Studio 2010
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Office
- Microsoft Office Excel 2007
## Topics
- Office
- Data Analysis
## Updated
- 04/04/2012
## Description

<div class="introduction">
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left"><strong>Remarque&nbsp;:</strong></th>
</tr>
<tr>
<td>
<p>Cet exemple s'ex&eacute;cute dans Microsoft Office Excel&nbsp;2007 et versions ult&eacute;rieures.</p>
</td>
</tr>
</tbody>
</table>
</div>
<p>Cet exemple montre des t&acirc;ches d'analyse des donn&eacute;es ex&eacute;cut&eacute;es &agrave; l'aide des boutons de barre d'outils et des menus dans Microsoft Office Excel&nbsp;2007. Les donn&eacute;es sont stock&eacute;es dans les fichiers XML.</p>
<p>Par ailleurs, cet exemple est enti&egrave;rement localisable&nbsp;; il illustre comment tirer parti de System.Resources..::.ResourceManager et des fichiers de ressources manag&eacute;es (RESX). Le code a &eacute;t&eacute; &eacute;crit en vue d'&ecirc;tre
 globalis&eacute; &agrave; l'aide de techniques de commutation de culture qui &eacute;taient n&eacute;cessaires dans les versions ant&eacute;rieures de Visual Studio Tools pour Office. Ces techniques ne sont plus n&eacute;cessaires en raison d'une modification
 apport&eacute;e au fonctionnement de Visual Studio Tools pour Office avec Excel. Pour plus d'informations, consultez Globalisation et localisation de solutions Office, Mise en forme de donn&eacute;es dans Excel avec diff&eacute;rents param&egrave;tres r&eacute;gionaux,
 et Comment&nbsp;: rendre les litt&eacute;raux de cha&icirc;ne s&eacute;curis&eacute;s du point de vue de la r&eacute;gion dans Excel &agrave; l'aide de la r&eacute;flexion.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left"><strong>Remarque&nbsp;:</strong></th>
</tr>
<tr>
<td>
<p>Cet exemple n'est pas ex&eacute;cut&eacute; si vous disposez d'une version en anglais d'Office fonctionnant sous Windows avec les param&egrave;tres r&eacute;gionaux autres que l'anglais (&Eacute;tats-Unis).</p>
</td>
</tr>
</tbody>
</table>
</div>
<p>L'exemple est un outil de gestion de stocks simple pour un magasin de glaces fictif. Le classeur poss&egrave;de des syst&egrave;mes pour le suivi des ventes, du stock et des produits vendus. Chacun de ces syst&egrave;mes stocke les donn&eacute;es dans des
 fichiers XML.</p>
<p>Les stocks du magasin sont r&eacute;gis par les contraintes suivantes&nbsp;:</p>
<ul>
<li>
<p>La capacit&eacute; de stockage est limit&eacute;e &agrave; 300&nbsp;unit&eacute;s de glaces.</p>
</li><li>
<p>Les commandes de glaces sont livr&eacute;es une fois par semaine, le matin.</p>
</li><li>
<p>Les commandes doivent &ecirc;tre pass&eacute;es au moins deux jours avant la date de livraison planifi&eacute;e. Le planning pr&eacute;voit le passage et la r&eacute;ception des commandes chaque mardi et jeudi, respectivement.</p>
</li><li>
<p>La livraison de toute marchandise requise en dehors de ce planning entra&icirc;nera des co&ucirc;ts suppl&eacute;mentaires d'un montant &eacute;gal &agrave;&nbsp;25.</p>
</li></ul>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left"><strong>Note de s&eacute;curit&eacute;&nbsp;:</strong></th>
</tr>
<tr>
<td>
<p>Cet exemple de code a pour but d'illustrer un concept et affiche uniquement le code pertinent pour ce concept. Il peut ne pas r&eacute;pondre aux exigences de s&eacute;curit&eacute; d'un environnement sp&eacute;cifique et ne doit pas &ecirc;tre utilis&eacute;
 tel quel. Nous vous conseillons d'ajouter un code de gestion des erreurs et de s&eacute;curit&eacute; afin de renforcer la s&eacute;curit&eacute; et la fiabilit&eacute; de vos projets. Microsoft fournit cet exemple de code &laquo;&nbsp;EN L'&Eacute;TAT&nbsp;&raquo;,
 sans garantie d'aucune sorte.</p>
</td>
</tr>
</tbody>
</table>
</div>
<p>Pour plus d'informations sur la fa&ccedil;on d'installer l'exemple de projet sur votre ordinateur, consultez la rubrique Comment&nbsp;: installer et utiliser des exemples de fichiers trouv&eacute;s dans l'aide.</p>
</div>
<h3 class="procedureSubHeading">Pour ex&eacute;cuter cet exemple</h3>
<div class="subSection">
<ol>
<li>
<p>Appuyez sur&nbsp;F5.</p>
<p>Le classeur s'ouvre dans la feuille de calcul Inventory, qui contient un tableau crois&eacute; dynamique des ventes quotidiennes moyennes et des b&eacute;n&eacute;fices quotidiens moyens par parfum, ainsi qu'un contr&ocirc;le ListObject qui indique les donn&eacute;es
 de ventes de la journ&eacute;e pr&eacute;c&eacute;dente. Notez que deux groupes, appel&eacute;s respectivement<span class="ui">Commandes de menu</span>&nbsp;et&nbsp;<span class="ui">Barres d'outils personnalis&eacute;es</span>, ont &eacute;t&eacute; ajout&eacute;s
 &agrave; l'onglet&nbsp;<span class="ui">Compl&eacute;ments</span>&nbsp;du Ruban. Un menu&nbsp;<span class="ui">Orders</span>&nbsp;a &eacute;t&eacute; ajout&eacute; au groupe&nbsp;<span class="ui">Commandes de menu</span>&nbsp;et deux boutons correspondant
 aux deux &eacute;l&eacute;ments de menu ont &eacute;t&eacute; ajout&eacute;s au groupe&nbsp;<span class="ui">Barres d'outils personnalis&eacute;es</span>.</p>
</li><li>
<p>Consultez les donn&eacute;es historiques des ventes en s&eacute;lectionnant une date diff&eacute;rente dans le contr&ocirc;le Calendar. Si vous s&eacute;lectionnez le dernier jour des donn&eacute;es dans la source de donn&eacute;es, deux colonnes suppl&eacute;mentaires
 (<span class="ui">Estimated Inventory</span>&nbsp;et&nbsp;<span class="ui">Recommendation</span>) s'affichent.</p>
</li><li>
<p>Cliquez sur&nbsp;<span class="ui">Add New Date</span>&nbsp;afin d'ajouter des donn&eacute;es pour un nouveau jour.</p>
<p>Le contr&ocirc;le ListObject est effac&eacute;, de sorte que vous puissiez entrer les valeurs d'inventaire de fin de journ&eacute;e pour chaque parfum. Alors que vous entrez l'inventaire en cours pour chaque parfum de glace, la colonne&nbsp;<span class="ui">Estimated
 Inventory</span>&nbsp;affiche les d&eacute;ficits ou les exc&eacute;dents attendus en fin de semaine. La colonne&nbsp;<span class="ui">Recommendation</span>indique s'il est recommand&eacute; de cr&eacute;er une commande non planifi&eacute;e. Le volet Actions
 affiche une liste d'&eacute;l&eacute;ments d'inventaire hauts et d'&eacute;l&eacute;ments d'inventaire bas.</p>
</li><li>
<p>Cliquez sur&nbsp;<span class="ui">Enregistrer les donn&eacute;es</span>&nbsp;pour enregistrer les modifications apport&eacute;es.</p>
</li><li>
<p>Cliquez sur un parfum de glace dans l'une des listes du volet Actions.</p>
<p>Les donn&eacute;es historiques des ventes et un diagramme de tendance relatif &agrave; ce parfum apparaissent dans la feuille de calcul Details.</p>
</li><li>
<p>Si une commande non planifi&eacute;e est recommand&eacute;e, cliquez sur&nbsp;<span class="ui">Create</span>&nbsp;pour d&eacute;terminer les parfums et la quantit&eacute; &agrave; commander.</p>
</li><li>
<p>Une nouvelle feuille de calcul nomm&eacute;e&nbsp;<span class="ui">Unscheduled Order_</span><span class="placeholder">&lt;Date&gt;</span>&nbsp;est ajout&eacute;e au classeur. La feuille de calcul &eacute;value la quantit&eacute; de chaque parfum de glace
 qui doit &ecirc;tre command&eacute;e afin d'&eacute;viter toute p&eacute;nurie pour le reste de la semaine.</p>
</li><li>
<p>Cliquez sur&nbsp;<span class="ui">Create Weekly Order</span>&nbsp;dans le menu&nbsp;<span class="ui">Orders</span>&nbsp;pour cr&eacute;er la commande hebdomadaire.</p>
<p>Les informations de ventes sont lues &agrave; partir des fichiers XML pour les deux semaines pr&eacute;c&eacute;dentes, la moyenne des ventes quotidiennes est calcul&eacute;e, et un &eacute;cart type de distribution est d&eacute;termin&eacute;. Les futures
 ventes sont estim&eacute;es &agrave; partir de la moyenne des ventes journali&egrave;res &agrave; laquelle sont ajout&eacute;s deux &eacute;carts types, puis ce chiffre est multipli&eacute; par sept jours. Il en r&eacute;sulte une probabilit&eacute; de 95,4&nbsp;%
 que la quantit&eacute; command&eacute;e couvrira les ventes pr&eacute;vues pour la semaine.</p>
<p>Une nouvelle feuille de calcul nomm&eacute;e&nbsp;<span class="ui">Weekly Order_</span><span class="placeholder">&lt;Date&gt;</span>&nbsp;est ajout&eacute;e au classeur.&nbsp;<span class="placeholder">&lt;Date&gt;</span>&nbsp;est la date de commande
 pr&eacute;vue.</p>
</li></ol>
</div>
<h1 class="heading"><span>Fonctionnement</span></h1>
<div class="section" id="demonstratesSection">
<p>Cet exemple illustre les t&acirc;ches suivantes&nbsp;:</p>
<ul>
<li>
<p>Lecture de donn&eacute;es depuis des fichiers XML.</p>
</li><li>
<p>Personnalisation des menus et des barres d'outils.</p>
</li><li>
<p>Utilisation de fonctions int&eacute;gr&eacute;es d'Excel pour analyser des donn&eacute;es.</p>
</li><li>
<p>Cr&eacute;ation de tableaux crois&eacute;s dynamiques li&eacute;s &agrave; des donn&eacute;es dans des fichiers XML.</p>
</li><li>
<p>Liaison de donn&eacute;es XML aux contr&ocirc;les de liste Excel.</p>
</li><li>
<p>Cr&eacute;ation de graphiques.</p>
</li><li>
<p>Pr&eacute;paration de la pr&eacute;sentation de l'interface utilisateur et des cha&icirc;nes en vue de leur localisation.</p>
</li></ul>
</div>
