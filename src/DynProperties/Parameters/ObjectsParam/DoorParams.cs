using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynObjects;

namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Расширенные инструменты работы с дверьми
    /// </summary>
    public class DoorParams
    {
        public Renga.IDoorParams _i;
        internal DoorParams (object DoorParams_object)
        {
            this._i = DoorParams_object as Renga.IDoorParams;
        }
        /// <summary>
        /// Приведение объекта модели (двери) к данному классу
        /// </summary>
        /// <param name="ModelObject_door"></param>
        public DoorParams (DynRenga.DynObjects.ModelObject ModelObject_door)
        {
            this._i = ModelObject_door._i as Renga.IDoorParams;
        }
        public dg.Point Position => dg.Point.ByCoordinates(this._i.Position.X, this._i.Position.Y, this._i.Position.Z);
        public double Width => this._i.Width;
        public double Height => this._i.Height;
        public double VerticalOffset => this._i.VerticalOffset;

        /// <summary>
        /// Возвращает идентификаторы объектов модели, связанные с дверью
        /// </summary>
        /// <returns></returns>
        public int[] GetAffectedObjectIds() => this._i.GetAffectedObjectIds().Cast<int>().ToArray();
        /// <summary>
        /// Возвращает проецию двери на плоскости
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Curve2D CalculateProjection() => new DynGeometry.Curve2D(this._i.CalculateProjection());
    }
}
