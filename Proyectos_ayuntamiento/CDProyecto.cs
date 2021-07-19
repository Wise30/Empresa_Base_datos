using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace Proyectos_ayuntamiento
{
    public class CDProyecto
    {
        private int dId_Proyecto;
        private string dnombre_proyecto, dfecha_inicio, dlugar_proyecto, destado, dpresupuesto, ddescripcion;

        public CDProyecto()
        {

        }

        public CDProyecto(int pId_Proyecto,
                          string pNombre_proyecto,
                          string pFecha_inicio,
                          string pLugar_proyecto,
                          string pEstado,
                          string pPresupuesto,
                          string pDescripcion
                          )
        {
            dId_Proyecto = pId_Proyecto;
            dnombre_proyecto = pNombre_proyecto;
            dfecha_inicio = pFecha_inicio;
            dlugar_proyecto = pLugar_proyecto;
            destado = pEstado;
            dpresupuesto = pPresupuesto;
            ddescripcion = pDescripcion;

        }

        public int Id_Proyecto
        {
            get { return dId_Proyecto; }
            set { dId_Proyecto = value; }
        }
        public string nombre_proyecto
        {
            get { return dnombre_proyecto; }
            set { dnombre_proyecto = value; }
        }
        public string fecha_inicio
        {
            get { return dfecha_inicio; }
            set { dfecha_inicio = value; }
        }
        public string lugar_proyecto
        {
            get { return dlugar_proyecto; }
            set { dlugar_proyecto = value; }
        }
        public string estado
        {
            get { return destado; }
            set { destado = value; }
        }
        public string presupuesto
        {
            get { return dpresupuesto; }
            set { dpresupuesto = value; }
        }
        public string descripcion
        {
            get { return ddescripcion; }
            set { ddescripcion = value; }
        }

        //método para insertar un nuevo Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Insertar(CDProyecto objProyecto)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("ProyectoInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /*Envío los parámetros al procedimiento almacenado.
                - Los nombres que aparece con el signo @ delante son los parámetros que hemos
                creado en el procedimiento almacenado de la base de datos.
                - Los nombres que aparecen al lado son las propiedades del objeto objSuplidor que se pasará
                como parámetro con los valores deseados.
                */
                micomando.Parameters.AddWithValue("@Id_Proyecto", objProyecto.Id_Proyecto);
                micomando.Parameters.AddWithValue("@nombre_proyecto", objProyecto.nombre_proyecto);
                micomando.Parameters.AddWithValue("@fecha_inicio", objProyecto.fecha_inicio);
                micomando.Parameters.AddWithValue("@lugar_proyecto", objProyecto.lugar_proyecto);
                micomando.Parameters.AddWithValue("@estado", objProyecto.estado);
                micomando.Parameters.AddWithValue("@presupuesto", objProyecto.presupuesto);
                micomando.Parameters.AddWithValue("@descripcion", objProyecto.descripcion);


                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente" :
                "No se pudo Insertar correctamente el nuevo Proyecto!";

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //Luego de realizar el proceso de forma correcta o no
            finally
            {
                //Cierro la conexion si esta abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            //Devuelvo el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }

        //método para actualizar los datos del Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Actualizar(CDProyecto objProyecto)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexion con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este cas ProyectoActualizar
                SqlCommand micomando = new SqlCommand("ProyectoActualizar", sqlCon);
                sqlCon.Open(); //Abro la conexion
                micomando.CommandType = CommandType.StoredProcedure; //indico que se ejecutara un procedimiento almacenado
                /*Envío los parámetros al procedimiento almacenado.
                - Los nombres que aparece con el signo @ delante son los parámetros que hemos
                creado en el procedimiento almacenado de la base de datos.
                - Los nombres que aparecen al lado son las propiedades del objeto objSuplidor que se pasará
                como parámetro con los valores deseados.
                */
                micomando.Parameters.AddWithValue("@Id_Proyecto", objProyecto.Id_Proyecto);
                micomando.Parameters.AddWithValue("@nombre_proyecto", objProyecto.nombre_proyecto);
                micomando.Parameters.AddWithValue("@fecha_inicio", objProyecto.fecha_inicio);
                micomando.Parameters.AddWithValue("@lugar_proyecto", objProyecto.lugar_proyecto);
                micomando.Parameters.AddWithValue("@estado", objProyecto.estado);
                micomando.Parameters.AddWithValue("@presupuesto", objProyecto.presupuesto);
                micomando.Parameters.AddWithValue("@descripcion", objProyecto.descripcion);
                //hasta aqui el pase de parametros
                /*Ejecuto la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente
                de lo contrario se devuelve el mensaje indicando que fue incorrecto.
                */
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualización completada correctamente" :
                "No se pudo Actualizar correctamente los datos del Proyecto!";
            }
            //Si ocurre algún error se captura y se muestra el mensaje
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //Luego de realizar el proceso de forma correcta o no
            finally
            {
                //Cierro la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            //Devuelvo el mensaje correspondiente de acuerdo a lo que haya resultado del comando
            return mensaje;
        }

    }


}
