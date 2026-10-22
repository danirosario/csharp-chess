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
        public bool Check {  get; private set; }
        public Piece VulnerableToEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1; 
            CurrentPlayer = Color.White;
            MatchFinished = false;
            Check = false;
            VulnerableToEnPassant = null;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            AddPieces();
        }

        public Piece ExecuteMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseAmountOfMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(piece, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            //#jogada especial roque pequeno
            if(piece is King && destination.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position destinationRook = new Position(origin.Row, origin.Column + 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncreaseAmountOfMoves();
                Board.AddPiece(R, destinationRook);
            }

            //#jogada especial roque grande
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position destinationRook = new Position(origin.Row, origin.Column - 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncreaseAmountOfMoves();
                Board.AddPiece(R, destinationRook);
            }

            //#jogada especial en passant
            if (piece is Pawn)
            {
                if (origin.Column != destination.Column && capturedPiece == null)
                {
                    Position posP;
                    if (piece.Color == Color.White)
                    {
                        posP = new Position(destination.Row + 1, destination.Column);
                    }
                    else
                    {
                        posP = new Position(destination.Row - 1, destination.Column);
                    }
                    capturedPiece = Board.RemovePiece(posP);
                    capturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void ResetMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destination);
            p.DecreaseAmountOfMoves();

            if (capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, destination);
                capturedPieces.Remove(capturedPiece);
            }
            Board.AddPiece(p, origin);

            //#jogada especial roque pequeno
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position destinationRook = new Position(origin.Row, origin.Column + 1);
                Piece R = Board.RemovePiece(destinationRook);
                R.DecreaseAmountOfMoves();
                Board.AddPiece(R, originRook);
            }

            //#jogada especial roque grande
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position destinationRook = new Position(origin.Row, origin.Column - 1);
                Piece R = Board.RemovePiece(destinationRook);
                R.DecreaseAmountOfMoves();
                Board.AddPiece(R, originRook);
            }

            //#jogada especial en passant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && capturedPiece == VulnerableToEnPassant)
                {
                    Piece pawn = Board.RemovePiece(destination);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destination.Column);
                    }
                    else
                    {
                        posP = new Position(4, destination.Column);
                    }
                    Board.AddPiece(pawn, posP);
                }
            }
        }

        public void TryMakeMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination); 

            if (IsCheck(CurrentPlayer))
            {
                ResetMove(origin, destination, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsCheck(Opponent(CurrentPlayer))) 
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsCheckmate(Opponent(CurrentPlayer)))
            {
                MatchFinished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            Piece p = Board.Piece(destination);
            
            //#jogada especial En Passant
            if(p is Pawn && (destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2))
            {
                VulnerableToEnPassant = p;
            }
            else
            {
                VulnerableToEnPassant = null;
            }


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

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece IsTheKing(Color color)
        {
            foreach (Piece piece in piecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece; 
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece K = IsTheKing(color);
            if (K == null)
            {
                throw new BoardException("Não tem rei no tabuleiro");
            }

            foreach(Piece piece in piecesInPlay(Opponent(color)))
            {
                bool[,] allPossibleMoves = piece.PossibleMovements();
                if (allPossibleMoves[K.Position.Row, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach(Piece piece in piecesInPlay(color))
            {
                bool[,] allPossibleMoves = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++) 
                    { 
                        if (allPossibleMoves[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destination);
                            bool isCheck = IsCheck(color);
                            ResetMove(origin, destination, capturedPiece);
                            if (!isCheck)
                            {
                                return false;
                            }
                        }
                    }
                } 
            }
            return true;
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
            AddNewPiece('e', 1, new King(Board, Color.White, this));
            AddNewPiece('f', 1, new Bishop(Board, Color.White));
            AddNewPiece('g', 1, new Knight(Board, Color.White));
            AddNewPiece('h', 1, new Rook(Board, Color.White));

            AddNewPiece('a', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('b', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('c', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('d', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('e', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('f', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('g', 2, new Pawn(Board, Color.White, this));
            AddNewPiece('h', 2, new Pawn(Board, Color.White, this));

            AddNewPiece('a', 8, new Rook(Board, Color.Black));
            AddNewPiece('b', 8, new Knight(Board, Color.Black));
            AddNewPiece('c', 8, new Bishop(Board, Color.Black));
            AddNewPiece('d', 8, new Queen(Board, Color.Black));
            AddNewPiece('e', 8, new King(Board, Color.Black, this));
            AddNewPiece('f', 8, new Bishop(Board, Color.Black));
            AddNewPiece('g', 8, new Knight(Board, Color.Black));
            AddNewPiece('h', 8, new Rook(Board, Color.Black));

            AddNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            AddNewPiece('h', 7, new Pawn(Board, Color.Black, this));
        }
    }
}
