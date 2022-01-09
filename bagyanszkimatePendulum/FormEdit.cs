using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bagyanszkimatePendulum
{
    public partial class FormEdit : Form
    {
        public string ConnectionString { get; set; }
        public int iD { get; set; }

        public FormEdit(int id, string connectionstring)
        {
            ConnectionString = connectionstring;
            iD = id;

            InitializeComponent();
        }

        private void updatebnt(object sender, EventArgs e)
        {
            DialogResult dlgrslt = MessageBox.Show("Are you sure you want save the changes?", "Exit", MessageBoxButtons.YesNo);
            if (dlgrslt == DialogResult.Yes)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    new SqlCommand(
                        "UPDATE tracks " +
                       $"SET title = '{textBox1.Text}' , length = '{textBox2.Text}' , url = '{textBox4.Text}' " +
                       $"WHERE id =  {iD};", connection).ExecuteNonQuery();
                }
                this.Close();
            }
            else
            {

            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var r = new SqlCommand(
                    "SELECT tracks.title, tracks.length,albums.title, tracks.url " +
                    "FROM albums, tracks " +
                   $"WHERE albums.Id = tracks.album AND tracks.id = {iD};", connection).ExecuteReader();
                while (r.Read())
                {
                    textBox1.Text = $"{r[0]}";
                    textBox2.Text = $"{r[1]}";
                    textBox3.Text = $"{r[2]}";
                    textBox4.Text = $"{r[3]}";
                }
            }
        }
    }
}
