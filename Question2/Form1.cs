using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> modules = new List<string>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string module_name = txtModuleName.Text;

            if (string.IsNullOrWhiteSpace(module_name))
            {
                MessageBox.Show("Please provide a module name!", "Missing Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (modules.Contains(module_name))
            {
                MessageBox.Show("Module already exist", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // Adding module to the list (backend)
            modules.Add(module_name);


            // Trying to display the updated list in the listbox (Frontend)
            listModules.Items.Clear();

            foreach (string A_module in modules)
            {
                listModules.Items.Add(A_module);
            }

            txtModuleName.Clear();

            txtModuleName.Focus();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listModules.SelectedItem == null)
            {
                MessageBox.Show("Please select a module to be removed!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // Remove from the list<> the specific selected module
            string selected_module = listModules.SelectedItem.ToString();
            modules.Remove(selected_module);

            // TRying to display the fresh updated list<> in the listbox
            listModules.Items.Clear();

            foreach (string single_module in modules)
            {
                // Adding a module individually to the listbox
                listModules.Items.Add(single_module);
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string module_name = txtSearch.Text;

            if (string.IsNullOrWhiteSpace(module_name))
            {
                MessageBox.Show("Please provide a module name!", "Missing Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int index = modules.IndexOf(module_name);

            if (index != -1)
            {
                MessageBox.Show($"The module is found at position {index}");
            }
            else
            {
                MessageBox.Show("Module not found!");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            modules.Sort();

            // TRying to display the fresh updated list<> in the listbox
            listModules.Items.Clear(); 

            foreach (string single_module in modules)
            {
                // Adding a module individually to the listbox
                listModules.Items.Add(single_module);
            }

        }
    }
}
