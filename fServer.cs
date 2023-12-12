using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class fServer : Form
    {
        Form1 mainForm;
        public TcpListener server;
        public String dateServer;

        private static fServer serverForm;
        Thread t;
        bool workThread;
        NetworkStream streamServer;
        public fServer(Form1 mainForm)
        {
            InitializeComponent();
            this.textBox1.Hide();
            this.tbServerDate.Hide();
            this.btnSend.Hide();

            this.FormClosed += FServer_FormClosed;
            btnSend.Click += btnSend_Click;
            this.mainForm = mainForm;
            tbServerDate.KeyPress += tbServerDate_KeyPress;

            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            t = new Thread(new ThreadStart(Asculta_Server));
            workThread = true;

            t.Start();
            serverForm = this;
            textBox2.SelectionStart = 0;
        }

        public void Asculta_Server()
        {
            while (workThread)
            {
                Socket socketServer = server.AcceptSocket();
                if(IsSocketConnected(socketServer))
                {
                    MethodInvoker closeForm = new MethodInvoker(()=> this.WindowState = System.Windows.Forms.FormWindowState.Minimized);
                    this.Invoke(closeForm);
                    MethodInvoker openMainForm = new MethodInvoker(() => mainForm.WindowState = System.Windows.Forms.FormWindowState.Normal);
                    mainForm.Invoke(openMainForm);
                }
                
                try
                {
                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);

                    while (workThread)
                    {

                        string dateServer = citireServer.ReadLine();

                        if (dateServer == null) break;//primesc nimic - clientul a plecat

                        if (dateServer == "#Gata") //ca sa pot sa inchid serverul
                            workThread = false;
                        MethodInvoker m = new MethodInvoker(() =>
                        serverForm.textBox1.Text += (socketServer.LocalEndPoint + ": " + dateServer + Environment.NewLine));
                        serverForm.textBox1.Invoke(m);

                        MethodInvoker n = new MethodInvoker(() => mainForm.game.UpdateTable(Convert.ToInt32(dateServer[0] - '0'),
                            Convert.ToInt32(dateServer[1] - '0'),
                            Convert.ToInt32(dateServer[2] - '0'),
                            Convert.ToInt32(dateServer[3]) - '0'));
                        mainForm.Invoke(n);

                    }
                    streamServer.Close();
                }
                catch (Exception e)
                {
#if LOG
                    Console.WriteLine(e.Message);
#endif
                }
                socketServer.Close();
            }
        }

        static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);

        }

        private void FServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            workThread = false;
            streamServer.Close();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(tbServerDate.Text);
                textBox1.Text += "Server: " + tbServerDate.Text + Environment.NewLine;
                tbServerDate.Clear();
                // s_text.Close();
            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                //  client.Close();
            }
        }

        private void tbServerDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnSend_Click(sender, e);
            }
        }

        public void Set_tbServerDate(string pozitii)
        {
            tbServerDate.Text = pozitii;
            try
            {

                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(tbServerDate.Text);
                textBox1.Text += "Server: " + tbServerDate.Text + Environment.NewLine;
                tbServerDate.Clear();
                // s_text.Close();
            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                //  client.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Waiting...";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
