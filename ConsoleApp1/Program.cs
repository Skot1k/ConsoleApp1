using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

class NonogramSolver
        {
            static void Main(string[] args)
            {
                int[,] puzzle =
                {
                    {0, 0, 1, 1},
                    {1, 1, 0, 0},
                    {0, 1, 1, 0},
                    {1, 1, 1, 1}
                };

                SolveNonogram(puzzle);
                PrintSolution(puzzle);
            }

            static void SolveNonogram(int[,] puzzle)
            {
                int rows = puzzle.GetLength(0);
                int cols = puzzle.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    SolveRow(puzzle, i, cols);
                }

                for (int i = 0; i < cols; i++)
                {
                    SolveColumn(puzzle, i, rows);
                }
            }

            static void SolveRow(int[,] puzzle, int row, int cols)
            {
                int[] clues = new int[cols];
                int clueIndex = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (puzzle[row, col] == 1)
                    {
                        clues[clueIndex]++;
                    }
                    else if (clues[clueIndex] > 0)
                    {
                        clueIndex++;
                    }
                }

                ApplyClues(puzzle, row, clues);
            }

            static void SolveColumn(int[,] puzzle, int col, int rows)
            {
                int[] clues = new int[rows];
                int clueIndex = 0;

                for (int row = 0; row < rows; row++)
                {
                    if (puzzle[row, col] == 1)
                    {
                        clues[clueIndex]++;
                    }
                    else if (clues[clueIndex] > 0)
                    {
                        clueIndex++;
                    }
                }

                ApplyClues(puzzle, col, clues);
            }

            static void ApplyClues(int[,] puzzle, int index, int[] clues)
            {
                int[] sequence = new int[puzzle.GetLength(1)];
                int sequenceIndex = 0;

                foreach (int clue in clues)
                {
                    for (int i = 0; i < clue; i++)
                    {
                        sequence[sequenceIndex++] = 1;
                    }
                    if (sequenceIndex < sequence.Length)
                    {
                        sequence[sequenceIndex++] = 0;
                    }
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (puzzle.GetLength(0) > puzzle.GetLength(1))
                    {
                        puzzle[index, i] = sequence[i];
                    }
                    else
                    {
                        puzzle[i, index] = sequence[i];
                    }
                }
            }

            static void PrintSolution(int[,] puzzle)
            {
                int rows = puzzle.GetLength(0);
                int cols = puzzle.GetLength(1);

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(puzzle[row, col] == 1 ? "#" : " ");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}

