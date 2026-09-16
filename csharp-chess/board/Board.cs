namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            this.Rows    = rows;
            this.Columns = columns;
            this.Pieces  = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public void AddPiece(Piece p, Position x)
        {
            Pieces[x.Row, x.Column] = p;

        }
    }
} 