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
    public partial class WebForm3 : System.Web.UI.Page
    {
        const string CON_STR = "Data Source=ACADEMY021-VM;Initial Catalog=Contacts2;Integrated Security=SSPI;";
        SqlConnection myConnection = new SqlConnection(CON_STR);
        List<Person> contactList = new List<Person>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }
        private void LoadContacts()
        {
            SqlCommand myPrintCommand = new SqlCommand("select * from Contact", myConnection);

            try
            {
                myConnection.Open();
                SqlDataReader myRead = myPrintCommand.ExecuteReader();

                contactList.Clear();
                while (myRead.Read())
                {
                    string id = myRead["ID"].ToString();
                    string firstname = myRead["firstname"].ToString();
                    string lastname = myRead["lastname"].ToString();
                    contactList.Add(new Person(firstname, lastname, id));
                }
            }

            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }
                       
            string info2 = "<div class=\"container\"><table class=\"table table-striped\"id=\"myTable\">";
            info2 += "<\thead><\tr>";
            info2 += "<th>ID</th>";
            info2 += "<th>Firstname</th>";
            info2 += "<th>Lastname</th>";
            info2 += "</tr></thead>";
            info2 += "<tbody>";

            foreach (var p in contactList)
            {
                info2 += "<tr class=\"clickable-row\"><td>" + p.ID + "</td><td>" + p.FirstName + "</td><td>" + p.LastName + "</td></tr>";
            }

            info2 += "</tbody></table></div>";

            LiteralMain.Text = info2;
        }

        protected void lBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p1 = lBoxContacts.SelectedIndex;

            Session["myId"] = p1;
        }
    }
}
