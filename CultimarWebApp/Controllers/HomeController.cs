﻿using CultimarWebApp.Models;
using CultimarWebApp.Models.Filters;
using CultimarWebApp.Utils;
using CultimarWebApp.Utils.DAO;
using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CultimarWebApp.Controllers
{
    public class HomeController : Controller
    {
        Control _control = new Control();
        public ActionResult Index()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                return View();
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult Mantenedores()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoOrigen> parametrosOrigen = _control.ListadoParametrosOrigen();
                ViewBag.ParametrosOrigen = parametrosOrigen;
                IEnumerable<ObjetoDestino> parametrosDestino = _control.ListadoParametrosDestino();
                ViewBag.ParametrosDestino = parametrosDestino;
                IEnumerable<ObjetoEspecies> parametrosEspecies = _control.ListadoParametrosEspecies();
                ViewBag.ParametrosEspecies = parametrosEspecies;
                IEnumerable<ObjetoTipoContenedor> parametrosTipoContenedor = _control.ListadoTipoContenedor();
                ViewBag.ParametrosTipoContenedor = parametrosTipoContenedor;
                IEnumerable<ObjetoTipoIdentificacion> parametrosTipoIdentificacion = _control.ListadoTipoIdentificacion();
                ViewBag.ParametrosTipoIdentificacion = parametrosTipoIdentificacion;
                IEnumerable<ObjetoTipoMortalidad> parametrosTipoMortalidad = _control.ListadoTipoMortalidad();
                ViewBag.ParametrosTipoMortalidad = parametrosTipoMortalidad;
                IEnumerable<ObjetoTipoSistema> parametrosTipoSistema = _control.ListadoTipoSistema();
                ViewBag.ParametrosTipoSistema = parametrosTipoSistema;


                return View();
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult FactoresMedicion()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoFactoresMedicion> model = _control.ListaFactoresMedicion();
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult Usuarios()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoUsuarios> model = _control.ListadoUsuarios();
                IEnumerable<SelectListItem> items = _control.ListadoPerfiles().Select(c => new SelectListItem() {
                                                                            Text = c.NombrePerfil,
                                                                            Value = c.IdPerfil.ToString()
                                                }).ToList();
                ViewBag.Perfil = items;


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult Perfiles()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoPerfil> model = _control.ListadoPerfiles();
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }

        }
        public JsonResult GrabaDatos(string rut, string pass, string nombreUsuario, string apellidoUsuario, int idPerfil)
        {
            var usuario = new ObjetoUsuarios();
            var validador = 0;
            if (!string.IsNullOrEmpty(rut))
            {
                if (ValidaRut.DigitoVerificador(rut))
                {
                    usuario.RutUsuario = rut;
                    usuario.Pass = HashMd5.GetMD5(pass);
                    usuario.NombreUsuario = string.Concat(nombreUsuario, " ", apellidoUsuario);
                    usuario.IdPerfil = idPerfil;
                    if (_control.getVerificaUsuario(rut))
                    {
                        validador = 2;
                    }
                    else
                    {
                        if (_control.setGrabaUsuario(usuario))
                        {
                            validador = 1;
                        }
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            else
            {
                validador = 4;
            }
            //, JsonRequestBehavior.AllowGet --- solo si se usa metodo GET
            return (Json(validador));
        }

        public JsonResult AutorizaUsuario(int idUsuario)
        {

            var validador = 0;

            if (_control.setAutorizaUsuario(idUsuario))
            {
                validador = 1;
            }

            return (Json(validador));
        }

        public JsonResult QuitapermisoUsuarios(int idUsuario)
        {

            var validador = 0;

            if (_control.setQuitaPermisoUsuario(idUsuario))
            {
                validador = 1;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroOrigen(int idOrigen, string nombreOrigen)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreOrigen))
                {
                    var origen = new ObjetoOrigen()
                    {
                        IdOrigen = idOrigen,
                        NombreOrigen = nombreOrigen
                    };
                    if (_control.setGrabaParametroOrigen(origen))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }
            
            return (Json(validador));
        }

        public JsonResult GrabaParametrosDestino(int idDestino, string nombreDestino)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreDestino))
                {
                    var destino = new ObjetoDestino()
                    {
                        IdDestino = idDestino,
                        NombreDestino = nombreDestino
                    };
                    if (_control.setGrabaParametroDestino(destino))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroEspecie(int idEspecie, string nombreEspecie)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreEspecie))
                {
                    var especies = new ObjetoEspecies()
                    {
                        IdEspecies = idEspecie,
                        NombreEspecies = nombreEspecie
                    };
                    if (_control.setGrabaParametroEspecies(especies))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
                
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroTipoSistema(int idTipoSistema, string nombreSistema)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreSistema))
                {
                    var tipoSistema = new ObjetoTipoSistema()
                    {
                        IdTipoSistema = idTipoSistema,
                        NombreSistema = nombreSistema
                    };
                    if (_control.setGrabaParametrosTipoSistema(tipoSistema))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));

        }
        public JsonResult GrabaParametroTipoMortalidad(int idTipoMortalidad, string nombreMortalidad)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreMortalidad))
                {
                    var tipoMortalidad = new ObjetoTipoMortalidad()
                    {
                        IdMortalidad = idTipoMortalidad,
                        NombreMortalidad = nombreMortalidad
                    };
                    if (_control.setGrabaParametrosTipoMortalidad(tipoMortalidad))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }
        public JsonResult GrabaParametroTipoIdentificacion(int idTipoIdentificacion, string nombreIdentificacion)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreIdentificacion))
                {
                    var tipoIdentificacion = new ObjetoTipoIdentificacion()
                    {
                        IdIdentificacion = idTipoIdentificacion,
                        NombreIdentificacion = nombreIdentificacion
                    };
                    if (_control.setGrabaParametrosTipoIdentificacion(tipoIdentificacion))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }
        public JsonResult GrabaParametroTipoContenedor(int idContenedor, string nombreContenedor, string tipoContenedor)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreContenedor) && !string.IsNullOrEmpty(tipoContenedor))
                {
                    var PtipoContenedor = new ObjetoTipoContenedor()
                    {
                        IdContenedor = idContenedor,
                        NombreContenedor = nombreContenedor,
                        TipoContenedor = tipoContenedor
                    };
                    if (_control.setGrabaParametrosTipoContenedor(PtipoContenedor))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }



        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }



    }
}