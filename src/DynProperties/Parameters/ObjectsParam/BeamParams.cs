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

namespace DynRenga.DynProperties.Parameters.ObjectsParam.Beam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IBeamParams (расширенные свойства Балки)
    /// </summary>
    public class BeamParams
    {
        public Renga.IBeamParams _i;
        /// <summary>
        /// Инициация класса из объекта модели Renga.IModelObject
        /// </summary>
        /// <param name="ModelObject_Beam"></param>
        internal BeamParams(object ModelObject_Beam)
        {
            this._i = ModelObject_Beam  as Renga.IBeamParams;
        }
        /// <summary>
        /// Приведение объекта модели (балки) к данному классу
        /// </summary>
        /// <param name="ModelObject_beam"></param>
        public BeamParams(DynRenga.DynObjects.ModelObject ModelObject_beam)
        {
            this._i = ModelObject_beam._i as Renga.IBeamParams;
        }
        /// <summary>
        /// Получение базовой линии балки как объекта геометрии Curve3D (см. класс в DynGeometry)
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Curve3D GetBaseline => new DynGeometry.Curve3D(this._i.GetBaseline());
        /// <summary>
        /// Получение расположения профиля балки (объект Placement2D)
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Placement2D GetProfilePlacement => new DynGeometry.Placement2D(this._i.GetProfilePlacement());
        /// <summary>
        /// Получение трехмерного расположения профиля балки (объект Placement3D) 
        /// по заданному параметру кривой
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DynGeometry.Placement3D GetProfilePlacementOnBaseline(double param)
        {
            return new DynGeometry.Placement3D(this._i.GetProfilePlacementOnBaseline(param));
        }
        //properties
        /// <summary>
        /// Получение целочисленного идентификатора стиля балки
        /// </summary>
        /// <returns></returns>
        public int StyleId => this._i.StyleId;
        /// <summary>
        /// Получение значения вертикального смещения балки
        /// </summary>
        /// <returns></returns>
        public double VerticalOffset => this._i.VerticalOffset;

    }
    
}
