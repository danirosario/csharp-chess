using board;

namespace chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
        }
    }
}
