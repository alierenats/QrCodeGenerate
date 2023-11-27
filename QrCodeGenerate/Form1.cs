using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace QrCodeGenerate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            pictureBox1.Image = encoder.Encode(textBox1.Text);
            string base64Image = ImageToBase64(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Png);
            string webPageHtml = base64Image;
            textBox2.Text = webPageHtml;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }
    }
}
