using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BlackPawn : Piece
    {
        public BlackPawn(int pozX, int pozY, Game gme) : base(pozX,pozY,gme)
        {
            picBox.Image = Properties.Resources.black_pawn;
            this.color = "b";
        }

        private bool isFirstMove = true;

        public override bool CanMove(int xInit, int yInit, int xDest, int yDest, string pieceType)
        {
            if (isFirstMove)
            {
                if (xInit == xDest && (yDest - yInit == 1 || yDest - yInit == 2))
                {
                    isFirstMove = false;
                }
                if (pieceType == "ChessGame.BlackPawn")
                {
                    isFirstMove = false;
                    return (xInit == xDest || Math.Abs(xInit - xDest) == 1) && (yDest - yInit == 1 || yDest - yInit == 2);
                }
                return xInit == xDest && (yDest - yInit == 1 || yDest - yInit == 2);
            }
            else
            {
                if (pieceType == "ChessGame.BlackPawn")
                {
                    return (xInit == xDest || Math.Abs(xInit - xDest) == 1) && yDest - yInit == 1;
                }
                return xInit == xDest && yDest - yInit== 1;
            }

        }
    }
}
