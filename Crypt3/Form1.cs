using crypt3;
using System.Collections;
using System.IO;
using System.Text;

namespace Crypt3
{
    public partial class Form1 : Form
    {
        private string fileContent = string.Empty;
        private string fileName = string.Empty;
        Huffman huffman = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void îòêðûòüÔàéëToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = ofd.FileName;
                fileContent = File.ReadAllText(ofd.FileName);
                richTextBox1.Text = fileContent;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void îòêðûòüÀðõèâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = ofd.FileName;
                fileContent = File.ReadAllText(ofd.FileName);
                richTextBox2.Text = fileContent;
            }
            else
            {
                MessageBox.Show("Error");
                return;
            }
            var rrr = huffman.DecompressFile(ofd.FileName, "3.txt");
            richTextBox2.Text = rrr.Item1;
            richTextBox3.Text = rrr.Item2;
        }
        //Compress
        private void button1_Click(object sender, EventArgs e)
        {
            var compressed = huffman.Compress(fileName, "2.txt");
            richTextBox2.Text = compressed;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Letter", "Letter");
            dataGridView1.Columns.Add("Frequency", "Frequency");
            dataGridView1.Columns.Add("Code", "Code");

            var t = huffman.tNode;
            List<Node> nodes = new List<Node>();
            Next(t);
            nodes = nodes.OrderByDescending(n => n.freq).ToList();
            var letters = nodes.Select(n => n.symbol).ToArray();
            var strLetters = System.Text.Encoding.UTF8.GetString(letters);
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].c = strLetters[i].ToString();
            }
            foreach (Node node in nodes)
            {
                dataGridView1.Rows.Add(new string[] { node.symbol.ToString(), node.freq.ToString(), node.code });
            }
            label4.Text = $"Original:{new FileInfo(fileName).Length}    Compressed:{new FileInfo("2.txt").Length}";



            void Next(Node node)
            {
                if (node.bit0 == null)
                {
                    nodes.Add(node);
                }
                else
                {
                    Next(node.bit0);
                    Next(node.bit1);
                }
            }

        }
    }






}