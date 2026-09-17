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

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool isPieceAtPosition(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void AddPiece(Piece p, Position position)
        {
            if (isPieceAtPosition(position))
            {
                throw new BoardException("Position occupied, there is a piece in that position");
            }
            
            Pieces[position.Row, position.Column] = p;
            p.Position = position;
        }

        public bool ValidePosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidePosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
} 