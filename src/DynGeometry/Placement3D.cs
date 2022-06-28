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
    public class Placement3D
    {
        private Placement3D() { }
        /// <summary>
        /// Получение свойств позиции объекта в пространстве - точку начала и векторы-базис
        /// </summary>
        /// <param name="com_IPlacement3D">COM-объект IPlacement3D</param>
        /// <returns>Словарь с параметрами</returns>
        [dr.MultiReturn(new[] { "Origin", "AxisX" , "AxisY", "AxisZ" })]
        public static Dictionary <string,object> GetInfo (object com_IPlacement3D)
        {
            IPlacement3D place = com_IPlacement3D as IPlacement3D;
            return new Dictionary<string, object>
            {
                {"Origin", place.Origin },
                {"AxisX", place.AxisX },
                {"AxisY", place.AxisY },
                {"AxisZ", place.AxisZ }
            };
        }
    }
}
