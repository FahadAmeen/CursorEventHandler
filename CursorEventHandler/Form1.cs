using System;
using System.Windows.Forms;

namespace CursorEventHandler
{
    public partial class Form1 : Form
    {
        public double UserInput { get; set; }
        private readonly ReadJson _inputValues;


        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"-0.00051";
            UserInput = double.Parse(textBox1.Text);
            _inputValues = new ReadJson();
            // Algorithm(UserInput);
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox) sender;
            string text = tb.Text;

            ValueChanged(text);
        }

        private void ValueChanged(object value)
        {
            double numb = double.Parse(value.ToString());
            Algorithm(numb);
        }

        private void Algorithm(double numb)
        {
            // getting values from the json file
            if (numb >= double.Parse(_inputValues.GetValueIf("Value_1_If")))
            {
                MouseEventHandler.LeftMouseClick(int.Parse(_inputValues.GetValueIf("1_Click_Left_Button_X_Axis_If")),
                    int.Parse(_inputValues.GetValueIf("1_Click_Left_Button_Y_Axis_If")));
                MouseEventHandler.SetCursorPos(int.Parse(_inputValues.GetValueIf("Move_Cursor_to_X_Axis_If")),
                    int.Parse(_inputValues.GetValueIf("Move_Cursor_to_Y_Axis_If")));
                Delay_1_If:
                MouseEventHandler.Delay(int.Parse(_inputValues.GetValueIf("Delay_1_If")));

                if (String.Equals(_inputValues.GetValueIf("Required_Pixel_Color_If"), MouseEventHandler.GetColor(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    MouseEventHandler.LeftMouseClick();
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueIf("Delay_2_If")));
                    MouseEventHandler.RightMouseClick(
                        int.Parse(_inputValues.GetValueIf("3_Click_Right_Button_X_Axis_If")),
                        int.Parse(_inputValues.GetValueIf("3_Click_Right_Button_Y_Axis_If")));
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueIf("Delay_3_If")));
                    MouseEventHandler.LeftMouseClick(
                        int.Parse(_inputValues.GetValueIf("4_Click_Left_Button_X_Axis_If")),
                        int.Parse(_inputValues.GetValueIf("4_Click_Left_Button_Y_Axis_If ")));
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueIf("Delay_4_If")));
                    MouseEventHandler.LeftMouseClick(
                        int.Parse(_inputValues.GetValueIf("5_Click_Left_Button_X_Axis_If")),
                        int.Parse(_inputValues.GetValueIf("5_Click_Left_Button_Y_Axis_If ")));
                }
                else
                {
                    // goto Delay_1_If;
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueIf("Delay_1_If")));
                }
            }
            else if (numb <= double.Parse(_inputValues.GetValueElse("Value_1_Else")))
            {
                MouseEventHandler.LeftMouseClick(
                    int.Parse(_inputValues.GetValueElse("1_Click_Left_Button_X_Axis_Else")),
                    int.Parse(_inputValues.GetValueElse("1_Click_Left_Button_Y_Axis_Else")));
                MouseEventHandler.SetCursorPos(int.Parse(_inputValues.GetValueElse("Move_Cursor_to_X_Axis_Else")),
                    int.Parse(_inputValues.GetValueElse("Move_Cursor_to_Y_Axis_Else")));
                Delay_1_Else:
                MouseEventHandler.Delay(int.Parse(_inputValues.GetValueElse("Delay_1_Else")));


                if (String.Equals(_inputValues.GetValueElse("Required_Pixel_Color_Else"), MouseEventHandler.GetColor(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    MouseEventHandler.LeftMouseClick();
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueElse("Delay_2_Else")));
                    MouseEventHandler.RightMouseClick(
                        int.Parse(_inputValues.GetValueElse("3_Click_Right_Button_X_Axis_Else")),
                        int.Parse(_inputValues.GetValueElse("3_Click_Right_Button_Y_Axis_Else")));
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueElse("Delay_3_Else")));
                    MouseEventHandler.LeftMouseClick(
                        int.Parse(_inputValues.GetValueElse("4_Click_Left_Button_X_Axis_Else")),
                        int.Parse(_inputValues.GetValueElse("4_Click_Left_Button_Y_Axis_Else ")));
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueElse("Delay_4_Else")));
                    MouseEventHandler.LeftMouseClick(
                        int.Parse(_inputValues.GetValueElse("5_Click_Left_Button_X_Axis_Else")),
                        int.Parse(_inputValues.GetValueElse("5_Click_Left_Button_Y_Axis_Else ")));
                }
                else
                {
                    // goto Delay_1_Else;
                    MouseEventHandler.Delay(int.Parse(_inputValues.GetValueElse("Delay_1_Else")));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}