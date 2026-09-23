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
    }
}
