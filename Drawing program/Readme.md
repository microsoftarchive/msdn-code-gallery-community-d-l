# Drawing program
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Win32
- C++
## Topics
- Windows Store Apps Develoment
## Updated
- 06/26/2016
## Description

<h1></h1>
<p><span style="font-size:medium">Hello it's me again,Gordan!!!I've created a drawing program using Win32 api(with GDI) and C&#43;&#43;.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Here is a little snippet of the code:</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">LRESULT CALLBACK WinProc2(HWND hwnd2, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case 1:
			changeBCK(hwnd, 0, 0, 0);
			if (isBlue == true)
			{
				changeBCK(hwnd, 0, 0, 255);
				isRed = false;
				isGreen = false;
				isYellow = false;
			}
			if (isRed == true)
			{
				changeBCK(hwnd, 255, 0, 0);
				isBlue = false;
				isYellow = false;
				isGreen = false;
			}
			if (isGreen == true)
			{
				changeBCK(hwnd, 0, 255, 0);
				isRed = false;
				isYellow = false;
				isBlue = false;
			}
			if (isYellow == true)
			{
				changeBCK(hwnd, 255, 255, 0);
				isRed = false;
				isGreen = false;
				isBlue = false;
			}
			break;
		case 2:
			isBlue = true;
			isRed = false;
			isGreen = false;
			isYellow = false;
			break;
		case 3:
			isRed = true;
			isBlue = false;
			isYellow = false;
			isGreen = false;
			break;
		case 4:
			isGreen = true;
			isRed = false;
			isYellow = false;
			isBlue = false;
			break;
		case 5:
			isYellow = true;
			isRed = false;
			isBlue = false;
			isGreen = false;
			break;
		case 6:
			isEraserActive = true;
			break;
		case 7:
			isText = true;
			break;
		case 8:
			isLine = true;
			break;
		case 9:
			isMLine = true;
			break;
		case 10:
			isYellow = false;
			isRed = false;
			isBlue = false;
			isGreen = false;
			break;
		case 11:
			isRect = true;
			break;
		case 12:
			isEllipse = true;
			break;
		case 14:
			isTriangle = true;
			break;
		case 13:
			isPentagon = true;
			break;
		case 15:
			isStar = true;
			break;
		case 16:
			isFourStar = true;
			break;
		case 17:
			isHex = true;
			break;
		case 18:
			isStarSix = true;
			break;
		case 19:
			isSolid = true;
			isDashed = false;
			break;
		case 20:
			isSolid = false;
			isDashed = true;
			break;
		}
		break;
	case WM_CLOSE:
		DestroyWindow(hwnd2);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hwnd2, msg, wParam, lParam);
		break;
	}
	return 0;
}</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;WinProc2(<span class="cpp__datatype">HWND</span>&nbsp;hwnd2,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;msg,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(msg)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(LOWORD(wParam))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">1</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changeBCK(hwnd,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(isBlue&nbsp;==&nbsp;<span class="cpp__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changeBCK(hwnd,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">255</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(isRed&nbsp;==&nbsp;<span class="cpp__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changeBCK(hwnd,&nbsp;<span class="cpp__number">255</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(isGreen&nbsp;==&nbsp;<span class="cpp__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changeBCK(hwnd,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">255</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(isYellow&nbsp;==&nbsp;<span class="cpp__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changeBCK(hwnd,&nbsp;<span class="cpp__number">255</span>,&nbsp;<span class="cpp__number">255</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">2</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">3</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">4</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">5</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">6</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isEraserActive&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">7</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isText&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">8</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isLine&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">9</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isMLine&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">10</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isYellow&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isBlue&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isGreen&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">11</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isRect&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">12</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isEllipse&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">14</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isTriangle&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">13</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isPentagon&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">15</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isStar&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">16</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isFourStar&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">17</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isHex&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">18</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isStarSix&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">19</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isSolid&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isDashed&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">20</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isSolid&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isDashed&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_CLOSE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DestroyWindow(hwnd2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_DESTROY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostQuitMessage(<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;DefWindowProc(hwnd2,&nbsp;msg,&nbsp;wParam,&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span><span class="cpp__number">0</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><span style="font-size:large">Ok so let's talk a little bit about the program:</span></strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><span style="font-size:large">1.The tools,shapes and colors are all in the context menu.How you access the context menu is by right clicking.</span></strong></div>
<div class="endscriptcode"><strong><span style="font-size:large">2.There are still some bugs like:</span></strong></div>
<div class="endscriptcode"><strong><span style="font-size:large">-It won't open or save a file(pls contact me I need your help with this I've tried to implement this but I failed like a 100 times)</span></strong></div>
<div class="endscriptcode"><strong><span style="font-size:large">-It won't change the pen style</span></strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:medium"><strong>-Keyboard input(pls contact me I need your help with this I've tried to implement this but I failed like a 100 times)</strong></span></div>
<div class="endscriptcode"><strong><span style="font-size:large"><br>
</span></strong></div>
<div class="endscriptcode"><strong><span style="font-size:large">The definition of Art</span></strong></div>
<div class="endscriptcode"></div>
</em>
<p></p>
<p><strong>Art</strong>&nbsp;is a diverse range of&nbsp;<a title="Human behavior" href="https://en.wikipedia.org/wiki/Human_behavior">human activities</a>&nbsp;in creating visual, auditory or performing artifacts (<a class="mw-redirect" title="Artworks" href="https://en.wikipedia.org/wiki/Artworks">artworks</a>),
 expressing the author's&nbsp;<a title="Imagination" href="https://en.wikipedia.org/wiki/Imagination">imaginative</a>&nbsp;or technical skill, intended to be appreciated for their beauty or emotional power.<sup id="cite_ref-OD_1-0" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-OD-1">[1]</a></sup><sup id="cite_ref-MW_2-0" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-MW-2">[2]</a></sup>&nbsp;In
 their most general form these activities include the production of works of art, the criticism of art, the study of the history of art, and the aesthetic dissemination of art.</p>
<p>The oldest documented forms of art are&nbsp;<a title="Visual arts" href="https://en.wikipedia.org/wiki/Visual_arts">visual arts</a>, which include creation of images or objects in fields including painting, sculpture,&nbsp;<a title="Printmaking" href="https://en.wikipedia.org/wiki/Printmaking">printmaking</a>,
 photography, and other visual media. Architecture is often included as one of the visual arts; however, like the&nbsp;<a title="Decorative arts" href="https://en.wikipedia.org/wiki/Decorative_arts">decorative arts</a>, or advertising,<sup id="cite_ref-advertising_3-0" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-advertising-3">[3]</a></sup>&nbsp;it
 involves the creation of objects where the practical considerations of use are essential&mdash;in a way that they usually are not in a painting, for example. Music, theatre, film, dance, and other&nbsp;<a title="Performing arts" href="https://en.wikipedia.org/wiki/Performing_arts">performing
 arts</a>, as well as literature and other media such as&nbsp;<a title="Interactive media" href="https://en.wikipedia.org/wiki/Interactive_media">interactive media</a>, are included in a broader definition of art or&nbsp;<a title="The arts" href="https://en.wikipedia.org/wiki/The_arts">the
 arts</a>.<sup id="cite_ref-OD_1-1" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-OD-1">[1]</a></sup><sup id="cite_ref-4" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-4">[4]</a></sup>&nbsp;Until the
 17th century,&nbsp;<em>art</em>&nbsp;referred to any skill or mastery and was not differentiated from&nbsp;<a title="Craft" href="https://en.wikipedia.org/wiki/Craft">crafts</a>&nbsp;or&nbsp;<a class="mw-redirect" title="Sciences" href="https://en.wikipedia.org/wiki/Sciences">sciences</a>.
 In modern usage after the 17th century, where aesthetic considerations are paramount, the fine arts are separated and distinguished from acquired skills in general, such as the decorative or&nbsp;<a title="Applied arts" href="https://en.wikipedia.org/wiki/Applied_arts">applied
 arts</a>.</p>
<p>Art may be characterized in terms of&nbsp;<a title="Mimesis" href="https://en.wikipedia.org/wiki/Mimesis">mimesis</a>&nbsp;(its representation of reality), expression, communication of emotion, or other qualities. During the&nbsp;<a title="Romanticism" href="https://en.wikipedia.org/wiki/Romanticism">Romantic
 period</a>, art came to be seen as &quot;a special faculty of the human mind to be classified with religion and science&quot;.<sup id="cite_ref-5" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-5">[5]</a></sup>&nbsp;Though the definition
 of what constitutes art is disputed<sup id="cite_ref-6" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-6">[6]</a></sup><sup id="cite_ref-7" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-7">[7]</a></sup><sup id="cite_ref-8" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-8">[8]</a></sup>&nbsp;and
 has changed over time, general descriptions mention an idea of imaginative or technical skill stemming from&nbsp;<a title="Agency (philosophy)" href="https://en.wikipedia.org/wiki/Agency_(philosophy)">human agency</a><sup id="cite_ref-9" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-9">[9]</a></sup>&nbsp;and
 creation.<sup id="cite_ref-britannica.com_10-0" class="reference"><a href="https://en.wikipedia.org/wiki/Art#cite_note-britannica.com-10">[10]</a></sup></p>
<p><em></p>
<div class="endscriptcode"><strong><span style="font-size:large"><br>
</span></strong></div>
<br>
</em>
<p></p>
<ul>
</ul>
<h1>More Information</h1>
<p><span style="font-size:medium">For more information email me at:</span></p>
<p><span style="font-size:medium">1.gordancraft@hotmail.com</span></p>
<p><span style="font-size:medium">2.gordandjuric@hotmail.com</span></p>
