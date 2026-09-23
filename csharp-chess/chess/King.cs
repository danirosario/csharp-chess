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
    }
}
