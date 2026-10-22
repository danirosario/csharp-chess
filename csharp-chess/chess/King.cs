using board;
using System.Text.RegularExpressions;

namespace chess
{
    internal class King : Piece
    {
        private ChessMatch Match;
        public King(Board chessBoard, Color color, ChessMatch match) : base(chessBoard, color) 
        {
            this.Match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != this.Color;
        }

        private bool CastlingTest(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p is Rook && p.Color == Color && p.AmountOfMoves == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleKingMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal direita acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal direita abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal esquerda abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //esquerda
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal esquerda acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //#jogada especial
            position.SetValues(Position.Row, Position.Column);

            if (AmountOfMoves == 0 && !Match.MatchFinished)
            {
                //roque pequeno
                Position rookPosition1 = new Position(Position.Row, Position.Column + 3);
                if (CastlingTest(rookPosition1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        possibleKingMoves[Position.Row, Position.Column + 2] = true;
                    }
                }
                //roque grande
                Position rookPosition2 = new Position(Position.Row, Position.Column - 4);
                if (CastlingTest(rookPosition2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        possibleKingMoves[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleKingMoves;
        }
    }
}
