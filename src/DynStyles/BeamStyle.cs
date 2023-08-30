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
    /// Класс для работы с интерфейсом Renga.IBeamStyle
    /// </summary>
    public class BeamStyle
    {
        public Renga.IBeamStyle _i;
        /// <summary>
        /// Инициализация интерфейса Renga.IBeamStyle из com-объекта
        /// </summary>
        /// <param name="BeamStyle_object"></param>
        internal BeamStyle(object BeamStyle_object)
        {
            this._i = BeamStyle_object as Renga.IBeamStyle;
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
        public object Profile => this._i.Profile;
    }
}
