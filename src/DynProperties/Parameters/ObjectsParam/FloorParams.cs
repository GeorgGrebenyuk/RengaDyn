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
    /// Расширенные инструменты работы с перекрытиями
    /// </summary>
    public class FloorParams
    {
        public Renga.IFloorParams _i;
        internal FloorParams(object FloorParams_object)
        {
            this._i = FloorParams_object as Renga.IFloorParams;
        }
        /// <summary>
        /// Приведение объекта модели (перекрытия) к данному классу
        /// </summary>
        /// <param name="ModelObject_floor"></param>
        public FloorParams(DynRenga.DynObjects.ModelObject ModelObject_floor)
        {
            this._i = ModelObject_floor._i as Renga.IFloorParams;
        }
        public double Thickness => this._i.Thickness;
        public double VerticalOffset => this._i.VerticalOffset;
        public DynGeometry.Curve2D GetContour() => new DynGeometry.Curve2D(this._i.GetContour());
        public int[] GetDependentObjectIds() => this._i.GetDependentObjectIds().Cast<int>().ToArray();
    }
}
