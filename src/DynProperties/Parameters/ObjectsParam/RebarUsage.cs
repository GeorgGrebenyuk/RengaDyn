﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IRebarUsage 
    /// (использование арматуры в арматурном узле или армируемом объекте)
    /// </summary>
    public class RebarUsage : Other.Technical.ICOM_Tools
    {
        public Renga.IRebarUsage r_usage;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IRebarUsage
        /// </summary>
        /// <param name="RebarUsage_object"></param>
        public RebarUsage(object RebarUsage_object)
        {
            this.r_usage = RebarUsage_object as Renga.IRebarUsage;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.r_usage == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение интерфейса Renga.IQuantityContainer (расчетных свойств)
        /// </summary>
        /// <returns></returns>
        public object GetQuantities => this.r_usage.GetQuantities();
        /// <summary>
        /// Получение геометрии в виде интерфейса Renga.ICurve3D
        /// </summary>
        /// <returns></returns>
        public object GetRebarGeometry => this.r_usage.GetRebarGeometry();
        /// <summary>
        /// Получение наборов систем координат арматурных объектов. 
        /// Если армирование проиходит на уровне - то относительно уровня; 
        /// если в составе объекта -- то относительно этого объекта
        /// </summary>
        /// <returns>Интерфейс Renga.IPlacement3DCollection</returns>
        public object GetPlacements => this.r_usage.GetPlacements();
    }
}
