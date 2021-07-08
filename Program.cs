using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessQueenPuzzle
{
    class Program
    {
        static int[,] _board = new int[8, 8];
        static int _solutionsCount = 0;
        static void Main(string[] args)
        {
            int[,] _board = new int[8, 8];
            int[,] _filledBoard = FindQueenColumn(_board, 0);
            //OutputBoard(_filledBoard);
            Console.WriteLine($"Solutions count: {_solutionsCount}");
            PauseApp();
        }
        static int[,] FindQueenColumn(int[,] board, int queenRow)
        {
            if (queenRow > 7)
            {
                _solutionsCount++;
                OutputBoard(board);
                return null;
            }
            for (int x = 0; x < 8; x++)
                if (CanPlaceQueen(board, x, queenRow))
                {
                    int[,] newBoard = (int[,])board.Clone();
                    PlaceQueen(newBoard, x, queenRow);
                    int[,] _filledBoard = FindQueenColumn(newBoard, queenRow + 1);
                    if (_filledBoard != null)
                        return _filledBoard;
                }
            return null;
        }
        static void PlaceQueen(int[,] board, int x, int y)
        {
            if (board[x, y] == 1)
                throw new Exception();
            for (int i = 0; i < 8; i++)
            {
                board[x, i] = 1;
                board[i, y] = 1;
                int step = i + 1;
                if (IsValidCord(x - step, y - step))
                    board[x - step, y - step] = 1;
                if (IsValidCord(x - step, y + step))
                    board[x - step, y + step] = 1;
                if (IsValidCord(x + step, y - step))
                    board[x + step, y - step] = 1;
                if (IsValidCord(x + step, y + step))
                    board[x + step, y + step] = 1;
            }
            board[x, y] = 5;
        }
        static bool CanPlaceQueen(int[,] board, int x, int y)
        {
            return board[x, y] == 0;
        }
        static void OutputBoard(int[,] board)
        {
            Console.WriteLine($"Board({_solutionsCount}):");
            for (int y = 0; y < 8; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < 8; x++)
                {
                    line.Append(board[x, y]);
                    if (x < 7)
                        line.Append(' ');
                }
                Console.WriteLine(line.ToString());
            }
            Console.WriteLine();
        }
        static void ResetBoard(int[,] board)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
        }
        static bool IsValidCord(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }
        static void PauseApp()
        {
            Console.ReadKey(true);
        }
    }
}
