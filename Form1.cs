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
    public partial class Form1 : Form
    {
        public Game game;
        public fServer server;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
            server = new fServer(this);
            server.Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            game = new Game(this);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.CreateSquares();
            game.CreatePieces();
        }
    }
}