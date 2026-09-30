using board;

namespace chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var match = new ChessMatch();

                while (!match.MatchFinished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.Write("\nOrigem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.Write("\nDestino: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMove(origin, destination);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}