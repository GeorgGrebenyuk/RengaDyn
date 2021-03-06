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
        public Renga.IPlacement2D pl2d;
        public Placement2D(object Placement2D_object)
        {
            this.pl2d = Placement2D_object as Renga.IPlacement2D;
        }
        //properties
        /// <summary>
        /// Получение точки начала СК
        /// </summary>
        /// <returns></returns>
        public dg.Point Origin()
        {
            Renga.Point2D p = this.pl2d.Origin;
            return dg.Point.ByCoordinates(p.X / 1000.0, p.Y / 1000.0,0);
        }
        /// <summary>
        /// Получение вектора X
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisX()
        {
            Renga.Vector2D vX = this.pl2d.AxisX;
            return dg.Vector.ByCoordinates(vX.X / 1000.0, vX.Y / 1000.0, 0);
        }
        /// <summary>
        /// Получение вектора Y
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisY()
        {
            Renga.Vector2D vY = this.pl2d.AxisY;
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
        public bool IsOrthogonal()
        {
            return this.pl2d.IsOrthogonal();
        }
        /// <summary>
        /// Проверка, является ли нормальной данная СК
        /// </summary>
        /// <returns></returns>
        public bool IsNormal()
        {
            return this.pl2d.IsNormal();
        }
        /// <summary>
        /// Проверка, является ли данная СК левосторонней
        /// </summary>
        /// <returns></returns>
        public bool IsLeft()
        {
            return this.pl2d.IsLeft();
        }
        /// <summary>
        /// Получение Renga.ITransform3D из текущей СК в глобальную
        /// </summary>
        /// <returns></returns>
        public object GetTransformFrom()
        {
            return this.pl2d.GetTransformFrom();
        }
        /// <summary>
        /// Получение Renga.ITransform3D из глобальной СК в текущую
        /// </summary>
        /// <returns></returns>
        public object GetTransformInto()
        {
            return this.pl2d.GetTransformInto();
        }
        /// <summary>
        /// Получение копии текущей СК
        /// </summary>
        /// <returns></returns>
        public object GetCopy()
        {
            return this.pl2d.GetCopy();
        }

    }
}
