using board;

namespace chess
{
    internal class Pawn : Piece
    {
        private ChessMatch Match;
        public Pawn(Board chessBoard, Color color, ChessMatch match) : base(chessBoard, color) 
        { 
            this.Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p.Color != Color;
        }

        private bool PositionFree(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possiblePawnMoves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(Position.Row, Position.Column);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.ValidePosition(pos) && PositionFree(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;

                    Position pos2 = new Position(Position.Row - 2, Position.Column);
                    if (Board.ValidePosition(pos2) && PositionFree(pos2) && AmountOfMoves == 0)
                    {
                        possiblePawnMoves[pos2.Row, pos2.Column] = true;
                    }
                }

                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidePosition(pos) && HasEnemy(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidePosition(pos) && HasEnemy(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;
                }

                //#jogada especial en passant (esquerda)
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidePosition(left) && HasEnemy(left) && Board.Piece(left) == Match.VulnerableToEnPassant)
                    {
                        possiblePawnMoves[left.Row - 1, left.Column] = true;
                    }
                }

                //# (direita)
                if (Position.Row == 3)
                {
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidePosition(right) && HasEnemy(right) && Board.Piece(right) == Match.VulnerableToEnPassant)
                    {
                        possiblePawnMoves[right.Row - 1, right.Column] = true;
                    }
                }
            } 
            else 
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidePosition(pos) && PositionFree(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;

                    Position pos2 = new Position(Position.Row + 2, Position.Column);
                    if (Board.ValidePosition(pos2) && PositionFree(pos2) && AmountOfMoves == 0)
                    {
                        possiblePawnMoves[pos2.Row, pos2.Column] = true;
                    }
                }

                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidePosition(pos) && HasEnemy(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidePosition(pos) && HasEnemy(pos))
                {
                    possiblePawnMoves[pos.Row, pos.Column] = true;
                }

                //#jogada especial en passant (esquerda)
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidePosition(left) && HasEnemy(left) && Board.Piece(left) == Match.VulnerableToEnPassant)
                    {
                        possiblePawnMoves[left.Row + 1, left.Column] = true;
                    }
                }

                //# (direita)
                if (Position.Row == 4)
                {
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidePosition(right) && HasEnemy(right) && Board.Piece(right) == Match.VulnerableToEnPassant)
                    {
                        possiblePawnMoves[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return possiblePawnMoves;
        }
    }
}
