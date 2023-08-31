using System;
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
    /// Класс для представления отдельного объекта на трассе
    /// </summary>
    public class RouteJointParams
    {
        public Renga.RouteJointParams _i;
        internal RouteJointParams(object RouteJointParams_object)
        {
            this._i = (Renga.RouteJointParams)RouteJointParams_object;
        }
        /// <summary>
        /// Возвращает идентификатор объекта модели - родительской трассы
        /// </summary>
        public int route_Id => this._i.routeId;
        /// <summary>
        /// Возвращает положение объекта на трассе в виде числа [0...1] * Route.Length
        /// </summary>
        public double parameter => this._i.parameter;

    }
}
