using System;
using System.IO;
using System.Windows.Forms;

namespace Unity_Game_StringToCSV
{
    public partial class Form1 : Form
    {
        private StringProcessor stringProcessor;
        private Logger logger;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private Label label1;
        private Label label2;

        public Form1()
        {
            InitializeComponent();
            stringProcessor = new StringProcessor();
            logger = new Logger();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Select Unity string file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                textBox2.Text = Path.ChangeExtension(openFileDialog.FileName, ".csv");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Select CSV file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                stringProcessor.ExtractStrings(textBox1.Text, textBox2.Text);
                logger.LogMessage($"Strings extracted to {textBox2.Text}");
                listBox1.Items.Add($"Strings extracted to {textBox2.Text}");
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                listBox1.Items.Add($"Error: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                stringProcessor.ImportCsv(textBox2.Text, textBox1.Text);
                logger.LogMessage($"Translations imported to {textBox1.Text}");
                listBox1.Items.Add($"Translations imported to {textBox1.Text}");
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                listBox1.Items.Add($"Error: {ex.Message}");
            }
        }
    }
}