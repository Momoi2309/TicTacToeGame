using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_si_Zero
{
    public partial class tictactoe : Form
    {
        bool mutare = true; // true= X , false= O
        int nr_mutare = 0; // de cate ori jucatorul realizeaza o mutare
        static String player1, player2; //variabile statice pe tot programul (numele jucatorilor)
        public tictactoe()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(string n1, string n2) //clasa publica de tip static
        {
            player1 = n1;
            player2 = n2;
        }
        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicație realizată de Momoi Alex", "Tot respectu");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (mutare)
                b.Text = "X";
            else
                b.Text = "O";
            mutare = !mutare;
            b.Enabled = false;
            nr_mutare++;

            verifica_castigator();
        }

        private void verifica_castigator()
        {
            //verificare castigator pe orizontala

            bool exista_castigator = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))// primul buton trebuie sa fie dezactivat intrucat altfel nu va functiona pentru ca toate butoanele au acelasi text: " "
                exista_castigator = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                exista_castigator = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                exista_castigator = true;

            //verificare pe diagonala

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))// primul buton trebuie sa fie dezactivat intrucat altfel nu va functiona pentru ca toate butoanele au acelasi text: " "
                exista_castigator = true;
            else if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!A3.Enabled))
                exista_castigator = true;

            //verificare pe verticala

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))// primul buton trebuie sa fie dezactivat intrucat altfel nu va functiona pentru ca toate butoanele au acelasi text: " "
                exista_castigator = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                exista_castigator = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                exista_castigator = true;

            if(exista_castigator)
            {
                disableButtons();
                String castigator = "";
                if (mutare)
                {
                    castigator = player2;//O
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    castigator = player1;// X (la ultima mutare se schimba mutarea
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show("*doot*      " + castigator + " AI CÂȘTIGAT      *doot*", "CAMPIONU");
            }//end if

            else
            {
                if (nr_mutare == 9)
                {
                   draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("EGALITATE", "2 din 3"); 
                }

            }
        }//end verifica_castigator

        private void disableButtons()
        {
            try
            {
                foreach(Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }//end try
            catch { }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mutare = true;// Jocul va incepe mereu cu mutarea lui X
            nr_mutare = 0;
           
           
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c; //cast
                        b.Enabled = true; //pt fiecare control din form il castez drept buton
                        b.Text = "";
                    }//end try
                    catch { }
                }//end foreach
           
            
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            { 
            if (mutare)
                b.Text = "X";
            else
                b.Text = "O";
            }//end if
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }//end if
        }

        private void restartWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void tictactoe_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); //va afisa form2 pana nu se introduc datele necesar iar abia apoi jocul 
            label1.Text = player1; //numele playerilor vor fi deja setati din form 2 odata inchis (din functia setPlayerNames din clasa publica statica
            label3.Text = player2;
        }
    }
}
