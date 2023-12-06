using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackKnight : Piece
    {
        public BlackKnight(int pozX, int pozY, Game gme) : base(pozX,pozY,gme)
        {
            picBox.Image = Properties.Resources.black_knight;
            this.color = "b";
        }

        public override bool CanMove(int xInit, int yInit, int xDest, int yDest, string pieceType)
        {
            return (Math.Abs(xDest - xInit) == 1 && Math.Abs(yDest - yInit) == 2) || (Math.Abs(xDest - xInit) == 2 && Math.Abs(yDest - yInit) == 1);
        }
    }
}
