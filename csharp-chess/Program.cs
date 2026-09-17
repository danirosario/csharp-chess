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
                var board = new Board(8, 8);

                board.AddPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.AddPiece(new Rook(board, Color.Black), new Position(0, 7));

                board.AddPiece(new Knigth(board, Color.Black), new Position(0, 1));
                board.AddPiece(new Knigth(board, Color.Black), new Position(0, 6));

                board.AddPiece(new Bishop(board, Color.Black), new Position(0, 2));
                board.AddPiece(new Bishop(board, Color.Black), new Position(0, 5));

                board.AddPiece(new Queen(board, Color.Black), new Position(0, 3));
                board.AddPiece(new King (board, Color.Black), new Position(0, 4));

                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 0));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 1));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 2));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 3));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 4));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 5));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 6));
                board.AddPiece(new Pawn(board, Color.Black), new Position(1, 7));

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}