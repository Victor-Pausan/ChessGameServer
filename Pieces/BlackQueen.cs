using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackQueen : Piece
    {
        public BlackQueen(int pozX, int pozY, Game gme) : base(pozX,pozY,gme)
        {
            picBox.Image = Properties.Resources.black_queen;
            this.color = "b";
        }

        public override bool CanMove(int xInit, int yInit, int xDest, int yDest, string pieceType)
        {
            return (xInit == xDest || yInit == yDest) || (Math.Abs(xInit - xDest) == Math.Abs(yInit - yDest));
        }
    }
}
