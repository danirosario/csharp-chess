using board;
using chess;

namespace csharp_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var match = new ChessMatch();

                Screen.PrintBoard(match.Board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}