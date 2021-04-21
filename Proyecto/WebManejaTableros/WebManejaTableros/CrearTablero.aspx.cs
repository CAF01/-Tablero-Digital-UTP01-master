using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Businesslayer;

namespace WebManejaTableros
{
    public partial class CrearTablero : System.Web.UI.Page
    {
        Negocio DB = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["idus"] == -1|| (string)Session["user"] == null || (string)Session["tipo"] =="ALUMNO")
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    Button2.Enabled = false;
                    Button1.Enabled = false;
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if((int)Session["idtablero"]<0)
            {
                MimessageBox("ERROR", "DEBES PRIMERO COMPLETAR LA INFORMACIÓN Y CREAR TU TABLERO", 4);
            }
            else
            {
                if (string.IsNullOrEmpty(TB3.Text) && string.IsNullOrEmpty(TB4.Text) && string.IsNullOrEmpty(TB5.Text))
                {
                    if(Session["bot2"]==null)
                    {
                        MimessageBox("ERROR", "TU TABLERO DEBE TENER AL MENOS UNA ACTIVIDAD PARA CONTINUAR", 4);
                    }
                    else
                    {
                        if ((bool)Session["bot2"] == true)
                        {
                            Session["bot2"] = false;
                            Response.Redirect("CrearTablero1.aspx");
                        }
                        else
                        {
                            MimessageBox("ERROR", "TU TABLERO DEBE TENER AL MENOS UNA ACTIVIDAD PARA CONTINUAR", 4);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(TB3.Text) || !string.IsNullOrEmpty(TB4.Text) || !string.IsNullOrEmpty(TB5.Text))
                {
                    if (!string.IsNullOrEmpty(TB3.Text))
                        DB.Insertaractividadatablero(TB3.Text, (int)Session["idtablero"]);
                    if (!string.IsNullOrEmpty(TB4.Text))
                        DB.Insertaractividadatablero(TB4.Text, (int)Session["idtablero"]);
                    if (!string.IsNullOrEmpty(TB5.Text))
                        DB.Insertaractividadatablero(TB5.Text, (int)Session["idtablero"]);
                    Response.Redirect("CrearTablero1.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((int)Session["idtablero"] < 0)
            {
                MimessageBox("ERROR", "DEBES PRIMERO COMPLETAR LA INFORMACIÓN Y CREAR TU TABLERO", 4);
            }
            else
            {
                if (string.IsNullOrEmpty(TB3.Text) && string.IsNullOrEmpty(TB4.Text) && string.IsNullOrEmpty(TB5.Text))
                {
                    MimessageBox("ALERTA", "Debe completar todas las actividades para agregar más", 1);//Debe completar todas las actividades para agregar más
                }
                if (!string.IsNullOrEmpty(TB3.Text) && !string.IsNullOrEmpty(TB4.Text) && !string.IsNullOrEmpty(TB5.Text))
                {
                    if (!string.IsNullOrEmpty(TB3.Text))
                        DB.Insertaractividadatablero(TB3.Text, (int)Session["idtablero"]);
                    if (!string.IsNullOrEmpty(TB4.Text))
                        DB.Insertaractividadatablero(TB4.Text, (int)Session["idtablero"]);
                    if (!string.IsNullOrEmpty(TB5.Text))
                        DB.Insertaractividadatablero(TB5.Text, (int)Session["idtablero"]);
                    TB3.Text = "";TB4.Text = "";TB5.Text = "";
                    Session["bot2"] = true;
                    MimessageBox("CONTINUAR", "AHORA PUEDES AÑADIR MAS ACTIVIDADES A TU TABLERO", 3);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)//METODO EN REPARACIÓN
        {
            if((string.IsNullOrEmpty(TB1.Text))||(string.IsNullOrEmpty(TB2.Text)))
            {
                MimessageBox("ALERTA", "LOS CAMPOS DE REGISTRO DE UN TABLERO NO DEBEN QUEDAR VACIOS", 2);
            }
            else
            {
                object[] ob = new object[2];
                if(DB.CrearunTablero((int)Session["idus"],TB1.Text,TB2.Text, (string)Session["user"],ref ob))
                {
                    Button3.Enabled = false;
                    Button2.Enabled = true;
                    Button1.Enabled = true;
                    TB1.Enabled = false;
                    TB2.Enabled = false;
                    Session["idtablero"] = (int)ob[0];
                    MimessageBox("CORRECTO", "AHORA PUEDES COMPLETAR LOS CAMPOS PARA LAS ACTIVIDADES DE TÚ TABLERO", 3);
                    //Puedes añadir actividades
                }
                else
                {
                    MimessageBox("ERROR", "No se pudo completar el registro del tablero", 4);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if((object)Session["idtablero"]==null)
            {
                Response.Redirect("WebForm4.aspx");
            }
            else
            {
                if ((int)Session["idtablero"] < 0)
                {
                    Response.Redirect("WebForm4.aspx");
                }
                else
                {
                    DB.CancelarRegistroTablero((int)Session["idtablero"]);
                    Session["idtablero"] = -1;
                    Response.Redirect("WebForm4.aspx");
                }
            }
            
        }
    }
}