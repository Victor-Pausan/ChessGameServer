using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class WhitePawn : Piece
    {
        public WhitePawn(int pozX, int pozY, Game gme) : base(pozX,pozY,gme)
        {
            picBox.Image = Properties.Resources.white_pawn;
            this.color = "w";
        }

        private bool isFirstMove = true;

        public override bool CanMove(int xInit, int yInit, int xDest, int yDest,string pieceType)
        {
            if (isFirstMove)
            {
                if (xInit == xDest && (yInit - yDest == 1 || yInit - yDest == 2))
                {
                    isFirstMove = false;
                }
                if (pieceType == "ChessGame.WhitePawn")
                {
                    isFirstMove = false;
                    return (xInit == xDest || Math.Abs(xInit - xDest) == 1) && (yInit - yDest == 1 || yInit - yDest == 2);
                }
                return xInit == xDest && (yInit-yDest == 1 || yInit-yDest== 2);
            }
            else
            {
                if(pieceType=="ChessGame.WhitePawn")
                {
                    return (xInit == xDest || Math.Abs(xInit-xDest) == 1)  && yInit - yDest == 1;
                }
                return xInit == xDest && yInit-yDest== 1;
            }

        }
    }
}
