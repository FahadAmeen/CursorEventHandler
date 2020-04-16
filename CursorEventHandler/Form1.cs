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
            textBox1.Text = "0.00051";
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


                if (InputValues.GetValueIf("Required_Pixel_Color_If") == MouseEventHandler.GetColor().ToLower())
                {
                    MouseEventHandler.LeftMouseClick();
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueIf("Delay_2_If")));
                    MouseEventHandler.RightMouseClick(int.Parse(InputValues.GetValueIf("3_Click_Right_Button_X_Axis_If")), int.Parse(InputValues.GetValueIf("3_Click_Right_Button_Y_Axis_If")));
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueIf("Delay_3_If")));
                    MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueIf("4_Click_Left_Button_X_Axis_If")), int.Parse(InputValues.GetValueIf("4_Click_Left_Button_Y_Axis_If ")));
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueIf("Delay_4_If")));
                    MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueIf("5_Click_Left_Button_X_Axis_If")), int.Parse(InputValues.GetValueIf("5_Click_Left_Button_Y_Axis_If ")));

                }
                
            }
            else if (numb <= double.Parse(InputValues.GetValueIf("Value_1_Else")))
            {
                MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueElse("1_Click_Left_Button_X_Axis_Else")), int.Parse(InputValues.GetValueElse("1_Click_Left_Button_Y_Axis_Else")));
                MouseEventHandler.SetCursorPos(int.Parse(InputValues.GetValueElse("Move_Cursor_to_X_Axis_Else")),
                    int.Parse(InputValues.GetValueElse("Move_Cursor_to_Y_Axis_Else")));
                MouseEventHandler.Delay(int.Parse(InputValues.GetValueElse("Delay_1_Else")));


                if (InputValues.GetValueElse("Required_Pixel_Color_Else") == MouseEventHandler.GetColor().ToLower())
                {
                    MouseEventHandler.LeftMouseClick();
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueElse("Delay_2_Else")));
                    MouseEventHandler.RightMouseClick(int.Parse(InputValues.GetValueElse("3_Click_Right_Button_X_Axis_Else")), int.Parse(InputValues.GetValueElse("3_Click_Right_Button_Y_Axis_Else")));
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueElse("Delay_3_Else")));
                    MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueElse("4_Click_Left_Button_X_Axis_Else")), int.Parse(InputValues.GetValueElse("4_Click_Left_Button_Y_Axis_Else ")));
                    MouseEventHandler.Delay(int.Parse(InputValues.GetValueElse("Delay_4_Else")));
                    MouseEventHandler.LeftMouseClick(int.Parse(InputValues.GetValueElse("5_Click_Left_Button_X_Axis_Else")), int.Parse(InputValues.GetValueElse("5_Click_Left_Button_Y_Axis_Else ")));

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
