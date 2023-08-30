using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynDocument.Views;

namespace DynRenga.Other
{
    /// <summary>
    /// Класс для работы с камерой в 3D-виде
    /// </summary>
    public class Camera3D
    {
        public Renga.ICamera3D _i;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.ICamera3D. Получать из ModelView.Camera
        /// </summary>
        /// <param name="_i"></param>
        internal Camera3D (object Camera3D_object)
        {
            this._i = Camera3D_object as Renga.ICamera3D;
        }
        /// <summary>
        /// Возвращает Камеру из текущего 3D вида
        /// </summary>
        /// <param name="ModelView"></param>
        public Camera3D (ModelView ModelView)
        {
            this._i = (ModelView._i as Renga.IView3DParams).Camera;
        }
        //properties
        /// <summary>
        /// Точка расположения камеры в 3D
        /// </summary>
        /// <returns></returns>
        public dg.Point Position() => dg.Point.ByCoordinates(
            this._i.Position.X / 1000d,
            this._i.Position.Y / 1000d,
            this._i.Position.Z / 1000d);
        /// <summary>
        /// Точка, куда смотрит камера в 3D
        /// </summary>
        /// <returns></returns>
        public dg.Point FocusPoint() => dg.Point.ByCoordinates(
            this._i.FocusPoint.X / 1000d,
            this._i.FocusPoint.Y / 1000d,
            this._i.FocusPoint.Z / 1000d);
        /// <summary>
        /// Ось Z камеры
        /// </summary>
        /// <returns></returns>
        public dg.Vector UpVector() => dg.Vector.ByCoordinates(
            this._i.UpVector.X / 1000d,
            this._i.UpVector.Y / 1000d,
            this._i.UpVector.Z / 1000d);
        /// <summary>
        /// Горизонтальный угол обзора, в радианах.
        /// </summary>
        public double FovHorizontal => this._i.FovHorizontal;
        /// <summary>
        /// Вертикальный угол обзора, в радианах
        /// </summary>
        public double FovVertical => this._i.FovVertical;

        /// <summary>
        /// Новое позиционирование камеры (угол обзора) для данных параметров
        /// </summary>
        /// <param name="focusPoint"></param>
        /// <param name="position"></param>
        /// <param name="upVector"></param>
        public void LookAt(dg.Point focusPoint, dg.Point position, dg.Vector upVector)
        {
            Renga.FloatPoint3D focus = new FloatPoint3D();
            focus.X = (float)(focusPoint.X * 1000f);
            focus.Y = (float)(focusPoint.Y * 1000f);
            focus.Z = (float)(focusPoint.Z * 1000f);
            Renga.FloatPoint3D pos = new FloatPoint3D();
            pos.X = (float)(position.X * 1000f);
            pos.Y = (float)(position.Y * 1000f);
            pos.Z = (float)(position.Z * 1000f);
            Renga.FloatVector3D vector = new FloatVector3D();
            vector.X = (float)(upVector.X * 1000f);
            vector.Y = (float)(upVector.Y * 1000f);
            vector.Z = (float)(upVector.Z * 1000f);
            this._i.LookAt(focus, pos, vector);
        }
    }
}
