using System;
using System.Windows.Forms;

namespace CursorEventHandler
{
    public partial class Form1 : Form
    {
        public double _userInput { get; set; }
        private ReadJson InputValues;




        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "01234.223";
            _userInput= double.Parse(textBox1.Text);
            textBox1.TextChanged += TextBox1_TextChanged;
            InputValues=new ReadJson();
            // Algo(_userInput);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string text = tb.Text;

            ValueChanged(text);
        }
        private void ValueChanged(object value)
        {
            double numb = double.Parse(value.ToString());
            Algo(numb);
        }

        private void Algo(double numb)
        {
            if (numb >= double.Parse(InputValues.GetValueIf("Value_1_If")))
            {
                MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueIf("1_Click_Left_Button_X_Axis_If")), int.Parse(InputValues.GetValueIf("1_Click_Left_Button_Y_Axis_If")));
                MouseEventHandler.SetCursorPos(int.Parse(InputValues.GetValueIf("Move_Cursor_to_X_Axis_If")),
                    int.Parse(InputValues.GetValueIf("Move_Cursor_to_Y_Axis_If")));
                MouseEventHandler.Delay(int.Parse(InputValues.GetValueIf("Delay_1_If")));
                // MessageBox.Show("Ok");
            }
            if(InputValues.GetValueIf("(Required_Pixel_Color_If"))
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
