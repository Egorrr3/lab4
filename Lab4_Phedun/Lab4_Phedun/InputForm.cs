using Lab4_Phedun.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Phedun
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        void checkEmpty()
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox11.Text) ||
                string.IsNullOrWhiteSpace(textBox12.Text)
                )
            {
                throw new Exception("Всі поля повинні бути заповнені");
            }
        }

        void checkInput()
        {
            if (
                textBox1.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox2.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox3.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox4.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox5.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox6.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox7.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox8.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox9.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox10.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox11.Text.Contains(Table.TXT_SPLIT_SYMBOL) ||
                textBox12.Text.Contains(Table.TXT_SPLIT_SYMBOL)
                )
            {
                throw new Exception("Не використовуйте символ " + Table.TXT_SPLIT_SYMBOL);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                checkEmpty();
                checkInput();
                Event worker = new Event(
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text,
                    textBox5.Text,
                    textBox6.Text,
                    textBox7.Text,
                    new PreparationInfo(textBox8.Text, textBox9.Text),
                    textBox10.Text,
                    textBox11.Text,
                    textBox12.Text
                );

                Table.AddRow(worker.GetData());
                UserMessager.SuccessAdditionMessage();
                Close();
            }
            catch (Exception exception)
            {
                UserMessager.InputErrorMessage(exception);
            }
        }
    }
}
