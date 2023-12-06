using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Game
    {
        public Form1 mainForm;
        public Game(Form1 f)
        {
            mainForm = f;
        }

        public Square[,] _chessBoardPanels;
        public int xPoz = 0, yPoz = 0;
        public List<Piece> list = new List<Piece>();

        public void CreateSquares()
        {
            _chessBoardPanels = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Square p = new Square(this);
                    _chessBoardPanels[i, j] = p;
                    p.panel.Size = new Size(80, 80);
                    p.panel.Location = new Point(xPoz, yPoz);
                    if ((i + j) % 2 != 0)
                    {
                        p.panel.BackColor = Color.FromArgb(100, 152, 51);
                    }
                    else
                    {
                        p.panel.BackColor = Color.FromArgb(232, 236, 204);
                    }
                    mainForm.Controls.Add(p.panel);
                    xPoz += 80;
                }
                yPoz += 80;
                xPoz = 0;
            }
        }
        public void CreatePieces()
        {
            for (int i = 0; i < 8; i++)
            {
                //pioni albi
                WhitePawn wp = new WhitePawn(i, 6, this);
                Show(wp);

                //pioni negri
                BlackPawn bp = new BlackPawn(i, 1, this);
                Show(bp);
            }

            //ture albe
            WhiteRook wr = new WhiteRook(7, 7, this);
            Show(wr);
            wr = new WhiteRook(0, 7, this);
            Show(wr);

            //ture negre
            BlackRook br = new BlackRook(0, 0, this);
            Show(br);
            br = new BlackRook(7, 0, this);
            Show(br);

            //cal alb
            WhiteKnight wk = new WhiteKnight(1, 7, this);
            Show(wk);
            wk = new WhiteKnight(6, 7, this);
            Show(wk);

            //cal negru
            BlackKnight bk = new BlackKnight(1, 0, this);
            Show(bk);
            bk = new BlackKnight(6, 0, this);
            Show(bk);

            //nebun alb
            WhiteBishop wb = new WhiteBishop(2, 7, this);
            Show(wb);
            wb = new WhiteBishop(5, 7, this);
            Show(wb);

            //nebun negru
            BlackBishop bb = new BlackBishop(2, 0, this);
            Show(bb);
            bb = new BlackBishop(5, 0, this);
            Show(bb);

            //regina alba
            WhiteQueen wq = new WhiteQueen(3, 7, this);
            Show(wq);

            //regina neagra
            BlackQueen bq = new BlackQueen(3, 0, this);
            Show(bq);

            //rege alb
            WhiteKing wK = new WhiteKing(4, 7, this);
            Show(wK);

            //rege negru
            BlackKing bK = new BlackKing(4, 0, this);
            Show(bK);

        }

        public void SetPanelColor(int pozX, int pozY)
        {
            //Console.WriteLine(pozX + " " + pozY);
            if ((pozX + pozY) % 2 != 0)
                this._chessBoardPanels[pozY, pozX].panel.BackColor = Color.FromArgb(100, 152, 51);
            else
                this._chessBoardPanels[pozY, pozX].panel.BackColor = Color.FromArgb(232, 236, 204);
        }

        public void Show(Piece piece)
        {
            piece.picBox.Location = _chessBoardPanels[piece.PozY, piece.PozX].panel.Location;
            piece.picBox.BackColor = _chessBoardPanels[piece.PozY, piece.PozX].panel.BackColor;
            mainForm.Controls.Add(piece.picBox);
            piece.picBox.BringToFront();
            list.Add(piece);
        }

        public void UpdateTable(int initX, int initY, int destX, int destY)
        {
            Console.WriteLine(initX+" "+initY+ " "+ destX+ " "+destY);
            foreach (Piece i in list)
            {
                if (i.PozX == initX && i.PozY == initY)
                {
                    foreach (Piece j in list)
                    {
                        if (j.PozX == destX && j.PozY == destY)
                        {
                            i.picBox.Location = j.picBox.Location;
                            this.SetPanelColor(i.PozX, i.PozY);
                            this.SetPanelColor(destX, destY);
                            i.picBox.BackColor = this._chessBoardPanels[destX, destY].panel.BackColor;
                            i.PozX = destX;
                            i.PozY = destY;
                            i.picBox.BringToFront();
                            j.picBox.SendToBack();
                            list.Remove(j);
                            return;
                        }
                    }

                    Square s;
                    s = _chessBoardPanels[destY, destX];

                    i.picBox.Location = s.panel.Location;
                    this.SetPanelColor(i.PozX, i.PozY);
                    this.SetPanelColor(destX, destY);
                    i.picBox.BackColor = s.panel.BackColor;
                    i.PozX = destX;
                    i.PozY = destY;
                    s.panel.BringToFront();
                    i.picBox.BringToFront();

                }
            }
        }
    }
}
