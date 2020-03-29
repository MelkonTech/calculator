using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmain : Form
    {
        public List<double> numbers = new List<double>();
        public List<string> operators = new List<string>();
        public bool cantText = false;

        public frmain()
        {
            InitializeComponent();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (cantText)
            {
                lbScreen.Text = "";
                cantText = false;
            }

            if (lbScreen.Text.Contains(",")) lbScreen.Text += bt.Text;
            else
            {
                double num = 0;
                if (lbScreen.Text.Length < 15 && Double.TryParse(lbScreen.Text + bt.Text, out num)) lbScreen.Text = Convert.ToString(num);
            }
        }

        private void bt_plus_Click(object sender, EventArgs e)
        {
            lblast.Text = lblast.Text.Remove(0, lblast.Text.IndexOf('=') + 1);
            Button bt = (Button)sender;
            lblast.Text = string.Concat(lblast.Text, lbScreen.Text, bt.Text);
            operators.Add(bt.Text);
            getSum();
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            lblast.Text = "";
            numbers.Clear();
            operators.Clear();
            lbScreen.Text = "0";
        }

        private void bt_equal_Click(object sender, EventArgs e)
        {
            lblast.Text = lblast.Text.Remove(0, lblast.Text.IndexOf('=') + 1);
            lblast.Text = string.Concat(lblast.Text, lbScreen.Text, "=");
            lbhistory.Items.Insert(0, string.Concat(lblast.Text, lbScreen.Text, '\n').Trim());

            getSum();

            numbers.Clear();
            operators.Clear();
        }

        private void getSum()
        {
            numbers.Add(Convert.ToDouble(lbScreen.Text));
            if (numbers.Count > 1)
            {
                double sum = numbers[0];
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (operators[i] == bt_plus.Text)
                    {
                        sum += numbers[i + 1];
                    }
                    else if (operators[i] == bt_substraction.Text)
                    {
                        sum -= numbers[i + 1];
                    }
                    else if (operators[i] == bt_divide.Text)
                    {
                        sum /= numbers[i + 1];
                    }
                    else if (operators[i] == bt_multiple.Text)
                    {
                        sum *= numbers[i + 1];
                    }
                }
                lbScreen.Text = Convert.ToString(sum);
            }
            cantText = true;
        }

        private void bt_negative_Click(object sender, EventArgs e)
        {
            lbScreen.Text = Convert.ToString(Convert.ToDouble(lbScreen.Text) * (-1));
        }

        private void bt_float_Click(object sender, EventArgs e)
        {
            if (!lbScreen.Text.Contains(",")) lbScreen.Text += ",";
        }

        private void bt_sqrt_Click(object sender, EventArgs e)
        {
            lbScreen.Text = Convert.ToString(Math.Sqrt(Double.Parse(lbScreen.Text)));
        }

        private void bt_sqr_Click(object sender, EventArgs e)
        {
            lbScreen.Text = Convert.ToString(Math.Pow(Double.Parse(lbScreen.Text), 2));
        }

        private void bt_backspace_Click(object sender, EventArgs e)
        {
            if (lbScreen.Text.Length > 1) lbScreen.Text = lbScreen.Text.Remove(lbScreen.Text.Length - 1, 1);
            else lbScreen.Text = "0";
        }

        private void bt_clearScreen_Click(object sender, EventArgs e)
        {
            lbScreen.Text = "0";
        }

        private void bt_division1_Click(object sender, EventArgs e)
        {
            lbScreen.Text = Convert.ToString(1 / Double.Parse(lbScreen.Text));
        }

        private void bt_modul_Click(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (operators[i] == bt_plus.Text)
                {
                    sum += numbers[i];
                }
                else if (operators[i] == bt_substraction.Text)
                {
                    sum -= numbers[i];
                }
                else if (operators[i] == bt_divide.Text)
                {
                    sum /= numbers[i];
                }
                else if (operators[i] == bt_multiple.Text)
                {
                    sum *= numbers[i];
                }
            }

            lbScreen.Text = Convert.ToString(sum / 100 * double.Parse(lbScreen.Text));
        }

        private void bt_history_clear_Click(object sender, EventArgs e)
        {
            lbhistory.Visible = !lbhistory.Visible;
            bt_clear_history.Visible = !bt_clear_history.Visible;
        }

        private void bt_clear_history_Click(object sender, EventArgs e)
        {
            lbhistory.Items.Clear();
        }

    }
}