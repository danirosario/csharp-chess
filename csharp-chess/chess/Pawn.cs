using board;

namespace chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board chessBoard, Color color) : base(chessBoard, color) { }

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
            }

            return possiblePawnMoves;
        }
    }
}
