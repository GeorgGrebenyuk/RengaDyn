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
    /// Класс для работы с интерфейсом Renga.ICurve2D
    /// </summary>
    public class Curve2D
    {
        public Renga.ICurve2D _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.ICurve2D
        /// </summary>
        /// <param name="Curve2D_object"></param>
        internal Curve2D(object Curve2D_object)
        {
            this._i = Curve2D_object as Renga.ICurve2D;
        }
        /// <summary>
        /// Все типы кривой (Curve2DType)
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Curve2DType_Undefined", "Curve2DType_LineSegment" ,
        "Curve2DType_Arc","Curve2DType_PolyCurve"})]
        public static Dictionary<string, object> Curve2DTypes()
        {
            return new Dictionary<string, object>()
            {
                {"Curve2DType_Undefined",Renga.Curve2DType.Curve2DType_Undefined },
                {"Curve2DType_LineSegment",Renga.Curve2DType.Curve2DType_LineSegment  },
                {"Curve2DType_Arc",Renga.Curve2DType.Curve2DType_Arc },
                {"Curve2DType_PolyCurve",Renga.Curve2DType.Curve2DType_PolyCurve }
            };
        }
        /// <summary>
        /// Получение Curve2DType
        /// </summary>
        /// <returns></returns>
        public object Curve2DType => this._i.Curve2DType;
        /// <summary>
        /// Получение Curve2DType как строкого значения (наименования типа)
        /// </summary>
        /// <returns></returns>
        public string GetCurve2DTypeAsString()
        {
            IEnumerable<KeyValuePair<string, object>> data = Curve2DTypes().Where(a => (Renga.Curve2DType)a.Value == this._i.Curve2DType);
            if (data.Any()) return data.First().Key;
            else return null;
        }
        /// <summary>
        /// Получение минимального параметра кривой
        /// </summary>
        /// <returns></returns>
        public double MinParameter => this._i.MinParameter;
        /// <summary>
        /// Получение максимального параметра кривой
        /// </summary>
        /// <returns></returns>
        public double MaxParameter => this._i.MaxParameter;
        //functions
        /// <summary>
        /// Получение начальной точки кривой
        /// </summary>
        /// <returns></returns>
        public dg.Point GetBeginPoint()
        {
            Renga.Point2D p2d = this._i.GetBeginPoint();
            return dg.Point.ByCoordinates(p2d.X / 1000.0, p2d.Y / 1000.0);
        }
        /// <summary>
        /// Получение конечной точки кривой
        /// </summary>
        /// <returns></returns>
        public dg.Point GetEndPoint()
        {
            Renga.Point2D p2d = this._i.GetEndPoint();
            return dg.Point.ByCoordinates(p2d.X / 1000.0, p2d.Y / 1000.0);
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
            Renga.Point2D p2d = this._i.GetPointOn(param);
            return dg.Point.ByCoordinates(p2d.X / 1000.0, p2d.Y / 1000.0);
        }
        /// <summary>
        /// Вычисление длины кривой (в м.)
        /// </summary>
        /// <returns></returns>
        public double GetLength => this._i.GetLength();
        /// <summary>
        /// Получает ограничивающий BoundingBox вокруг кривой
        /// </summary>
        /// <returns></returns>
        public dg.BoundingBox GetGabarit()
        {
            Renga.Point2D p1;
            Renga.Point2D p2;
            this._i.GetGabarit(out p1, out p2);
            return dg.BoundingBox.ByGeometry(new List<dg.Point> {
                dg.Point.ByCoordinates(p1.X/1000.0, p1.Y/1000.0),
                dg.Point.ByCoordinates(p2.X/1000.0, p2.Y/1000.0)});
        }
        /// <summary>
        /// Проверка, замкнутая ли кривая
        /// </summary>
        /// <returns></returns>
        public bool IsClosed => this._i.IsClosed();
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
            return this._i.GetParameterAtDistance(startT, distance, direction);
        }
        /// <summary>
        /// Получение (создание) интерфейса ICurve2D как кривой, обрезанной по данной
        /// </summary>
        /// <param name="T1">Начальная точка обрезки в виде параметра</param>
        /// <param name="T2">Конечная точка обрезки в виде параметра</param>
        /// <param name="sense">Направление обрезаемой (новой) кривой. 1 = направление не менятся;
        /// -1 = направление меняется на противоположное</param>
        /// <returns></returns>
        public Curve2D GetTrimmed(double T1, double T2, int sense)
        {
            return new Curve2D(this._i.GetTrimmed(T1, T2, sense));
        }
        /// <summary>
        /// Вычисляет ближайшую проекцию точки на кривую 
        /// (точка может быть расположена вне кривой)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public double PointProjection(dg.Point point)
        {
            Renga.Point2D p2d = new Point2D();
            p2d.X = point.X;
            p2d.Y = point.Y;
            return this._i.PointProjection(p2d);
        }
        /// <summary>
        /// Получение новой кривой (копии данной), оттрансформированной 
        /// по данному координатному преобразованию
        /// </summary>
        /// <param name="Transfrom">Класс для трехмерного координатного преобразования</param>
        /// <returns></returns>
        public Curve2D GetTransformed(Transform2D Transfrom)
        {
            return new Curve2D(this._i.GetTransformed(Transfrom._i));
        }
        /// <summary>
        /// Получение кривой, смещенной на данный вектор
        /// </summary>
        /// <param name="pOffset">Вектор смещения кривой</param>
        /// <returns></returns>
        public Curve2D GetOffseted(double pOffset)
        {
            return new Curve2D(this._i.GetOffseted(pOffset));
        }
        /// <summary>
        /// Преобразует данную плоскую линию в трехмерную
        /// </summary>
        /// <param name="Placement3D"></param>
        /// <returns></returns>
        public Curve3D CreateCurve3D(Placement3D Placement3D)
        {
            return new Curve3D(this._i.CreateCurve3D(Placement3D._i));
        }
        /// <summary>
        /// Преобразование в dynamo PolyCurve
        /// </summary>
        /// <param name="parts_in_meter">Число сегментов полилинии в 1 метре</param>
        /// <returns></returns>
        public dg.PolyCurve ToDynamoPolyCurve(int parts_in_meter = 2)
        {
            Renga.Point2D curve_start_point = this._i.GetBeginPoint();
            Renga.Point2D curve_end_point = this._i.GetEndPoint();

            List<dg.Point> points = new List<dg.Point>();
            double param_start = this._i.PointProjection(curve_start_point);
            double param_end = this._i.PointProjection(curve_end_point);
            double curve_length = this._i.GetLength() / 1000.0;

            int count_parts = Convert.ToInt32(curve_length * parts_in_meter);
            for (int counter_param = 0; counter_param < count_parts; counter_param++)
            {
                double new_param = param_start + (param_end - param_start) / count_parts * counter_param;
                Renga.Point2D calc_point = this._i.GetPointOn(new_param);
                points.Add(dg.Point.ByCoordinates(calc_point.X / 1000.0, calc_point.Y / 1000.0));
            }
            return dg.PolyCurve.ByPoints(points);

        }
    }
}
