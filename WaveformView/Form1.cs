using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    TODO
        overload char array display so it shows the chars, not the type
        Find a way to set property grids to their natural height
        set up new chunks
*/

namespace WaveformView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int xOffset = 0;
            int yOffset = 0;

            Riff riff = new Riff(47);
            ChunkDisplay disp = new ChunkDisplay(riff);
            disp.Size = new Size(panel1.Width - 10, 100);
            disp.Location = new Point(xOffset, yOffset);;
            panel1.Controls.Add(disp);

            yOffset += 110;

            Fmt fmt = new Fmt(1, 2, 3, 4, 5, 6, 7);
            ChunkDisplay dips2 = new ChunkDisplay(fmt);
            dips2.Size = new Size(panel1.Width - 10, 100);
            dips2.Location = new Point(xOffset, yOffset);
            panel1.Controls.Add(dips2);

            yOffset += 110;

            Data data = new Data(15);
            ChunkDisplay disp3 = new ChunkDisplay(data);
            disp3.Size = new Size(panel1.Width - 10, 100);
            disp3.Location = new Point(xOffset, yOffset);
            panel1.Controls.Add(disp3);            
        }
    }
}
