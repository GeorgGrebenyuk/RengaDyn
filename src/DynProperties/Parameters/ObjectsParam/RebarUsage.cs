using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynProperties.Quantities;

namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IRebarUsage 
    /// (использование арматуры в арматурном узле или армируемом объекте)
    /// </summary>
    public class RebarUsage
    {
        public Renga.IRebarUsage _i;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IRebarUsage
        /// </summary>
        /// <param name="RebarUsage_object"></param>
        internal RebarUsage(object RebarUsage_object)
        {
            this._i = RebarUsage_object as Renga.IRebarUsage;
        }
        /// <summary>
        /// Приведение объекта модели (арматуры) к данному классу
        /// </summary>
        /// <param name="ModelObject_RebarUsage"></param>
        public RebarUsage(DynRenga.DynObjects.ModelObject ModelObject_RebarUsage)
        {
            this._i = ModelObject_RebarUsage._i as Renga.IRebarUsage;
        }
        /// <summary>
        /// Получение интерфейса Renga.IQuantityContainer (расчетных свойств)
        /// </summary>
        /// <returns></returns>
        public QuantityContainer GetQuantities() => new QuantityContainer(this._i.GetQuantities());
        /// <summary>
        /// Получение геометрии в виде интерфейса Renga.ICurve3D
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Curve3D GetRebarGeometry => new DynGeometry.Curve3D(this._i.GetRebarGeometry());
        /// <summary>
        /// Получение наборов систем координат арматурных объектов. 
        /// Если армирование проиходит на уровне - то относительно уровня; 
        /// если в составе объекта -- то относительно этого объекта
        /// </summary>
        /// <returns>Интерфейс Renga.IPlacement3DCollection</returns>
        public DynGeometry.Placement3DCollection GetPlacements => new DynGeometry.Placement3DCollection(this._i.GetPlacements());
    }
}
