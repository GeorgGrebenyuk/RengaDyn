using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Parameters.ObjectsParam.Column
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IColumnParams (расширенные свойства Колонны)
    /// </summary>
    public class ColumnParams
    {
        public Renga.IColumnParams _i;
        /// <summary>
        /// Инициация класса из объекта модели - колонны
        /// </summary>
        /// <param name="ModelObject_column"></param>
        internal ColumnParams(object ModelObject_column)
        {
            this._i = ModelObject_column as Renga.IColumnParams;
        }
        /// <summary>
        /// Приведение объекта модели (колонны) к данному классу
        /// </summary>
        /// <param name="ModelObject_column"></param>
        public ColumnParams(DynRenga.DynObjects.ModelObject ModelObject_column)
        {
            this._i = ModelObject_column._i as Renga.IColumnParams;
        }
        //properties
        /// <summary>
        /// Получение высоты колонны
        /// </summary>
        /// <returns></returns>
        public double Height => this._i.Height;
        /// <summary>
        /// Получение идентификатора (int) стиля колонны
        /// </summary>
        /// <returns></returns>
        public int StyleId => this._i.StyleId;
        /// <summary>
        /// Получение точки в 3D-места установкиколонны
        /// </summary>
        /// <returns></returns>
        public dg.Point Position()
        {
            Renga.Point3D pos = this._i.Position;
            return dg.Point.ByCoordinates(pos.X, pos.Y, pos.Z);
        }
        /// <summary>
        /// Получение вертикального смещения объекта.
        /// </summary>
        /// <returns></returns>
        public double VerticalOffset => this._i.VerticalOffset;
        //functions
        /// <summary>
        /// Получение локальной системы координат для проиля колонны
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Placement2D GetProfilePlacement => new DynGeometry.Placement2D(this._i.GetProfilePlacement());
    }
    
}
