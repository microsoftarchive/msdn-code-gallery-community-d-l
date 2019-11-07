Imports System.Drawing
Imports System.Threading

Module Module1

    Sub Main()
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
                snakeLength += 1
                score += 10
                ShowScore(score)
            End If

            If foodPosition = Point.Empty Then
                foodPosition = ShowFood(screenSize, snake)
            End If
        End While

        Console.ResetColor()
        Console.SetCursorPosition(screenSize.Width/2 - 4, screenSize.Height/2)
        Console.Write("Game Over")
        Thread.Sleep(2000)
        Console.ReadKey()
    End Sub

    Private Function MoveSnake(snake As Queue(Of Point), targetPosition As Point, _
                               snakeLength As Integer, screenSize As Size)
        Dim lastPoint = snake.Last()

        If lastPoint.Equals(targetPosition) Then Return True

        If snake.Any(Function(x) x.Equals(targetPosition)) Then Return False

        If targetPosition.X < 0 OrElse targetPosition.X >= screenSize.Width _
            OrElse targetPosition.Y < 0 OrElse targetPosition.Y >= screenSize.Height Then
            Return False
        End If

        Console.BackgroundColor = ConsoleColor.Green
        Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1)
        Console.WriteLine(" ")

        snake.Enqueue(targetPosition)

        Console.BackgroundColor = ConsoleColor.Red
        Console.SetCursorPosition(targetPosition.X + 1, targetPosition.Y + 1)
        Console.Write(" ")

        ' Quitar cola
        If snake.Count > snakeLength Then
            Dim removePoint = snake.Dequeue()
            Console.BackgroundColor = ConsoleColor.Black
            Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1)
            Console.Write(" ")
        End If
        Return True
    End Function

    Private Function GetDirection(currentDirection As Direction) As Direction
        If Not Console.KeyAvailable Then Return currentDirection

        Dim key = Console.ReadKey(True).Key
        Select Case key
            Case ConsoleKey.DownArrow
                If currentDirection <> Direction.Up Then _
                    currentDirection = Direction.Down
            Case ConsoleKey.LeftArrow
                If currentDirection <> Direction.Rigth Then _
                    currentDirection = Direction.Left
            Case ConsoleKey.RightArrow
                If currentDirection <> Direction.Left Then _
                    currentDirection = Direction.Rigth
            Case ConsoleKey.UpArrow
                If currentDirection <> Direction.Down Then _
                    currentDirection = Direction.Up
        End Select
        Return currentDirection
    End Function

    Private Function GetNextPosition(direction As Direction, currentPosition As Point)
        Dim nextPosition As New Point(currentPosition.X, currentPosition.Y)
        Select Case direction
            Case Direction.Up
                nextPosition.Y -= 1
            Case Direction.Left
                nextPosition.X -= 1
            Case Direction.Down
                nextPosition.Y += 1
            Case Direction.Rigth
                nextPosition.X += 1
        End Select
        Return nextPosition
    End Function

    Private Function ShowFood(screenSize As Size, snake As Queue(Of Point)) As Point
        Dim foodPoint = Point.Empty
        Dim snakeHead = snake.Last()
        Dim rnd As New Random()
        Do
            Dim x = rnd.Next(0, screenSize.Width - 1)
            Dim y = rnd.Next(0, screenSize.Height - 1)
            If snake.All(Function(p) p.X <> x OrElse p.Y <> y) _
               AndAlso Math.Abs(x - snakeHead.X) + Math.Abs(y - snakeHead.Y) > 8 Then
                foodPoint = new Point(x, y)
            End If
        Loop While foodPoint = Point.Empty

        Console.BackgroundColor = ConsoleColor.Blue
        Console.SetCursorPosition(foodPoint.X + 1, foodPoint.Y + 1)
        Console.Write(" ")

        Return foodPoint
    End Function

    Private Sub DrawScreen(screenSize As Size)
        Console.Title = "Snake"
        Console.WindowHeight = screenSize.Height + 2
        Console.WindowWidth = screenSize.Width + 2
        Console.BufferHeight = Console.WindowHeight
        Console.BufferWidth = Console.WindowWidth
        Console.CursorVisible = False
        Console.BackgroundColor = ConsoleColor.White
        Console.Clear()

        Console.BackgroundColor = ConsoleColor.Black
        For row As Integer = 0 To screenSize.Height -1
            For col As Integer = 0 To screenSize.Width -1
                Console.SetCursorPosition(col + 1, row + 1)
                Console.Write(" ")
            Next
        Next
    End Sub

    Private Sub ShowScore(score As Integer)
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.SetCursorPosition(1, 0)
        Console.Write($"Puntuación: {score.ToString("00000000")}")
    End Sub

    Friend Enum Direction
        Down
        Left
        Rigth
        Up
    End Enum

End Module
