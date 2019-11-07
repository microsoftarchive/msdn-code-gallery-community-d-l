using System;
using Flags;
using System.Globalization;
using System.Threading;

namespace Fermasmas.Flags
{
    abstract class Flag
    {
        public virtual int Width
        {
            get { return 79; }
        }

        public virtual int Height
        {
            get { return 24; }
        }

        protected virtual int WidthSectors
        {
            get { return 1; }
        }

        protected virtual int HeightSectors
        {
            get { return 1; }
        }

        protected bool IsWidthSector(int sector, int value)
        {
            int sectorWidth = Width / WidthSectors;
            return value >= sectorWidth * Math.Max(sector - 1, 0)
              && value < sectorWidth * sector;
        }

        protected bool IsHeightSector(int sector, int value)
        {
            int sectorHeight = Height / HeightSectors;
            return value >= sectorHeight * Math.Max(sector - 1, 0)
              && value < sectorHeight * sector;
        }

        protected void SetupEdgeSquare()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        protected abstract void SetupSquare(int x, int y);

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.ResetColor();
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                        SetupEdgeSquare();
                    else
                        SetupSquare(x, y);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }

    class GermanFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 3; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsHeightSector(1, y))
                Console.BackgroundColor = ConsoleColor.Black;
            else if (IsHeightSector(2, y))
                Console.BackgroundColor = ConsoleColor.Red;
            else if (IsHeightSector(3, y))
                Console.BackgroundColor = ConsoleColor.Yellow;
        }
    }

    class SpanishFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 3; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsHeightSector(2, y))
                Console.BackgroundColor = ConsoleColor.Yellow;
            else
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }

    class FrenchFlag : Flag
    {
        protected override int WidthSectors
        {
            get { return 3; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(1, x))
                Console.BackgroundColor = ConsoleColor.Blue;
            else if (IsWidthSector(2, x))
                Console.BackgroundColor = ConsoleColor.White;
            else if (IsWidthSector(3, x))
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }

    class ItalianFlag : Flag
    {
        protected override int WidthSectors
        {
            get { return 3; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(1, x))
                Console.BackgroundColor = ConsoleColor.Green;
            else if (IsWidthSector(2, x))
                Console.BackgroundColor = ConsoleColor.White;
            else if (IsWidthSector(3, x))
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }

    class SwissFlag : Flag
    {
        public override int Width
        {
            get
            {
                return (int)Math.Round(Math.Min(base.Width, base.Height) * 1.7, 0);
            }
        }

        public override int Height
        {
            get { return Math.Min(base.Width, base.Height); }
        }

        protected override int HeightSectors
        {
            get { return 5; }
        }

        protected override int WidthSectors
        {
            get { return 6; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (((IsHeightSector(2, y) || IsHeightSector(4, y)) &&
                  IsWidthSector(4, x)) || (IsHeightSector(3, y) &&
                 (IsWidthSector(3, x) || IsWidthSector(4, x) ||
                 IsWidthSector(5, x))))
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }

    class EnglishFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 9; }
        }

        protected override int WidthSectors
        {
            get { return 9; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(5, x) || IsWidthSector(6, x) ||
                IsHeightSector(6, y) || IsHeightSector(7, y) ||
                IsHeightSector(8, y))
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.White;
        }
    }

    class SweedishFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 9; }
        }

        protected override int WidthSectors
        {
            get { return 15; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(6, x) || IsWidthSector(7, x) ||
                IsHeightSector(6, y) || IsHeightSector(7, y) ||
                IsHeightSector(8, y))
                Console.BackgroundColor = ConsoleColor.Yellow;
            else
                Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
    }

    class NorwegianFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 15; }
        }

        protected override int WidthSectors
        {
            get { return 25; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(10, x) || IsWidthSector(11, x) ||
                IsHeightSector(12, y) || IsHeightSector(13, y) ||
                IsHeightSector(14, y))
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            else if (IsWidthSector(9, x) || IsWidthSector(12, x) ||
                     IsHeightSector(11, y) || IsHeightSector(15, y))
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.Red;
        }
    }

    class IcelandicFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 15; }
        }

        protected override int WidthSectors
        {
            get { return 25; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsWidthSector(10, x) || IsWidthSector(11, x) ||
                IsHeightSector(12, y) || IsHeightSector(13, y) ||
                IsHeightSector(14, y))
                Console.BackgroundColor = ConsoleColor.DarkRed;
            else if (IsWidthSector(9, x) || IsWidthSector(12, x) ||
                     IsHeightSector(11, y) || IsHeightSector(15, y))
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
    }

    class GreekFlag : Flag
    {
        protected override int HeightSectors
        {
            get { return 10; }
        }

        protected override int WidthSectors
        {
            get { return 12; }
        }

        protected override void SetupSquare(int x, int y)
        {
            if (IsHeightSector(3, y) || IsHeightSector(5, y) ||
                IsHeightSector(7, y) || IsHeightSector(9, y))
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.DarkBlue;

            if (IsWidthSector(1, x) || IsWidthSector(2, x) ||
                IsWidthSector(3, x) || IsWidthSector(4, x) ||
                IsWidthSector(5, x))
            {
                if (IsHeightSector(1, y) || IsHeightSector(2, y) ||
                    IsHeightSector(3, y) || IsHeightSector(4, y) ||
                    IsHeightSector(5, y) || IsHeightSector(6, y))
                {
                    if (IsWidthSector(3, x) || IsHeightSector(4, y))
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
            }
        }
    }

    class Program
    {
        static void SwitchLanguage()
        {
            Console.Clear();
            Console.WriteLine(Resources.LanguageInstructions);
            Console.WriteLine(Resources.English);
            Console.WriteLine(Resources.Spanish);
            var key = Console.ReadKey(true);

            CultureInfo culture;
            switch (key.Key)
            {
                case ConsoleKey.E:
                    culture = new CultureInfo("en-US");
                    break;

                case ConsoleKey.S:
                    culture = new CultureInfo("es-MX");
                    break;

                default:
                    culture = null;
                    Console.WriteLine(Resources.InvalidKey);
                    Console.ReadKey(true);
                    break;
            }
            if (culture != null)
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }

        static void Main(string[] args)
        {
            Flag flag;
            bool quit;
     
            do
            {
                Console.Clear();
                Console.WriteLine(Resources.Instructions);
                Console.WriteLine(Resources.Germany);
                Console.WriteLine(Resources.Spain);
                Console.WriteLine(Resources.France);
                Console.WriteLine(Resources.Italy);
                Console.WriteLine(Resources.Switzerland);
                Console.WriteLine(Resources.England);
                Console.WriteLine(Resources.Sweeden);
                Console.WriteLine(Resources.Norway);
                Console.WriteLine(Resources.Iceland);
                Console.WriteLine(Resources.Greece);
                Console.WriteLine(Resources.Quit);
                Console.WriteLine(Resources.Language);
                ConsoleKeyInfo key = Console.ReadKey(true);

                flag = null;
                quit = false;
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        quit = true;
                        break;

                    case ConsoleKey.L:
                        SwitchLanguage();
                        break;

                    case ConsoleKey.D1:
                        flag = new GermanFlag();
                        break;

                    case ConsoleKey.D2:
                        flag = new SpanishFlag();
                        break;

                    case ConsoleKey.D3:
                        flag = new FrenchFlag();
                        break;

                    case ConsoleKey.D4:
                        flag = new ItalianFlag();
                        break;

                    case ConsoleKey.D5:
                        flag = new SwissFlag();
                        break;

                    case ConsoleKey.D6:
                        flag = new EnglishFlag();
                        break;

                    case ConsoleKey.D7:
                        flag = new SweedishFlag();
                        break;

                    case ConsoleKey.D8:
                        flag = new NorwegianFlag();
                        break;

                    case ConsoleKey.D9:
                        flag = new IcelandicFlag();
                        break;

                    case ConsoleKey.D0:
                        flag = new GreekFlag();
                        break;

                    default:
                        Console.WriteLine(Resources.InvalidKey);
                        Console.ReadKey(true);
                        break;
                }

                if (flag != null)
                {
                    Console.Clear();
                    flag.Draw();
                    Console.ReadKey(true);
                    Console.ResetColor();
                }
            } while (!quit);
        }
    }
}

