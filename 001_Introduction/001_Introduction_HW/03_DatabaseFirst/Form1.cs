using DatabaseFirst.Entities;
using Microsoft.VisualBasic.ApplicationServices;
using System;

namespace DatabaseFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This method executes when you click the Button
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TestDbContext())
                {
                    // Get the data from the DbSet to List
                    var orderList = context.Orders.ToList();

                    // Show in Grid
                    dataGridView1.DataSource = orderList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing database: {ex.Message}");
            }
        }
    }
}
