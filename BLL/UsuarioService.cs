﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly string connectionString;

        public UsuarioService()
        {
            connectionString = "Data Source=localhost;Initial Catalog=IglesiaDB;Integrated Security=True";
            var connectionManager = new ConnectionManager();
            usuarioRepository = new UsuarioRepository(connectionManager);
        }

        public string Guardar(Usuario usuario)
        {
            try
            {
                // Validar que el email no exista
                var usuarioExistente = usuarioRepository.BuscarPorEmail(usuario.email);
                if (usuarioExistente != null)
                {
                    return $"Error al guardar: El email {usuario.email} ya está registrado";
                }

                usuarioRepository.Guardar(usuario);
                return $"Usuario {usuario.nombre} {usuario.apellido_paterno} guardado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al guardar: {ex.Message}";
            }
        }

        public string Modificar(Usuario usuario)
        {
            try
            {
                // Validar que el usuario exista
                var usuarioExistente = usuarioRepository.BuscarPorId(usuario.id_usuario);
                if (usuarioExistente == null)
                {
                    return $"Error al modificar: El usuario con ID {usuario.id_usuario} no existe";
                }

                // Validar que el email no esté en uso por otro usuario
                var usuarioPorEmail = usuarioRepository.BuscarPorEmail(usuario.email);
                if (usuarioPorEmail != null && usuarioPorEmail.id_usuario != usuario.id_usuario)
                {
                    return $"Error al modificar: El email {usuario.email} ya está en uso por otro usuario";
                }

                usuarioRepository.Modificar(usuario);
                return $"Usuario {usuario.nombre} {usuario.apellido_paterno} modificado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al modificar: {ex.Message}";
            }
        }

        public string CambiarPassword(int idUsuario, string passwordActual, string nuevoPassword)
        {
            try
            {
                // Validar que el usuario exista
                var usuario = usuarioRepository.BuscarPorId(idUsuario);
                if (usuario == null)
                {
                    return $"Error al cambiar contraseña: El usuario con ID {idUsuario} no existe";
                }

                // Validar que la contraseña actual sea correcta
                if (usuario.clave != passwordActual)
                {
                    return "Error al cambiar contraseña: La contraseña actual es incorrecta";
                }

                usuarioRepository.CambiarPassword(idUsuario, nuevoPassword);
                return "Contraseña cambiada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al cambiar contraseña: {ex.Message}";
            }
        }

        public string Eliminar(int idUsuario)
        {
            try
            {
                // Validar que el usuario exista
                var usuario = usuarioRepository.BuscarPorId(idUsuario);
                if (usuario == null)
                {
                    return $"Error al eliminar: El usuario con ID {idUsuario} no existe";
                }

                usuarioRepository.Eliminar(idUsuario);
                return $"Usuario {usuario.nombre} {usuario.apellido_paterno} eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return usuarioRepository.BuscarPorId(idUsuario);
        }

        public Usuario BuscarPorEmail(string email)
        {
            return usuarioRepository.BuscarPorEmail(email);
        }

        public Usuario Login(string email, string clave)
        {
            return usuarioRepository.Login(email, clave);
        }

        public List<Usuario> Consultar()
        {
            return usuarioRepository.ConsultarTodos();
        }

        public List<UsuarioDTO> ConsultarDTO()
        {
            var usuarios = usuarioRepository.ConsultarTodos();
            var usuariosDTO = new List<UsuarioDTO>();

            foreach (var usuario in usuarios)
            {
                usuariosDTO.Add(new UsuarioDTO
                {
                    id_usuario = usuario.id_usuario,
                    NombreCompleto = usuario.NombreCompleto,
                    email = usuario.email,
                    es_miembro = usuario.es_miembro == "S" ? "Sí" : "No"
                });
            }

            return usuariosDTO;
        }
    }
}
