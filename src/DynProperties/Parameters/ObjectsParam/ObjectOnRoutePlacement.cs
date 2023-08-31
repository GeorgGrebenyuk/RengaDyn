using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IObjectOnRoutePlacement
    /// </summary>
    public class ObjectOnRoutePlacement
    {
        public Renga.IObjectOnRoutePlacement _i;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IObjectOnRoutePlacement
        /// </summary>
        /// <param name="ObjectOnRoutePlacement_object"></param>
        internal ObjectOnRoutePlacement(object ObjectOnRoutePlacement_object)
        {
            this._i = ObjectOnRoutePlacement_object as Renga.IObjectOnRoutePlacement;
        }
        /// <summary>
        ///  Получение идентификатора объекта
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;

        /// <summary>
        /// Получение параметра кривой базовой линии
        /// </summary>
        /// <returns></returns>
        public double Parameter => this._i.parameter;
    }
}
