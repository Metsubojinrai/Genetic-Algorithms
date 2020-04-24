using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FrmPathDetail : Form
    {
        private string[] edgeContent, weightContent;
        private int totalCost;

        public FrmPathDetail()
        {
            InitializeComponent();
        }

        public FrmPathDetail(string[] edge, string[] weight)
        {
            InitializeComponent();
            edgeContent = edge;
            weightContent = weight;
        }

        private void lvwPathDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void FrmPathDetail_Load(object sender, EventArgs e)
        {
            lvwPathDetail.View = View.Details;
            lvwPathDetail.BackColor = Color.LightYellow;
            lvwPathDetail.Columns.Add("No.");
            lvwPathDetail.Columns[0].Width = 35;

            lvwPathDetail.Columns.Add("Edge");
            lvwPathDetail.Columns[1].Width = 200;

            lvwPathDetail.Columns.Add("Weight");
            lvwPathDetail.Columns[2].Width = 150;

            ListViewItem lvwItem;

            for (int i = 0; i < edgeContent.Count(); i++)
            {
                lvwItem = new ListViewItem((i + 1).ToString());
                lvwItem.UseItemStyleForSubItems = false;

                lvwItem.SubItems.Add(edgeContent[i]);
                lvwItem.SubItems[1].ForeColor = Color.Blue;

                lvwItem.SubItems.Add(weightContent[i]);
                lvwItem.SubItems[2].ForeColor = Color.ForestGreen;

                lvwPathDetail.Items.Add(lvwItem);
                totalCost += int.Parse(weightContent[i]);
            }
            lvwItem = new ListViewItem("#");
            lvwItem.UseItemStyleForSubItems = false;

            lvwItem.SubItems.Add("Total cost");
            lvwItem.SubItems.Add(totalCost.ToString());
            lvwItem.SubItems[2].ForeColor = Color.Red;
            lvwItem.SubItems[2].Font = new Font(lvwItem.SubItems[1].Font, FontStyle.Bold);

            lvwPathDetail.Items.Add(lvwItem);
        }
    }
}
