using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Teste
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String v = Request.QueryString["action"];
            if (v == "logout")
            {
                Session["userid"] = null;
            }
            if (Session["userid"] != null)
            {
                Response.Redirect("dados.aspx");
            }
            
        }

        protected void Make_Login(object sender, EventArgs e)
        {
            string password = Password_.Text;
            string user = Username_.Text;
            string text = "";
            if ((user != "") && (password != ""))
            {
                SqlDataReader reader = null;
                SqlConnection sqlConnection1 = null;
                try
                {
                    sqlConnection1 = new SqlConnection("Data Source=77.91.207.66;Initial Catalog=Activos24;Persist Security Info=True;User ID=teste;Password=12345678");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select No from vw_stock_cliente_login where Nome = '" + user + "' and Password = '" + password + "';";
                    text += " command: " + cmd.CommandText;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        object valor = 0;
                        valor = reader.GetValue(0);
                        Session["userid"] = valor;
                        Session["login"] = "sim";
                        Response.Redirect("dados.aspx");
                    }
                    else
                    {
                        Password_.Text = "";
                        Username_.Text = "";
                        LabelError.Visible = true;
                    }
                }
                catch (SqlException ex)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (sqlConnection1 != null) sqlConnection1.Close();
                }
            }
        }
    }
}