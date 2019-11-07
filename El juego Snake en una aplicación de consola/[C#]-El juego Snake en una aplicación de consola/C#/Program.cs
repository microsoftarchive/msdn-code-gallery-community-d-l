using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            var score = 0;
            var speed = 100;
            var foodPosition = Point.Empty;
            var screenSize = new Size(60, 20);
            var snake = new Queue<Point>();
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
                    snakeLength++;
                    score += 10;
                    ShowScore(score);
                }

                if (foodPosition == Point.Empty)
                {
                    foodPosition = ShowFood(screenSize, snake);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(screenSize.Width/2 - 4, screenSize.Height/2);
            Console.Write("Game Over");
            Thread.Sleep(2000);
            Console.ReadKey();
        }

        private static void DrawScreen(Size size)
        {
            Console.Title = "Snake";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col +1 , row + 1);
                    Console.Write(" ");
                }
            }
        }

        private static bool MoveSnake(Queue<Point> snake, Point targetPosition, 
            int snakeLength, Size screenSize)
        {
            var lastPoint = snake.Last();

            if (lastPoint.Equals(targetPosition)) return true;

            if (snake.Any(x => x.Equals(targetPosition))) return false;

            if (targetPosition.X < 0 || targetPosition.X >= screenSize.Width
                    || targetPosition.Y < 0 || targetPosition.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            snake.Enqueue(targetPosition);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(targetPosition.X + 1, targetPosition.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (snake.Count > snakeLength)
            {
                var removePoint = snake.Dequeue();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Direction GetDirection(Direction currentDirection)
        {
            if (!Console.KeyAvailable) return currentDirection;

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (currentDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    if (currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
            }
            return currentDirection;
        }

        private static Point GetNextPosition(Direction direction, Point currentPosition)
        {
            Point nextPosition = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Up:
                    nextPosition.Y--;
                    break;
                case Direction.Left:
                    nextPosition.X--;
                    break;
                case Direction.Down:
                    nextPosition.Y++;
                    break;
                case Direction.Right:
                    nextPosition.X++;
                    break;
            }
            return nextPosition;
        }

        private static Point ShowFood(Size screenSize, Queue<Point> snake)
        {
            var foodPoint = Point.Empty;
            var snakeHead = snake.Last();
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (snake.All(p => p.X != x || p.Y != y)
                    && Math.Abs(x - snakeHead.X) + Math.Abs(y - snakeHead.Y) > 8)
                {
                    foodPoint = new Point(x, y);
                }

            } while (foodPoint == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(foodPoint.X + 1, foodPoint.Y + 1);
            Console.Write(" ");

            return foodPoint;
        }

        private static void ShowScore(int score)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {score.ToString("00000000")}");
        }


    }

    internal enum Direction
    {
        Down, Left, Right, Up
    }
}
