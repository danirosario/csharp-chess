using System.Collections.Generic;
using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer {  get; private set; }
        public bool MatchFinished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1; 
            CurrentPlayer = Color.White;
            MatchFinished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            AddPieces();
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseAmountOfMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(piece, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
        }

        public void TryMakeMove(Position origin, Position destination)
        {
            ExecuteMove(origin, destination); 
            Turn++;
            ChangePlayer();
        }

        public void IsValideMoveOrigin(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("Nao eh possivel mover uma peca adversaria!");
            }

            if (!Board.Piece(position).HasLegalMoves())
            {
                throw new BoardException("Nao existem movimentos possiveis para a peca escolhida!");
            }
        }

        public void IsValideMoveDestination(Position origin, Position destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Posicao de destino invalida!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPiecesColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces) 
            { 
                if(piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(capturedPiecesColor(color));
            return aux;
        }

        public void AddNewPiece(char column, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, row).ToPosition());
            pieces.Add(piece);
        }
        private void AddPieces() 
        {
            AddNewPiece('a', 1, new Rook(Board, Color.White));
            AddNewPiece('b', 1, new Knight(Board, Color.White));
            AddNewPiece('c', 1, new Bishop(Board, Color.White));
            AddNewPiece('d', 1, new Queen(Board, Color.White));
            AddNewPiece('e', 1, new King(Board, Color.White));
            AddNewPiece('f', 1, new Bishop(Board, Color.White));
            AddNewPiece('g', 1, new Knight(Board, Color.White));
            AddNewPiece('h', 1, new Rook(Board, Color.White));

            AddNewPiece('a', 8, new Rook(Board, Color.Black));
            AddNewPiece('b', 8, new Knight(Board, Color.Black));
            AddNewPiece('c', 8, new Bishop(Board, Color.Black));
            AddNewPiece('d', 8, new Queen(Board, Color.Black));
            AddNewPiece('e', 8, new King(Board, Color.Black));
            AddNewPiece('f', 8, new Bishop(Board, Color.Black));
            AddNewPiece('g', 8, new Knight(Board, Color.Black));
            AddNewPiece('h', 8, new Rook(Board, Color.Black));
        }
    }
}
