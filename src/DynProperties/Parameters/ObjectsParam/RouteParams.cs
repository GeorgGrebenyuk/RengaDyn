using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Parameters.ObjectsParam.Route
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IRouteParams
    /// </summary>
    public class RouteParams
    {
        public Renga.IRouteParams _i;
        /// <summary>
        /// Инициализация класса из объекта модели Route
        /// </summary>
        /// <param name="ModelObject_Route"></param>
        internal RouteParams(object ModelObject_Route)
        {
            this._i = ModelObject_Route as Renga.IRouteParams;
        }
        //properties
        /// <summary>
        /// Получение идентификатора объекта модели, расположенном на начале трассы
        /// </summary>
        /// <returns></returns>
        public int SourceModelObjectId => this._i.SourceModelObjectId; 
        /// <summary>
        /// Получение идентификатора объекта модели, расположенном на конце трассы
        /// </summary>
        /// <returns></returns>
        public int TargetModelObjectId => this._i.TargetModelObjectId; 
        /// <summary>
        /// Получение идентификатора стиля трассы
        /// </summary>
        /// <returns></returns>
        public int SystemStyleId => this._i.SystemStyleId; 

        //functions
        /// <summary>
        /// Получение числа точек трассировки трассы
        /// </summary>
        /// <returns></returns>
        public int GetJointCount => this._i.GetJointCount(); 
        /// <summary>
        /// Получение числа присоединенных объектов (аксессуаров, фитингов) к трассе
        /// </summary>
        /// <returns></returns>
        public int GetObjectOnRouteCount => this._i.GetObjectOnRouteCount(); 
        /// <summary>
        /// Получение оси трассы как объекта Renga.ICurve3D
        /// </summary>
        /// <returns></returns>
        public DynGeometry.Curve3D GetContour => new DynGeometry.Curve3D(this._i.GetContour()); 
        /// <summary>
        /// Получение списка структур Renga.RouteJointParams,
        /// информация о геометрическом положении точек трассировки
        /// </summary>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(false)]
        public List<object> GetJointsParams()
        {
            List<object> joints = new List<object>();
            for (int i = 0; i < this._i.GetJointCount(); i++)
            {
                joints.Add(this._i.GetJointParams(i));
            }
            return joints;
        }
        /// <summary>
        /// Получение списка интерфейсов Renga.IObjectOnRoutePlacement,
        /// информация о геометрическом положении точек трассировки
        /// </summary>
        /// <returns></returns>
        public List<ObjectOnRoutePlacement> GetObjectsOnRoutePlacement()
        {
            List<ObjectOnRoutePlacement> joints = new List<ObjectOnRoutePlacement>();
            for (int i = 0; i < this._i.GetObjectOnRouteCount(); i++)
            {
                joints.Add(new ObjectOnRoutePlacement(this._i.GetObjectOnRoutePlacement(i)));
            }
            return joints;
        }
    }
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
