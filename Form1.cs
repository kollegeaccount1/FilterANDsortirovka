using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.FolderModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Model1 database = new Model1();
        List<Pavilion>pavilions = new List<Pavilion>();
        List<Pavilion>PavilionsChange=new List<Pavilion>();
        List<string>pavilionsProp= new List<string>(); 

        private void Form1_Load(object sender, EventArgs e)
        {
            PavilionsChange=pavilions=database.Pavilion.ToList();
            loadStartData();
            LoadDataCombo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        PavilionsChange=pavilions.Where(x=>x.Status.Contains(textBox1.Text)).ToList().ToList();
            LoadOrder();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void loadStartData()
        {
            pavilionBindingSource.DataSource = PavilionsChange;
        }
        private void LoadDataCombo()
        {
            pavilionsProp=typeof(Pavilion).GetProperties().Select(x=>x.Name).ToList();
            pavilionsProp.RemoveRange(pavilionsProp.Count - 2, 2);
            comboBox1.DataSource = pavilionsProp;
            comboBox1.SelectedIndex = 0;
        }
        private void LoadOrder()
        {
            PavilionsChange = checkBox1.Checked ?
            PavilionsChange.OrderByDescending(p => p.GetType().GetProperties().
            First(x => x.Name == comboBox1.SelectedItem.ToString()).GetValue(p)).ToList()
            :PavilionsChange.OrderBy(p=>p.GetType().GetProperties().
            First(x=>x.Name==comboBox1.SelectedItem.ToString()).GetValue(p)).ToList();
            loadStartData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
