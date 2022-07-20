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
        public Renga.IBeamStyle beam_style;
        /// <summary>
        /// Инициализация интерфейса Renga.IBeamStyle из com-объекта
        /// </summary>
        /// <param name="BeamStyle_object"></param>
        public BeamStyle(object BeamStyle_object)
        {
            this.beam_style = BeamStyle_object as Renga.IBeamStyle;
        }
        /// <summary>
        /// Получение целочисленного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.beam_style.Id;
        }
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.beam_style.Name;
        }
        /// <summary>
        /// Получение интерфейса Renga.IProfile
        /// </summary>
        /// <returns></returns>
        public object Profile()
        {
            return this.beam_style.Profile;
        }
    }
}
