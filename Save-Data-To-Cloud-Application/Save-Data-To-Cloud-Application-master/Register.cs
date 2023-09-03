using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Save_Data_To_Cloud
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("Server=tcp:testing-innocent.database.windows.net,1433;Initial Catalog=Save-To-Cloud;Persist Security Info=False;User ID=Innocent;Password=************;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        public Register()
        {
            InitializeComponent();
        }

        private void resetB_Click(object sender, EventArgs e)
        {
            resetX();
        }

        private void resetX()
        {
            fnameT.Clear();
            lnameT.Clear();
            emailT.Clear();
            addressRtxb.Clear();
            genderCmb.SelectedIndex = -1;
            ageS.Value = 0;
            saRd.Checked = false;
            nonRd.Checked = false;

            fnameT.Focus();

        }

        private void saveB_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Citizen;
                if (saRd.Checked)

                    Citizen = "SA";
                else
                    Citizen = "Non SA";
                SqlCommand com = new SqlCommand(""INSERT INTO Member VALUES('"+fnameT.Text+"','"+lnameT.Text+"','"+emailT.Text+"','"+addressRtxb.Text+"','"+genderCmb.SelectedItem.ToString()+"','"+datePicker.Value+"','"+ageS.Value+"','"+ Citizen+"')"", con);
                try
                {
                    com.ExecuteNonQuery();
                    resetX();

                }
                catch (Exception exx)
                {

                    MessageBox.Show("Failed to save to the database\n\n" + exx.Message);
                }

                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to connect to the database\n\n" + ex.Message);
            }

        }
    }
}
