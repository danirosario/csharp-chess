using board;

namespace chess
{
    internal class Knigth : Piece
    {
        public Knigth(Board chessBoard, Color color) : base(chessBoard, color) { }

        public override string ToString()
        {
            return "N";
        }
    }
}
