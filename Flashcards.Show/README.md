# Flashcards.Show
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- WPF
- Microsoft Azure
- Windows Phone 7
## Topics
- Windows
- Cross Platform Code Reuse
## Updated
- 02/24/2011
## Description

<p><img src="18551-flashcardlogo.png" alt="" width="710" height="138"></p>
<p>Have you ever needed to memorize a number of objects&rsquo; names, such as word definitions in a new language, animals' names, people&rsquo;s names, or tree leaf shape nomenclature? If you did, you might have employed a useful tool, known as the flashcard.
 By creating cards with questions, pictures, or terms on one side and answers, names, and descriptions on the other side, you can more easily perform the rote memorization of a category of things. This application takes that concept and makes it easy for you
 to produce decks of flashcards and also enables you to play three different types of games that make it easy and fun to learn</p>
<p><strong><em>Version 2 </em></strong></p>
<p>In version 2 we added support for Silverlight , Windows Phone, and Windows Azure. This version includes</p>
<ul>
<li>ClickOnce installation for quick and easy installation and distribution </li><li>Sharing of decks via Azure - Now you can&nbsp;easily share your decks&nbsp;with friends
</li><li>Silverlight application that lets you view shared decks from any supported browser
</li><li>Windows Phone implemintation </li></ul>
<p><strong>Getting Started</strong><br>
This is a demo application that anyone can install and enjoy. However if you are a developer, there is a surprise. We also include the source code for this sample and you can download the entire source code to learn how to write cool Windows 7 applications
 using features like the Taskbar and Windows Touch.</p>
<p><strong>Installing the Sample</strong><br>
You can use the <a href="http://flashcardsshowclient.blob.core.windows.net/flashcards/WPFClient/FlashCards.Show.application">
Flashcards.Show ClickOnce installer</a>. This will install the application into the appropriate Program Files folder and creates start menu shortcuts for running the application in Admin mode and Game mode. After the installer finishes, you can run the application
 in either Admin mode or Game mode.<br>
<br>
<strong>Running the Application in Admin Mode</strong><br>
The admin mode of the application is used to manage the deck of cards that are available with the application install. When you first run the application in&nbsp;admin mode, you can edit existing decks or create a new deck. Each deck includes cards and these
 cards can include few different content elements such as text, image, video, and sound.<br>
<br>
<strong>Using the Application in Game Mode</strong><br>
When the application starts, the currently available decks will appear on the screen. You can navigate through the list of available decks using the arrow<br>
button, by using the mouse to scroll, or by using your fingers touching the decks strip. When a deck is selected, buttons for the available games for the<br>
deck appear below the deck. Clicking these buttons will start one of the following games.</p>
<ul>
<li>Learning game </li><li>Matching game </li><li>Memory game </li></ul>
<p><strong>Working With Visual Studio</strong><br>
<strong>Before</strong> you can run Windows WPF the application from Visual Studio, make sure you
<strong><a href="http://flashcardsshowclient.blob.core.windows.net/flashcards/WPFClient/FlashCards.Show.application">install</a> the application!</strong> The Windows WPF app will NOT run properly from Visual studio without&nbsp;installing it first.</p>
<p>The solution found in the FlashCardsSolution_Source.zip file includes a&nbsp;FlashCardsSolutionWithOutWindowsAzure.sln Visual Studio solution file that contains all the client projects (WPF, SL, and WP) but not the Windows Azure. The FlashCardsSolution_Full_WithWindowsAzure.sln&nbsp;Visual
 Studio solution file, found in the WindowsAzureServices, is the complete solution for all projects including Windows Azure. You'll need to install the Windows Azure SDK.</p>
<p>To fully compile the application source code you will need to install:</p>
<ul>
<li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en">Windows 7 SDK</a>
</li><li><a href="http://www.microsoft.com/expression/products/Blend_Overview.aspx">Microsoft Expression Blend</a> 3 (or higher)
</li><li>Windows Azure SDK and Windows Azure Tools for Microsoft Visual Studio (<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018">November</a> 2010 or higher)
</li></ul>
