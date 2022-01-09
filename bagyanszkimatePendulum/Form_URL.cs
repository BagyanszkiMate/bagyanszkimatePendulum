using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendulum
{
    public partial class Form_URL : Form
    {
        public string ConnectionString { get; set; }
        public int Id { get; set; }
        public Form_URL(int id, string connectionstring)
        {
            ConnectionString = connectionstring;
            Id = id;  
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                new SqlCommand(
                    "UPDATE tracks " +
                   $"SET url = '{txtbox.Text}' " +
                   $"WHERE id =  {Id};", connection).ExecuteNonQuery();
            }            
        }
    }
}
