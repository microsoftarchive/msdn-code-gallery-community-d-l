# El juego Snake en una aplicación de consola
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- .NET
- Console
- VB.Net
## Topics
- Games
- Juegos
## Updated
- 06/01/2016
## Description

<h1>Introducci&oacute;n</h1>
<p><em>El ejemplo muestra c&oacute;mo construir el cl&aacute;sico juego Snake en una aplicaci&oacute;n de consola.</em></p>
<h1>Descripci&oacute;n</h1>
<p><em>La visualizaci&oacute;n de la serpiente se mantiene a trav&eacute;s de un objeto Queue que almacena las posiciones de los diferentes puntos de la cola de la serpiente.</em></p>
<p><em>De esta forma seg&uacute;n va avanzando la serpiente se van a&ntilde;adiendo los puntos a trav&eacute;s del m&eacute;todo Enqueue a la vez que se eliminan los &uacute;ltimos puntos de la cola de la serpiente a trav&eacute;s del m&eacute;todo Dequeue.</em></p>
<p><em>El funcionamiento del juego se apoya en 4 funciones:</em></p>
<ol>
<li><em>MoveSnake. Que se encarga de dibujar la serpiente en la pantalla en su nueva posici&oacute;n. La funci&oacute;n devuelve un valor booleano indicando si el movimiento es posible, si no lo es, porque la serpiente choca contra los bordes de la pantalla
 o contra su propia cola devuelve false provocando el fin del juego.</em> </li><li><em>GetDirection. Es la responsable de capturar las pulsaciones de teclado del jugador y modificar la direcci&oacute;n que sigue la serpiente en funci&oacute;n de &eacute;stas. Devuelve un valor Direction indicando la direcci&oacute;n en que se deber&iacute;a
 mover la serpiente.</em> </li><li><em>GetNextPosition. Se encarga de calcular la nueva posici&oacute;n de la serpiente teniendo en cuenta su posici&oacute;n actual y la direcci&oacute;n.</em>
</li><li><em>ShowFood. Muestra en pantalla, en una posici&oacute;n aleatoria, un elemento que representa la comida de la serpiente. Devuelve la posici&oacute;n en la que se ha mostrado la comida.</em>
</li></ol>
<p><em>Con estas funciones el c&oacute;digo del m&eacute;todo principal pr&aacute;cticamente se reduce a ir llamando al m&eacute;todo MoveSnake hasta que &eacute;ste devuelve false y finaliza el juego.</em></p>
<p><em>Despu&eacute;s de cada movimiento comprueba si ha alcanzado la comida (y en tal caso muestra otra) y calcula la nueva direcci&oacute;n y posici&oacute;n.</em><em>&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">        static void Main()
        {
            var score = 0;
            var speed = 100;
            var foodPosition = Point.Empty;
            var screenSize = new Size(60, 20);
            var snake = new Queue&lt;Point&gt;();
            var snakeLength = 3;
            var currentPosition = new Point(0, 9);
            snake.Enqueue(currentPosition);
            var direction = Direction.Right;

            DrawScreen(screenSize);
            ShowScore(score);

            while (MoveSnake(snake, currentPosition, snakeLength, screenSize))
            {
                Thread.Sleep(speed);
                direction = GetDirection(direction);
                currentPosition = GetNextPosition(direction, currentPosition);

                if (currentPosition.Equals(foodPosition))
                {
                    foodPosition = Point.Empty;
                    snakeLength&#43;&#43;;
                    score &#43;= 10;
                    ShowScore(score);
                }

                if (foodPosition == Point.Empty)
                {
                    foodPosition = ShowFood(screenSize, snake);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(screenSize.Width/2 - 4, screenSize.Height/2);
            Console.Write(&quot;Game Over&quot;);
            Thread.Sleep(2000);
            Console.ReadKey();
        }
</pre>
<pre class="hidden">    Sub Main()
        Dim score = 0
        Dim speed = 100
        Dim foodPosition = Point.Empty
        Dim screenSize As New Size(60, 20)
        Dim snake As New Queue(Of Point)
        Dim snakeLength = 3
        Dim currentPosition As New Point(0, 9)
        snake.Enqueue(currentPosition)
        Dim direction As Direction = Direction.Rigth

        DrawScreen(screenSize)
        ShowScore(score)

        While MoveSnake(snake, currentPosition, snakeLength, screenSize)
            Thread.Sleep(speed)
            direction = GetDirection(direction)
            currentPosition = GetNextPosition(direction, currentPosition)

            If currentPosition.Equals(foodPosition) Then
                foodPosition = Point.Empty
                snakeLength &#43;= 1
                score &#43;= 10
                ShowScore(score)
            End If

            If foodPosition = Point.Empty Then
                foodPosition = ShowFood(screenSize, snake)
            End If
        End While

        Console.ResetColor()
        Console.SetCursorPosition(screenSize.Width/2 - 4, screenSize.Height/2)
        Console.Write(&quot;Game Over&quot;)
        Thread.Sleep(2000)
        Console.ReadKey()
    End Sub
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;score&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;speed&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;foodPosition&nbsp;=&nbsp;Point.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;screenSize&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__number">60</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;snake&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Queue&lt;Point&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;snakeLength&nbsp;=&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;currentPosition&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">9</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;snake.Enqueue(currentPosition);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;direction&nbsp;=&nbsp;Direction.Right;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawScreen(screenSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowScore(score);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(MoveSnake(snake,&nbsp;currentPosition,&nbsp;snakeLength,&nbsp;screenSize))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(speed);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;direction&nbsp;=&nbsp;GetDirection(direction);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentPosition&nbsp;=&nbsp;GetNextPosition(direction,&nbsp;currentPosition);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(currentPosition.Equals(foodPosition))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foodPosition&nbsp;=&nbsp;Point.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;snakeLength&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;score&nbsp;&#43;=&nbsp;<span class="cs__number">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowScore(score);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(foodPosition&nbsp;==&nbsp;Point.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foodPosition&nbsp;=&nbsp;ShowFood(screenSize,&nbsp;snake);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ResetColor();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.SetCursorPosition(screenSize.Width/<span class="cs__number">2</span>&nbsp;-&nbsp;<span class="cs__number">4</span>,&nbsp;screenSize.Height/<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;Game&nbsp;Over&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">2000</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<em><em>.</em></em></pre>
</div>
</div>
</div>
<h1>M&aacute;s Informaci&oacute;n</h1>
<p><em>Se puede encontrar una descripci&oacute;n m&aacute;s detallada del c&oacute;digo del ejemplo en:</em></p>
<p><em><a title="Juego Snake" href="http://pildorasdotnet.blogspot.com/2016/05/juego-snake-en-aplicacion-de-consola.html">Juego Snake en aplicaci&oacute;n de consola</a></em></p>
<p><em><br>
</em></p>
