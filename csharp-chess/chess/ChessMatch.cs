using System;
using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool MatchFinished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1; 
            CurrentPlayer = Color.White;
            MatchFinished = false;
            AddPieces();
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseAmountOfMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(piece, destination);
        }

        private void AddPieces() 
        { 
            Board.AddPiece(new Rook(Board, Color.White),   new ChessPosition('a', 1).ToPosition());
         // Board.AddPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.AddPiece(new Queen(Board, Color.White),  new ChessPosition('d', 1).ToPosition());
            Board.AddPiece(new King(Board, Color.White),   new ChessPosition('e', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
         // Board.AddPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.AddPiece(new Rook(Board, Color.White),   new ChessPosition('h', 1).ToPosition());

            Board.AddPiece(new Rook(Board, Color.Black),   new ChessPosition('a', 8).ToPosition());
         // Board.AddPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.AddPiece(new Queen(Board, Color.Black),  new ChessPosition('d', 8).ToPosition());
            Board.AddPiece(new King(Board, Color.Black),   new ChessPosition('e', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
         // Board.AddPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.AddPiece(new Rook(Board, Color.Black),   new ChessPosition('h', 8).ToPosition());
        }
    }
}
