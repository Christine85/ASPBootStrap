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
    public partial class WebForm7 : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                lBoxContacts.Items.Clear();
                foreach (var p in contactList)
                {
                    ListItem tmpItem = new ListItem($"{p.FirstName} {p.LastName}", p.ID);
                    lBoxContacts.Items.Add(tmpItem);
                }
            }
            else
            {
                int selIndex = lBoxContacts.SelectedIndex;
                lBoxContacts.Items.Clear();

                foreach (var p in contactList)
                {
                    ListItem tmpItem = new ListItem($"{p.FirstName} {p.LastName}", p.ID);
                    lBoxContacts.Items.Add(tmpItem);
                }
                if (selIndex >= 0 && selIndex < contactList.Count)
                {
                    lBoxContacts.SelectedIndex = selIndex;
                }
                else if (selIndex == contactList.Count)
                {
                    lBoxContacts.SelectedIndex = selIndex - 1;
                }
            }          
        }

        protected void lBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person p = contactList.Find(t => t.ID == lBoxContacts.SelectedValue);
            txtBoxFirstName.Text = p.FirstName;
            txtBoxLastName.Text = p.LastName;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Person p = contactList.Find(t => t.ID == lBoxContacts.SelectedValue);
            try
            {
                myConnection.Open();

                string firstname = txtBoxFirstName.Text;
                string lastname = txtBoxLastName.Text;
                int id = Convert.ToInt32(p.ID);

                SqlCommand myCommand = new SqlCommand($"update contact set Firstname = '{firstname}', Lastname = '{lastname}' where ID = {id};", myConnection);
                myCommand.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }
            txtBoxFirstName.Text = string.Empty;
            txtBoxLastName.Text = string.Empty;
            LoadContacts();
        }
    }
}