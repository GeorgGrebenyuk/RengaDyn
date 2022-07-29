using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynProperties.Parameters.ObjectsParam.Beam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IBeamParams (расширенные свойства Балки)
    /// </summary>
    public class BeamParams
    {
        public Renga.IBeamParams beam_params;
        /// <summary>
        /// Инициация класса из объекта модели Renga.IModelObject
        /// </summary>
        /// <param name="ModelObject_Beam"></param>
        public BeamParams(object ModelObject_Beam)
        {
            this.beam_params = ModelObject_Beam  as Renga.IBeamParams;
        }
        /// <summary>
        /// Получение базовой линии балки как объекта геометрии Curve3D (см. класс в DynGeometry)
        /// </summary>
        /// <returns></returns>
        public object GetBaseline()
        {
            return this.beam_params.GetBaseline();
        }
        /// <summary>
        /// Получение расположения профиля балки (объект Placement2D)
        /// </summary>
        /// <returns></returns>
        public object GetProfilePlacement()
        {
            return this.beam_params.GetProfilePlacement();
        }
        /// <summary>
        /// Получение трехмерного расположения профиля балки (объект Placement3D) 
        /// по заданному параметру кривой
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public object GetProfilePlacementOnBaseline(double param)
        {
            return this.beam_params.GetProfilePlacementOnBaseline(param);
        }
        //properties
        /// <summary>
        /// Получение целочисленного идентификатора стиля балки
        /// </summary>
        /// <returns></returns>
        public int StyleId()
        {
            return this.beam_params.StyleId;
        }
        /// <summary>
        /// Получение значения вертикального смещения балки
        /// </summary>
        /// <returns></returns>
        public double VerticalOffset()
        {
            return this.beam_params.VerticalOffset;
        }

    }
    
}
