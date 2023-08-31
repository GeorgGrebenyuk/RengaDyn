using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Расширенные инструменты представления проёма
    /// </summary>
    public  class OpeningParams
    {
        public Renga.IOpeningParams _i;
        internal OpeningParams(object OpeningParams_object)
        {
            this._i = OpeningParams_object as Renga.IOpeningParams;
        }
        /// <summary>
        /// Приведение объекта модели (перекрытия) к данному классу
        /// </summary>
        /// <param name="ModelObject_opening"></param>
        public OpeningParams(DynRenga.DynObjects.ModelObject ModelObject_opening)
        {
            this._i = ModelObject_opening._i as Renga.IOpeningParams;
        }
        public double Thickness => this._i.Thickness;
        public double VerticalOffset => this._i.VerticalOffset;
        public DynGeometry.Curve2D GetContour() => new DynGeometry.Curve2D(this._i.GetContour());
        public int[] GetAffectedObjectIds() => this._i.GetAffectedObjectIds().Cast<int>().ToArray();
    }
}
