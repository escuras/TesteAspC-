using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

public class DataVW
{
    public Object Referencia { get; set; }
    public Object Design { get; set; }
    public Object Stock { get; set; }
    public Object Lote { get; set; }
    public Object Validade { get; set; }
    public Object Imagem { get; set; }

}

namespace Teste
{
   

    public partial class dados : System.Web.UI.Page
    {
        protected string tabela {
            get;
            set;
        }

        protected List<DataVW> listaCSV;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"] != null)
            {
                List<Object[]> lista  = Values();
                if (lista != null)
                {
                    listaCSV = new List<DataVW>();
                    DataVW vw = new DataVW();
                    string color1 = "#f6f6f6";
                    string color2 = "#f3f3f3";
                    string color;
                    tabela = "<table id='tabela' style='margin-top:10px;' class='table table-inverse'>" +
                        "<thead>" +
                            "<tr>" +
                                "<th style='background-color:#000; height:50px; color:#fff;border-radius:5px 0px 0px 0px' class='text-center'> Referência </th>" +
                                "<th style='background-color:#000; height:50px; color:#fff;' class='text-center'> Design </th>" +
                                "<th style='background-color:#000; height:50px; color:#fff;' class='text-center'> Stock </th>" +
                                "<th style='background-color:#000; height:50px; color:#fff;' class='text-center'> Lote </th>" +
                                "<th style='background-color:#000; height:50px; color:#fff;' class='text-center'> Validade </th>" +
                                "<th style='background-color:#000; height:50px; color:#fff;border-radius:0px 5px 0px 0px' class='text-center'> Imagem </th>" +
                            "</tr>" +
                        "</thead>" +
                        "<tbody>";
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (i % 2 == 0) color = color1;
                        else color = color2;
                        tabela += "<tr>";
                        Object[] t = lista[i];
                        vw = new DataVW();
                        vw.Referencia = t[0];
                        vw.Design = t[1];
                        vw.Stock = t[2];
                        vw.Lote = t[3];
                        vw.Validade = t[4];
                        vw.Imagem = t[5];
                        listaCSV.Add(vw);
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + t[0] + "</td>";
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + t[1] + "</td>";
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + t[2] + "</td>";
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + t[3] + "</td>";
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + t[4] + "</td>";
                        tabela += "<td style='background-color:" + color + "' class='text-center'> " + "<input type='radio' style='outline:none' name='radio' value=" + t[5] + "/> " + "</td>";
                        tabela += "</tr>";
                    }
                    tabela += "</tbody>" +
                    "</table>";
                    Button1.Visible = true;
                }
                else
                {
                    tabela = "<div style='width:100%; margin:auto; text-align:center; color:red;margin-top:100px'>Não existem resultados!</div>";
                    Button1.Visible = false;
                }
            }
            else
            {
                Button1.Visible = false;
                Response.Redirect("index.aspx");
            }
        }

        private List<Object[]> Values()
        {
            if (Session["userid"] != null)
            {
                SqlDataReader reader = null;
                SqlConnection sqlConnection1 = null;
                try
                {
                    sqlConnection1 = new SqlConnection("Data Source=77.91.207.66;Initial Catalog=Activos24;Persist Security Info=True;User ID=teste;Password=12345678");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select Ref, design, stock, lote, Validade, Imagem from vw_Stock_Cliente where CL = '" + Session["userid"] + "';";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    reader = cmd.ExecuteReader();
                    List<Object[]> lista = new List<Object[]>();
                    int i = 0;
                    Object[] objeto;
                    while (reader.Read())
                    {
                        objeto = new Object[6];
                        var count = reader.GetValues(objeto);
                        lista.Add(objeto);
                    }
                    return lista;
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
                return null;
            }
            return null;
        }

        protected void Export(Object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Contact.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteCSV(listaCSV, Response.Output);
            Response.End();
        }

        private void WriteCSV(List<DataVW> data, TextWriter output)
        {
            string separacao = ",";
            output.Write("Referência");
            output.Write(separacao);
            output.Write("Design");
            output.Write(separacao);
            output.Write("Stock");
            output.Write(separacao);
            output.Write("Lote");
            output.Write(separacao);
            output.Write("Validade");
            output.Write(separacao);
            output.Write("Imagem");
            output.WriteLine();
            foreach (DataVW item in data)
            {
                output.Write(item.Referencia);
                output.Write(separacao);
                output.Write(item.Design);
                output.Write(separacao);
                output.Write(item.Stock);
                output.Write(separacao);
                output.Write(item.Lote);
                output.Write(separacao);
                output.Write(item.Validade);
                output.Write(separacao);
                output.Write(item.Imagem);
                output.WriteLine();
            }
        }

    }
}