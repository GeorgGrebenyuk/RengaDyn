using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynGeometry;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IColumnStyle, одиночным стилем колонны
    /// </summary>
    public class ColumnStyle
    {
        public Renga.IColumnStyle _i;
        /// <summary>
        /// Инициализация класса через интерфейс Renga.IBeamStyle
        /// </summary>
        /// <param name="ColumnStyle_object"></param>
        internal ColumnStyle(object ColumnStyle_object)
        {
            this._i = ColumnStyle_object as Renga.IColumnStyle;
        }
        /// <summary>
        /// Получение целочисленного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение интерфейса Renga.IProfile
        /// </summary>
        /// <returns></returns>
        public Profile Profile => new Profile(this._i.Profile);
    }
}
