namespace board
{
    class Piece
    {
        public Position Position {  get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Board board, Color color)
        {
            this.Position      = position;
            this.Board         = board;
            this.Color         = color;
            this.AmountOfMoves = 0;
        }

    }
}
