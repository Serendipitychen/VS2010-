﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 串口调试助手_Tony
{
    public partial class Extend : UserControl
    {
        public Extend()
        {
            InitializeComponent();
        }

        private void Extend_Load(object sender, EventArgs e)
        {
            this.button_Send.Tag = this.textBox1;
        }
    }
}
