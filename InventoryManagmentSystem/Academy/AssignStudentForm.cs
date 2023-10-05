using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AssignStudentForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<Guid, string> academyMap = new Dictionary<Guid, string>();
        AcademyForm parent = null;
        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            academyMap = HelperDatabaseCall.AcademyListNames(connection);
            foreach (var value in academyMap.Values)
            {
                cbAcademy.Items.Add(value);
            }

            this.parent = parent;
        }

        private void cbAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid academyId = Guid.Empty;
            foreach(var key in academyMap.Keys)
            {
                if (academyMap[key] == cbAcademy.Text)
                {
                    academyId = key;
                }
            }

            if(academyId == Guid.Empty)
            {
                return;
            }

            Dictionary<Guid, string> classMap = HelperDatabaseCall.ClassListNames(connection, academyId);
            cbClasses.Items.Clear();
            foreach(var value in classMap.Values)
            {
                cbClasses.Items.Add(value);
            }

            if(cbClasses.Items.Count > 0)
            {
                cbClasses.Enabled = true;
            }
        }
    }
}
