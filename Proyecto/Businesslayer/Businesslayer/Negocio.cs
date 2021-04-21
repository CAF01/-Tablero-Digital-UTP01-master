using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AcessoDatosAutos;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using AccesoDatosAutos;
using System.Drawing.Imaging;
//Se importan los recursos necesarios para la clase de manejo de operaciones de nuestro proyecto.
namespace Businesslayer
{
    //Esta clase corresponde a operaciones especificas de nuestro tablero
    public class Negocio
    {
        private Acceso operacion = null;
        string msg = "";
        //En el constructor es necesario pasar la cadena de conexión que se pasara a nuestra clase
        //de "Acceso", para poder realizar las modificaciones en la base de datos.
        public Negocio(string Cadcon)
        {
            operacion = new Acceso(Cadcon);
        }
        //Método que corresponde a la inserción de un nuevo usuario.
        //Se realiza la implementación de parametros, y el paso de la información recolectada en el formulario.
        public bool ValidaExistenciaUsuario(string usuario)
        {
            string sql = "SELECT idUsuario from Usuario where Usuario=@us";
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="us",
                    SqlDbType=SqlDbType.VarChar,
                    Size=100,
                    Value=usuario
                }
            };
            bool val = operacion.ConsultaDRseguro(sql, ref msg, par).Result;
            return val;
        }
        public bool ValidaExistenciaEquipo(string Nombequipo)
        {
            string sql = "select idequipo from Equipo where Nomequipo=@eq";
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="eq",
                    SqlDbType=SqlDbType.VarChar,
                    Size=100,
                    Value=Nombequipo
                }
            };
            bool val = operacion.ConsultaDRseguro(sql, ref msg, par).Result;
            return val;
        }
        public void Cancelarregistroequipo(int idequipo)
        {
            string sql = "delete from Usuario_equipo where idEquipo=@numero";
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="numero",
                    SqlDbType=SqlDbType.Int,
                    Size=4,
                    Value=idequipo
                }
            };
            operacion.modregistrosmaseguro(sql, ref msg, par);
            sql = "delete from equipo where idEquipo=@equipoid";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="equipoid",
                    SqlDbType=SqlDbType.Int,
                    Size=4,
                    Value=idequipo
                }
            };
            operacion.modregistrosmaseguro(sql, ref msg, pars);
        }
        public void CancelarRegistroTablero(int idtablero)
        {
            string sql = "delete from Actividad where idTablero=@idt";
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="idt",
                    SqlDbType=SqlDbType.Int,
                    Size=4,
                    Value=idtablero
                }
            };
            operacion.modregistrosmaseguro(sql, ref msg, par);
            sql = "delete from Usuario_tablero where idTablero=@idut";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="idut",
                    SqlDbType=SqlDbType.Int,
                    Size=4,
                    Value=idtablero
                }
            };
            operacion.modregistrosmaseguro(sql, ref msg, pars);
            sql = "delete from Tablero where idTablero=@tabid";
            SqlParameter[] parss = new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName="tabid",
                    SqlDbType=SqlDbType.Int,
                    Size=4,
                    Value=idtablero
                }
            };
            operacion.modregistrosmaseguro(sql, ref msg, parss);
        }
        public string InsertarUsuario(string[] objetos)
        {
            SqlParameter[] misparams = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName="nom",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=objetos[0]
                    },
                    new SqlParameter
                    {
                        ParameterName="app",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=objetos[1]
                    },
                    new SqlParameter
                    {
                        ParameterName="apm",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=objetos[2]
                    },
                    new SqlParameter
                    {
                        ParameterName="user",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=objetos[3]
                    },
                    new SqlParameter
                    {
                        ParameterName="pass",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=objetos[4]
                    },
                    new SqlParameter
                    {
                        ParameterName="type",
                        SqlDbType=SqlDbType.VarChar,
                        Size=15,
                        Value=objetos[5]
                    },
                    new SqlParameter
                    {
                        ParameterName="avatar",
                        SqlDbType=SqlDbType.VarChar,
                        Value=objetos[6]
                    }
                };
            string sql = "insert into Usuario (Nombre,App,Apm,Usuario,Password,TipoUs,Avatarurl) values(@nom,@app,@apm,@user,@pass,@type,@avatar)";
            operacion.modregistrosmaseguro(sql, ref msg, misparams);
            return msg;
        }
        //Método encargado de realizar la consulta a la base de datos, sobre si un usuario
        //que esta intentando acceder, contiene credenciales previamente creadas y validadas.
        public object[] IniciarSesion(string us, string pass)
        {
            object[] a = null;
            string sql = "Select 1 from Usuario where Usuario=@us and Password=@pass";
            SqlParameter[] coleccion =
            {
                    new SqlParameter
                    {
                        ParameterName="us",
                        Value=us,
                        SqlDbType=SqlDbType.VarChar,
                        Size=100
                    },
                    new SqlParameter
                    {
                        ParameterName="pass",
                        SqlDbType=SqlDbType.VarChar,
                        Size=100,
                        Value=pass
                    }
            };
            if (operacion.ConsultaDRseguro(sql, ref msg, coleccion).Result)
            {
                a = new object[4];
                string sqls = "Select TipoUs from Usuario where Usuario='" + us + "' and Password='" + pass + "';";
                string lee = operacion.Consultatipous(sqls, ref msg);
                a[0] = us;//Usuario
                a[1] = pass;//Contraseña
                a[2] = lee;//Tipo USUARIO
                sqls = "Select idUsuario from Usuario where Usuario='" + us + "' and Password='" + pass + "';";
                int idus = (operacion.Consultanumerito(sqls, ref msg));
                a[3] = idus;
            }
            return a;
        }
        //Permite recuperar información indispensable para nuestro usuario, como su nombre, url de su avatar, y tableros
        //a los que pertenece.
        public object[] RecuperaDatosIniciados(string us, string pass)
        {
            object[] resp = new object[3];
            string nam = "";
            string sq = "select Avatarurl from Usuario where Usuario='" + us + "' and Password='" + pass + "';";
            string url = operacion.Consultatipous(sq, ref msg);
            sq = "select Nombre from Usuario where Usuario='" + us + "'";
            nam = operacion.Consultatipous(sq, ref msg);
            sq = "select App from Usuario where Usuario='" + us + "'";
            nam = nam + " " + operacion.Consultatipous(sq, ref msg);
            sq = "select Apm from Usuario where Usuario='" + us + "'";
            nam = nam + " " + operacion.Consultatipous(sq, ref msg);
            sq = "select T.idTablero AS Num,T.Nomclase, T.titulo from Usuario_tablero INNER JOIN Tablero AS T ON Usuario_tablero.idTablero=T.idTablero INNER JOIN Usuario AS U ON Usuario_tablero.idUsuario=U.idUsuario WHERE U.Usuario='" + us + "'";
            DataSet Tab = operacion.ConsultaDataSet(sq, ref msg);
            resp[0] = nam;
            resp[1] = url;
            resp[2] = Tab;
            return resp;
        }
        //Permite recuperar información indispensable para un profesor, como su nombre, url de su avatar, y tableros
        //que administra.
        public object[] RecuperaDatosIniciadosmaestro(string us, string pass)
        {
            object[] resp = new object[2];
            string nam = "";
            string sq = "select Avatarurl from Usuario where Usuario='" + us + "' and Password='" + pass + "';";
            string url = operacion.Consultatipous(sq, ref msg);
            sq = "select Nombre from Usuario where Usuario='" + us + "'";
            nam = operacion.Consultatipous(sq, ref msg);
            sq = "select App from Usuario where Usuario='" + us + "'";
            nam = nam + " " + operacion.Consultatipous(sq, ref msg);
            sq = "select Apm from Usuario where Usuario='" + us + "'";
            nam = nam + " " + operacion.Consultatipous(sq, ref msg);
            resp[0] = nam;
            resp[1] = url;
            return resp;
        }
        /*public string RecuperarNombreProfesor(int idusuario)
        {
            string sql = "Select Nombre, app,apm from Usuario where idusuario=4";

        }*/
        //Método para recuperar nombre de equipo, url y dueño de un equipo, para posteriormente crearlo
        //Y asociar a este usuario a este nuevo equipo
        public int Insertarunequipo(string nombre, string avatarurl, int idusuario)
        {
            int idequipo = -1;
            string sql = "insert into equipo (Nomequipo,avatarurl) values (@nome,@avatar);";
            SqlParameter[] coll =
            {
                    new SqlParameter()
                    {
                        ParameterName="nome",
                        SqlDbType=System.Data.SqlDbType.VarChar,
                        Size=100,
                        Value=nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName="avatar",
                        SqlDbType=System.Data.SqlDbType.VarChar,
                        Value=avatarurl
                    }
                };
            if (operacion.modregistrosmaseguro(sql, ref msg, coll).Result)
            {
                sql = "select idEquipo from Equipo where Nomequipo='" + nombre + "' " + "and avatarurl='" + avatarurl + "';";
                idequipo = operacion.Consultanumerito(sql, ref msg);
                sql = "insert into Usuario_Equipo (idUsuario,idEquipo) values (" + idusuario + "," + idequipo + ")";
                operacion.ModificarBD(sql, ref msg);
            }
            return idequipo;
        }
        //Método para devolver el nombre de un equipo, en base a una busqueda, de la cual se apoya en nuestro formulario.
        //Donde se muestran tablas de los equipos.
        public string Consultarnomequipo(int idequipo)
        {
            string sql = "Select Nomequipo from Equipo where idEquipo=" + idequipo;
            string nomb = operacion.Consultatipous(sql, ref msg);
            return nomb;
        }
        //Método para añadir miembros a un equipo ya creado, se solicita el nombre de usuario del integrante,
        //y el id del equipo al que se quiere unir.
        public string Insertarmiembrosaequipo(string usuario, int idequipo)
        {
            string msg = "";
            string sql = "INSERT into Usuario_equipo (idUsuario,idEquipo) values ((Select idUsuario from Usuario where Usuario=@nombuser),@idequipo)";
            SqlParameter[] par =
            {
                        new SqlParameter
                        {
                            ParameterName="nombuser",
                            Value=usuario,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="idequipo",
                            Value=idequipo,
                            SqlDbType=SqlDbType.Int
                        }
                    };
            if (operacion.modregistrosmaseguro(sql, ref msg, par).Result)
                msg = "Compañero agregado";
            else
                msg = "Fallo al localizar al compañerito";
            return msg;
        }
        //Método que necesita reestructuración, para nuevas necesidades en el proyecto.
        public bool CrearunTablero(int idusuario, string titulo, string clase, string usuario, ref object[] dev)
        {
            //  CAMBIAR RUTA Ó MANEJAR TABLEROS POR ID
            string nombqr = DateTime.Now.DayOfYear + idusuario + titulo.Substring(0, 1).ToUpper() + clase.Substring(0, 1).ToUpper() + usuario.Substring(0, 3).ToUpper() + DateTime.Now.Millisecond;
            string sql = "Insert into Tablero (Nomclase,titulo,codigotablero) values (@nomb,@tit,@cod)";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("nomb",System.Data.SqlDbType.VarChar),
                new SqlParameter("tit",System.Data.SqlDbType.VarChar),
                new SqlParameter("cod",System.Data.SqlDbType.VarChar)
            };
            pars[0].Value = clase;
            pars[1].Value = titulo;
            pars[2].Value = nombqr;
            operacion.modregistrosmaseguro(sql, ref msg, pars);
            sql = "Insert into Usuario_tablero (idUsuario,idTablero,puntuacion) values (" + idusuario + ",(Select idTablero from Tablero where codigotablero='" + nombqr + "'),0)";
            var Response = operacion.ModificarBD(sql, ref msg).Result;
            sql = "select idtablero from tablero where Nomclase='" + clase + "' and codigotablero='" + nombqr + "'";
            int equipo = operacion.Consultanumerito(sql, ref msg);
            dev[0] = (int)equipo;
            if (equipo > 0)
                Response = true;
            return Response;
        }

        //Método que permite añadir actividades a un tablero, esto solo recupera el nombre de la actividad
        //y el tablero al que pertenece. Previamente validados en el formulario.
        public bool Insertaractividadatablero(string actividad, int idtablero)
        {
            bool insr = false;
            string sql = "Insert into Actividad (Nomact,idTablero) values (@act,@idtab)";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("act",System.Data.SqlDbType.VarChar),
                new SqlParameter("idtab",System.Data.SqlDbType.Int)
            };
            pars[0].Value = actividad;
            pars[1].Value = idtablero;
            if (operacion.modregistrosmaseguro(sql, ref msg, pars).Result)
                insr = true;
            return insr;
        }
        //Permite adjuntar insignias, "Valor, img, tablero al que pertenece" son necesarios.
        public bool Insertarinsigniastablero(string[] url, int[] valores, int idtablero)
        {
            bool resp = false;
            string sql = "";
            for (int a = 0; a < 3; a++)
            {
                sql = "insert into Insignia (insigniaurl,valor,idTablero) values ('" + url[a] + "'," + valores[a] + "," + idtablero + ")";
                if (operacion.ModificarBD(sql, ref msg).Result)
                {
                    resp = true;
                }
                else
                {
                    resp = false;
                    break;
                }
            }
            return resp;
        }
        //Método que devuelve en una "tabla", todos los equipos a los que pertenece un usuario.
        public DataTable ConsultaEquiposdeunusuario(int id)
        {
            DataTable tabla = null;
            string sql = "Select UE.idEquipo AS Num,E.Nomequipo AS EQUIPOS from Usuario_equipo AS UE INNER JOIN Equipo AS E ON E.idEquipo=UE.idEquipo INNER JOIN Usuario AS U ON U.idUsuario=UE.idUsuario WHERE U.idUsuario=" + id;
            tabla = operacion.ConsultaDataSet(sql, ref msg).Tables[0];
            return tabla;
        }
        //Recupera los nombres de los integrantes, cuales pertenecen a un determinado equipo.
        public SqlDataReader Consultaintegrantesdeequipo(int equipo)
        {
            string sql = "Select  U.usuario,U.nombre from Usuario_equipo AS UE INNER JOIN Usuario AS U ON U.idUsuario=UE.idUsuario INNER JOIN Equipo AS E ON E.idEquipo=UE.idEquipo WHERE E.idEquipo=" + equipo;
            SqlDataReader resp = operacion.ConsultaDR(sql, ref msg);
            return resp;
        }
        public string Consultaintegrantesdeequipopornomequipo(string equipo)
        {
            string sql = "Select  U.usuario,U.nombre, U.app from Usuario_equipo AS UE INNER JOIN Usuario AS U ON U.idUsuario=UE.idUsuario INNER JOIN Equipo AS E ON E.idEquipo=UE.idEquipo WHERE E.Nomequipo='" + equipo+"'";
            SqlDataReader resp = operacion.ConsultaDR(sql, ref msg);
            List<string> lista = new List<string>();
            lista.Clear();
            while (resp.Read())
            {
                lista.Add(" | Usuario:" + resp.GetString(0) + ", Nombre:" + resp.GetString(1) + " | ");
            }
            int a = 0;
            string b = "";
            while (a < lista.Count)
            {
                b = b + lista[a];
                a++;
            }
            return b;
        }
        //Recupera el id de un TABLERO en caso de que un equipo tenga registrado un tablero
        public int idtableroequipo(int equipo)
        {
            string sql = "Select T.idTablero from Equipo_tablero AS ET INNER JOIN Equipo AS E ON E.idEquipo=ET.idEquipo INNER JOIN Tablero AS T ON T.idTablero=ET.idTablero WHERE ET.idEquipo=" + equipo;
            return operacion.Consultanumerito(sql, ref msg);
        }
        //Método que devuelve en una tabla, los tableros que administra un profesor.
        public DataTable ConsultaTablerosProfesor(int idprofesor)
        {
            DataTable tabla = null;
            string sql = "select T.idTablero as Tablero,T.titulo as Titulo, T.Nomclase AS Clase from Usuario_tablero AS UT inner join TABLERO as T on T.idTablero=UT.idTablero inner join Usuario AS U on U.idUsuario=UT.idUsuario where U.idUsuario=" + idprofesor;
            tabla = operacion.ConsultaDataSet(sql, ref msg).Tables[0];
            return tabla;
        }

        //Método para imprimir un datatable
        public DataTable Construirtablero(int idtablero)
        {
            List<string> actividades = new List<string>();
            DataTable tablero = new DataTable();
            tablero.Columns.Add("Integrantes");
            string sql = "select Nomact from Actividad where idTablero=" + idtablero + " order by idActividad ASC";
            SqlDataReader acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    actividades.Add(acts.GetString(0));
                }
                int b = 0;
                while (b < actividades.Count)
                {
                    tablero.Columns.Add(actividades[b]);
                    b++;
                }
            }
            tablero.Columns.Add("Puntuación");
            //integrantes filas
            sql = "select U.Usuario from Usuario_tablero AS UT inner join Usuario AS U ON U.idUsuario = UT.idUsuario inner join Tablero AS T ON T.idTablero = UT.idTablero WHERE U.TipoUs = 'ALUMNO' and T.idTablero = " + idtablero + " ORDER BY U.idUsuario ASC";
            acts = operacion.ConsultaDR(sql, ref msg);
            actividades.Clear();
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    actividades.Add(acts.GetString(0));
                }
            }
            for (int c = 0; c < actividades.Count(); c++)
            {
                tablero.Rows.Add(actividades[c]);
            }
            int total = tablero.Columns.Count;
            sql = "select puntuacion from Usuario_tablero AS UT INNER JOIN Usuario AS U ON U.idUsuario = UT.idUsuario where UT.idTablero = " + idtablero + " and U.TipoUs = 'ALUMNO' order by UT.idUsuario ASC";
            List<int> puntuaciones = new List<int>();
            acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    puntuaciones.Add(Convert.ToInt32(acts[0]));
                }
            }
            for (int c = 0; c < puntuaciones.Count; c++)
            {
                tablero.Rows[c][total - 1] = puntuaciones[c];
            }
            int j = 1;
            while (j < total - 1)
            {
                sql = "select U.Usuario, I.valor from Usuario_Actividad_Valor AS UAV INNER JOIN Actividad AS A ON A.idActividad = UAV.idActividad INNER JOIN Insignia AS I ON I.idInsignia = UAV.idInsignia INNER JOIN Usuario AS U ON U.idUsuario=UAV.idUsuario where A.Nomact = '" + tablero.Columns[j].ColumnName + "' and UAV.idTablero = " + idtablero + " order by UAV.idUsuario ASC";
                acts = operacion.ConsultaDR(sql, ref msg);
                if (acts.HasRows)
                {
                    while (acts.Read())
                    {
                        string usuar = acts[0] + "";
                        for (int a = 0; a < tablero.Rows.Count; a++)
                        {
                            if (tablero.Rows[a][0].ToString() == usuar)
                            {
                                tablero.Rows[a][j] = acts[1];
                            }
                        }
                    }
                }
                //tablero.Columns[j].ColumnName;
                j++;
            }
            sql = "select U.Usuario, UT.puntuacion from Usuario_tablero AS UT inner join Usuario AS U ON U.idUsuario=UT.idUsuario WHERE U.TipoUs='ALUMNO' and UT.idTablero=" + idtablero + " ORDER BY U.idUsuario ASC";
            acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    string usuar = acts[0] + "";
                    for (int a = 0; a < tablero.Rows.Count; a++)
                    {
                        if (tablero.Rows[a][0].ToString() == usuar)
                        {
                            tablero.Rows[a][total - 1] = acts[1];
                        }
                    }
                }
            }
            return tablero;
        }

        public DataTable ConstruirtableroEquipo(int idtablero)
        {
            List<string> actividades = new List<string>();
            DataTable tablero = new DataTable();
            tablero.Columns.Add("Integrantes");
            string sql = "select Nomact from Actividad where idTablero=" + idtablero + " order by idActividad ASC";
            SqlDataReader acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    actividades.Add(acts.GetString(0));
                }
                int b = 0;
                while (b < actividades.Count)
                {
                    tablero.Columns.Add(actividades[b]);
                    b++;
                }
            }
            tablero.Columns.Add("Puntuación");
            //integrantes filas
            sql = "Select e.Nomequipo from Equipo_tablero AS ET INNER JOIN Tablero AS T ON T.idTablero=ET.idTablero INNER JOIN Equipo AS E ON E.idEquipo=ET.idEquipo WHERE T.idTablero=" + idtablero + " ORDER BY E.idEquipo";
            acts = operacion.ConsultaDR(sql, ref msg);
            actividades.Clear();
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    actividades.Add(acts.GetString(0));
                }
            }
            for (int c = 0; c < actividades.Count(); c++)
            {
                tablero.Rows.Add(actividades[c]);
            }
            int total = tablero.Columns.Count;
            sql = "select puntuacion from Equipo_tablero where idTablero=" + idtablero + " ORDER BY idEquipo ASC";
            List<int> puntuaciones = new List<int>();
            acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    puntuaciones.Add(Convert.ToInt32(acts[0]));
                }
            }
            for (int c = 0; c < puntuaciones.Count; c++)
            {
                tablero.Rows[c][total - 1] = puntuaciones[c];
            }
            int j = 1;
            while (j < total - 1)
            {
                sql = "select E.Nomequipo, I.valor from Equipo_Actividad_Valor AS EAV INNER JOIN Actividad AS A ON A.idActividad = EAV.idActividad INNER JOIN Insignia AS I ON I.idInsignia = EAV.idInsignia INNER JOIN Equipo AS E ON E.idEquipo=EAV.idEquipo where A.Nomact ='" + tablero.Columns[j].ColumnName + "' and EAV.idTablero = " + idtablero + " ORDER by EAV.idEquipo ASC";
                acts = operacion.ConsultaDR(sql, ref msg);
                if (acts.HasRows)
                {
                    while (acts.Read())
                    {
                        string usuar = acts[0] + "";
                        for (int a = 0; a < tablero.Rows.Count; a++)
                        {
                            if (tablero.Rows[a][0].ToString() == usuar)
                            {
                                tablero.Rows[a][j] = acts[1];
                            }
                        }
                    }
                }
                //tablero.Columns[j].ColumnName;
                j++;
            }
            sql = "select E.nomequipo, ET.puntuacion from Equipo_tablero AS ET inner join Equipo AS E ON E.idEquipo=ET.idEquipo WHERE ET.idTablero=" + idtablero + " ORDER BY E.idEquipo ASC";
            acts = operacion.ConsultaDR(sql, ref msg);
            if (acts.HasRows)
            {
                while (acts.Read())
                {
                    string usuar = acts[0] + "";
                    for (int a = 0; a < tablero.Rows.Count; a++)
                    {
                        if (tablero.Rows[a][0].ToString() == usuar)
                        {
                            tablero.Rows[a][total - 1] = acts[1];
                        }
                    }
                }
            }
            return tablero;
        }
        public string[] recuperardatostablero(int idtablero)
        {
            string[] cadenas = new string[4];
            string sql = "Select U.Nombre, U.App, U.Apm, t.titulo,T.Nomclase,T.codigotablero from Usuario_tablero AS UT INNER JOIN Usuario AS U ON U.idUsuario = UT.idUsuario INNER JOIN Tablero AS T ON T.idTablero = UT.idTablero where U.TipoUs = 'PROFESOR' and T.idTablero = " + idtablero + "";
            SqlDataReader recibe;
            recibe = operacion.ConsultaDR(sql, ref msg);
            if (recibe.HasRows)
            {
                string nombre = "";
                recibe.Read();
                nombre = recibe[0] + " " + recibe[1] + " " + recibe[2];
                cadenas[0] = nombre;
                cadenas[1] = recibe[3].ToString();
                cadenas[2] = recibe[4].ToString();
                cadenas[3] = recibe[5].ToString();
            }
            return cadenas;
        }
        public GenericResponse<bool> Verificaexistenciausuariotablero(int idusuario, string codigotablero)
        {
            GenericResponse<bool> Resultado = new GenericResponse<bool>(Data: false, message: "ERROR CON TABLERO", Result: false);
            string sql = "select T.idTablero from Usuario_tablero  AS UT INNER JOIN Tablero as T ON T.idTablero=UT.idTablero WHERE T.codigotablero='" + codigotablero + "'";
            int val = operacion.Consultanumerito(sql, ref msg);
            if (val <= 0)
                Resultado.Message = "NO EXISTE EL TABLERO CON EL CÓDIGO ESPECIFICADO";
            else
            {
                sql = "select * from Equipo_tablero where idTablero=" + val;
                SqlDataReader resp = operacion.ConsultaDR(sql, ref msg);
                if (resp.HasRows)
                {
                    Resultado.Message = "ESTE TABLERO CORRESPONDE A UNO DISEÑADO PARA EQUIPOS DE TRABAJO";
                }
                else
                {
                    //verificar usuario_Tablero
                    sql = "select * from Usuario_tablero where idTablero=" + val + " and idUsuario=" + idusuario + "";
                    resp = operacion.ConsultaDR(sql, ref msg);
                    if (resp.HasRows)
                    {
                        Resultado.Message = "USUARIO YA REGISTRADO EN EL TABLERO ESPECIFICADO";
                    }
                    else
                    {
                        sql = "insert into Usuario_tablero values (" + idusuario + "," + val + ",0)";
                        if (operacion.ModificarBD(sql, ref msg).Result)
                        {
                            Resultado.Message = val + "";
                            Resultado.Result = true;
                        }
                    }
                }
            }
            return Resultado;
        }
        //Verificar que no intervieran los id tableros para con los deeee Usuario //
        public GenericResponse<bool> Verificaexistenciaequipotablero(int idequipo, string codigotablero)
        {
            GenericResponse<bool> Resultado = new GenericResponse<bool>(Data: false, message: "ERROR CON TABLERO", Result: false);
            string sql = "select T.idTablero from Usuario_tablero  AS UT INNER JOIN Tablero as T ON T.idTablero=UT.idTablero WHERE T.codigotablero='" + codigotablero + "'";
            int val = operacion.Consultanumerito(sql, ref msg);
            if (val <= 0)
                Resultado.Message = "NO EXISTE EL TABLERO CON EL CÓDIGO ESPECIFICADO";
            else
            {
                sql = "select * from Usuario_tablero AS UT INNER JOIN Usuario AS U ON U.idUsuario=UT.idUsuario WHERE U.TipoUs='ALUMNO' AND UT.idTablero=" + val;
                SqlDataReader resp = operacion.ConsultaDR(sql, ref msg);
                if (resp.HasRows)
                {
                    Resultado.Message = "ESTE TABLERO FUE DESIGNADO PARA TRABAJO INDIVIDUAL, NO EN EQUIPOS";
                }
                else
                {
                    //verificar usuario_Tablero
                    sql = "select * from Equipo_tablero where idTablero=" + val + " and idEquipo=" + idequipo + "";
                    resp = operacion.ConsultaDR(sql, ref msg);
                    if (resp.HasRows)
                    {
                        Resultado.Message = "EQUIPO YA REGISTRADO EN EL TABLERO ESPECIFICADO";
                    }
                    else
                    {
                        sql = "INSERT into Equipo_tablero values (" + idequipo + "," + val + ",0)";
                        if (operacion.ModificarBD(sql, ref msg).Result)
                        {
                            Resultado.Message = val + "";
                            Resultado.Result = true;
                        }
                    }
                }
            }
            return Resultado;
        }

        public bool Verificartipotablero(int idtablero)
        {
            bool fal = false;
            string sql = "select * from Equipo_tablero where idTablero=" + idtablero;
            SqlDataReader lee = operacion.ConsultaDR(sql, ref msg);
            if (lee.HasRows)
            {
                fal = true;
            }
            return fal;
        }

        public List<string> Recuperaractividades(int idtablero)
        {
            List<string> lista = new List<string>();
            string sql = "select nomact AS Actividad from Actividad where idTablero=" + idtablero;
            SqlDataReader lectura = operacion.ConsultaDR(sql, ref msg);
            if(lectura.HasRows)
            {
                while(lectura.Read())
                {
                    lista.Add(lectura[0].ToString());
                }
            }
            return lista;
        }

        public List<double> Recuperarinsignias(int idtablero)
        {
            List<double> lista = new List<double>();
            string sql = "select valor from Insignia where idTablero=" + idtablero;
            SqlDataReader lectura = operacion.ConsultaDR(sql, ref msg);
            if (lectura.HasRows)
            {
                while (lectura.Read())
                {
                    lista.Add(Convert.ToDouble(lectura[0]));
                }
            }
            return lista;
        }
        public bool otorgaractinUS(string us,double valor, int tablero,string actividad)
        {
            bool val = false;
            //Validar si no tiene la actividad previamente registrada
            string sql = "select idUsuario, idActividad from Usuario_Actividad_Valor where idUsuario=(select idUsuario from Usuario where Usuario='" + us + "') and idActividad=(select idActividad from Actividad where Nomact='" + actividad + "')";
            SqlDataReader comprobar = operacion.ConsultaDR(sql, ref msg);
            sql = "Select idUsuario from Usuario where Usuario='" + us + "'";
            int idusuario = operacion.Consultanumerito(sql, ref msg);
            sql = "select idInsignia from Insignia where valor=" + valor + " and idTablero=" + tablero;
            int idinsignia = operacion.Consultanumerito(sql, ref msg);
            sql = "select idactividad from Actividad where Nomact='" + actividad + "' and idTablero=" + tablero;
            int idactividad = operacion.Consultanumerito(sql, ref msg);
            if (comprobar.HasRows)
            {
                //actualizar
                sql = "update Usuario_Actividad_Valor set idInsignia=@ins where idUsuario=@us and idActividad=@act and idTablero=@tab";
                SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="ins",
                            Value=idinsignia,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="us",
                            Value=idusuario,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="act",
                            Value=idactividad,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
                };
                if (operacion.modregistrosmaseguro(sql, ref msg, parameters).Result)
                {
                    val = true;
                    actualizarpuntuacionusuario(idusuario, tablero);
                }
                    
            }
            else
            {
                sql = "Insert into Usuario_Actividad_Valor (idUsuario,idActividad,idInsignia,idTablero) values (@us,@act,@ins,@tab)";
                SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="ins",
                            Value=idinsignia,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="us",
                            Value=idusuario,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="act",
                            Value=idactividad,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
                };
                if (operacion.modregistrosmaseguro(sql, ref msg, parameters).Result)
                {
                    val = true;
                    actualizarpuntuacionusuario(idusuario, tablero);
                }
            }
            return val;
        }
        public void actualizarpuntuacionusuario(int idusuario, int tablero)
        {
            string sql = "update Usuario_tablero set puntuacion=(select sum(I.valor) from Usuario_Actividad_Valor as UAV inner join Insignia as I on I.idInsignia=UAV.idInsignia where UAV.idUsuario=@us and UAV.idTablero=@tab) where idUsuario=@us and idTablero=@tab";
            SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="us",
                            Value=idusuario,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
            };
            operacion.modregistrosmaseguro(sql, ref msg, parameters);
        }

        public bool otorgaractinEQ(string eq, double valor, int tablero, string actividad)
        {
            bool val = false;
            //Validar si no tiene la actividad previamente registrada
            string sql = "select idEquipo, idActividad from Equipo_Actividad_Valor where idEquipo=(select idEquipo from Equipo where Nomequipo='"+eq+"') and idActividad=(select idActividad from Actividad where Nomact='"+actividad+"')";
            SqlDataReader comprobar = operacion.ConsultaDR(sql, ref msg);
            sql = "Select idEquipo from Equipo where Nomequipo='" + eq + "'";
            int idequipo = operacion.Consultanumerito(sql, ref msg);
            sql = "select idInsignia from Insignia where valor=" + valor + " and idTablero=" + tablero;
            int idinsignia = operacion.Consultanumerito(sql, ref msg);
            sql = "select idactividad from Actividad where Nomact='" + actividad + "' and idTablero=" + tablero;
            int idactividad = operacion.Consultanumerito(sql, ref msg);
            if (comprobar.HasRows)
            {
                //actualizar
                sql = "update Equipo_Actividad_Valor set idInsignia=@ins where idEquipo=@eq and idActividad=@act and idTablero=@tab";
                SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="ins",
                            Value=idinsignia,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="eq",
                            Value=idequipo,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="act",
                            Value=idactividad,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
                };
                if (operacion.modregistrosmaseguro(sql, ref msg, parameters).Result)
                {
                    val = true;
                    actualizarpuntuacionEquipo(idequipo, tablero);
                }

            }
            else
            {
                sql = "Insert into Equipo_Actividad_Valor (idEquipo,idActividad,idInsignia,idTablero) values (@eq,@act,@ins,@tab)";
                SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="ins",
                            Value=idinsignia,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="eq",
                            Value=idequipo,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="act",
                            Value=idactividad,
                            SqlDbType=SqlDbType.Int
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
                };
                if (operacion.modregistrosmaseguro(sql, ref msg, parameters).Result)
                {
                    val = true;
                    actualizarpuntuacionEquipo(idequipo, tablero);
                }
            }
            return val;
        }
        public void actualizarpuntuacionEquipo(int idequipo, int tablero)
        {
            string sql = "update Equipo_tablero set puntuacion=(select sum(I.valor) from Equipo_Actividad_Valor as EAV inner join Insignia as I on I.idInsignia=EAV.idInsignia where EAV.idEquipo=@eq and EAV.idTablero=@tab) where idEquipo=@eq and idTablero=@tab";
            SqlParameter[] parameters =
                {
                        new SqlParameter
                        {
                            ParameterName="eq",
                            Value=idequipo,
                            SqlDbType=SqlDbType.VarChar
                        },
                        new SqlParameter
                        {
                            ParameterName="tab",
                            Value=tablero,
                            SqlDbType=SqlDbType.Int
                        }
            };
            operacion.modregistrosmaseguro(sql, ref msg, parameters);
        }
    }
}
