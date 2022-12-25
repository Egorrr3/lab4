using Lab4_Phedun.Classes;

namespace Lab4_Phedun
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(toolStripTextBox4.Text))
                {
                    if (int.TryParse(toolStripTextBox4.Text, out int index))
                    {
                        mainDataGridView.Rows.RemoveAt(index - 1);
                        Table.tableData.RemoveAt(index - 1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                UserMessager.NumberOutOfRangeMessage();
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Table.ExportToJson();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Table.ImportFromJson();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Table.Import();
            }
            catch (ArgumentOutOfRangeException)
            {
                UserMessager.FileFormatMessage();
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                Table.Export();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                {
                    UserMessager.InputEventMessage();
                }
                else
                {
                    string searchCriteria = toolStripTextBox1.Text;

                    Table.FilterByCell(searchCriteria, 0);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox2.Text))
                {
                    UserMessager.InputFacultyMessage();
                }
                else
                {
                    string searchCriteria = toolStripTextBox2.Text;

                    Table.FilterByCell(searchCriteria, 2);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox3.Text))
                {
                    UserMessager.InputPipMessage();
                }
                else
                {
                    string searchCriteria = toolStripTextBox3.Text;

                    Table.FilterByCell(searchCriteria, 1);
                    Table.PrintTableFiltered();
                }
            }
            catch (Exception exception)
            {
                UserMessager.GeneralErrorMessage(exception);
            }
        }

        private void cancelSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table.PrintTable();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Table.SetupDataGridView(mainDataGridView);
        }
    }
}