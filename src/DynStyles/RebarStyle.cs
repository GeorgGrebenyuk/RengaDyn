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
    public class RebarStyle : Other.Technical.ICOM_Tools
    {
        public Renga.IRebarStyle rebar_style;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IRebarStyle
        /// </summary>
        /// <param name="RebarStyle_object"></param>
        public RebarStyle(object RebarStyle_object)
        {
            this.rebar_style = RebarStyle_object as Renga.IRebarStyle;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.rebar_style == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение численного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.rebar_style.Id;
        }
        /// <summary>
        /// Получение имени стиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.rebar_style.Name;
        }
        /// <summary>
        /// Получение марки арматуры
        /// </summary>
        /// <returns></returns>
        public string GradeName()
        {
            return this.rebar_style.GradeName;
        }
        /// <summary>
        /// Получение диаметра рамтуры в милиметрах
        /// </summary>
        /// <returns></returns>
        public double Diameter()
        {
            return this.rebar_style.Diameter;
        }
        /// <summary>
        /// Получение численного идентификатора материала арматуры
        /// </summary>
        /// <returns></returns>
        public int MaterialId()
        {
            return this.rebar_style.MaterialId;
        }
        /// <summary>
        /// Предел прочности арматуры при растяжении
        /// </summary>
        /// <returns></returns>
        public double GradeTensileStrength()
        {
            return this.rebar_style.GradeTensileStrength;
        }
    }
}
