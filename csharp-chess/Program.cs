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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match.Board);
                        Console.WriteLine("\nTurno: " + match.Turn);
                        Console.WriteLine("Aguardando jogada: " + match.CurrentPlayer);

                        Console.Write("\nOrigem: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.IsValideMoveOrigin(origin);

                        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.Write("\nDestino: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        match.IsValideMoveDestination(origin, destination);

                        match.TryMakeMove(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}