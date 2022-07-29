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
        public Renga.IColumnParams column_params;
        /// <summary>
        /// Инициация класса из объекта модели - колонны
        /// </summary>
        /// <param name="ModelObject_column"></param>
        public ColumnParams(object ModelObject_column)
        {
            this.column_params = ModelObject_column as Renga.IColumnParams;
        }
        //properties
        /// <summary>
        /// Получение высоты колонны
        /// </summary>
        /// <returns></returns>
        public double Height()
        {
            return this.column_params.Height;
        }
        /// <summary>
        /// Получение идентификатора (int) стиля колонны
        /// </summary>
        /// <returns></returns>
        public int StyleId()
        {
            return this.column_params.StyleId;
        }
        /// <summary>
        /// Получение точки в 3D-места установкиколонны
        /// </summary>
        /// <returns></returns>
        public dg.Point Position()
        {
            Renga.Point3D pos = this.column_params.Position;
            return dg.Point.ByCoordinates(pos.X, pos.Y, pos.Z);
        }
        /// <summary>
        /// Получение вертикального смещения объекта.
        /// </summary>
        /// <returns></returns>
        public double VerticalOffset()
        {
            return this.column_params.VerticalOffset;
        }
        //functions
        /// <summary>
        /// Получение локальной системы координат для проиля колонны
        /// </summary>
        /// <returns></returns>
        public object GetProfilePlacement()
        {
            return this.column_params.GetProfilePlacement();
        }
    }
    
}
