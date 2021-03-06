﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.IO;
using System.Drawing.Imaging;

///注意有一个qrcode_data的文件夹，要放在Debug根目录下面！！！！

namespace 二维码解析
{
    public partial class Form1 : Form
    {
        private static Form1 instance=null;
        private Form1()
        {
            InitializeComponent();
        }
        public static Form1 create_instance()
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text == null)
            {
                MessageBox.Show("解析字符不能为空！！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QRCodeEncoder qr = new QRCodeEncoder();
            qr.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qr.QRCodeScale = 4;
            qr.QRCodeVersion = 7; //为0可以防止字符串太长时编码错误
            qr.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            Image bmp = qr.Encode(textBox1.Text.Trim());
            this.pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter="JPEG IMAGE|*.jpg|bitmap image|*.bmp|gif imag|*.gif|png imag|*.png";
            FileStream fs = null;
            ImageFormat  format=null;
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch(sfd.FilterIndex)
                {
                    case 0:
                        format=ImageFormat.Jpeg;
                        break;
                    case 1:
                        format=ImageFormat.Bmp;
                        break;
                    case 2:
                        format=ImageFormat.Gif;
                        break;
                    case 3:
                        format=ImageFormat.Png;
                        break;
                    default:format=ImageFormat.Png;
                        break;
                }
                if (sfd.FileName != null && sfd.FileName != "")
                {
                    fs = new FileStream(sfd.FileName,FileMode.Create,FileAccess.Write);
                    this.pictureBox1.Image.Save(fs, format);
                }
                fs.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPEG IMAGE|*.jpg|bitmap image|*.bmp|gif imag|*.gif|png imag|*.png";
            if (op.ShowDialog() == DialogResult.OK)
                this.pictureBox1.Image = new Bitmap(op.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QRCodeDecoder qrd = new QRCodeDecoder();
            sbyte[] resultData =qrd.decodeBytes(new QRCodeBitmapImage(new Bitmap(this.pictureBox1.Image)));
            //label1.Text = qrd.decode(new QRCodeBitmapImage(new Bitmap(this.pictureBox1.Image)),Encoding.Unicode);
            byte[] myResultData = SbyteToByte(resultData);
            if (IsUnicode(myResultData))
                label1.Text = Encoding.Unicode.GetString(myResultData);
            else
                label1.Text = Encoding.ASCII.GetString(myResultData);


        }
        byte[] SbyteToByte(sbyte[] _sbyte)
        {
            byte[] myByte = new byte[_sbyte.Length];
            for (int i = 0; i < _sbyte.Length; i++)
            {
                if (_sbyte[i] > 0)
                    myByte[i] = (byte)_sbyte[i];
                else
                    myByte[i] = (byte)(_sbyte[i] + 256);
            }
            return myByte;
        }
        public static bool IsUnicode(byte[] byteData)//unicode（中文）与ASCII码的区别
        {
            //string value1 = FromASCIIByteArray(byteData);
            //string value2 = FromUnicodeByteArray(byteData);
            //byte[] ascii = AsciiStringToByteArray(value1);
            //byte[] unicode = UnicodeStringToByteArray(value2);
            //if (ascii[0] != unicode[0])
            //    return true;
            //return false;
            bool isUnicode = false;
            foreach (byte value in byteData)
            {
                if (value > 127)
                {
                    isUnicode = true;
                    break;
                }

            }
            return isUnicode;//返回是不是Unicode编码
        }
        public bool IsQRImage(Bitmap bmp,out string content)
        {
            bool result = true;
            QRCodeDecoder qrd = new QRCodeDecoder();
                try
                {
                   content= qrd.decode(new QRCodeBitmapImage(bmp));
                }
                catch(Exception e)
                {
                    result=false;
                    content = null;
                    return result;
                }
            
            return result;
        }
    }
}
