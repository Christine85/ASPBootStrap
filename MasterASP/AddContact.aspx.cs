using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace MasterASP
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY021-VM;Initial Catalog=Contacts2;Integrated Security=SSPI;";
        SqlConnection myConnection = new SqlConnection(CON_STR);
        List<Person> contactList = new List<Person>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBoxFirstName.Text != "" && txtBoxLastName.Text != "")
            {
                try
                {
                    myConnection.Open();

                    string firstname = txtBoxFirstName.Text;
                    string lastname = txtBoxLastName.Text;
                    int id = 0;

                    SqlCommand addContact = new SqlCommand("AddContact", myConnection);
                    addContact.CommandType = CommandType.StoredProcedure;

                    addContact.Parameters.AddWithValue("@FirstName", firstname);
                    addContact.Parameters.AddWithValue("@LastName", lastname);
                    addContact.Parameters.AddWithValue("@new_id", id);

                    addContact.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}');</script>");
                }
                finally
                {
                    myConnection.Close();
                }

                
                string info = "<div class=\"alert alert-success\"><strong>" + txtBoxFirstName.Text + " " + txtBoxLastName.Text + "</strong> added to contacts! </div>";
                LiteralInfo.Text = info;

                txtBoxFirstName.Text = string.Empty;
                txtBoxLastName.Text = string.Empty;
            }
            else
            {
                string info = "<div class=\"alert alert-danger\"><strong>Fail!</strong> Textbox empty! </div>";
                LiteralInfo.Text = info;
            }
        }
    }
}