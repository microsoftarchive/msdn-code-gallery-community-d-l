Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Globalization
Imports System.Resources
Imports System.Windows

' Le informazioni generali relative a un assembly sono controllate dal seguente 
' insieme di attributi. Per modificare le informazioni associate a un assembly
' è necessario modificare i valori di questi attributi.

' Controllare i valori degli attributi dell'assembly

<Assembly: AssemblyTitle("Multibinding.vb")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Multibinding.vb")> 
<Assembly: AssemblyCopyright("Copyright ©  2013")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: ComVisible(false)>

'Per iniziare la compilazione delle applicazioni localizzabili, impostare 
'<UICulture>CultureYouAreCodingWith</UICulture> nel file VBPROJ
'all'interno di un <PropertyGroup>. Ad esempio, se si utilizza l'inglese (Stati Uniti) 
'nei file di origine, impostare <UICulture> su "en-US". Rimuovere quindi il commento
'dall'attributo NeutralResourceLanguage seguente. Aggiornare "en-US" nella riga
'seguente in modo che corrisponda all'impostazione di UICulture nel file di progetto.

'<Assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)> 


'L'attributo ThemeInfo indica la possibile posizione dei dizionari risorse generici e specifici del tema.
'Primo parametro: posizione dei dizionari risorse specifici del tema
'(in uso se non è possibile trovare una risorsa nella pagina 
' oppure nei dizionari delle risorse dell'applicazione)

'Parametro 2: posizione del dizionario risorse generico
'(in uso se non è possibile trovare una risorsa nella pagina 
'un'applicazione e alcun dizionario risorse specifico del tema)
<Assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)>



'Se il progetto viene esposto a COM, il GUID seguente verrà utilizzato come ID della libreria dei tipi
<Assembly: Guid("7c769b3a-709e-433b-b02e-949109a8735f")> 

' Le informazioni sulla versione di un assembly sono costituite dai seguenti quattro valori:
'
'      Numero di versione principale
'      Numero di versione secondario 
'      Numero build
'      Revisione
'
' È possibile specificare tutti i valori oppure impostare valori predefiniti per i numeri relativi alla revisione e alla build 
' utilizzando l'asterisco (*) come descritto di seguito:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 
