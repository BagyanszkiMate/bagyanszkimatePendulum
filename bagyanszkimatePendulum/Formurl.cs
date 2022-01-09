using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bagyanszkimatePendulum
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

 
        }
    }
}
