using board;

namespace chess
{
    internal class King : Piece
    {
        public King(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null || p.Color != this.Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleKingMoves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //acima
            position.SetValues(position.Row - 1, position.Column);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal direita acima
            position.SetValues(position.Row - 1, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //direita
            position.SetValues(position.Row, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal direita abaixo
            position.SetValues(position.Row + 1, position.Column + 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //abaixo
            position.SetValues(position.Row + 1, position.Column);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal esquerda abaixo
            position.SetValues(position.Row + 1, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //esquerda
            position.SetValues(position.Row, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            //diagonal esquerda acima
            position.SetValues(position.Row - 1, position.Column - 1);
            if (Board.ValidePosition(position) && CanMove(position))
            {
                possibleKingMoves[position.Row, position.Column] = true;
            }

            return possibleKingMoves;
        }
    }
}
