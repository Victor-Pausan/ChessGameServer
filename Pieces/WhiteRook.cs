using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class WhiteRook : Piece
    {
        public WhiteRook(int pozX, int pozY, Game gme) : base(pozX,pozY,gme)
        {
            picBox.Image = Properties.Resources.white_tower;
            this.color = "w";
        }

        public override bool CanMove(int xInit, int yInit, int xDest, int yDest, string pieceType)
        {
            return xInit == xDest || yInit == yDest;
        }
    }
}
