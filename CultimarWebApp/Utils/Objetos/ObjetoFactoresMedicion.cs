﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoFactoresMedicion
    {
        private int _idFactor;
        private string _nombreFactor;
        private string _parametroFactor;
        private string _frecuenciaFactor;
        private string _temperaturaFactor;
        private string _alimentacionFactor;
        private string _oxigenoFactor;
        private bool _estado;
        
        public int IdFactor { get { return _idFactor; } set { _idFactor = value; }}
        public string NombreFactor { get { return _nombreFactor;} set { _nombreFactor = value; }}
        public string ParametroFactor { get { return _parametroFactor;} set { _parametroFactor = value; }}
        public string FrecuenciaFactor { get { return _frecuenciaFactor;} set { _frecuenciaFactor = value; }}
        public string TemperaturaFactor { get { return _temperaturaFactor;} set { _temperaturaFactor = value; }}
        public string AlimentacionFactor { get { return _alimentacionFactor;} set { _alimentacionFactor = value; }}
        public string OxigenoFactor { get { return _oxigenoFactor;} set { _oxigenoFactor = value; }}
        public bool Estado { get { return _estado;} set { _estado = value; }}
    }
}