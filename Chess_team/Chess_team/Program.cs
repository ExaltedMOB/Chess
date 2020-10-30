using System;

namespace Chess_team
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
        }
        static void Fild()
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
        }
        static void TablePrint(int hight, int whight, int gorisontNum, int vertNum, int gorisontPass, int vertPass)
        {
            VertPassing(vertPass);
            LinePrint(whight, gorisontNum, gorisontPass, "┌", "┬", "┐");
            for (int i = 1; i <= vertNum; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    GorisontPassing(gorisontPass);
                    WhitespacePrint(whight, gorisontNum, gorisontPass);
                }
                if (i != vertNum) LinePrint(whight, gorisontNum, gorisontPass, "├", "┼", "┤");
            }
            LinePrint(whight, gorisontNum, gorisontPass, "└", "┴", "┘");
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
        static void LinePrint(int whight, int GorisontNum, int GorisontPass, string LineStart, string LineInside, string LineEnd)
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
            Console.WriteLine(LineEnd);
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
    }
}
