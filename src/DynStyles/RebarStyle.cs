using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IRebarStyle, стилем арматуры
    /// </summary>
    public class RebarStyle 
    {
        public Renga.IRebarStyle _i;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IRebarStyle
        /// </summary>
        /// <param name="RebarStyle_object"></param>
        internal RebarStyle(object RebarStyle_object)
        {
            this._i = RebarStyle_object as Renga.IRebarStyle;
        }
        /// <summary>
        /// Получение численного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение имени стиля
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение марки арматуры
        /// </summary>
        /// <returns></returns>
        public string GradeName => this._i.GradeName;
        /// <summary>
        /// Получение диаметра рамтуры в милиметрах
        /// </summary>
        /// <returns></returns>
        public double Diameter => this._i.Diameter;
        /// <summary>
        /// Получение численного идентификатора материала арматуры
        /// </summary>
        /// <returns></returns>
        public int MaterialId => this._i.MaterialId;
        /// <summary>
        /// Предел прочности арматуры при растяжении
        /// </summary>
        /// <returns></returns>
        public double GradeTensileStrength => this._i.GradeTensileStrength;
    }
}
