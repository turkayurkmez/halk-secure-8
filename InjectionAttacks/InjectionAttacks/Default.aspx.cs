using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");

        SqlCommand command = new SqlCommand("Select * from Employees Where FirstName = @name  AND LastName =@pass", sqlConnection);

        command.Parameters.AddWithValue("@name", textBoxUserName.Text);
        command.Parameters.AddWithValue("@pass", TextBoxPassword.Text);

        sqlConnection.Open();
        var reader = command.ExecuteReader();

        LabelResult.Text = reader.Read() ? "İşlem Başarılı" : "İşlem Başarısız";

        sqlConnection.Close();



    }
}