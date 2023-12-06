using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class PromoteForm : Form
    {
        public Game game;
        public int indexOfPawnInList;
        public string promotedPieceName;
        public PromoteForm(Game game, int indexOfPawnInList)
        {
            this.game = game;
            this.indexOfPawnInList = indexOfPawnInList;
            InitializeComponent();
        }

        private void PromoteForm_Load(object sender, EventArgs e)
        {
            
        }

        private void promoteTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = promoteTo.SelectedIndex;
            int count = promoteTo.Items.Count;

            for(int x=0; x<count; x++)
            {
                if(index != x)
                {
                    promoteTo.SetItemChecked(x, false);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for(int i=0; i<promoteTo.Items.Count; i++)
            {
                if(promoteTo.GetItemChecked(i))
                {
                    promotedPieceName = promoteTo.SelectedItem.ToString();
                    break;
                }
            }

            Piece p = game.list[indexOfPawnInList];
            int x = p.PozX;
            int y = p.PozY;

            switch (this.promotedPieceName)
            {
                case "Queen": 
                    p.picBox.SendToBack();
                    game.list.Remove(p);
                    if (p.GetType().ToString() == "ChessGame.WhitePawn")
                    {
                        WhiteQueen wq = new WhiteQueen(x, y, game);
                        game.Show(wq);
                    }
                    else
                    {
                        BlackQueen bq = new BlackQueen(x, y, game);
                        game.Show(bq);
                    }
                    this.Close();
                    break;

                case "Bishop":
                    p.picBox.SendToBack();
                    game.list.Remove(p);
                    if (p.GetType().ToString() == "ChessGame.WhitePawn")
                    {
                        WhiteBishop wq = new WhiteBishop(x, y, game);
                        game.Show(wq);
                    }
                    else
                    {
                        BlackBishop bq = new BlackBishop(x, y, game);
                        game.Show(bq);
                    }
                    this.Close();
                    break;

                case "Knight":
                    p.picBox.SendToBack();
                    game.list.Remove(p);
                    if (p.GetType().ToString() == "ChessGame.WhitePawn")
                    {
                        WhiteKnight wq = new WhiteKnight(x, y, game);
                        game.Show(wq);
                    }
                    else
                    {
                        BlackKnight bq = new BlackKnight(x, y, game);
                        game.Show(bq);
                    }
                    this.Close();
                    break;

                case "Rook":
                    p.picBox.SendToBack();
                    game.list.Remove(p);
                    if (p.GetType().ToString() == "ChessGame.WhitePawn")
                    {
                        WhiteRook wq = new WhiteRook(x, y, game);
                        game.Show(wq);
                    }
                    else
                    {
                        BlackRook bq = new BlackRook(x, y, game);
                        game.Show(bq);
                    }
                    this.Close();
                    break;
            }

        }
    }
}
