using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;



namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TcpClient tcpClient = new TcpClient();
            using var stream =  new StreamWriter(tcpClient.GetStream());
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
            int size = data.Length;

            string name = openFileDialog1.FileName.Split("\\").Last();
            byte[] nameEncoded = Encoding.UTF8.GetBytes(name);
            
            stream.Write(nameEncoded.Length);
            stream.Write(nameEncoded);
            stream.Write(size);
            stream.Write(data);
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
