using board;
using chess;

namespace csharp_chess
{
    class Program
    {
        static void Main(string[] args)
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


            Screen.PrintBoard(board);

        }
    }
}