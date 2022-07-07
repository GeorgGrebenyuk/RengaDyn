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
    public class Transform3D
    {
        public Renga.ITransform3D tr3d;
        public Transform3D()
        {
            
        }
    }
}
