using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PirmasWeb
{
    [Serializable]
    public class UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolName { get; set; }
        public string Age { get; set; }
        public string Languages { get; set; }
    }

    public partial class Forma1 : System.Web.UI.Page
    {
        private List<UserRegistration> cachedUserData = new List<UserRegistration>();

        protected void Page_Load(object sender, EventArgs e)
        {
            cachedUserData = new List<UserRegistration>();

            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 14; i <= 25; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }

            UpdateTableContents();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!ClientValidationCheck()) return;
            if (!ServerValidationCheck()) return;

            AddUserData();
            Response.Redirect(Request.RawUrl);
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            ClearAllUserData();
            UpdateTableContents();
        }

        /// <summary>
        /// Checks if all input fields are filled on the client, before calling ServerValidationCheck method.
        /// </summary>
        protected bool ClientValidationCheck()
        {
            return Page.IsValid;
        }

        /// <summary>
        /// Checks if all client input fields have the correct formatting. (Example: Names cannot have numbers)
        /// </summary>
        protected bool ServerValidationCheck()
        {
            foreach (char c in TextBox1.Text)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }

            foreach (char c in TextBox2.Text)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }

        protected void AddUserData()
        {
            var newUser = new UserRegistration
            {
                FirstName = TextBox1.Text,
                LastName = TextBox2.Text,
                Age = DropDownList1.SelectedValue,
                SchoolName = TextBox3.Text,
                Languages = string.Join(", ", CheckBoxList1.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value)),
            };


            if (cachedUserData == null) cachedUserData = new List<UserRegistration>();
            cachedUserData.Add(newUser);
            SaveUserData();
            UpdateTableContents();
        }

        protected void SaveUserData()
        {
            Session["SavedUserData"] = cachedUserData;
        }

        protected void LoadUserData()
        {
            var saved = Session["SavedUserData"] as List<UserRegistration>;
            cachedUserData = saved ?? new List<UserRegistration>();
        }

        protected void ClearAllUserData()
        {
            cachedUserData = new List<UserRegistration>();
            SaveUserData();

            UpdateTableContents();
        }

        protected void GenerateTableHeaders()
        {
            TableRow row = new TableRow();

            TableCell index = new TableCell();
            index.Text = "<b>Eilės nr.</b>";
            row.Cells.Add(index);

            TableCell title = new TableCell();
            title.Text = "<b>Vardas/Pavardė</b>";
            row.Cells.Add(title);

            TableCell schoolName = new TableCell();
            schoolName.Text = "<b>Mokyklos pavadinimas</b>";
            row.Cells.Add(schoolName);

            TableCell age = new TableCell();
            age.Text = "<b>Amžius (metai)</b>";
            row.Cells.Add(age);

            TableCell programmingLanguages = new TableCell();
            programmingLanguages.Text = "<b>Kalbos</b>";
            row.Cells.Add(programmingLanguages);

            Table1.Rows.Add(row);

            Table1.Rows[0].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void UpdateTableContents()
        {
            LoadUserData();
            Table1.Rows.Clear();
            GenerateTableHeaders();

            if (cachedUserData == null || cachedUserData.Count == 0) return;

            for (int i = 0; i < cachedUserData.Count; i++)
            {
                TableRow newRow = new TableRow();

                newRow.Cells.Add(new TableCell { Text = (i + 1).ToString() });

                newRow.Cells.Add(new TableCell { Text = string.Format("{0} {1}", cachedUserData[i].FirstName, cachedUserData[i].LastName) });

                newRow.Cells.Add(new TableCell { Text = cachedUserData[i].SchoolName });

                newRow.Cells.Add(new TableCell { Text = cachedUserData[i].Age });

                newRow.Cells.Add(new TableCell { Text = string.IsNullOrEmpty(cachedUserData[i].Languages) ? "-" : cachedUserData[i].Languages });

                Table1.Rows.Add(newRow);

            }
        }
    }
}