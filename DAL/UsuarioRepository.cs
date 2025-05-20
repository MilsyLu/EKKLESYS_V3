﻿using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using Oracle.ManagedDataAccess.Types;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly ConnectionManager connectionManager;

        public UsuarioRepository(ConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public void Guardar(Usuario usuario)
        {
            //using (var connection = connectionManager.GetConnection())
            //{
            //    connection.Open();
            //    using (var command = new OracleCommand())
            //    {
            //        command.Connection = connection;
            //        command.CommandText = @"INSERT INTO Usuarios (nombre, apellido_paterno, fecha_nacimiento, direccion, 
            //                              telefono, telefono2, email, cedula, password, es_miembro, ruta_imagen_usuario, id_comuna, es_administrador) 
            //                              VALUES (:nombre, :apellido_paterno, :fecha_nacimiento, :direccion, 
            //                              :telefono, :telefono2, :email, :cedula, :clave, :es_miembro, :ruta_imagen_usuario, :id_comuna, :es_administrador)";

            //        command.Parameters.Add("nombre", usuario.nombre);
            //        command.Parameters.Add("apellido_paterno", usuario.apellido_paterno);
            //        command.Parameters.Add("fecha_nacimiento", usuario.fecha_nacimiento);
            //        command.Parameters.Add("direccion", usuario.direccion);
            //        command.Parameters.Add("telefono", usuario.telefono);
            //        command.Parameters.Add("telefono2", usuario.telefono2 ?? (object)DBNull.Value);
            //        command.Parameters.Add("email", usuario.email);
            //        command.Parameters.Add("cedula", usuario.cedula);
            //        command.Parameters.Add("clave", usuario.clave);
            //        command.Parameters.Add("es_miembro", usuario.es_miembro);
            //        command.Parameters.Add("ruta_imagen_usuario", usuario.ruta_imagen_usuario ?? (object)DBNull.Value);
            //        command.Parameters.Add("id_comuna", usuario.id_comuna);
            //        command.Parameters.Add("es_administrador", usuario.es_administrador);

            //        command.ExecuteNonQuery();
            //    }
            //}

            using (var connection = connectionManager.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "pkg_usuarios.sp_registrar_usuario";

                        // Parámetros de entrada
                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.nombre;
                        command.Parameters.Add("p_apellido_paterno", OracleDbType.Varchar2).Value = usuario.apellido_paterno;
                        command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usuario.email;
                        command.Parameters.Add("p_clave", OracleDbType.Varchar2).Value = usuario.clave;
                        command.Parameters.Add("p_telefono", OracleDbType.Varchar2).Value = usuario.telefono ?? (object)DBNull.Value;
                        command.Parameters.Add("p_cedula", OracleDbType.Varchar2).Value = usuario.cedula ?? (object)DBNull.Value;
                        command.Parameters.Add("p_fecha_nacimiento", OracleDbType.Date).Value = usuario.fecha_nacimiento != DateTime.MinValue ? (object)usuario.fecha_nacimiento : DBNull.Value;
                        command.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = usuario.direccion ?? (object)DBNull.Value;
                        command.Parameters.Add("p_id_comuna", OracleDbType.Int32).Value = usuario.id_comuna > 0 ? (object)usuario.id_comuna : DBNull.Value;
                        command.Parameters.Add("p_telefono_2", OracleDbType.Varchar2).Value = usuario.telefono_2 ?? (object)DBNull.Value;
                        command.Parameters.Add("p_ruta_imagen_usuario", OracleDbType.Varchar2).Value = usuario.ruta_imagen_usuario ?? (object)DBNull.Value; // Nuevo parámetro

                        // Parámetros de salida
                        OracleParameter p_resultado = new OracleParameter("p_resultado", OracleDbType.Int32);
                        p_resultado.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(p_resultado);

                        OracleParameter p_mensaje = new OracleParameter("p_mensaje", OracleDbType.Varchar2, 500);
                        p_mensaje.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(p_mensaje);

                        command.ExecuteNonQuery();

                        int resultado;
                        if (p_resultado.Value == DBNull.Value)
                        {
                            resultado = 0;
                        }
                        else
                        {
                            try
                            {
                                resultado = Convert.ToInt32(p_resultado.Value);
                            }
                            catch (InvalidCastException)
                            {
                                // Si hay un error de conversión, intenta con OracleDecimal
                                OracleDecimal oracleDecimal = (OracleDecimal)p_resultado.Value;
                                resultado = oracleDecimal.ToInt32();
                            }
                        }
                        if (resultado <= 0)
                        {
                            throw new Exception($"Error al registrar usuario: {p_mensaje.Value}");
                        }

                        usuario.id_usuario = resultado; // El ID generado se devuelve en p_resultado
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error de Oracle: {ex.Message}, Código: {ex.Number}");
                    throw;
                }
            }

        }

        //public void Modificar(Usuario usuario)
        //{
        //    using (var connection = connectionManager.GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new OracleCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = @"UPDATE Usuarios SET nombre = :nombre, apellido_paterno = :apellido_paterno, 
        //                                  fecha_nacimiento = :fecha_nacimiento, direccion = :direccion, telefono = :telefono, 
        //                                  telefono2 = :telefono2, email = :email, cedula = :cedula, es_miembro = :es_miembro, 
        //                                  ruta_imagen_usuario = :ruta_imagen_usuario, id_comuna = :id_comuna, es_administrador = :es_administrador 
        //                                  WHERE id_usuario = :id_usuario";

        //            command.Parameters.Add("id_usuario", usuario.id_usuario);
        //            command.Parameters.Add("nombre", usuario.nombre);
        //            command.Parameters.Add("apellido_paterno", usuario.apellido_paterno);
        //            command.Parameters.Add("fecha_nacimiento", usuario.fecha_nacimiento);
        //            command.Parameters.Add("direccion", usuario.direccion);
        //            command.Parameters.Add("telefono", usuario.telefono);
        //            command.Parameters.Add("telefono_2", usuario.telefono_2 ?? (object)DBNull.Value);
        //            command.Parameters.Add("email", usuario.email);
        //            command.Parameters.Add("cedula", usuario.cedula);
        //            command.Parameters.Add("es_miembro", usuario.es_miembro);
        //            command.Parameters.Add("ruta_imagen_usuario", usuario.ruta_imagen_usuario ?? (object)DBNull.Value);
        //            command.Parameters.Add("id_comuna", usuario.id_comuna);
        //            command.Parameters.Add("es_administrador", usuario.es_administrador);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        public void Modificar(Usuario usuario)
        {
            using (var connection = connectionManager.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "pkg_usuarios.sp_actualizar_perfil";

                        // Parámetros de entrada
                        command.Parameters.Add("p_id_usuario", OracleDbType.Int32).Value = usuario.id_usuario;
                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usuario.nombre;
                        command.Parameters.Add("p_apellido_paterno", OracleDbType.Varchar2).Value = usuario.apellido_paterno;
                        command.Parameters.Add("p_telefono", OracleDbType.Varchar2).Value = usuario.telefono ?? (object)DBNull.Value;
                        command.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = usuario.direccion ?? (object)DBNull.Value;
                        command.Parameters.Add("p_id_comuna", OracleDbType.Int32).Value = usuario.id_comuna > 0 ? (object)usuario.id_comuna : DBNull.Value;
                        command.Parameters.Add("p_telefono_2", OracleDbType.Varchar2).Value = usuario.telefono_2 ?? (object)DBNull.Value;
                        command.Parameters.Add("p_ruta_imagen_usuario", OracleDbType.Varchar2).Value = usuario.ruta_imagen_usuario ?? (object)DBNull.Value;

                        // Parámetros de salida
                        OracleParameter p_resultado = new OracleParameter("p_resultado", OracleDbType.Int32);
                        p_resultado.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(p_resultado);

                        OracleParameter p_mensaje = new OracleParameter("p_mensaje", OracleDbType.Varchar2, 500);
                        p_mensaje.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(p_mensaje);

                        command.ExecuteNonQuery();

                        int resultado = Convert.ToInt32(p_resultado.Value);
                        if (resultado <= 0)
                        {
                            throw new Exception($"Error al actualizar perfil: {p_mensaje.Value}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al modificar usuario: {ex.Message}");
                    throw;
                }
            }
        }

        public void CambiarPassword(int idUsuario, string nuevoPassword)
        {
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Usuarios SET clave = :clave WHERE id_usuario = :id_usuario";

                    command.Parameters.Add("id_usuario", idUsuario);
                    command.Parameters.Add("clave", nuevoPassword);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idUsuario)
        {
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Usuarios WHERE id_usuario = :id_usuario";

                    command.Parameters.Add("id_usuario", idUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            Usuario usuario = null;
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios WHERE id_usuario = :id_usuario";
                    command.Parameters.Add("id_usuario", idUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = MapToUsuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        public Usuario BuscarPorEmail(string email)
        {
            Usuario usuario = null;
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios WHERE email = :email";
                    command.Parameters.Add("email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = MapToUsuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        public Usuario Login(string email, string clave)
        {
            Usuario usuario = null;
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios WHERE email = :email AND clave = :clave";

                    command.Parameters.Add("email", email);
                    command.Parameters.Add("clave", clave);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = MapToUsuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (var connection = connectionManager.GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = MapToUsuario(reader);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        private Usuario MapToUsuario(OracleDataReader reader)
        {
            try
            {
                return new Usuario
                {
                    id_usuario = Convert.ToInt32(reader["ID_USUARIO"]),
                    nombre = reader["NOMBRE"].ToString(),
                    apellido_paterno = reader["APELLIDO_PATERNO"].ToString(),
                    fecha_nacimiento = reader["FECHA_NACIMIENTO"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_NACIMIENTO"]) : DateTime.MinValue,
                    direccion = reader["DIRECCION"] != DBNull.Value ? reader["DIRECCION"].ToString() : null,
                    telefono = reader["TELEFONO"] != DBNull.Value ? reader["TELEFONO"].ToString() : null,
                    telefono_2 = reader["TELEFONO_2"] != DBNull.Value ? reader["TELEFONO_2"].ToString() : null, // Corregido: TELEFONO_2 en lugar de telefono2
                    email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                    cedula = reader["CEDULA"] != DBNull.Value ? reader["CEDULA"].ToString() : null,
                    clave = reader["CLAVE"].ToString(),
                    es_miembro = reader["ES_MIEMBRO"].ToString(),
                    es_administrador = reader["ES_ADMINISTRADOR"].ToString(),
                    id_comuna = reader["ID_COMUNA"] != DBNull.Value ? Convert.ToInt32(reader["ID_COMUNA"]) : 0,
                    ruta_imagen_usuario = reader["ruta_imagen_usuario"] != DBNull.Value ? reader["ruta_imagen_usuario"].ToString() : null
                };
            }
            catch (IndexOutOfRangeException ex)
            {
                // Depuración: imprimir los nombres de las columnas disponibles
                Console.WriteLine("Columnas disponibles en el resultado:");
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine($"{i}: {reader.GetName(i)}");
                }
                throw new Exception($"Error al mapear usuario: {ex.Message}", ex);
            }
        }
    }
}
