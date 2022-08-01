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
    /// Класс для работы с интерфейсом Renga.IPlacement3D - локальной системой координат 
    /// в трехмерном пространстве
    /// </summary>
    public class Placement3D : Other.Technical.ICOM_Tools
    {
        public Renga.IPlacement3D pl3d;
        public Placement3D (object Placement3D_object)
        {
            this.pl3d = Placement3D_object as Renga.IPlacement3D;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.pl3d == null) return false;
            else return true;
        }
        //properties
        /// <summary>
        /// Получение точки начала СК
        /// </summary>
        /// <returns></returns>
        public dg.Point Origin()
        {
            Renga.Point3D p = this.pl3d.Origin;
            return dg.Point.ByCoordinates(p.X / 1000.0, p.Y / 1000.0, p.Z / 1000.0);
        }
        /// <summary>
        /// Получение вектора X
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisX()
        {
            Renga.Vector3D vX = this.pl3d.AxisX;
            return dg.Vector.ByCoordinates(vX.X / 1000.0, vX.Y / 1000.0, vX.Z / 1000.0);
        }
        /// <summary>
        /// Получение вектора Y
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisY()
        {
            Renga.Vector3D vY = this.pl3d.AxisY;
            return dg.Vector.ByCoordinates(vY.X / 1000.0, vY.Y / 1000.0, vY.Z / 1000.0);
        }
        /// <summary>
        /// Получение вектора Z
        /// </summary>
        /// <returns></returns>
        public dg.Vector AxisZ()
        {
            Renga.Vector3D vZ = this.pl3d.AxisZ;
            return dg.Vector.ByCoordinates(vZ.X / 1000.0, vZ.Y / 1000.0, vZ.Z / 1000.0);
        }
        //functions
        /// <summary>
        /// Преобразование в представление Dynamo CoordinateSystem
        /// </summary>
        /// <returns></returns>
        public dg.CoordinateSystem ToDynamoCoordinateSystem()
        {
            return dg.CoordinateSystem.ByOriginVectors(this.Origin(), this.AxisX(), this.AxisY(), this.AxisZ());
        }
        /// <summary>
        /// Проверка, является ли ортогональной данная СК
        /// </summary>
        /// <returns></returns>
        public bool IsOrthogonal()
        {
            return this.pl3d.IsOrthogonal();
        }
        /// <summary>
        /// Проверка, является ли нормальной данная СК
        /// </summary>
        /// <returns></returns>
        public bool IsNormal()
        {
            return this.pl3d.IsNormal();
        }
        /// <summary>
        /// Проверка, является ли данная СК левосторонней
        /// </summary>
        /// <returns></returns>
        public bool IsLeft()
        {
            return this.pl3d.IsLeft();
        }
        /// <summary>
        /// Получение Renga.ITransform3D из текущей СК в глобальную
        /// </summary>
        /// <returns></returns>
        public object GetTransformFrom()
        {
            return this.pl3d.GetTransformFrom();
        }
        /// <summary>
        /// Получение Renga.ITransform3D из глобальной СК в текущую
        /// </summary>
        /// <returns></returns>
        public object GetTransformInto()
        {
            return this.pl3d.GetTransformInto();
        }
        /// <summary>
        /// Перемещение на указанный вектор
        /// </summary>
        /// <param name="vector_to_moving"></param>
        public void Move (dg.Vector vector_to_moving)
        {
            Renga.Vector3D vec;
            vec.X = vector_to_moving.X * 1000.0;
            vec.Y = vector_to_moving.Y * 1000.0;
            vec.Z = vector_to_moving.Z * 1000.0;
            this.pl3d.Move(vec);
        }
        /// <summary>
        /// Поворот вокруг указанной оси (вектора)
        /// </summary>
        /// <param name="vector_axis_rotate"></param>
        public void Rotate(dg.Vector vector_axis_rotate)
        {
            Renga.Vector3D vec;
            vec.X = vector_axis_rotate.X * 1000.0;
            vec.Y = vector_axis_rotate.Y * 1000.0;
            vec.Z = vector_axis_rotate.Z * 1000.0;
            this.pl3d.Move(vec);
        }
        /// <summary>
        /// Применение трансформации через интерфейс Renga.ITransform3D
        /// </summary>
        /// <param name="transform"></param>
        public void Transform (DynGeometry.Transform3D transform)
        {
            this.pl3d.Transform(transform.tr3d);
        }
        /// <summary>
        /// Получение копии текущей СК
        /// </summary>
        /// <returns></returns>
        public object GetCopy()
        {
            return this.pl3d.GetCopy();
        }

    }
}
