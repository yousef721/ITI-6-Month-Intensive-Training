using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap09
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connectionString = "Data Source=.;User ID=SA;Password=reallyStrong123;Initial Catalog=pubs;TrustServerCertificate=True";
        }
        string connectionString;

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter data = new SqlDataAdapter("SELECT au_id, au_fName, au_lName, contract FROM authors", connection);
                    DataTable dt = new DataTable();
                    data.Fill(dt);

                    // Fill DataGridView
                    dataGridView.DataSource = dt;

                    // Fill ListBox with author first names
                    listBoxData.DataSource = dt;
                    dt.Columns.Add("FullName", typeof(string), "au_fname + ' ' + au_lname");
                    listBoxData.DisplayMember = "FullName";  
                    //listBoxData.ValueMember = "au_id";
                } catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFName.Text))
            {
                MessageBox.Show("First name is required.");
                return;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("Last name is required.");
                return;
            }

            // Validate Contract (checkbox or other control)
            bool contractValue = contractTrue.Checked;

            // Generate ID
            string newId = GenerateAuthorId();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "INSERT INTO authors(au_id, au_fname, au_lname, contract) VALUES (@au_id, @au_fname, @au_lname, @contract)",
                        connection, transaction);

                    sqlCommand.Parameters.AddWithValue("@au_id", newId);
                    sqlCommand.Parameters.AddWithValue("@au_fname", txtFName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@au_lname", txtLName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@contract", contractValue);

                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();

                    txtFName.Text = "";
                    txtLName.Text = "";

                    MessageBox.Show($"Author inserted successfully with ID: {newId}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private string GenerateAuthorId()
        {
            Random rnd = new Random();

            int part1 = rnd.Next(100, 999);   // 3 digits
            int part2 = rnd.Next(10, 99);     // 2 digits
            int part3 = rnd.Next(1000, 9999); // 4 digits

            return $"{part1}-{part2}-{part3}";
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "UPDATE authors SET au_fname = @au_fname, au_lname = @au_lname, contract = @contract WHERE au_id = @au_id",
                        connection, transaction);

                    sqlCommand.Parameters.AddWithValue("@au_id", txtId.Text);
                    sqlCommand.Parameters.AddWithValue("@au_fname", txtFName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@au_lname", txtLName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@contract", contractTrue.Checked);

                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();

                    txtId.Text = "";
                    txtFName.Text = "";
                    txtLName.Text = "";

                    MessageBox.Show("Author updated successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the click is on a valid row, not the header
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Fill textboxes with values from the row
                txtId.Text = row.Cells["au_id"].Value?.ToString();
                txtFName.Text = row.Cells["au_fname"].Value?.ToString();
                txtLName.Text = row.Cells["au_lname"].Value?.ToString();

                // Handle contract column (boolean)
                if (row.Cells["contract"].Value != null)
                {
                    bool contractValue = Convert.ToBoolean(row.Cells["contract"].Value);

                    if (contractValue)
                    {
                        contractTrue.Checked = true;
                    }
                    else
                    {
                        contractFalse.Checked = true;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm before deleting
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this author?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No)
            {
                // User clicked No, cancel deletion
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(
                        "DELETE FROM authors WHERE au_id = @au_id",
                        connection, transaction);

                    sqlCommand.Parameters.AddWithValue("@au_id", txtId.Text);

                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();

                    txtId.Text = "";
                    txtFName.Text = "";
                    txtLName.Text = "";

                    MessageBox.Show("Author deleted successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
