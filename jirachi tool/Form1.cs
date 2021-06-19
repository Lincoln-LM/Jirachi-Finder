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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private uint nametovalue(string name)
        {
            Dictionary<char, uint> chartohex = new Dictionary<char, uint>(){
                                  {'A', 0xBB},
                                  {'B', 0xBC},
                                  {'C', 0xBD},
                                  {'D', 0xBE},
                                  {'E', 0xBF},
                                  {'F', 0xC0},
                                  {'G', 0xC1},
                                  {'H', 0xC2},
                                  {'I', 0xC3},
                                  {'J', 0xC4},
                                  {'K', 0xC5},
                                  {'L', 0xC6},
                                  {'M', 0xC7},
                                  {'N', 0xC8},
                                  {'O', 0xC9},
                                  {'P', 0xCA},
                                  {'Q', 0xCB},
                                  {'R', 0xCC},
                                  {'S', 0xCD},
                                  {'T', 0xCE},
                                  {'U', 0xCF},
                                  {'V', 0xD0},
                                  {'W', 0xD1},
                                  {'X', 0xD2},
                                  {'Y', 0xD3},
                                  {'Z', 0xD4},

                                  {'a', 0xD5},
                                  {'b', 0xD6},
                                  {'c', 0xD7},
                                  {'d', 0xD8},
                                  {'e', 0xD9},
                                  {'f', 0xDA},
                                  {'g', 0xDB},
                                  {'h', 0xDC},
                                  {'i', 0xDD},
                                  {'j', 0xDE},
                                  {'k', 0xDF},
                                  {'l', 0xE0},
                                  {'m', 0xE1},
                                  {'n', 0xE2},
                                  {'o', 0xE3},
                                  {'p', 0xE4},
                                  {'q', 0xE5},
                                  {'r', 0xE6},
                                  {'s', 0xE7},
                                  {'t', 0xE8},
                                  {'u', 0xE9},
                                  {'v', 0xEA},
                                  {'w', 0xEB},
                                  {'x', 0xEC},
                                  {'y', 0xED},
                                  {'z', 0xEE},


                                  {' ', 0x00},
                                  {'．', 0xAD},
                                  {'，', 0xB8},

                                  {'0', 0xA1},
                                  {'1', 0xA2},
                                  {'2', 0xA3},
                                  {'3', 0xA4},
                                  {'4', 0xA5},
                                  {'5', 0xA6},
                                  {'6', 0xA7},
                                  {'7', 0xA8},
                                  {'8', 0xA9},
                                  {'9', 0xAA},

                                  {'！', 0xAB},
                                  {'？', 0xAC},
                                  
                                  {'♂', 0xB5},
                                  {'♀', 0xB6},

                                  {'／', 0xBA},

                                  {'－', 0xAE},

                                  {'‥', 0xB0},
                                  {'“', 0xB1},
                                  {'”', 0xB2},
                                  {'‘', 0xB3},
                                  {'’', 0xB4}

            };

            uint tvalue = 4278190080;

            int num = 0;
            do
            {
                if (num < name.Length)
                {
                    tvalue = (uint)((unchecked((ulong)tvalue) + unchecked((ulong)(chartohex[name[num]] << checked(unchecked(num % 4) * 8)))) & 0xFFFFFFFFu);
                }
                else
                {
                    tvalue = (uint)((unchecked((ulong)tvalue) + unchecked((ulong)(uint)(255 << checked(unchecked(num % 4) * 8)))) & 0xFFFFFFFFu);
                }
                num++;
            }
            while (num <= 6);
            return tvalue;



        }

        private void change(object sender, EventArgs e)
        {
            uint gender_value = ((uint)(TID.Value) << 16);
            uint time_value = 0x1;
            uint starter_value;
            bool treecko = true;
            bool torchic = true;
            bool mudkip = true;
            uint text_value = 0;
            uint scene_value = 0;
            uint style_value = 0;
            uint sound_value = 0;
            uint button_value = 0;
            uint pokemon_value = 0x10;
            uint name_value = nametovalue(NAME.Text);

            if (FEMALECHECK.Checked)
            {
                gender_value += 0x1;
            }

            if (TIMEXX00CHECK.Checked)
            {
                time_value = 0x180000;
            }
            else if (TIMEXXXXCHECK.Checked)
            {
                time_value = 0x3C170000;
            }

            if (TORCHICCHECK.Checked)
            {
                starter_value = 0x40000000;
                treecko = false;
            }
            else if (MUDKIPCHECK.Checked)
            {
                starter_value = 0x2;
                torchic = false;
            }
            else
            {
                starter_value = 0x08000000;
                mudkip = false;
            }

            if (torchic)
            {
                starter_value += 0x40000000;
            }

            if (treecko)
            {
                starter_value += 0x08000000;
            }

            if (mudkip)
            {
                starter_value += 0x2;
            }


            if (MIDCHECK.Checked)
            {
                text_value = 0x1;
            }
            else if (FASTCHECK.Checked)
            {
                text_value = 0x2;
            }

            if (OFFCHECK.Checked)
            {
                scene_value = 0x400;
            }
            
            if (SETCHECK.Checked)
            {
                style_value = 0x200;
            }

            if (STEREOCHECK.Checked)
            {
                sound_value = 0x100;
            }

            if (LRCHECK.Checked)
            {
                button_value = 0x1000000;
            }
            else if (LACHECK.Checked)
            {
                button_value = 0x2000000;
            }

            if (ZIGZAGOONCHECK.Checked)
            {
                pokemon_value += 0x40;
            }

            if (WURMPLECHECK.Checked)
            {
                pokemon_value += 0x100;
            }

            if (WINGULLCHECK.Checked)
            {
                pokemon_value += 0x200000;
            }

            uint u32checksum = ((uint)MINUTES.Value + ((uint)SECONDS.Value << 8)) + ((uint)FRAMES.Value << 16) + (((uint)FRAMETYPE.Value - 1) * 0x8) + (uint)SID.Value + pokemon_value + gender_value + time_value + starter_value + text_value + scene_value + style_value + sound_value + button_value + name_value;
            uint u16checksum = ((u32checksum >> 16) + (u32checksum & 0xFFFF)) & 0xFFFF;
            label1.Text = u16checksum.ToString("X4");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            uint spsv = 20043 / 8;

            List<string> natures = new List<string> {
                "Hardy","Lonely","Brave","Adamant","Naughty",
                "Bold","Docile","Relaxed","Impish","Lax",
                "Timid","Hasty","Serious","Jolly","Naive",
                "Modest","Mild","Quiet","Bashful","Rash",
                "Calm","Gentle","Sassy","Careful","Quirky"};

            uint gender_value = ((uint)(TID.Value) << 16);
            uint time_value = 0x1;
            uint starter_value;
            bool treecko = true;
            bool torchic = true;
            bool mudkip = true;
            uint text_value = 0;
            uint scene_value = 0;
            uint style_value = 0;
            uint sound_value = 0;
            uint button_value = 0;
            uint pokemon_value = 0x10;
            uint name_value = nametovalue(NAME.Text);

            if (FEMALECHECK.Checked)
            {
                gender_value += 0x1;
            }

            if (TIMEXX00CHECK.Checked)
            {
                time_value = 0x180000;
            }
            else if (TIMEXXXXCHECK.Checked)
            {
                time_value = 0x3C170000;
            }

            if (TORCHICCHECK.Checked)
            {
                starter_value = 0x40000000;
                treecko = false;
            }
            else if (MUDKIPCHECK.Checked)
            {
                starter_value = 0x2;
                torchic = false;
            }
            else
            {
                starter_value = 0x08000000;
                mudkip = false;
            }

            if (torchic)
            {
                starter_value += 0x40000000;
            }

            if (treecko)
            {
                starter_value += 0x08000000;
            }

            if (mudkip)
            {
                starter_value += 0x2;
            }


            if (MIDCHECK.Checked)
            {
                text_value = 0x1;
            }
            else if (FASTCHECK.Checked)
            {
                text_value = 0x2;
            }

            if (OFFCHECK.Checked)
            {
                scene_value = 0x400;
            }

            if (SETCHECK.Checked)
            {
                style_value = 0x200;
            }

            if (STEREOCHECK.Checked)
            {
                sound_value = 0x100;
            }

            if (LRCHECK.Checked)
            {
                button_value = 0x1000000;
            }
            else if (LACHECK.Checked)
            {
                button_value = 0x2000000;
            }

            if (ZIGZAGOONCHECK.Checked)
            {
                pokemon_value += 0x40;
            }

            if (WURMPLECHECK.Checked)
            {
                pokemon_value += 0x100;
            }

            if (WINGULLCHECK.Checked)
            {
                pokemon_value += 0x200000;
            }

            uint u32base = (((uint)FRAMETYPE.Value - 1) * 0x8) + (uint)SID.Value + pokemon_value + gender_value + time_value + starter_value + text_value + scene_value + style_value + sound_value + button_value + name_value;

            uint sminutes = (uint)MINUTESMIN.Value;
            uint sseconds = (uint)SECONDSMIN.Value;
            uint sframes = (uint)FRAMESMIN.Value;
            uint sseed = u32base;

            uint waitminutes = (uint)MINUTESMAX.Value;
            uint waitseconds = (uint)SECONDSMAX.Value;
            uint waitframes = (uint)FRAMESMAX.Value;


            uint waittotal = (waitminutes*60 + waitseconds)*60 + waitframes;
            uint totalframes = (sminutes * 60 + sseconds) * 60 + sframes;
            for (int i=0; i<waittotal; i++)
            {
                sframes += 1;
                totalframes += 1;

                if (sframes>=60)
                {
                    sframes = 0;
                    sseconds += 1;
                    if (sseconds==60)
                    {
                        sseconds = 0;
                        sminutes += 1; 
                    }
                }

                sseed = ((uint)MINUTES.Value + (uint)SECONDS.Value << 8) + ((uint)FRAMES.Value << 16) + sseed;
                uint u16sseed = ((sseed >> 16) + (sseed & 0xFFFF)) & 0xFFFF;
                LCRNG go = new LCRNG(u16sseed);
                uint high = go.nextUShort();
                uint low = go.nextUShort();
                uint iv1 = go.nextUShort();
                uint iv2 = go.nextUShort();
                uint pid = (high << 16) | low;
                uint psv = (high ^ low) / 8;
                string shiny = "No";

                if (psv == spsv) {
                    shiny = "Yes";
                }

                List<uint> ivs = GetIVs(iv1, iv2);

                dataGridView1.Rows.Add(u16sseed.ToString("X4"), totalframes, sminutes, sseconds, sframes, pid.ToString("X8"), shiny, natures[(int)(pid%25)], ivs[0], ivs[1], ivs[2], ivs[3], ivs[4], ivs[5]);
            }


            
        }
        private List<uint> GetIVs(uint iv1, uint iv2)
        {
            uint hp = iv1 & 0x1f;
            uint atk = (iv1 >> 5) & 0x1f;
            uint defense = (iv1 >> 10) & 0x1f;
            uint spa = (iv2 >> 5) & 0x1f;
            uint spd = (iv2 >> 10) & 0x1f;
            uint spe = iv2 & 0x1f;
            return new List<uint> { hp, atk, defense, spa, spd, spe };
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void enter(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "BACKSPACE")
            {
                if (NAME.Text.Length > 0)
                {
                    NAME.Text = NAME.Text.Substring(0, (NAME.Text.Length - 1));
                }
            }
            else if (NAME.Text.Length < 7)
            {
                NAME.Text += ((Button)sender).Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearcherButton_Click(object sender, EventArgs e)
        {

            uint gender_value = ((uint)(TID.Value) << 16);
            uint time_value = 0x1;
            uint starter_value;
            bool treecko = true;
            bool torchic = true;
            bool mudkip = true;
            uint text_value = 0;
            uint scene_value = 0;
            uint style_value = 0;
            uint sound_value = 0;
            uint button_value = 0;
            uint pokemon_value = 0x10;
            uint name_value = nametovalue(NAME.Text);

            if (FEMALECHECK.Checked)
            {
                gender_value += 0x1;
            }

            if (TIMEXX00CHECK.Checked)
            {
                time_value = 0x180000;
            }
            else if (TIMEXXXXCHECK.Checked)
            {
                time_value = 0x3C170000;
            }

            if (TORCHICCHECK.Checked)
            {
                starter_value = 0x40000000;
                treecko = false;
            }
            else if (MUDKIPCHECK.Checked)
            {
                starter_value = 0x2;
                torchic = false;
            }
            else
            {
                starter_value = 0x08000000;
                mudkip = false;
            }

            if (torchic)
            {
                starter_value += 0x40000000;
            }

            if (treecko)
            {
                starter_value += 0x08000000;
            }

            if (mudkip)
            {
                starter_value += 0x2;
            }


            if (MIDCHECK.Checked)
            {
                text_value = 0x1;
            }
            else if (FASTCHECK.Checked)
            {
                text_value = 0x2;
            }

            if (OFFCHECK.Checked)
            {
                scene_value = 0x400;
            }

            if (SETCHECK.Checked)
            {
                style_value = 0x200;
            }

            if (STEREOCHECK.Checked)
            {
                sound_value = 0x100;
            }

            if (LRCHECK.Checked)
            {
                button_value = 0x1000000;
            }
            else if (LACHECK.Checked)
            {
                button_value = 0x2000000;
            }

            if (ZIGZAGOONCHECK.Checked)
            {
                pokemon_value += 0x40;
            }

            if (WURMPLECHECK.Checked)
            {
                pokemon_value += 0x100;
            }

            if (WINGULLCHECK.Checked)
            {
                pokemon_value += 0x200000;
            }

            uint u32checksum = (((uint)FRAMETYPE.Value - 1) * 0x8) + (uint)SID.Value + pokemon_value + gender_value + time_value + starter_value + text_value + scene_value + style_value + sound_value + button_value + name_value;

            Form2 SearcherForm = new Form2(u32checksum);
            SearcherForm.Show();
        }
    }
}
