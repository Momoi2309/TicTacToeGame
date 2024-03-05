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
        bool against_ai = false;//initial jocu e 2 player
       // static String player1, player2; //variabile statice pe tot programul (numele jucatorilor)
        public tictactoe()
        {
            InitializeComponent();
        }

      /*  public static void setPlayerNames(string n1, string n2) //clasa publica de tip static
        {
            player1 = n1;
            player2 = n2;
        } */ 
        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicație realizată de Momoi Alex\n\n Pentru a juca vs o persoana,se va preciza numele playerului in zona 'Computer' ", " Tot Respectu ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((p1.Text == "Player 1") || (p2.Text =="Player 2") )
            {
                MessageBox.Show("Trebuie sa precizezi numele jucatorilor inainte de a incepe jocul \n Tasteaza 'Computer' pentru a jucat vs Computer");
            }
            else
            { Button b = (Button)sender;
                if (mutare)
                    b.Text = "X";
                else
                    b.Text = "O";
                mutare = !mutare;
                b.Enabled = false;
                nr_mutare++;
                label2.Focus();

                verifica_castigator();
               
            }
            ///Nr_mutare<9 trebuie implementat  deoarece in caz de egalitate, computerul nu mai are ce buton sa apese(computerul va da click doar de 8 ori inainte de mutarea a 9 a adversarului)
            if ((!mutare)&&(against_ai)&&(nr_mutare<9)) ///verifica daca atunci cand e rundul lui O este impotriva ai-ului.
            {
                ai_make_move();
            }
           
        }//end button click
        private void ai_make_move()
        {
            ///prioriate 1: castiga jocul
            ///prioritate 2: blocheaza X
            ///prioritate 3: strategie spatiu colt
            ///prioritate 4:alege un spatiu gol

            Button turn = null;

            //strategii de castigare a jocului
            turn = look_for_win_or_block("O");///se intra in functia look for win or block si se marcheaza cu O spatiile libere
            if(turn==null)
            {
                turn = look_for_win_or_block("X");///se cauta blocarea playerului 1 (X)
                if(turn==null)
                {
                    turn= look_for_corner();
                    if(turn==null)
                    {
                        turn = look_for_open_space();
                    }
                }///end if look for open space
            }///end if look for block
            turn.PerformClick();///daca mutarea diferita de null computerul va face mutarea respectiva
        }///end ai make move

        private Button look_for_win_or_block(String mark)
        {
            Console.WriteLine("Caut castig sau blocare" + mark);
            ///TEST PE ORIZONTALA
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3; ///completeaza ultima miscare pt a castiga /sau pt a bloca miscarea finala a adversarului
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            ///TEST PE VERTICALA
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            ///TEST PE DIAGONALA
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;///completeaza ultima miscare pt a castiga/sau pt a bloca miscarea finala a adversarului

            return null; ///daca nu a gasit computerul un loc unde sa faca o miscare pt a castiga returneaza null
        } /// end LOOK FOR WIN OR BLOCK AI
        private Button look_for_corner()
        {
            Console.WriteLine("Caut colt liber");///Cand computerul deja marcheaza intr un colt va cauta coltul opus liber pt a castiga pe diagonala
            if (A1.Text == "O") 
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "") ///daca niciun colt nu e marcat, va lua unul liber
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null; ///daca fiecare colt este luat de X atunci va returna null
        }/// end LOOK FOR CORNER AI
        private Button look_for_open_space() /// Functie AI pentru a cauta spatiu liber pt mutare
        {
            Console.WriteLine("Caut spatiu liber");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button; //casting de fiecare control(tool folosit in form) pt buton
                if (b != null)
                {
                    if (b.Text == "") //daca butonul este liber se va putea face miscarea dorita
                        return b;
                }//end if
            }//end if

            return null;
        }///end LOOK FOR OPEN SPACE AI
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
                disableButtons(); //dezactiveaza butoanele pt a nu mai fi modificate mutarile (cheat)
                String castigator = "";
                if (mutare)
                {
                    castigator = p2.Text;// O
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    castigator = p1.Text;// X (la ultima mutare se schimba mutarea)
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show("*doot*      " + castigator + " AI CÂȘTIGAT            *doot*", "CAMPIONU");
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
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end try
                catch { }
            }//end foreach
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) //functie de restart joc
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

        private void button_enter(object sender, EventArgs e) //mark ul pozitiilor
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
            }
        }

        private void restartWinCountToolStripMenuItem_Click(object sender, EventArgs e) //functie de restart a win counturilor
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void tictactoe_Load(object sender, EventArgs e) //launch joc
        {
            /*Form2 f2 = new Form2();
            f2.ShowDialog(); //va afisa form2 pana nu se introduc datele necesar iar abia apoi jocul 
            label1.Text = player1; //numele playerilor vor fi deja setati din form 2 odata inchis (din functia setPlayerNames din clasa publica statica
            label3.Text = player2; */
            setDefaultToolStripMenuItem.PerformClick(); //apeleaza la deschiderea jocului vs ai implicit
        }

        private void p2_TextChanged(object sender, EventArgs e) ///functie de set a jocului vs ai
        {
            if (p2.Text.ToUpper()=="COMPUTER") ///converteste cuvantul "computer" la uppercase sub orice forma ar fi el scris
                against_ai = true;
            else
                against_ai = false;

        }

        private void setDefaultToolStripMenuItem_Click(object sender, EventArgs e) ///functie ce initializeaza jocul initial vs ai
        {
            p1.Text = "Alex";
            p2.Text = "Computer";
        }
    }
}
