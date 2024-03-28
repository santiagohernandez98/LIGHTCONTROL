using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_PQRSBase
    {

        public bool Modificar(PQRS pqr)
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.ModificarPQRS", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", pqr.Id);
                    cmd.Parameters.AddWithValue("@fecha_registro", pqr.FechaRegistro);
                    cmd.Parameters.AddWithValue("@canal", pqr.Canal);
                    cmd.Parameters.AddWithValue("@tipo_pqrs", pqr.TipoPQRS);
                    cmd.Parameters.AddWithValue("@referencia", pqr.Referencia);
                    cmd.Parameters.AddWithValue("@documento", pqr.Documento);
                    cmd.Parameters.AddWithValue("@nombre", pqr.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", pqr.Telefono);
                    cmd.Parameters.AddWithValue("@correo_electronico", pqr.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@descripcion_afectacion", pqr.DescripcionAfectacion);
                    cmd.Parameters.AddWithValue("@tipo_alumbrado", pqr.TipoAlumbrado);
                    cmd.Parameters.AddWithValue("@estado", pqr.Estado);
                    cmd.Parameters.AddWithValue("@observaciones", pqr.Observaciones);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Registrar(PQRS pqr)
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.GuardarPQRS",
                                                    oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fecha_registro", pqr.FechaRegistro);
                    cmd.Parameters.AddWithValue("@canal", pqr.Canal);
                    cmd.Parameters.AddWithValue("@tipo_pqrs", pqr.TipoPQRS);
                    cmd.Parameters.AddWithValue("@referencia", pqr.Referencia);
                    cmd.Parameters.AddWithValue("@documento", pqr.Documento);
                    cmd.Parameters.AddWithValue("@nombre", pqr.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", pqr.Telefono);
                    cmd.Parameters.AddWithValue("@correo_electronico", pqr.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@descripcion_afectacion", pqr.DescripcionAfectacion);
                    cmd.Parameters.AddWithValue("@tipo_alumbrado", pqr.TipoAlumbrado);
                    cmd.Parameters.AddWithValue("@estado", pqr.Estado);
                    cmd.Parameters.AddWithValue("@observaciones", pqr.Observaciones);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}