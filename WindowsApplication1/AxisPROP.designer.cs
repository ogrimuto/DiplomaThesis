using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Axis : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            Pic = new PictureBox();
            Pic.MouseDown += new MouseEventHandler(Pic_MouseDown);
            ((System.ComponentModel.ISupportInitialize)Pic).BeginInit();
            SuspendLayout();
            // 
            // Pic
            // 
            Pic.BackColor = Color.White;
            Pic.BorderStyle = BorderStyle.FixedSingle;
            Pic.Dock = DockStyle.Fill;
            Pic.Location = new Point(0, 0);
            Pic.Name = "Pic";
            Pic.Size = new Size(150, 150);
            Pic.TabIndex = 0;
            Pic.TabStop = false;
            // 
            // Axis
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Pic);
            Name = "Axis";
            ((System.ComponentModel.ISupportInitialize)Pic).EndInit();
            Resize += new EventHandler(UserControl_Resize);
            ResumeLayout(false);

        }
        internal PictureBox Pic;

    }
}