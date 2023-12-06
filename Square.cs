using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class Square
    {
        private Game game;
        public int x, y;
        public Panel panel;

        public Square(Game gme)
        {
            game = gme;
            panel = new Panel();
            this.panel.Click += PanelClick;
        }

        private void PanelClick(object sender, EventArgs e)
        {
            x = this.panel.TabIndex % 8;
            y = this.panel.TabIndex / 8;
            foreach(Piece p in game.list)
            {
                if(p.GetIsClicked()==true)
                {
                    if (p.CanMove(p.PozX, p.PozY, this.x, this.y,"panel"))
                    {

                        game.mainForm.server.Set_tbServerDate(p.PozX.ToString() + p.PozY.ToString() + this.x.ToString() + this.y.ToString());

                        p.picBox.Location = this.panel.Location;
                        p.SetisClicked(false);
                        game.SetPanelColor(p.PozX, p.PozY);
                        game.SetPanelColor(this.x, this.y);
                        p.PozX = this.x;
                        p.PozY = this.y;
                        p.picBox.BackColor = this.panel.BackColor;
                        p.picBox.BringToFront();

                        ////promote white pawn
                        //if (p.GetType().ToString() == "ChessGame.WhitePawn" && p.PozY == 0)
                        //{
                        //    PromoteForm promForm = new PromoteForm(game, game.list.IndexOf(p));
                        //    promForm.ShowDialog();
                        //}

                        ////promote black pawn
                        //if (p.GetType().ToString() == "ChessGame.BlackPawn" && p.PozY == 7)
                        //{
                        //    PromoteForm promForm = new PromoteForm(game, game.list.IndexOf(p));
                        //    promForm.ShowDialog();
                        //}
                        break;
                    }
                }
            }
        }
    }
}
