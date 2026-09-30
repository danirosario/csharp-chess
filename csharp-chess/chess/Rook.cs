using board;

namespace chess
{
    internal class Rook : Piece
    {
        public Rook(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleRookMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            // acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleRookMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
            }

            // abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleRookMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row = position.Row + 1;
            }

            // direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleRookMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            // esquerda
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleRookMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }

            return possibleRookMoves;
        }
    }
}
