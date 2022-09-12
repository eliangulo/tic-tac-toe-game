using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrondEnd
{
    public partial class Form1 : Form
    {
        //variables
        string jugadorX = "";
        string jugadorO = "";
        bool cambio = true; // creamos variable para el metodo (b)
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnClickButton(false);
        }
        private void OnClickButton(bool enabled)
        {
            btn1.Enabled = enabled;
            btn1.Font = new Font(btn1.Font.FontFamily, 30);
            btn2.Enabled = enabled;
            btn2.Font = new Font(btn2.Font.FontFamily, 30);
            btn3.Enabled = enabled;
            btn3.Font = new Font(btn3.Font.FontFamily, 30);
            btn4.Enabled = enabled;
            btn4.Font = new Font(btn4.Font.FontFamily, 30);
            btn5.Enabled = enabled;
            btn5.Font = new Font(btn4.Font.FontFamily, 30);
            btn6.Enabled = enabled;
            btn6.Font = new Font(btn6.Font.FontFamily, 30);
            btn7.Enabled = enabled;
            btn7.Font = new Font(btn7.Font.FontFamily, 30);
            btn8.Enabled = enabled;
            btn8.Font = new Font(btn8.Font.FontFamily, 30);
            btn9.Enabled = enabled;
            btn9.Font = new Font(btn9.Font.FontFamily, 30);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            //ingresar nombre y con que juegan X o 0
            if (txtJugador1.Text == "" && txtJugador2.Text == "")
            {
                MessageBox.Show("El nombre de los jugadores no debe estar vacio",
                    "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtJugador1.Text == "")
                {
                    MessageBox.Show("El nombre de los jugador 1 no debe estar vacio",
                    "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txtJugador2.Text == "")
                {
                    MessageBox.Show("El nombre de los jugador 2 no debe estar vacio",
                    "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (txtJugador1.Text != "" && txtJugador2.Text != "")
            {
                if (rbtnJugador1X.Checked && rbtnJugador2O.Checked)
                {
                    jugadorX = txtJugador1.Text;
                    jugadorO = txtJugador2.Text;
                    rtbnJugador1O.Enabled = false;
                    rbtnJugador2O.Enabled = false;
                    rbtnJugador1X.Enabled = false;
                    rbtnJugador2X.Enabled = false;
                    PlayGame();
                }
                if (rtbnJugador1O.Checked && rbtnJugador2X.Checked)
                {
                    jugadorX = txtJugador2.Text;
                    jugadorO = txtJugador1.Text;
                    rbtnJugador1X.Enabled = false;
                    rtbnJugador1O.Enabled = false;
                    rbtnJugador2X.Enabled = false;
                    rbtnJugador2O.Enabled = false;
                    PlayGame();
                }
                if (rbtnJugador1X.Checked && rbtnJugador2X.Checked)
                {
                    MessageBox.Show("Solo un jugador puede seleccionar la letra X.",
                   "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rtbnJugador1O.Checked && rbtnJugador2O.Checked)
                {
                    MessageBox.Show("Solo un jugador puede seleccionar la letra O.",
                   "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rbtnJugador1X.Checked == false && rtbnJugador1O.Checked == false ||
                   rbtnJugador2X.Checked == false && rbtnJugador2O.Checked == false)
                {
                    MessageBox.Show("Cada jugador debe seleccionar una letra.",
                   "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void PlayGame()
        {  //Metodo para que use el nombre del jugador en vez de jugador 1
            lblJugadorUno.Text = txtJugador1.Text;
            lblJugador2.Text = txtJugador2.Text;
            //visibilidad del puntador
            lblPuntosJ1.Visible = true;
            lblPuntosJ2.Visible = true;

            groupBox1.Text = "Marcador";
            //Desaparezca o aparezaca los botones principales
            btnLimpiar.Visible = true;
            btnReiniciar.Visible = true;
            btnIniciar.Visible = false;
            txtJugador1.Visible = false;
            txtJugador2.Visible = false;
            MessageBox.Show("Empieza " + jugadorX,
            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //activacion de los botones (b)
            OnClickButton(true);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            //creamos un objeto (b = todos los botones)
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false; // boton desactivado
            Partida(); //metodo

        }

        private void Partida()
        {   //horizontales
            if ((btn1.Text == btn2.Text) & (btn2.Text == btn3.Text) && (!btn1.Enabled))
            { Validacion(btn1); }

            else if ((btn4.Text == btn5.Text) & (btn5.Text == btn6.Text) && (!btn4.Enabled))
            { Validacion(btn4); }

            else if ((btn7.Text == btn8.Text) & (btn8.Text == btn9.Text) && (!btn7.Enabled))
            { Validacion(btn7); }
            ///verticales
            if ((btn1.Text == btn4.Text) & (btn4.Text == btn7.Text) && (!btn1.Enabled))
            { Validacion(btn1); }

            else if ((btn2.Text == btn5.Text) & (btn5.Text == btn8.Text) && (!btn2.Enabled))
            { Validacion(btn2); }

            else if ((btn3.Text == btn6.Text) & (btn6.Text == btn9.Text) && (!btn3.Enabled))
            { Validacion(btn3); }

            //oblicua 
            if ((btn1.Text == btn5.Text) & (btn5.Text == btn9.Text) && (!btn1.Enabled))
            { Validacion(btn1); }

            else if ((btn3.Text == btn5.Text) & (btn5.Text == btn7.Text) && (!btn3.Enabled))
            { Validacion(btn3); }
            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Es un empate. ",
               "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnClickButton(true);
                empate = 0;
            }
        }

        public void Validacion(Button b)
        {
            empate = -1;
            if (b.Text == "X")
            {
                MessageBox.Show("Gana " + jugadorX, "Felicidades",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Gana " + jugadorO, "Felicidades",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;
            }
            if (rbtnJugador1X.Checked && rbtnJugador2O.Checked)
            {
                lblPuntosJ1.Text = ganadasX.ToString();
                lblPuntosJ2.Text = ganadasO.ToString();
            }
            else if (rtbnJugador1O.Checked && rbtnJugador2X.Checked)
            {
                lblPuntosJ2.Text = ganadasX.ToString();
                lblPuntosJ1.Text = ganadasO.ToString();
            }
            Limpiar();
            OnClickButton(true);
        }
        //Metodo limpiar
        private void Limpiar()
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnClickButton(true);
            empate = 0;
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnClickButton(false);
            btnLimpiar.Visible = false;
            btnReiniciar.Visible = false;   
            btnIniciar.Visible = true;
            txtJugador1.Visible = true;
            txtJugador2.Visible = true;
            txtJugador1.Text = "";
            txtJugador2.Text = "";
            jugadorX = "";
            jugadorO = "";
            ganadasX = 0;
            ganadasO = 0;
            cambio = true;
            lblPuntosJ1.Text = 0.ToString();
            lblPuntosJ2.Text = 0.ToString();
            lblJugadorUno.Text = "";
            lblJugador2.Text = "";

            rtbnJugador1O.Enabled = true;
            rbtnJugador2O.Enabled = true;
            rbtnJugador1X.Enabled = true;
            rbtnJugador2X.Enabled = true;

            rbtnJugador1X.Checked = false;
            rtbnJugador1O.Checked = false;
            rbtnJugador2X.Checked = false;
            rbtnJugador2O.Checked = false;

            lblPuntosJ1.Visible = false;
            lblPuntosJ2.Visible = false;

            groupBox1.Text = "Introduzca los jugadore";
        }

    }
 }   


