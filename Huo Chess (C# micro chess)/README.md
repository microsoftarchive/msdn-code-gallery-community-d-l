# Huo Chess (C# micro chess)
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Studio 2012
- Visual Studio 2013
- AI
- Visual Studio 2015
- Visual Studio 2017
## Topics
- Games
- Algorithm
- Chess algorithm
- Artificial Intelligence
- MiniMax
## Updated
- 02/20/2019
## Description

<h1>Introduction</h1>
<p><strong>Huo Chess</strong> by Spiros (Spyridon) Kakos (<a href="https://harmoniaPhilosophica.com">harmoniaPhilosophica.com</a>) is a free and fully open source micro chess program (available in C#, with the older versions also available in&nbsp;C&#43;&#43;, VB,
 XNA) that attempts to be smaller in size than the Commodore-era Microchess. The goal is to create the smallest chess program that exists. More versions are to come in the future. Please read the analytical article at
<a class="externalLink" href="http://www.codeproject.com/KB/game/cpp_microchess.aspx">
<span style="color:#3e62a6">http://www.codeproject.com/KB/game/cpp_microchess.aspx</span></a><span style="color:#30332d"> for an explanation of the chess engine algorithm. You can also find a tutorial on how to develop a chess program at
<a href="https://harmoniaPhilosophica.com/2011/09/28/how-to-develop-a-chess-program-for-2jszrulazj6wq-23/">
https://harmoniaPhilosophica.com/2011/09/28/how-to-develop-a-chess-program-for-2jszrulazj6wq-23/</a>.</span></p>
<h1><span>Building the Sample</span></h1>
<p>Current version is built with Visual Studio 2015/ 2017&nbsp;but can be also edited with Visual Studio 2013 &amp; 2015. Use Microsoft Visual Studio 2008, 2010 and 2012 to build the code of older versions (all available in
<a href="http://www.codeproject.com/Articles/20736/C-C-CLI-Micro-Chess-Huo-Chess" target="_blank">
Codeproject Huo Chess site</a>).</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The current version of Huo Chess is in <strong>C#&nbsp;</strong>and has been developed with&nbsp;<strong>Microsoft Visual Studio 2015/ 2017</strong>. I officially started developing the program in CLI C&#43;&#43; v8.0 (with Visual Studio 2008) and I named it &quot;Huo
 Chess&quot; for personal reasons (although the origins of the idea and the name date back to my Commodore 128 years).
<strong>The C&#43;&#43;, VB&nbsp;and</strong><strong> XNA Editions </strong>where updated until version 0.82.</p>
<p>Currently the last Huo Chess C# console application version 0.991 is <strong>45 KB in size</strong> (this size refers to the Console edition without a GUI), while the Huo Chess windows application with GUI is only
<strong>77 KB</strong> in size.&nbsp;The respective emulation of Microchess (the first microchess from the Commodore era) in C is 56 KB. However, it must be noted that
<em>the original Microchess, written in pure Assembly, was about 1 KB (</em><a class="externalLink" href="http://www.benlo.com/microchess/microchess1.html"><em>http://www.benlo.com/microchess/microchess1.html</em></a><em>)&hellip;something I believe no one
 will ever match!</em></p>
<p>Huo Chess plays decent chess and has managed to <strong>draw Microchess</strong>, but unfortunately will probably lose if it plays with Garry Kasparov :) It thinks up to 3 half-moves (this corresponds to Thinking_Depth = 2 in the code; note that the thinking
 starts from move 0) but can potentially think up to 5 half-moves (if you set Thinking_Depth to 4, but there are memory implications in doing that and the thinking tree must be trimmed so I will post this in a next version) Its algorithm can be used to study
 the underlying logic of a chess program or as a basis for your own chess program. You are free to reuse it in any way, as long as the source is properly cited.</p>
<p>The program implements the <strong>MiniMax algorithm</strong>. Huo Chess plays with the material in mind, while its code has some hints of positional strategic playing embedded.
<strong>More analytically: When the program starts thinking</strong>, it scans the chessboard to find where its pieces are (see
<em>ComputerMove</em> function) and then tries all possible moves it can make. It analyzes these moves up to the thinking depth I have defined (via the
<em>ComputerMove</em> -&gt; <em>Analyze_Move_1_HumanMove</em>&nbsp;-&gt;&nbsp;<em>Analyze_Move_2_ComputerMove</em>&nbsp;path), measures the score (see
<em>CountScore</em> function) of the final position reached from all possible move variants and &ndash; finally &ndash; chooses the move that leads to the most promising (from a score point of view) position (<em>ComputerMove</em> function).</p>
<p><img id="123672" src="http://i1.code.msdn.s-msft.com/windowsapps/huo-chess-c-c-vb-micro-fea2bb87/image/file/123672/1/huo%20chess%200_961%20algorithm_1_small.jpg" alt="" width="600" height="508"><br>
<br>
IMPORTANT NOTE by Author [Spyridon I. Kakos]: Huo Chess is intelligently designed, but it also evolves. The current version is stable. If you happen to play with Huo Chess and find any problems, make sure to tell me so that I can see what the problem is and
 try to fix it. Thanks in advance for your feedback and comments!</p>
<h1><span>Source Code Files</span></h1>
<p><em>In this project the following files are available for free download:</em></p>
<ul>
<li><em><em><em><em>Source code files of Huo Chess v0.991 Windows Application with GUI (ready to compile)</em></em></em></em>
</li><li><em><em><em><em>The executables of <em><em><em><em>Huo Chess v0.991 Windows Application with GUI</em></em></em></em></em></em></em></em>
</li><li><em><em><em><em>Source code and executables for the Huo Chess console application [inside the &quot;Other editions&quot; folder]</em></em></em></em>
</li><li><em>Source code and executables for the Huo Chess console application with GUI [&quot;Other editions&quot; folder]</em>
</li><li><em>Source code and executables for the Huo Chess Developers Edition, which contains analytical logs to document and analyze the thinking mechanism [&quot;Other editions&quot; folder]</em>
</li><li><em><em><em><em>Huo Chess Thought process v0.24 document describing the thought process</em></em></em></em>
</li></ul>
<h1>More Information</h1>
<p>For games played by Huo Chess and for an <strong>analytical explanation of its underlying logic</strong>, see
<a class="externalLink" href="http://www.codeproject.com/KB/game/cpp_microchess.aspx">
http://www.codeproject.com/KB/game/cpp_microchess.aspx</a>.</p>
<p>For a tutorial on how to develop a chess software application on your own see the following tutorial (these tutorials are based on the Huo Chess and are written by the creator of Huo Chess himself, i.e. me):</p>
<ul>
<li><a href="http://harmoniaphilosophica.wordpress.com/2011/09/28/how-to-develop-a-chess-program-for-2jszrulazj6wq-23/" target="_blank">How to Develop a Chess Program for Dummies</a> @ the
<a href="https://harmoniaphilosophica.com/">Harmonia Philosophica</a> portal. </li><li><a href="https://harmoniaphilosophica.com/2018/07/23/how-to-code-a-chess-program-in-one-day-c-and-java-examples/">How to code a chess program in one day. (C# and Java examples)</a>
</li></ul>
<p>The C# version files distributed here contain the Huo Chess 0.991 Windows Application version (which includes a GUI). The other versions (the console application with and without GUI) are being distributed in a folder &quot;Other versions&quot; inside the distributed
 folder (because the site does not allow uploading of different versions of the same program in different files).</p>
