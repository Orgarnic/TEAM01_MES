﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cohesion_Project
{
   public partial class Frm_Main : Form
   {
      public Frm_Main()
      {
         InitializeComponent();
      }

      private void Btn_Close_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void Frm_Main_Load(object sender, EventArgs e)
      {

      }
   }
}
