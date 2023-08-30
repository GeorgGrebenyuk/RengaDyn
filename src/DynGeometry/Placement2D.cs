using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynGeometry
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IPlacement2D - локальной системой координат 
    /// в двухмерном пространстве
    /// </summary>
    public class Placement2D
    {
        public Renga.IPlacement2D _i;
        internal Placement2D(object Placement2D_object)
        {
            this._i = Placement2D_object as Renga.IPlacement2D;
        }
        //properties
        /// <summary>
        /// Получение точки начала СК
        /// </summary>
        /// <returns></returns>
        public dg.Point Origin()
        {
            Renga.Point2D p = this._i.Origin;
            return dg.Point.ByCoordinates(p.X / 1000.0, p.Y / 1000.0,0);
        }
        /// <summary>
        /// Получение вектора X
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisX()
        {
            Renga.Vector2D vX = this._i.AxisX;
            return dg.Vector.ByCoordinates(vX.X / 1000.0, vX.Y / 1000.0, 0);
        }
        /// <summary>
        /// Получение вектора Y
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisY()
        {
            Renga.Vector2D vY = this._i.AxisY;
            return dg.Vector.ByCoordinates(vY.X / 1000.0, vY.Y / 1000.0, 0);
        }
        //functions
        /// <summary>
        /// Преобразование в представление Dynamo CoordinateSystem
        /// </summary>
        /// <returns></returns>
        public dg.CoordinateSystem ToDynamoCoordinateSystem()
        {
            return dg.CoordinateSystem.ByOriginVectors(this.Origin(), this.AxisX(), this.AxisY());
        }
        /// <summary>
        /// Проверка, является ли ортогональной данная СК
        /// </summary>
        /// <returns></returns>
        public bool IsOrthogonal => this._i.IsOrthogonal();
        /// <summary>
        /// Проверка, является ли нормальной данная СК
        /// </summary>
        /// <returns></returns>
        public bool IsNormal => this._i.IsNormal();
        /// <summary>
        /// Проверка, является ли данная СК левосторонней
        /// </summary>
        /// <returns></returns>
        public bool IsLeft => this._i.IsLeft();
        /// <summary>
        /// Получение Renga.ITransform3D из текущей СК в глобальную
        /// </summary>
        /// <returns></returns>
        public Transform2D GetTransformFrom => new Transform2D(this._i.GetTransformFrom());
        /// <summary>
        /// Получение Renga.ITransform3D из глобальной СК в текущую
        /// </summary>
        /// <returns></returns>
        public Transform2D GetTransformInto => new Transform2D(this._i.GetTransformInto());
        /// <summary>
        /// Получение копии текущей СК
        /// </summary>
        /// <returns></returns>
        public Placement2D GetCopy => new Placement2D( this._i.GetCopy());

    }
}
