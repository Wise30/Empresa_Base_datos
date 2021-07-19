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
    public class CDCompañia_suplidor
    {
        private int dId_proyecto;
        private String dCompañia_suplidor, dCargamento, dCantidad, dFecha_entrega, dObservacion;
        //Constructor vacío de la clase
        public CDCompañia_suplidor()
        {
        }
        //Constructor con parámetros de la clase
        //uso p para referirme a los parámetros
        public CDCompañia_suplidor(int pId_proyecto,
            string pCargamento, 
            string pCantidad, 
            string pFecha_entrega, 
            string pObservacion)
        {
            //Asignamos a cada propiedad de la clase el valor pasado como parámetro
            dId_proyecto = pId_proyecto;
            dCargamento = pCargamento;
            dCantidad = pCantidad;
            dFecha_entrega = pFecha_entrega;
            dObservacion = pObservacion;
        }
        #region para los métodos Get y Set
        public int Id_proyecto
        {
            get { return dId_proyecto; }
            set { dId_proyecto = value; }
        }
        public string dCompañia_suplidora
        {
            get { return dCompañia_suplidor; }
            set { dCompañia_suplidor = value; }
        }
        public string Cargamento
        {
            get { return dCargamento; }
            set { dCargamento = value; }
        }
        public string Cantidad
        {
            get { return dCantidad; }
            set { dCantidad = value; }
        }
        public string Fecha_entrega
        {
            get { return dFecha_entrega; }
            set { dFecha_entrega = value; }
        }
        public string Observacion
        {
            get { return dObservacion; }
            set { dObservacion = value; }
        }
        #endregion
        //método para insertar un nuevo Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Insertar(CDCompañia_suplidor objCompañia_suplidora)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = Proyectos_AyuntamientoConexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("Compañia_suplidoraInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;

                /*Envío los parámetros al procedimiento almacenado.
                - Los nombres que aparece con el signo @ delante son los parámetros que hemos
                creado en el procedimiento almacenado de la base de datos.
                - Los nombres que aparecen al lado son las propiedades del objeto objSuplidor que se pasará
                como parámetro con los valores deseados.
                */
                micomando.Parameters.AddWithValue("@Id_proyecto", objCompañia_suplidora.Id_proyecto);
                micomando.Parameters.AddWithValue("@Compañia_Suplidora", objCompañia_suplidora.dCompañia_suplidor);
                micomando.Parameters.AddWithValue("@Cargamento", objCompañia_suplidora.Cargamento);
                micomando.Parameters.AddWithValue("@Cantidad", objCompañia_suplidora.Cantidad);
                micomando.Parameters.AddWithValue("@Fecha_entrega", objCompañia_suplidora.Fecha_entrega);
                micomando.Parameters.AddWithValue("@Observacion",objCompañia_suplidora.Observacion);

                //hasta aquí el pase de parámetros
                /*Ejecuto la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente de lo
                 * contrario se devuelve el mensaje indicando que fue incorrecto.
                */
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente" :
                "No se pudo Insertar correctamente la nueva Compañia suplidora!";
            }
            //Si ocurre algún error se captura y se muestra el mensaje
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
        public string Actualizar(CDCompañia_suplidor objCompañia_suplidora)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexion con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = Proyectos_AyuntamientoConexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorActualizar
                SqlCommand micomando = new SqlCommand("Compañia_suplidoraActualizar", sqlCon);
                sqlCon.Open(); //Abro la conexion
                micomando.CommandType = CommandType.StoredProcedure; //indico que se ejecutara un procedimiento almacenado
                /*Envío los parámetros al procedimiento almacenado.
     - Los nombres que aparece con el signo @ delante son los parámetros que hemos
     creado en el procedimiento almacenado de la base de datos.
     - Los nombres que aparecen al lado son las propiedades del objeto objSuplidor que se pasará
    como parámetro con los valores deseados.
     */
                micomando.Parameters.AddWithValue("@Id_proyecto", objCompañia_suplidora.Id_proyecto);
                micomando.Parameters.AddWithValue("@Compañia_Suplidora", objCompañia_suplidora.dCompañia_suplidor);
                micomando.Parameters.AddWithValue("@Cargamento", objCompañia_suplidora.Cargamento);
                micomando.Parameters.AddWithValue("@Cantidad", objCompañia_suplidora.Cantidad);
                micomando.Parameters.AddWithValue("@Fecha_entrega", objCompañia_suplidora.Fecha_entrega);
                micomando.Parameters.AddWithValue("@Observacion", objCompañia_suplidora.Observacion);
                //hasta aqui el pase de parametros
                /*Ejecuto la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente
                de lo contrario se devuelve el mensaje indicando que fue incorrecto.
                */
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualización completada correctamente" :
                "No se pudo Actualizar correctamente los datos de la Compañia suplidora!";
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
