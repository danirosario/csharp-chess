using board;

namespace chess
{
    internal class Knight : Piece
    {
        public Knight(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "N";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleKnightMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //acima direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 2, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column + 2);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            //acima esquerda
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 2, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column - 2);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            //abaixo direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 2, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column - 2);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            //abaixo esquerda
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 2, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column + 2);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKnightMoves[position.Row, position.Column] = true;
            }

            return possibleKnightMoves;
        }
    }
}
