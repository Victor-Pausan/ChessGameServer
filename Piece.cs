using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public abstract class Piece 
    {
        private int pozX, pozY;
        private bool isClicked=false;
        protected string color;
        private Game game;
        public PictureBox picBox;

        public Piece(int pozX, int pozY, Game gme)
        {
            game = gme;
            picBox = new PictureBox();
            this.pozX = pozX;
            this.pozY = pozY;
            this.picBox.Size = new Size(80, 80);
            this.picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBox.Click += PieceClicked;
           
        }

        public int PozX { get => pozX; set => pozX = value; }
        public int PozY { get => pozY; set => pozY = value; }

        public bool GetIsClicked()
        {
            return this.isClicked;
        }

        public void SetisClicked(bool isClicked)
        {
            this.isClicked = isClicked;
        }

        public abstract bool CanMove(int xInit, int yInit, int xDest, int yDest, string pieceType);

        private void PieceClicked(object sender, EventArgs e)
        {
            bool passedIfCondition = false;
 
            //verific daca a fost alta piesa aleasa deja
            foreach (Piece i in game.list)
            {
                if(i.isClicked && !this.isClicked)
                {
                    passedIfCondition = true;
                    if (i.CanMove(i.pozX, i.pozY, this.pozX, this.pozY, i.GetType().ToString()))
                    {
                        if (i.color == this.color || this.GetType().ToString()== "ChessGame.WhiteKing"
                            || this.GetType().ToString() == "ChessGame.BlackKing")
                        {
                            break;
                        }

                        game.mainForm.server.Set_tbServerDate(i.pozX.ToString() + i.pozY.ToString() + this.pozX.ToString() + this.pozY.ToString());

                        i.picBox.Location = this.picBox.Location;
                        game.SetPanelColor(i.pozX, i.pozY);
                        game.SetPanelColor(this.pozX, this.pozY);
                        Console.WriteLine(game._chessBoardPanels[this.pozX, this.pozY].panel.BackColor);
                        i.picBox.BackColor = game._chessBoardPanels[this.pozX, this.pozY].panel.BackColor;
                        i.pozX = this.pozX;
                        i.pozY = this.pozY;
                        i.isClicked = false;
                        i.picBox.BringToFront();
                        this.picBox.SendToBack();
                        game.list.Remove(this);

                        ////promote white pawn
                        //if (i.GetType().ToString() == "ChessGame.WhitePawn" && i.pozY == 0)
                        //{
                        //    PromoteForm promForm = new PromoteForm(game, game.list.IndexOf(i));
                        //    promForm.ShowDialog();
                        //}

                        ////promote black pawn
                        //if (i.GetType().ToString() == "ChessGame.BlackPawn" && i.pozY == 7)
                        //{
                        //    PromoteForm promForm = new PromoteForm(game, game.list.IndexOf(i));
                        //    promForm.ShowDialog();
                        //}

                        break;
                    }
                }
            }

            var initColor = game._chessBoardPanels[this.pozY, this.pozX].panel.BackColor;
            if(!passedIfCondition)
                isClicked = true; 
            if (initColor == Color.FromArgb(235, 189, 52))
            {
                isClicked = false;
                game.SetPanelColor(pozX, pozY);
            }
            if(isClicked)
            {
                game._chessBoardPanels[pozY, pozX].panel.BackColor = Color.FromArgb(235, 189, 52) ;
            }

            this.picBox.BackColor = game._chessBoardPanels[pozY, pozX].panel.BackColor;
        }
    }
}
