using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PQRS
    {

        public static List<PQRS> Obtener()
        {
            List<PQRS> Lista = new List<PQRS>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("MostrarPQRS", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Lista.Add(new PQRS()
                        {
                            id = Convert.ToInt32(dr["id"].ToString()),
                            fecha_registro = Convert.ToDateTime(dr["fecha_registro"].ToString()),
                            canal = dr["canal"].ToString(),
                            tipo_pqrs = dr["tipo_pqrs"].ToString(),
                            referencia = dr["referencia"].ToString(),
                            documento = dr["documento"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            correo_electronico = dr["correo_electronico"].ToString(),
                            descripcion_afectacion = dr["descripcion_afectacion"].ToString(),
                            tipo_alumbrado = dr["tipo_alumbrado"].ToString(),
                            estado = dr["estado"].ToString(),
                            oberservaciones = dr["observaciones"].ToString(),
                            
               
                            
                        });
                    }
                    dr.Close();

                    return Lista;

                }
                catch (Exception ex)
                {
                    Lista = null;
                    return Lista;
                }
            }
        }


        public static bool Registrar(PQRS objeto)
        {

            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GuardarPQRS", oConexion);
                    cmd.Parameters.AddWithValue("fecha_registro", objeto.fecha_registro);
                    cmd.Parameters.AddWithValue("canal", objeto.canal);
                    cmd.Parameters.AddWithValue("tipo_pqrs", objeto.tipo_pqrs);
                    cmd.Parameters.AddWithValue("referencia", objeto.referencia);
                    cmd.Parameters.AddWithValue("documento", objeto.documento);
                    cmd.Parameters.AddWithValue("nombre", objeto.nombre);
                    cmd.Parameters.AddWithValue("telefono", objeto.telefono);
                    cmd.Parameters.AddWithValue("correo_electronico", objeto.correo_electronico);
                    cmd.Parameters.AddWithValue("descripcion_afectacion", objeto.descripcion_afectacion);
                    cmd.Parameters.AddWithValue("tipo_alumbrado", objeto.tipo_alumbrado);
                    cmd.Parameters.AddWithValue("estado", objeto.estado);
                    cmd.Parameters.AddWithValue("observaciones", objeto.oberservaciones);
                    

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
        /*
        public static bool Modificar(PQRS objeto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarEleccion", oConexion);
                    cmd.Parameters.AddWithValue("IdEleccion", objeto.IdEleccion);
                    cmd.Parameters.AddWithValue("Descripcion", objeto.Descripcion);
                    cmd.Parameters.AddWithValue("Cargo", objeto.Cargo);
                    cmd.Parameters.AddWithValue("Activo", objeto.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }
        */
    }
}
