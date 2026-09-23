using board;

namespace chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "B";
        }
    }
}
