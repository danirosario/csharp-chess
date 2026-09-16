using board;

namespace chess
{
    internal class Knigth : Piece
    {
        public Knigth(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
        }
    }
}
