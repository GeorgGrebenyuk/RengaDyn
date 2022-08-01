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
    public class RouteParams : Other.Technical.ICOM_Tools
    {
        public Renga.IRouteParams route_params;
        /// <summary>
        /// Инициализация класса из объекта модели Route
        /// </summary>
        /// <param name="ModelObject_Route"></param>
        public RouteParams(object ModelObject_Route)
        {
            this.route_params = ModelObject_Route as Renga.IRouteParams;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.route_params == null) return false;
            else return true;
        }
        //properties
        /// <summary>
        /// Получение идентификатора объекта модели, расположенном на начале трассы
        /// </summary>
        /// <returns></returns>
        public int SourceModelObjectId() 
        {
            return this.route_params.SourceModelObjectId; 
        }
        /// <summary>
        /// Получение идентификатора объекта модели, расположенном на конце трассы
        /// </summary>
        /// <returns></returns>
        public int TargetModelObjectId() 
        { 
            return this.route_params.TargetModelObjectId; 
        }
        /// <summary>
        /// Получение идентификатора стиля трассы
        /// </summary>
        /// <returns></returns>
        public int SystemStyleId() 
        { 
            return this.route_params.SystemStyleId; 
        }

        //functions
        /// <summary>
        /// Получение числа точек трассировки трассы
        /// </summary>
        /// <returns></returns>
        public int GetJointCount() 
        { 
            return this.route_params.GetJointCount(); 
        }
        /// <summary>
        /// Получение числа присоединенных объектов (аксессуаров, фитингов) к трассе
        /// </summary>
        /// <returns></returns>
        public int GetObjectOnRouteCount() 
        { 
            return this.route_params.GetObjectOnRouteCount(); 
        }
        /// <summary>
        /// Получение оси трассы как объекта Renga.ICurve3D
        /// </summary>
        /// <returns></returns>
        public object GetContour() 
        { 
            return this.route_params.GetContour(); 
        }
        /// <summary>
        /// Получение списка структур Renga.RouteJointParams,
        /// информация о геометрическом положении точек трассировки
        /// </summary>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(false)]
        public List<object> GetJointsParams()
        {
            List<object> joints = new List<object>();
            for (int i = 0; i < this.route_params.GetJointCount(); i++)
            {
                joints.Add(this.route_params.GetJointParams(i));
            }
            return joints;
        }
        /// <summary>
        /// Получение списка интерфейсов Renga.IObjectOnRoutePlacement,
        /// информация о геометрическом положении точек трассировки
        /// </summary>
        /// <returns></returns>
        public List<object> GetObjectsOnRoutePlacement()
        {
            List<object> joints = new List<object>();
            for (int i = 0; i < this.route_params.GetObjectOnRouteCount(); i++)
            {
                joints.Add(this.route_params.GetObjectOnRoutePlacement(i));
            }
            return joints;
        }
    }
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IObjectOnRoutePlacement
    /// </summary>
    public class ObjectOnRoutePlacement
    {
        public Renga.IObjectOnRoutePlacement obj;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IObjectOnRoutePlacement
        /// </summary>
        /// <param name="ObjectOnRoutePlacement_object"></param>
        public ObjectOnRoutePlacement(object ObjectOnRoutePlacement_object)
        {
            this.obj = ObjectOnRoutePlacement_object as Renga.IObjectOnRoutePlacement;
        }
        /// <summary>
        ///  Получение идентификатора объекта
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.obj.Id;
        }
        /// <summary>
        /// Получение параметра кривой базовой линии
        /// </summary>
        /// <returns></returns>
        public double Parameter()
        {
            return this.obj.parameter;
        }
    }

    

}
