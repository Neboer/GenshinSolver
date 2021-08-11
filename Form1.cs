using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static NumStr;
using static GenshinSolver.Solver;

namespace GenshinSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void init_state_text_TextChanged(object sender, EventArgs e)
        {

            var tl = GetMaxIntFromStr(init_state_text.Text);
            if (tl >= 3 && tl <= 5)
            {
                foreach (RadioButton c in modular.Controls)
                {
                    c.Checked = c.Tag.ToString() == tl.ToString();
                    c.Enabled = int.Parse(c.Tag.ToString()) >= tl;
                }
            }
        }

        private void nearby_button_Click(object sender, EventArgs e)
        {
            int count = init_state_text.Text.Length;
            float[,] change_list_value = generate_default_change_list(count);
            change_list.Items.Clear();
            for(int i=0;i < change_list_value.GetLength(0); i++)
            {
                change_list.Items.Add(FloatList2Str(change_list_value, i));
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if(change_list.Text.Length == init_state_text.TextLength)
            {
                change_list.Items.Add(change_list.Text);
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if(change_list.SelectedIndex > -1)
            {
                change_list.Items.RemoveAt(change_list.SelectedIndex);
            }
        }
        private void change_list_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (change_list.SelectedIndex > -1) Console.WriteLine(change_list.SelectedIndex);
            if (e.KeyChar == 13 && (change_list.SelectedIndex > -1) && (change_list.Text.Length == init_state_text.TextLength))
            {
                change_list.Items[change_list.SelectedIndex] = change_list.Text;
            } else if (e.KeyChar == 13 && (change_list.SelectedIndex == -1) && (change_list.Text.Length == init_state_text.TextLength))
            {
                change_list.Items.Add(change_list.Text);
            }
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            result_text.Clear();
            float[,] f_change_list = new float[change_list.Items.Count, init_state_text.TextLength];
            for(int i=0;i<change_list.Items.Count;i++)
            {
                Str2floatList((string)change_list.Items[i], f_change_list, i);
            }
            int mod = 0;
            foreach(RadioButton rb in modular.Controls)
            {
                if (rb.Checked) mod = int.Parse((string)rb.Tag);
            }
            if(mod > 0)
            {
                Solver P = new Solver(Str2floatList(init_state_text.Text), f_change_list, mod);
                try
                {
                    int[] solution = P.solve();
                    result_text.Text = IntList2Str(solution);
                } catch (NoneSolutionException)
                {
                    MessageBox.Show("无解", "求解错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (InfiniteSolutionException)
                {
                    MessageBox.Show("无穷解", "求解错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (MalformedMatrixException)
                {
                    MessageBox.Show("变化列表条件错误", "求解错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
