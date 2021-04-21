using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Businesslayer;
using System.Configuration;

namespace WebManejaTableros
{
    public partial class Crearequipo1 : System.Web.UI.Page
    {
        Negocio DB = null;
        int id = -1;
        string nomequipo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((int)Session["idus"] == -1) || ((int)Session["idequipo"] ==-1))
            {
                Response.Redirect("WebForm3.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    id = (int)Session["idequipo"];
                    //msg = "Post";
                    //Response.Write("EQUIPO: " + (string)Session["nomequipo"]);
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    id = (int)Session["idequipo"];
                    nomequipo=DB.Consultarnomequipo(id);
                    Session["nomequipo"] = nomequipo;
                    lblNomEquipo.Text=("EQUIPO: "+nomequipo);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB1.Text) && string.IsNullOrEmpty(TB2.Text) && string.IsNullOrEmpty(TB2.Text))
            {
                //Se crea un equipo vacio, solo con el creador // Ya no es posible agregar mas compañeros de momento
                Session["nomequipo"] = null;
                Session["idequipo"] = -1;
                Response.Redirect("WebForm3.aspx");
            }
            else
            {
                if (!string.IsNullOrEmpty(TB1.Text))
                {
                    DB.Insertarmiembrosaequipo(TB1.Text, (int)Session["idequipo"]);//Regresa Mensaje
                }
                if (!string.IsNullOrEmpty(TB2.Text))
                {
                    DB.Insertarmiembrosaequipo(TB2.Text, (int)Session["idequipo"]);//Regresa Mensaje
                }
                if (!string.IsNullOrEmpty(TB3.Text))
                {
                    DB.Insertarmiembrosaequipo(TB3.Text, (int)Session["idequipo"]);//Regresa Mensaje
                }
                Session["nomequipo"] = null;
                Session["idequipo"] = -1;
                Response.Redirect("WebForm3.aspx");
            }
        }

        public void MimessageBox(string titulo, string msg, short tipo)
        {
            string icono = "";
            switch (tipo)
            {
                case 1:
                    icono = "info";
                    break;
                case 2:
                    icono = "warning";
                    break;
                case 3:
                    icono = "success";
                    break;
                case 4:
                    icono = "error";
                    break;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "clave" + tipo, "sweetm('" + titulo + "','" + msg + "','" + icono + "')", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB1.Text))
            {
                DB.Insertarmiembrosaequipo(TB1.Text, (int)Session["idequipo"]);
            }
            if (!string.IsNullOrEmpty(TB2.Text))
            {
                DB.Insertarmiembrosaequipo(TB2.Text, (int)Session["idequipo"]);
            }
            if (!string.IsNullOrEmpty(TB3.Text))
            {
                DB.Insertarmiembrosaequipo(TB3.Text, (int)Session["idequipo"]);
            }
            //Limpiados o algo asi MENSAJE
            MimessageBox("CAJAS DE TEXTO LIMPIADAS", "COMPAÑEROS AGREGADOS, AHORA PUEDES AGREGAR MAS", 3);
            TB1.Text = "";TB2.Text = "";TB3.Text = "";
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            //Botón para cancelar registro de equipo, no para regresar página.
            DB.Cancelarregistroequipo((int)Session["idequipo"]);
            Response.Redirect("WebForm3.aspx");
        }
    }
}