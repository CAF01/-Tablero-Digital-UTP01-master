using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManejaTableros
{
    public partial class Tableroprofesor : System.Web.UI.Page
    {
        Negocio DB = null;
        string msg = "";
        int id = -1;
        int tablero = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["idus"] == -1 || (int)Session["numtablero"] <= 0 || (string)Session["tipo"] == "ALUMNO")
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                //Session["eqnom"] = "";
                //Session["usnom"] = "";
                if (IsPostBack)
                {
                    DB = (Negocio)Session["Datab"];
                    id = (int)Session["idus"];
                    tablero = (int)Session["numtablero"];
                    //msg = "Post";
                }
                else
                {
                    DB = new Negocio(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                    Session["Datab"] = DB;
                    if (DB.Verificartipotablero((int)Session["numtablero"]))
                    {
                        Session["tabtype"] = 2;//tablero de equipo
                        tablero = (int)Session["numtablero"];
                        string[] datos = DB.recuperardatostablero(tablero);
                        Label3.Text = datos[0];
                        Label1.Text = datos[1];
                        Label2.Text = datos[2];
                        Label4.Text = datos[3];
                        GridView1.DataSource = DB.ConstruirtableroEquipo(tablero);
                        GridView1.DataBind();
                        //Select para tablero
                    }
                    else
                    {
                       Session["tabtype"] = 3;//tablero individual
                       tablero = (int)Session["numtablero"];
                       string[] datos = DB.recuperardatostablero(tablero);
                       Label3.Text = datos[0];
                       Label1.Text = datos[1];
                       Label2.Text = datos[2];
                       Label4.Text = datos[3];
                       GridView1.DataSource = DB.Construirtablero(tablero);
                       GridView1.DataBind();
                       //Select para tablero
                    }
                    List<string> acts= DB.Recuperaractividades((int)Session["numtablero"]);
                    int b = 0;
                    DropDownList1.Items.Add("--SELECCIONAR--");
                    while(b<acts.Count)
                    {
                        DropDownList1.Items.Add(acts[b]);
                        b++;
                    }
                    List<double> insigs = DB.Recuperarinsignias((int)Session["numtablero"]);
                    int c = 0;
                    DropDownList2.Items.Add("--SELECCIONAR--");
                    while (c < insigs.Count)
                    {
                        DropDownList2.Items.Add(insigs[c].ToString());
                        c++;
                    }
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
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(GridView1.SelectedIndex>=0)
            {
                if((int)Session["tabtype"] == 2)
                {
                    Session["eqnom"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
                }
                if((int)Session["tabtype"] == 3)
                {
                    Session["usnom"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
                }
                if(DropDownList1.SelectedIndex>0 && DropDownList2.SelectedIndex>0)
                {
                    Button1.Enabled = true;
                }
                else
                {
                    Button1.Enabled = false;
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0 && DropDownList1.SelectedIndex > 0 && DropDownList2.SelectedIndex > 0)
                Button1.Enabled = true;
            else
            {
                Button1.Enabled = false;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0 && DropDownList1.SelectedIndex > 0 && DropDownList2.SelectedIndex > 0)
                Button1.Enabled = true;
            else
            {
                Button1.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if((string)Session["eqnom"]!="" || (string)Session["usnom"]!="")
            {
                if(DropDownList1.SelectedIndex>0 && DropDownList2.SelectedIndex>0 && GridView1.SelectedIndex>=0)
                {
                    //evento modificador
                    if ((int)Session["tabtype"] == 2)
                    {
                        if (DB.otorgaractinEQ((string)Session["eqnom"], Convert.ToDouble(DropDownList2.SelectedValue), (int)Session["numtablero"], DropDownList1.SelectedValue))
                        {
                            MimessageBox("FELICIDADES", "INSIGNIA OTORGADA", 3);
                        }
                        GridView1.DataSource = DB.ConstruirtableroEquipo(tablero);
                        GridView1.DataBind();
                        //Select para tablero
                        Session["eqnom"] = "";
                        Session["usnom"] = "";
                        DropDownList1.SelectedIndex = 0;
                        DropDownList2.SelectedIndex = 0;
                    }
                    if ((int)Session["tabtype"] == 3)
                    {
                        if(DB.otorgaractinUS((string)Session["usnom"], Convert.ToDouble(DropDownList2.SelectedValue), (int)Session["numtablero"], DropDownList1.SelectedValue))
                        {
                            MimessageBox("FELICIDADES", "INSIGNIA OTORGADA", 3);
                        }
                        GridView1.DataSource = DB.Construirtablero(tablero);
                        GridView1.DataBind();
                        Session["eqnom"] = "";
                        Session["usnom"] = "";
                        DropDownList1.SelectedIndex = 0;
                        DropDownList2.SelectedIndex = 0;
                        //Select para tablero
                    }
                    Button1.Enabled = false;
                }
                else
                {
                    Button1.Enabled = false;
                    MimessageBox("Alerta", "Debes seleccionar a un usuario|equipo, una actividad e insignia para otorgarlas correctamente", 2);
                }
            }
            else
            {
                Button1.Enabled = false;
                MimessageBox("Alerta", "Debes seleccionar a un usuario|equipo, una actividad e insignia para otorgarlas correctamente", 2);
            }
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Session["numtablero"] = -1;
            Response.Redirect("MisTableros.aspx");
        }
    }     

}