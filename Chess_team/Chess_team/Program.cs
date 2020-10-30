using System;

namespace Chess_team
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
        }
        static int[] ReturnChoosedCoordinate()
        {
            int hight = 2;
            int whight = 4;
            int gorisontNum = 8;
            int vertNum = 8;
            int gorisontPass = 1;
            int vertPass = 1;
            int positionX = 1;
            int positionY = 1;
            TablePrint(hight, whight, gorisontNum, vertNum, gorisontPass, vertPass);
            ReColour(positionX, positionY, gorisontPass, vertPass, hight, whight);
            return InteractiveBoard(positionX, positionY, vertNum, gorisontNum, hight, whight, gorisontPass, vertPass);
        }
        static void TablePrint(int hight, int whight, int gorisontNum, int vertNum, int gorisontPass, int vertPass)
        {
            VertPassing(vertPass);
            string[] fildCoordinate = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            LinePrint(whight, gorisontNum, gorisontPass, "┌", "┬", "┐", fildCoordinate[0]);
            for (int i = 1; i <= vertNum; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    GorisontPassing(gorisontPass);
                    WhitespacePrint(whight, gorisontNum, gorisontPass);
                }
                if (i != vertNum) LinePrint(whight, gorisontNum, gorisontPass, "├", "┼", "┤", fildCoordinate[i]);
            }
            LinePrint(whight, gorisontNum, gorisontPass, "└", "┴", "┘", "");
            PrintChessNumCoordinate(whight, gorisontPass);
        }
        static void GorisontPassing(int gorPass)
        {
            for (int i = 0; i < gorPass; i++)
            {
                Console.Write(" ");
            }
        }
        static void VertPassing(int vertPass)
        {
            for (int i = 0; i < vertPass; i++)
            {
                Console.WriteLine();
            }
        }
        static void LinePrint(int whight, int GorisontNum, int GorisontPass, string LineStart, string LineInside, string LineEnd, string fildCoordinate)
        {
            GorisontPassing(GorisontPass);
            Console.Write(LineStart);
            for (int i = 1; i <= GorisontNum; i++)
            {
                for (int j = 0; j < whight; j++)
                {
                    Console.Write("─");
                }
                if (i != GorisontNum) Console.Write(LineInside);
            }
            Console.Write(LineEnd);
            Console.WriteLine(fildCoordinate);
        }
        static void WhitespacePrint(int whight, int GorisontNum, int GorisontPass)
        {
            for (int i = 0; i < GorisontNum; i++)
            {
                Console.Write("│");
                for (int j = 0; j < whight; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("│");
        }
        static void PrintChessNumCoordinate(int whide, int gorisontPass)
        {
            GorisontPassing(gorisontPass);
            for (int i = 1 ; i <= 8; i++)
            {
                Console.Write(i);
                GorisontPassing(whide);
            }
        }
        static void ReColour(int gorID, int vertID, int gorisontPass, int vertPass, int hight, int whight)
        {
            Console.SetCursorPosition(GetPosition(gorisontPass, gorID, whight), GetPosition(vertPass, vertID, hight));
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < hight; i++)
            {
                Console.SetCursorPosition(GetPosition(gorisontPass, gorID, whight), GetPosition(vertPass, vertID, hight) + i);
                for (int j = 0; j < whight; j++)
                {
                    Console.Write(" ");
                }
                if (i == (hight - 1)) Console.SetCursorPosition(GetPosition(gorisontPass, gorID, whight), GetPosition(vertPass, vertID, hight));
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static int GetPosition(int pass, int ID, int WH)
        {
            return (pass + 1 + (ID - 1) + ((ID - 1) * WH));
        }
        static int[] GetMoove(int positionX, int positionY, int hight, int whight)
        {
            int[] delta = new int[3];
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo buttonPresed = Console.ReadKey();
                if (buttonPresed.Key == ConsoleKey.RightArrow) delta[0] = 1;
                if (buttonPresed.Key == ConsoleKey.LeftArrow) delta[0] = -1;
                if (buttonPresed.Key == ConsoleKey.UpArrow) delta[1] = -1;
                if (buttonPresed.Key == ConsoleKey.DownArrow) delta[1] = 1;
                if (buttonPresed.Key == ConsoleKey.Enter) delta[2] = 1;
            }
            System.Threading.Thread.Sleep(25);
            if (!IsMoveAvailable(positionX, positionY, hight, whight, delta)) 
            {
                delta[0] = 0;
                delta[1] = 0;
            }
            return delta;
        }
        static bool IsMoveAvailable(int positionX, int positionY, int hight, int whight, int[] delta)
        {
            bool result = false;
            if (positionX + delta[0] <= whight &&
                positionY + delta[1] <= hight &&
                positionX + delta[0] >= 1 &&
                positionY + delta[1] >= 1)
            {
                result = true;
            }
            return result;
        }
        static int[] InteractiveBoard(int positionX, int positionY, int vertNum, int gorisontNum, int hight, int whight, int gorisontPass, int vertPass)
        {
            while (true)
            {
                int[] delta = GetMoove(positionX, positionY, vertNum, gorisontNum);
                if (delta[0] != 0 || delta[1] != 0)
                {
                    positionX = positionX + delta[0];
                    positionY = positionY + delta[1];
                    TablePrint(hight, whight, gorisontNum, vertNum, gorisontPass, vertPass);
                    ReColour(positionX, positionY, gorisontPass, vertPass, hight, whight);
                    Console.SetCursorPosition(0, 0);
                }
                if (delta[2] == 1)
                {
                    return new int[] { positionX, positionY };
                }
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
