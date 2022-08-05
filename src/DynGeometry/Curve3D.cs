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
    /// Класс для работы с интерфейсом Renga.ICurve3D
    /// </summary>
    public class Curve3D : Other.Technical.ICOM_Tools
    {
        public Renga.ICurve3D curve_3d;
        /// <summary>
        /// Инициация класса из интерфейса Renga.ICurve3D
        /// </summary>
        /// <param name="Curve3D_object"></param>
        public Curve3D(object Curve3D_object)
        {
            this.curve_3d = Curve3D_object as Renga.ICurve3D;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.curve_3d == null) return false;
            else return true;
        }
        /// <summary>
        /// Все типы кривой (Curve3DType)
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Curve3DType_Undefined", "Curve3DType_LineSegment" ,
        "Curve3DType_Arc","Curve3DType_PolyCurve"})]
        public static Dictionary<string, object> Curve3DTypes()
        {
            return new Dictionary<string, object>()
            {
                {"Curve3DType_Undefined",Renga.Curve3DType.Curve3DType_Undefined },
                {"Curve3DType_LineSegment",Renga.Curve3DType.Curve3DType_LineSegment  },
                {"Curve3DType_Arc",Renga.Curve3DType.Curve3DType_Arc },
                {"Curve3DType_PolyCurve",Renga.Curve3DType.Curve3DType_PolyCurve }
            };
        }
        /// <summary>
        /// Получение Curve3DType
        /// </summary>
        /// <returns></returns>
        public object Curve3DType => this.curve_3d.Curve3DType;
        /// <summary>
        /// Получение Curve3DType как строкого значения (наименования типа)
        /// </summary>
        /// <returns></returns>
        public string GetCurve3DTypeAsString()
        {
            IEnumerable<KeyValuePair<string, object>> data = Curve3DTypes().Where(a => (Renga.Curve3DType)a.Value == this.curve_3d.Curve3DType);
            if (data.Any()) return data.First().Key;
            else return null;
        }
        /// <summary>
        /// Получение минимального параметра кривой
        /// </summary>
        /// <returns></returns>
        public double MinParameter => this.curve_3d.MinParameter;
        /// <summary>
        /// Получение максимального параметра кривой
        /// </summary>
        /// <returns></returns>
        public double MaxParameter => this.curve_3d.MaxParameter;
        //functions
        /// <summary>
        /// Получение начальной точки кривой
        /// </summary>
        /// <returns></returns>
        public dg.Point GetBeginPoint()
        {
            Renga.Point3D p3d = this.curve_3d.GetBeginPoint();
            return dg.Point.ByCoordinates(p3d.X / 1000.0, p3d.Y / 1000.0, p3d.Z / 1000.0);
        }
        /// <summary>
        /// Получение конечной точки кривой
        /// </summary>
        /// <returns></returns>
        public dg.Point GetEndPoint()
        {
            Renga.Point3D p3d = this.curve_3d.GetEndPoint();
            return dg.Point.ByCoordinates(p3d.X / 1000.0, p3d.Y / 1000.0, p3d.Z / 1000.0);
        }
        /// <summary>
        /// Вычисление точки на кривой по заданному значению параметра.
        /// Если param меньше BeginParameter или больше EndParameter, то
        /// param фиксируется до ближайшего допустимого
        /// </summary>
        /// <param name="param">параметр кривой для расчета точки на кривой</param>
        /// <returns></returns>
        public dg.Point GetPointOn(double param)
        {
            Renga.Point3D p3d = this.curve_3d.GetPointOn(param);
            return dg.Point.ByCoordinates(p3d.X / 1000.0, p3d.Y / 1000.0, p3d.Z / 1000.0);
        }
        /// <summary>
        /// Вычисление длины кривой (в м.)
        /// </summary>
        /// <returns></returns>
        public double GetLength => this.curve_3d.GetLength();
        /// <summary>
        /// Получает ограничивающий BoundingBox вокруг кривой
        /// </summary>
        /// <returns></returns>
        public dg.BoundingBox GetGabarit()
        {
            Renga.Cube bb = this.curve_3d.GetGabarit();
            return dg.BoundingBox.ByGeometry(new List<dg.Point> {
                dg.Point.ByCoordinates(bb.MIN.X/1000.0, bb.MIN.Y/1000.0,bb.MIN.Z/1000.0),
                dg.Point.ByCoordinates(bb.MAX.X/1000.0, bb.MAX.Y/1000.0,bb.MAX.Z/1000.0)});
        }
        /// <summary>
        /// Проверка, замкнутая ли кривая
        /// </summary>
        /// <returns></returns>
        public bool IsClosed => this.curve_3d.IsClosed();
        /// <summary>
        /// Вычисляет точку на кривой по смешению и расстоянию от кривой
        /// </summary>
        /// <param name="startT">Значение параметра, характеризиющее опорную точку</param>
        /// <param name="distance">Величина смещения вдоль кривой</param>
        /// <param name="direction">Направление смещения. Неотрицательное значение означает, 
        /// что смещение выполняется в сторону увеличения параметра; 
        /// в противном случае оно выполняется в сторону уменьшения параметра.</param>
        /// <returns>Велична параметра для результирующей точки. Для получения точки используйте
        /// ноду GetPointOn</returns>
        public double GetParameterAtDistance(double startT, double distance, int direction)
        {
            return this.curve_3d.GetParameterAtDistance(startT, distance, direction);
        }
        /// <summary>
        /// Получение (создание) интерфейса ICurve3D как кривой, обрезанной по данной
        /// </summary>
        /// <param name="T1">Начальная точка обрезки в виде параметра</param>
        /// <param name="T2">Конечная точка обрезки в виде параметра</param>
        /// <param name="sense">Направление обрезаемой (новой) кривой. 1 = направление не менятся;
        /// -1 = направление меняется на противоположное</param>
        /// <returns></returns>
        public object GetTrimmed(double T1, double T2, int sense)
        {
            return this.curve_3d.GetTrimmed(T1, T2, sense);
        }
        /// <summary>
        /// Вычисляет ближайшую проекцию точки на кривую 
        /// (точка может быть расположена вне кривой)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public double PointProjection(dg.Point point)
        {
            Renga.Point3D p3d = new Point3D();
            p3d.X = point.X;
            p3d.Y = point.Y;
            p3d.Z = point.Z;
            return this.curve_3d.PointProjection(ref p3d);
        }
        /// <summary>
        /// Получение новой кривой (копии данной), оттрансформированной 
        /// по данному координатному преобразованию
        /// </summary>
        /// <param name="Transfrom">Класс для трехмерного координатного преобразования</param>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(false)] //непонятно как создавать свой Renga.ITransform
        public object GetTransformed(Transform3D Transfrom)
        {
            return this.curve_3d.GetTransformed(Transfrom.tr3d);
        }
        /// <summary>
        /// Получение кривой, смещенной на данный вектор
        /// </summary>
        /// <param name="pOffset">Вектор смещения кривой</param>
        /// <returns></returns>
        public object GetOffseted(dg.Vector pOffset)
        {
            Renga.Vector3D v3d = new Vector3D();
            v3d.X = pOffset.X;
            v3d.Y = pOffset.Y;
            v3d.Z = pOffset.Z;
            return this.curve_3d.GetOffseted(ref v3d);
        }
        /// <summary>
        /// Преобразование в dynamo PolyCurve
        /// </summary>
        /// <param name="parts_in_meter">Число сегментов полилинии в 1 метре</param>
        /// <returns></returns>
        public dg.PolyCurve ToDynamoPolyCurve(int parts_in_meter = 2)
        {
            Renga.Point3D curve_start_point = this.curve_3d.GetBeginPoint();
            Renga.Point3D curve_end_point = this.curve_3d.GetEndPoint();

            List<dg.Point> points = new List<dg.Point>();
            double param_start = this.curve_3d.PointProjection(ref curve_start_point);
            double param_end = this.curve_3d.PointProjection(ref curve_end_point);
            double curve_length = this.curve_3d.GetLength()/1000.0;

            int count_parts = Convert.ToInt32(curve_length * parts_in_meter);
            for (int counter_param = 0; counter_param < count_parts; counter_param++)
            {
                double new_param = param_start + (param_end - param_start) / count_parts * counter_param;
                Renga.Point3D calc_point = this.curve_3d.GetPointOn(new_param);
                points.Add(dg.Point.ByCoordinates(calc_point.X / 1000.0, calc_point.Y / 1000.0, calc_point.Z / 1000.0));
            }
            return dg.PolyCurve.ByPoints(points);
            
        }
    }
}
