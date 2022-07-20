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
        public Renga.ITransform3D tr3d;
        public Transform3D(object Transform3D_object)
        {
            this.tr3d = Transform3D_object as Renga.ITransform3D;
        }
    }
}
