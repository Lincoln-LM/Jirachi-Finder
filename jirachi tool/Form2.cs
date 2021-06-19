using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jirachi_tool
{
    public partial class Form2 : Form
    {
        public ulong bbase;
        public Form2(ulong sbase)
        {
            InitializeComponent();
            bbase = sbase;
        }

        private Dictionary<string, uint> timecalc(ulong startt, uint target, uint ssecond, uint sminute, uint sframe)
        {
            ulong start = startt + (uint)(MINUTES.Value + SECONDS.Value * 0x100 + FRAMES.Value);
            uint dif = (uint)(target - start & 0xFFFF);
            uint seconds = dif / 0x100;
            uint minuteframe = dif % 0x100;

            if (seconds + ssecond > 59)
            {
                return new Dictionary<string, uint>() { { "minuteframe", 0 }, { "second", 0 } };
            }
            if (minuteframe+sminute+sframe > 118)
            {
                return new Dictionary<string, uint>() { { "minuteframe", 0 }, { "second", 0 } };
            }

            return new Dictionary<string, uint>() { { "minuteframe", minuteframe }, { "second", seconds } };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint sminutes = (uint)MINUTES.Value;
            uint sseconds = (uint)SECONDS.Value;
            uint sframes = (uint)FRAMES.Value;

            Dictionary<string, uint> time = timecalc(bbase, (uint)TARGET.Value, sseconds, sminutes, sframes);

            label1.Text = time["minuteframe"].ToString();
            label5.Text = time["second"].ToString();

        }
    }
}
