namespace board
{
    abstract class Piece
    {
        public Position Position {  get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.Position      = null;
            this.Board         = board;
            this.Color         = color;
            this.AmountOfMoves = 0;
        }
        public void IncreaseAmountOfMoves()
        {
            AmountOfMoves++;
        }

        public bool HasLegalMoves()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMovements(); 

    }
}
