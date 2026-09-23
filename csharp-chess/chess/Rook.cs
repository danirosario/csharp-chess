using board;

namespace chess
{
    internal class Rook : Piece
    {
        public Rook(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
