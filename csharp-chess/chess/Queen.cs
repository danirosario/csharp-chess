using board;

namespace chess
{
    internal class Queen : Piece
    {
        public Queen(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleQueenMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
            }

            //diagonal direita acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
                position.Column += 1;
            }

            //acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row += 1;
            }

            //diagonal direita abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row += 1;
                position.Column += 1;
            }

            // direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column + 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column += 1;
            }

            //diagonal esquerda abaixo
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row + 1, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row += 1;
                position.Column -= 1;
            }

            // direita
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Column -= 1;
            }

            //diagonal esquerda acima
            position.SetValues(Position.Row, Position.Column);
            position.SetValues(position.Row - 1, position.Column - 1);
            while (Board.ValidePosition(position) && CanMove(position))
            {
                possibleQueenMoves[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != this.Color)
                {
                    break;
                }
                position.Row -= 1;
                position.Column -= 1;
            }

            return possibleQueenMoves;
        }
    }
}
