using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class LifeGameWindow : Form
    {
        public LifeGameWindow()
        {
            InitializeComponent();
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            if (lifeGamePanel.GridWidth == (int)this.nud_width.Value && lifeGamePanel.GridHeight == (int)this.nud_height.Value)
            {
                lifeGamePanel.Duration = (int)(this.nud_duration.Value * 1000);
                btn_Change.Enabled = false;
            }
            else if (lifeGamePanel.IsEmpty() || (lifeGamePanel.GridHeight <= (int)this.nud_height.Value && lifeGamePanel.GridWidth <= (int)this.nud_width.Value) || MessageBox.Show("Do you want to resize the grid?\r\nSome of the state of cells will be lost.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lifeGamePanel.SetGrid((int)this.nud_width.Value, (int)this.nud_height.Value);
                lifeGamePanel.Duration = (int)(this.nud_duration.Value * 1000);
                btn_Change.Enabled = false;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            lifeGamePanel.Start();
            btn_Start.Enabled = false;
            btn_Stop.Enabled = true;
            btn_Change.Enabled = false;
            btn_Clear.Enabled = false;
            btn_load.Enabled = false;
            btn_save.Enabled = false;
            nud_duration.Enabled = false;
            nud_height.Enabled = false;
            nud_width.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            lifeGamePanel.Stop();
            /*
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;
            btn_Clear.Enabled = true;
            nud_duration.Enabled = true;
            nud_height.Enabled = true;
            nud_width.Enabled = true;
            if (lifeGamePanel.GridWidth != (int)this.nud_width.Value || lifeGamePanel.GridHeight != (int)this.nud_height.Value || lifeGamePanel.Duration != (int)(this.nud_duration.Value * 1000))
                btn_Change.Enabled = true;
            else
                btn_Change.Enabled = false;
            */
        }

        private void lifeGamePanel_Stopped(GameStatus NewStatus)
        {
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;
            btn_Clear.Enabled = true;
            btn_load.Enabled = true;
            btn_save.Enabled = true;
            nud_duration.Enabled = true;
            nud_height.Enabled = true;
            nud_width.Enabled = true;
            ChangeBtnCheck();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (lifeGamePanel.IsEmpty())
                return;
            if(MessageBox.Show("Do you want to clear the grid?\r\nIt will clear all the state of cells in the grid.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lifeGamePanel.Clear();
            }
        }

        private void ChangeBtnCheck()
        {
            if (lifeGamePanel.GridWidth != (int)this.nud_width.Value || lifeGamePanel.GridHeight != (int)this.nud_height.Value || lifeGamePanel.Duration != (int)(this.nud_duration.Value * 1000))
                btn_Change.Enabled = true;
            else
                btn_Change.Enabled = false;
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            ChangeBtnCheck();
        }

        private void lifeGamePanel_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (lifeGamePanel.IsEmpty())
            {
                MessageBox.Show("The grid is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "eP LifeGame Template File|*.etf";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                LifegameTemplateFile ltf = new LifegameTemplateFile(sfd.FileName, TemplateFileMode.SaveFile);
                ltf.SetGrid(lifeGamePanel.CurrentGrid, lifeGamePanel.GridHeight, lifeGamePanel.GridWidth, lifeGamePanel.Duration);
                ltf.Save();
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (!lifeGamePanel.IsEmpty() && MessageBox.Show("If you load the template file, the grid will be overwritten by the file.\r\nDo you want to load the template file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "eP LifeGame Template File|*.etf";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                LifegameTemplateFile ltf = new LifegameTemplateFile(ofd.FileName, TemplateFileMode.OpenFile);
                bool[,] output = ltf.Open();
                lifeGamePanel.SetGrid(output, ltf.GridWidth, ltf.GridHeight);
                lifeGamePanel.Duration = ltf.Duration;
                nud_duration.Value = (decimal)ltf.Duration / 1000;
                nud_width.Value = ltf.GridWidth;
                nud_height.Value = ltf.GridHeight;
                ChangeBtnCheck();
            }
        }
    }
}
