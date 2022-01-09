using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bagyanszkimatePendulum
{
    public partial class Form1 : Form
    {
        public string ConnectionString { set; get; }
        public Form1()
        {
           ConnectionString = @"Server = (localdb)\MSSQLLocalDB;" + "Database = music";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CombAlbum.Enabled = false;
            Tb.Enabled = false;
            AddButtn.Enabled = false;
            AddUrlButtn.Enabled = false;
            EditButtn.Enabled = false;
            FillComboBox_1();
        }
        private void FillRichTextBox()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var r = new SqlCommand(
                    "SELECT release " +
                    "FROM albums,tracks " +
                    $"WHERE albums.Id=tracks.album AND tracks.id = '{int.Parse(DatGriVie.CurrentRow.Cells[3].Value.ToString())}' ", connection).ExecuteReader();
                while (r.Read())
                {
                    RichTextBox.Text = $"Year of publication: {DateTime.Parse(r[0].ToString()).ToString("yyyy. MMMM dd.")}";
                }
                r.Close();
                var s = new SqlCommand(
                    "SELECT SUM(DATEDIFF(MINUTE, '00:00', tracks.length)) " +
                    "FROM albums,tracks " +
                    $"WHERE albums.Id=tracks.album AND albums.title LIKE '{CombAlbum.SelectedItem}' " +
                    $"GROUP BY tracks.album;", connection).ExecuteReader();
                while (s.Read())
                {
                    RichTextBox.Text += $"\n{s[0]} minutes";
                }

            }
        }

        private void FillDGV()
        {
            DatGriVie.Rows.Clear();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var r = new SqlCommand(
                    "SELECT tracks.title, tracks.length, tracks.url, tracks.id " +
                    "FROM tracks, albums " +
                    $"WHERE albums.Id = tracks.album AND albums.title LIKE '{CombAlbum.SelectedItem}%' AND tracks.title LIKE '{Tb.Text}%' ;", connection).ExecuteReader();

                while (r.Read())
                {
                    DatGriVie.Rows.Add(r[0], r[1], r[2], r[3]);
                }

            }
            Tb.Enabled = true;
        }

        private void FillComboBox_2()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var r = new SqlCommand(
                    $"SELECT title FROM albums WHERE artist LIKE '{CombArtist.SelectedItem}%' ", connection).ExecuteReader();
                while (r.Read())
                {
                    CombAlbum.Items.Add($"{r["title"]}");
                }
            }
        }

        private void FillComboBox_1()
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var r = new SqlCommand(
                    "SELECT artist FROM albums GROUP BY artist", connection).ExecuteReader();
                while (r.Read())
                {
                    CombArtist.Items.Add($"{r[0]}");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDGV();
            if (CombAlbum.SelectedItem.ToString() == "Hold Your Colour")
            {
                PicBox.Image = Properties.Resources.hold_your_colour;
            }
            if (CombAlbum.SelectedItem.ToString() == "In Silico")
            {
                PicBox.Image = Properties.Resources.in_silico;
            }
            if (CombAlbum.SelectedItem.ToString() == "Immersion")
            {
                PicBox.Image = Properties.Resources.immersion;
            }
            FillRichTextBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CombAlbum.Enabled = true;
            FillComboBox_2();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (DatGriVie.CurrentRow.Cells[2].Value.ToString() == "")
            {
                LinkL.Text = "Link not found";
                AddUrlButtn.Enabled = true;
            }
            else
            {
                LinkL.Text = $"https://youtu.be/{DatGriVie.CurrentRow.Cells[2].Value.ToString()}";
                AddUrlButtn.Enabled = false;
            }
            AddButtn.Enabled = true;
            EditButtn.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form_URL frmurl = new Form_URL(int.Parse(DatGriVie.CurrentRow.Cells[3].Value.ToString()), ConnectionString);
            frmurl.ShowDialog();
        }

        private void editbnt_Click(object sender, EventArgs e)
        {
            FormEdit frmedit = new FormEdit(int.Parse(DatGriVie.CurrentRow.Cells[3].Value.ToString()), ConnectionString);
            frmedit.ShowDialog();
        }
    }
}
