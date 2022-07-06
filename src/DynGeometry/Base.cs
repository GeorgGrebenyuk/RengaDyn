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
    [dr.IsVisibleInDynamoLibrary(false)]
    public class Base
    {
        private Base() { }
        /// <summary>
        /// Точка в 3D с координатами float
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns>Объект - FloatPoint3D</returns>
        public static object SetFloatPoint3D (float X, float Y, float Z)
        {
            Renga.FloatPoint3D point3d = new Renga.FloatPoint3D();
            point3d.X = X; point3d.Y = Y; point3d.Z = Z;
            return point3d;
        }
        /// <summary>
        /// Получение координат из объекта в 2D по типу
        /// </summary>
        /// <param name="com_Base2DGeometry">COM-объект геометрии (двухмерный объект)</param>
        /// <param name="ObjType">0 = FloatPoint2D, 1 = Point2D, 2 = Vector2D</param>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "X", "Y" })]
        public static Dictionary <string, object> GetCoords_2D (object com_Base2DGeometry, int ObjType)
        {
            switch (ObjType)
            {
                case 0:
                    {
                        FloatPoint2D pnt = (FloatPoint2D)com_Base2DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",pnt.X }, {"Y",pnt.Y}
                        };
                    }
                case 1:
                    {
                        Point2D pnt = (Point2D)com_Base2DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",pnt.X }, {"Y",pnt.Y}
                        };
                    }
                case 2:
                    {
                        Vector2D vct = (Vector2D)com_Base2DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",vct.X }, {"Y",vct.Y}
                        };
                    }
            }
            return null;
        }
        /// <summary>
        /// Получение координат из объекта в 3D по типу
        /// </summary>
        /// <param name="com_Base3DGeometry">COM-объект геометрии (трехмерный объект)</param>
        /// <param name="ObjType">0 = FloatPoint3D, 1 = Point3D, 2 = Vector3D, 3 = FloatVector3D</param>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "X", "Y", "Z" })]
        public static Dictionary<string, object> GetCoords_3D(object com_Base3DGeometry, int ObjType)
        {
            switch (ObjType)
            {
                case 0:
                    {
                        FloatPoint3D pnt = (FloatPoint3D)com_Base3DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",pnt.X }, {"Y",pnt.Y},{"Z", pnt.Z }
                        };
                    }
                case 1:
                    {
                        Point3D pnt = (Point3D)com_Base3DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",pnt.X }, {"Y",pnt.Y},{"Z", pnt.Z }
                        };
                    }
                case 2:
                    {
                        Vector3D vct = (Vector3D)com_Base3DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",vct.X }, {"Y",vct.Y},{"Z", vct.Z }
                        };
                    }
                case 3:
                    {
                        FloatVector3D vct = (FloatVector3D)com_Base3DGeometry;
                        return new Dictionary<string, object>
                        {
                            {"X",vct.X }, {"Y",vct.Y},{"Z", vct.Z }
                        };
                    }
            }
            return null;
        }
        /// <summary>
        /// Точка в 3D с координатами double
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns>Объект - Point3D</returns>
        public static object SetPoint3D(double X, double Y, double Z)
        {
            Renga.Point3D point3d = new Renga.Point3D();
            point3d.X = X; point3d.Y = Y; point3d.Z = Z;
            return point3d;
        }
        /// <summary>
        /// Точка в 2D с координатами float
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>Объект - FloatPoint2D</returns>
        public static object SetFloatPoint2D(float X, float Y)
        {
            Renga.FloatPoint2D point2d = new Renga.FloatPoint2D();
            point2d.X = X; point2d.Y = Y;
            return point2d;
        }
        /// <summary>
        /// Точка в 2D с координатами double
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>Объект - Point2D</returns>
        public static object SetPoint2D(double X, double Y)
        {
            Renga.Point2D point2d = new Renga.Point2D();
            point2d.X = X; point2d.Y = Y;
            return point2d;
        }
        /// <summary>
        /// Вектор в 3D с координатами float
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns>Объект - FloatVector3D</returns>
        public static object SetFloatVector3D(float X, float Y, float Z)
        {
            Renga.FloatVector3D Vector3d = new Renga.FloatVector3D();
            Vector3d.X = X; Vector3d.Y = Y; Vector3d.Z = Z;
            return Vector3d;
        }
        /// <summary>
        /// Вектор в 2D с координатами double
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>Объект - Vector2D</returns>
        public static object SetVector2D(double X, double Y)
        {
            Renga.Vector2D Vector2d = new Renga.Vector2D();
            Vector2d.X = X; Vector2d.Y = Y;
            return Vector2d;
        }
        /// <summary>
        /// Вектор в 3D с координатами double
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns>Объект - Vector3D</returns>
        public static object SetVector3D(double X, double Y, double Z)
        {
            Renga.Vector3D Vector3d = new Renga.Vector3D();
            Vector3d.X = X; Vector3d.Y = Y; Vector3d.Z = Z;
            return Vector3d;
        }
        /// <summary>
        /// Треугольник триангуляции с индексами номеров точек - вершин граней
        /// </summary>
        /// <param name="V0">Индекс точки первой грани</param>
        /// <param name="V1">Индекс точки второй грани</param>
        /// <param name="V2">Индекс точки третьей грани</param>
        /// <returns>Объект - Triangle</returns>
        public static object SetTriangle(int V0, int V1, int V2)
        {
            Renga.Triangle Triangle = new Renga.Triangle();
            Triangle.V0 = Convert.ToUInt32(V0);
            Triangle.V1 = Convert.ToUInt32(V1);
            Triangle.V2 = Convert.ToUInt32(V2);
            return Triangle;

        }
        /// <summary>
        /// Получение индексов объекта-Triangle
        /// </summary>
        /// <param name="com_Triangle">COM - объект(Triangle)</param>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "V0", "V1", "V2" })]
        public static Dictionary<string,object> GetTriangleInfo (object com_Triangle)
        {
            Triangle trg = (Triangle)com_Triangle;
            return new Dictionary<string, object>
            {
                {"V0", Convert.ToInt32(trg.V0) },
                {"V1", Convert.ToInt32(trg.V1) },
                {"V2", Convert.ToInt32(trg.V2) }
            };
        }


    }
}
