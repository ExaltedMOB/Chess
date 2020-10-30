using System;
using System.IO;

namespace Chess_team
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
        }

        static string GetPath(string path = "save.txt")
        {
            string filePath = Environment.CurrentDirectory;
            filePath = @filePath.Substring(0, filePath.IndexOf("bin")) + path;
            return filePath;
        }
        static void CreateFile(string path)
        {
            char[,] board = { {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  },
                              {'0','0','0','0','0','0','0','0'  } };
            string text = board.ToString();

            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }

        static void SaveBoard(char[,] board)
        {
            string filePath = GetPath();

            string text = board.ToString();

            using (FileStream fstream = new FileStream(filePath, FileMode.Open))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }

        static char[,] ConvertToCharArray(string text)
        {
            char[,] board = new char[8, 8];
            for(int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j]= text[i * 8 + j];
                }
            }
            return board;
        }

        static char[,] LoadBoard()
        {

            string textFromFile;
            string filePath = GetPath();

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                CreateFile(filePath);
            }

            using (FileStream fStream = File.OpenRead(filePath))
            {
                // преобразуем строку в байты 
                byte[] array = new byte[fStream.Length];
                // считываем данные 
                fStream.Read(array, 0, array.Length);
                // декодируем байты в строку 
                textFromFile = System.Text.Encoding.Default.GetString(array);
                //textFromFile = textFromFile.Trim();
            }

            char[,] board = ConvertToCharArray(textFromFile);

            return board;
        }
    }
}
