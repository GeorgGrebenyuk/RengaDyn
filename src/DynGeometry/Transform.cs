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
    /// Класс для работы с интерфейсом Renga.ITransform3D, матрицу трансформации геометрии объектов 4х4 
    /// </summary>
    public class Transform3D
    {
        public Renga.ITransform3D _i;
        internal Transform3D(object Transform3D_object)
        {
            this._i = Transform3D_object as Renga.ITransform3D;
        }
    }
    /// <summary>
    /// Класс для работы с интерфейсом Renga.ITransform2D
    /// </summary>
    public class Transform2D
    {
        public Renga.ITransform2D _i;
        internal Transform2D(object Transform2D_object)
        {
            this._i = Transform2D_object as Renga.ITransform2D;
        }
    }
}
