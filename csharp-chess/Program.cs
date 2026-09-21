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
                var position = new ChessPosition('c', 7);

                Console.WriteLine(position);

                Console.WriteLine(position.ToPosition());
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}