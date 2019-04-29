using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace HeapCompaction
{
    public partial class Form1 : Form
    {
        private byte[][] allocs = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FragmentLOH();
            GC.Collect();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FragmentLOH();
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
        }

        private void FragmentLOH()
        {
            int size = 90000;
            int maxmem = 1000;

            int numAllocs = maxmem * 1000000 / size;

            allocs = new byte[numAllocs / 2][];

            for (int i = 0; i < numAllocs / 2; i++)
            {
                allocs[i] = new byte[size];
            }

            for (int i = 1; i < numAllocs / 2; i += 2)
            {
                allocs[i] = null;
            }
        }
    }
}
