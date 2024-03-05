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
    public partial class Form2 : Form ///form pt setarea numelor jucatorilor (daca se doreste implementare se sterg comentariile din form2.cs si din form1.cs)
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  tictactoe.setPlayerNames(P1.Text, P2.Text); //preia valorile si le pune in text boxurile p1 si p2
            this.Close();//inchiderea formului 2 dupa introducerea numelor
        }
    }
}
