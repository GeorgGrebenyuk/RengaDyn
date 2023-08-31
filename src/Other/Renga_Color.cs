using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.Other
{
    /// <summary>
    /// Класс длля представления цвета объекта в Renga
    /// </summary>
    public class Renga_Color
    {
        public Renga.Color _i;
        internal Renga_Color(object Renga_Color_object)
        {
            this._i = (Renga.Color)Renga_Color_object;
        }
        /// <summary>
        /// Преобразование в системный цвет
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Color ToColor()
        {
            return System.Drawing.Color.FromArgb(Red, Green, Blue, Alpha);
        }
        public int Red => this._i.Red;
        public int Green => this._i.Green;
        public int Blue => this._i.Blue;
        public int Alpha => this._i.Alpha;
    }
}
