using board;

namespace chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleBishopMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //diagonal direita acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleBishopMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
                position.Column += 1;
            }

            //diagonal direita abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleBishopMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row += 1;
                position.Column += 1;
            }

            //diagonal esquerda abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleBishopMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row += 1;
                position.Column -= 1;
            }

            //diagonal esquerda acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleBishopMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
                position.Column -= 1;
            }

            return possibleBishopMoves;
        }
    }
}
