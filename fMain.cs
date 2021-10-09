using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaSuperCalculadora
{
    public partial class fMain : Form
    {

        private decimal _operand;
        
        private string _operandtxt;
        private string _operador;

        public fMain()
        {
            InitializeComponent();
            _Reset();
        }

        private void set_operandtxt(string value)//establece el valor de text box
        {

            //if is a numerical value
            if(value == "9" || value == "8" || value == "7" || value == "6" || value == "5" || value == "4" || value == "3" || value == "2" || value == "1" || value == "0")
            {
                //if value of _operandtxt is '0' 
                if (_operandtxt == "0")
                    _operandtxt = "";//delete it

                _operandtxt += value;//add the new value
                txtResult.Text = _operandtxt;
            }
            //if is an operator
            else if(value=="+" || value== "-" || value == "/" || value == "*")
            {
                //if there was an operator assigned

                if (_operador != "" && _operandtxt != "")
                {
                    doOperation();//do the last operation first
                }
                else if (_operador != "" && _operandtxt == "")
                {
                    _operandtxt = _operand.ToString();
                    _operand = 0;
                }


                if (_operandtxt != "")
                {
                    _operador = value;
                    _operand = decimal.Parse(_operandtxt);
                }
                txtResult.Text = _operandtxt+ " "+ _operador;
                _operandtxt = "";
            }
            //if is equal '='
            else if(value == "=")
            {
                if (_operandtxt != "")
                {
                    doOperation();
                }
                
            }
            //if is delete or backspace
            else if (value == "\b")
            {
                _Delete();
            }

            //if is reset or esc
            else if(value== "\u001b")
            {
                _Reset();
            }
            //if is decimal 
            else if (value == "," ||  value== ".")
            {
                if (_operandtxt.IndexOf(".") < 0)
                {
                    _operandtxt += ".";
                    txtResult.Text = _operandtxt;
                }
               
            }
            
        }

        private void doOperation()
        {
            decimal  resultado= 0;
            if (_operador == "+")
            {
                resultado = _operand + decimal.Parse(_operandtxt);
                
            }

            if (_operador == "-")
            {
                resultado = _operand - decimal.Parse(_operandtxt);
            }

            if (_operador == "*")
            {
                resultado = _operand * decimal.Parse(_operandtxt);
            }

            if (_operador == "/")
            {
                resultado = _operand / decimal.Parse(_operandtxt);
            }

            _operandtxt = resultado.ToString();
            _operand = 0;
            _operador = "";
            txtResult.Text = resultado.ToString();
            
        }

        private void _Delete()
        {
            if(_operandtxt.Length != 0)
            {
                if(_operandtxt.Length > 0)
                {
                    _operandtxt = _operandtxt.Substring(0, _operandtxt.Length - 1);
                    txtResult.Text = _operandtxt;
                }
                 
            }
            else
            {
                _operandtxt = "0";
            }
           
        }

        private void _Reset()
        {
            _operandtxt = "0";
            _operand = 0;
            _operador = "";
            txtResult.Text = "0";
        }

        private void fMain_Load(object sender, EventArgs e)//esta funcion es por darle doble click a main load
        {
            //no hace nada
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            set_operandtxt("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            set_operandtxt("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            set_operandtxt("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            set_operandtxt("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            set_operandtxt("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            set_operandtxt("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            set_operandtxt("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            set_operandtxt("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            set_operandtxt("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            set_operandtxt("0");
        }

        private void label2_Click(object sender, EventArgs e)//esta es de donde dice 'La Super Calculadora' 
        {
            //no hace nada
        }

        private void btnDeSuma_Click(object sender, EventArgs e)
        {
            set_operandtxt("+");
        }

        private void txtResult_KeyPress(object sender, KeyPressEventArgs e)//funcion nula
        {
            //no hace nada
        }

        private void fMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;
            set_operandtxt(keyPressed.ToString());
        }

        private void btnDeIgualdad_Click(object sender, EventArgs e)
        {
            if (_operandtxt != "")
            {
                doOperation();
            }
            
        }

        private void btnDeResta_Click(object sender, EventArgs e)
        {
            set_operandtxt("-");
        }

        private void btnDeBorrar_Click(object sender, EventArgs e)
        {
            _Delete();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _Reset();
        }

        private void btnDeDecimal_Click(object sender, EventArgs e)
        {
            set_operandtxt(",");
        }

        private void btnDeMultiplicar_Click(object sender, EventArgs e)
        {
            set_operandtxt("*");
        }

        private void btnDeDividir_Click(object sender, EventArgs e)
        {
            set_operandtxt("/");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //es donde dice 'by Beandro Brito Contreras'
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
