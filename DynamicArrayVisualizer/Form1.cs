using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicArrayVisualizer
{
    public partial class Form1 : Form
    {
        public static readonly CultureInfo EngCulture = new CultureInfo("en-US", false);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var fields = textBox1.Text.Split(Convert.ToChar(254).ToString(EngCulture).First());
            for (int i = 0; i < fields.Count(); i++)
                dataGridView1.Rows.Add(i + 1, fields[i]);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            var field = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var values = field.Split(Convert.ToChar(253).ToString(EngCulture).First());
            foreach (var val in values)
            {
                if (string.IsNullOrEmpty(val)) continue;
                var valueNode = new TreeNode(val);
                var subvalues = val.Split(Convert.ToChar(252).ToString(EngCulture).First());
                if (subvalues.Count() > 1)
                    foreach (var subval in subvalues)
                    {
                        if (string.IsNullOrEmpty(subval)) continue;
                        var subvalNode = new TreeNode(subval);
                        var TextValues = subval.Split(Convert.ToChar(251).ToString(EngCulture).First());
                        if (TextValues.Count() > 1)
                            foreach (var textval in TextValues)
                            {
                                if (string.IsNullOrEmpty(textval)) continue;
                                var textvalNode = new TreeNode(textval);
                                //var subTextValues = textval.Split(Convert.ToChar(250).ToString(EngCulture).First());
                                //if (subTextValues.Count() > 1)
                                //    textvalNode.Nodes.Add(string.Join(", ", subTextValues));
                                    //foreach (var stv in subTextValues)
                                    //{
                                    //    if (string.IsNullOrEmpty(stv)) continue;
                                    //    textvalNode.Nodes.Add(stv);
                                    //}
                                subvalNode.Nodes.Add(textvalNode);
                            }
                        valueNode.Nodes.Add(subvalNode);
                    }
                treeView1.Nodes.Add(valueNode);
            }
            treeView1.ExpandAll();
        }
    }
}
