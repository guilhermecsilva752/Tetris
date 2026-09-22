using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace FPTetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] tela = new int[25, 30];

            int pcX = 15;
            int pcY = 12;

            CriarTela(tela);

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                ApagarUltimaPosicao(tela, pcX, pcY);

                pcY++;

                DesenharTela(tela);

                Console.WriteLine($"Posição da pc: [{pcX}, {pcY}]");

                Thread.Sleep(1000);
            }
        }

        static void CriarTela(int[,] tela)
        {
            for (int row = 0; row < tela.GetLength(0); row++)
            {
                for (int col = 0; col < tela.GetLength(1); col++)
                {
                    if (row == 0 || row == tela.GetLength(0) - 1)
                    {
                        tela[row, col] = 1;
                    }

                    else if (col == 0 || col == tela.GetLength(1) - 1)
                    {
                        tela[row, col] = 1;
                    }

                    //if (row == pcY && col == pcX)
                    //{
                    //    tela[row, col] = 2;
                    //}
                }
            }
        }

        static void DesenharTela(int[,] tela)
        {
            for (int row = 0; row < tela.GetLength(0); row++)
            {
                for (int col = 0; col < tela.GetLength(1); col++)
                {
                    if (tela[row, col] == 1)
                    {
                        Console.Write("#");
                    }
                    else if (tela[row, col] == 2)
                    {
                        Console.Write("H");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

            }
        }

        static void ApagarUltimaPosicao(int[,] tela, int pcX, int pcY) // Função para mover a peça para baixo
        {
            if (pcY < tela.GetLength(0) - 1)
            {
                tela[pcY-1, pcX] = 0; // limpa a posição anterior
                tela[pcY, pcX] = 2; // nova posição
            }
        }
    }
}