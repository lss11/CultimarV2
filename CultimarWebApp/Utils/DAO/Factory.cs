﻿using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    /// <summary>
    /// Clase interna de Factory para conexion a la BD.
    /// </summary>
    internal class Factory
    {
        /// <summary>
        /// Metodo Menu
        /// Segun el ID del usuario, carga el menu para la aplicacion, siendo Abogado o Receptor.
        /// </summary>
        /// <param name="idUsuario">ID del usuario Logueado</param>
        /// <returns>Lista de Menú a ser consumida por Helper Menú</returns>
        public List<ObjetoMenu> MenuUsuario(int idUsuario)
        {
            var listadoMenu = new List<ObjetoMenu>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_ListaMenu", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idTipoRegistro", idUsuario}
                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMenu();
                    validador = data.Rows[i].Field<object>("id_Menu");
                    resultadoListado.IdMenu = validador != null ? data.Rows[i].Field<int>("id_Menu") : -1;

                    validador = data.Rows[i].Field<object>("Clase");
                    resultadoListado.Clase = validador != null ? data.Rows[i].Field<string>("Clase") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("PieMenu");
                    resultadoListado.PieMenu = validador != null ? data.Rows[i].Field<string>("PieMenu") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Titulo");
                    resultadoListado.Titulo = validador != null ? data.Rows[i].Field<string>("Titulo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Action");
                    resultadoListado.Accion = validador != null ? data.Rows[i].Field<string>("Action") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Controler");
                    resultadoListado.Controller = validador != null ? data.Rows[i].Field<string>("Controler") : "NO ASIGNADO";


                    listadoMenu.Add(resultadoListado);
                }
            }
            return listadoMenu;
        }

        /// <summary>
        /// Datos del usuario del sistema
        /// </summary>
        /// <param name="rut">RUT del usuario</param>
        /// <param name="pass">Password de usuario debe ir con HashMD5</param>
        /// <returns>Listado con los datos, para obtener el perfil y el nombre</returns>
        public List<ObjetoLogin> LoginUsuario(string rut, string pass)
        {
            var DatosLogin = new List<ObjetoLogin>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LOGIN", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"rut", rut},
                                                                                                {"pass", pass }
                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoLogin();
                    validador = data.Rows[i].Field<object>("id_Perfil");
                    resultadoListado.IdPerfil = validador != null ? data.Rows[i].Field<int>("id_Perfil") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.Nombre = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("RUT");
                    resultadoListado.Rut = validador != null ? data.Rows[i].Field<string>("RUT") : "NO ASIGNADO";

                    DatosLogin.Add(resultadoListado);
                }
            }
            return DatosLogin;
        }

        /// <summary>
        /// Listado de Perfiles del sistema
        /// </summary>
        /// <returns>lista con los perfiles del sistema.</returns>
        public List<ObjetoPerfil> ListadoPerfiles()
        {
            var ListadoPerfil = new List<ObjetoPerfil>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOPERFILES", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoPerfil();
                    validador = data.Rows[i].Field<object>("id_Perfil");
                    resultadoListado.IdPerfil = validador != null ? data.Rows[i].Field<int>("id_Perfil") : -1;

                    validador = data.Rows[i].Field<object>("NombrePerfil");
                    resultadoListado.NombrePerfil = validador != null ? data.Rows[i].Field<string>("NombrePerfil") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Descripcion");
                    resultadoListado.DescripcionPerfil = validador != null ? data.Rows[i].Field<string>("Descripcion") : "NO ASIGNADO";

                    ListadoPerfil.Add(resultadoListado);
                }
            }
            return ListadoPerfil;
        }

        public List<ObjetoOrigen> ListadoParametrosOrigen()
        {
            var ListadoOrigen = new List<ObjetoOrigen>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOORIGEN", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoOrigen();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdOrigen = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreOrigen = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoOrigen.Add(resultadoListado);
                }
            }
            return ListadoOrigen;
        }
        public List<ObjetoDestino> ListadoParametrosDestino()
        {
            var ListadoDestino = new List<ObjetoDestino>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADODESTINO", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoDestino();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdDestino = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Destino");
                    resultadoListado.NombreDestino = validador != null ? data.Rows[i].Field<string>("Destino") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoDestino.Add(resultadoListado);
                }
            }
            return ListadoDestino;
        }

        public List<ObjetoEspecies> ListadoParametrosEspecies()
        {
            var ListadoEspecies = new List<ObjetoEspecies>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOESPECIES", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoEspecies();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdEspecies = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreEspecies = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoEspecies.Add(resultadoListado);
                }
            }
            return ListadoEspecies;
        }

        public List<ObjetoTipoContenedor> ListadoTipoContenedor()
        {
            var ListadoTipoContenedor = new List<ObjetoTipoContenedor>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_TIPOCONTENEDOR", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoContenedor();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdContenedor = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Tipo");
                    resultadoListado.TipoContenedor = validador != null ? data.Rows[i].Field<string>("Tipo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoTipoContenedor.Add(resultadoListado);
                }
            }
            return ListadoTipoContenedor;
        }

        public List<ObjetoTipoIdentificacion> ListadoTipoIdentificacion()
        {
            var ListadoTipoIdentificacion = new List<ObjetoTipoIdentificacion>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOTIPOIDENTIFICACION", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoIdentificacion();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdIdentificacion = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreIdentificacion = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoTipoIdentificacion.Add(resultadoListado);
                }
            }
            return ListadoTipoIdentificacion;
        }

        public List<ObjetoTipoMortalidad> ListadoTipoMortalidad()
        {
            var ListadoTipoMortalidad = new List<ObjetoTipoMortalidad>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOTIPOMORTALIDAD", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoMortalidad();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreMortalidad = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoTipoMortalidad.Add(resultadoListado);
                }
            }
            return ListadoTipoMortalidad;
        }
        public List<ObjetoTipoSistema> ListadoTipoSistema()
        {
            var ListadoTipoSistema = new List<ObjetoTipoSistema>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOTIPOSISTEMA", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoSistema();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdTipoSistema = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreSistema = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoTipoSistema.Add(resultadoListado);
                }
            }
            return ListadoTipoSistema;
        }
        /// <summary>
        /// Listado de Factores de medicion
        /// </summary>
        /// <returns>lista con los factores de medicion</returns>
        public List<ObjetoFactoresMedicion> ListadoFactoresMedicion()
        {
            var ListadoUsuarios = new List<ObjetoFactoresMedicion>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTAFACTORESMEDICION", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoFactoresMedicion();
                    validador = data.Rows[i].Field<object>("idFactor");
                    resultadoListado.IdFactor = validador != null ? data.Rows[i].Field<int>("idFactor") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreFactor = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Parametro");
                    resultadoListado.ParametroFactor = validador != null ? data.Rows[i].Field<string>("Parametro") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Frecuencia");
                    resultadoListado.FrecuenciaFactor = validador != null ? data.Rows[i].Field<string>("Frecuencia") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Temperatura");
                    resultadoListado.TemperaturaFactor = validador != null ? data.Rows[i].Field<string>("Temperatura") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Alimentacion");
                    resultadoListado.AlimentacionFactor = validador != null ? data.Rows[i].Field<string>("Alimentacion") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Oxigeno");
                    resultadoListado.OxigenoFactor = validador != null ? data.Rows[i].Field<string>("Oxigeno") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    ListadoUsuarios.Add(resultadoListado);
                }
            }
            return ListadoUsuarios;
        }
        /// <summary>
        /// Listado de Usuarios
        /// </summary>
        /// <returns>listado de usuarios del sistema</returns>
        public List<ObjetoUsuarios> ListadoUsuarios()
        {
            var ListadoUsuarios = new List<ObjetoUsuarios>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOUSUARIOS", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoUsuarios();
                    validador = data.Rows[i].Field<object>("id_Usuario");
                    resultadoListado.IdUsuario = validador != null ? data.Rows[i].Field<int>("id_Usuario") : -1;

                    validador = data.Rows[i].Field<object>("RUT");
                    resultadoListado.RutUsuario = validador != null ? data.Rows[i].Field<string>("RUT") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreUsuario = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("NombrePerfil");
                    resultadoListado.NombrePerfilUsuario = validador != null ? data.Rows[i].Field<string>("NombrePerfil") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("AutorizaModificacion");
                    resultadoListado.PuedeModificar = validador != null ? data.Rows[i].Field<bool>("AutorizaModificacion") : false;

                    validador = data.Rows[i].Field<object>("Activo");
                    resultadoListado.Activo = validador != null ? data.Rows[i].Field<bool>("Activo") : false;

                    validador = data.Rows[i].Field<object>("id_Perfil");
                    resultadoListado.IdPerfil = validador != null ? data.Rows[i].Field<int>("id_Perfil") : -1;


                    ListadoUsuarios.Add(resultadoListado);
                }
            }
            return ListadoUsuarios;
        }
        /// <summary>
        /// Metodo para grabar un nuevo usuario
        /// </summary>
        /// <param name="usuario">Objeto del tipo usuario con todos los datos</param>
        /// <returns>valor mayor a 1 si el grabado resulta OK, 0 si hay error. </returns>
        public bool setGrabaUsuario(ObjetoUsuarios usuario)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAUSUARIO", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"rutUsuario", usuario.RutUsuario},
                                                                                                {"pass", usuario.Pass },
                                                                                                {"nombreUsuario", usuario.NombreUsuario },
                                                                                                {"idPerfil", usuario.IdPerfil }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo de grabacion de parametros de Origen
        /// </summary>
        /// <param name="origen">Objeto tipo Origen con todos los datos</param>
        /// <returns>True o False según resultado en la BD</returns>
        public bool setGrabaParametroOrigen(ObjetoOrigen origen)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAORIGEN", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idOrigen", origen.IdOrigen},
                                                                                                {"nombreOrigen", origen.NombreOrigen }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo de grabacion de parametros de Destino
        /// </summary>
        /// <param name="destino">Objeto tipo destino con todos los datos</param>
        /// <returns>True o False, segun resultado en la BD.</returns>
        public bool setGrabaParametroDestino(ObjetoDestino destino)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABADESTINO", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idDestino", destino.IdDestino},
                                                                                                {"nombreDestino", destino.NombreDestino }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Metodo de grabacion de parametro Especies
        /// </summary>
        /// <param name="especies">Objeto tipo especies con todos los parametros</param>
        /// <returns>true o false segun el caso</returns>
        public bool setGrabaParametrosEspecies(ObjetoEspecies especies)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAESPECIES", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idEspecies", especies.IdEspecies},
                                                                                                {"nombreEspecies", especies.NombreEspecies }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Metodo de grabacion para parametro de tipoContenedor
        /// </summary>
        /// <param name="tipoContenedor">objeto tipo contenedor con todos los parametros</param>
        /// <returns>true o false segun el caso</returns>
        public bool setGrabaParametrosTipoContenedor(ObjetoTipoContenedor tipoContenedor)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABATIPOCONTENEDOR", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idTipoContenedor", tipoContenedor.IdContenedor },
                                                                                                {"nombreContenedor",tipoContenedor.NombreContenedor },
                                                                                                {"tipoContenedor",tipoContenedor.TipoContenedor }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// metodo de grabacion de parametros de Tipo de Identificacion
        /// </summary>
        /// <param name="tipoIdentificacion">objeto tipo identificacion con todos los parametros</param>
        /// <returns>true o false segun corresponda</returns>
        public bool setGrabaParametrosTipoIdentificacion(ObjetoTipoIdentificacion tipoIdentificacion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABATIPOIDENTIFICACION", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idTipoIdentificacion", tipoIdentificacion.IdIdentificacion },
                                                                                                {"nombreIdentificacion",tipoIdentificacion.NombreIdentificacion }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Metodo de grabacion de parametros de tipo de Mortalidad
        /// </summary>
        /// <param name="tipoMortalidad">Objeto tipo mortalidad con todos los parametros</param>
        /// <returns>true o false segun corresponda</returns>
        public bool setGrabaParametrosTipoMortalidad(ObjetoTipoMortalidad tipoMortalidad)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABATIPOMORTALIDAD", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idTipoMortalidad", tipoMortalidad.IdMortalidad },
                                                                                                {"nombreMortalidad",tipoMortalidad.NombreMortalidad }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Metodo de grabacion de parametros de tipo de sistema
        /// </summary>
        /// <param name="tipoSistema">Objeto tipo Sistema con todos los parametros</param>
        /// <returns>true o false segun corresponda</returns>
        public bool setGrabaParametrosTipoSistema(ObjetoTipoSistema tipoSistema)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABATIPOSISTEMA", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idTipoSistema", tipoSistema.IdTipoSistema },
                                                                                                {"nombreSistema", tipoSistema.NombreSistema }
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que consume SP para autorizar usuario
        /// </summary>
        /// <param name="idUsuario">Id Usuario al que le dan la autorización</param>
        /// <returns>True o false</returns>
        public bool setAutorizaUsuario(int idUsuario)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_AUTORIZAUSUARIO", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idUsuario", idUsuario}
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }
        /// <summary>
        /// Metodo para Quitar permisos de modificacion a usuarios
        /// </summary>
        /// <param name="idUsuario">Id del usuario al que quitara el permiso</param>
        /// <returns>true o false segun corresponda</returns>
        public bool setQuitaPermisoUsuario(int idUsuario)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_QUITAPERMISOUSUARIO", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"idUsuario", idUsuario}
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo para verificar usuario y evitar el ingreso de un usuario duplicado por RUT
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <returns>1 si existe, 0 si no</returns>
        public bool getVerificaUsuario(string rutUsuario)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_VALIDAUSUARIOINGRESO", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"RUT", rutUsuario}
                                                                                            });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }

    }
}