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
    /// Класс для работы с группой Region2D
    /// </summary>
    public class Region2DCollection
    {
        public Renga.IRegion2DCollection _i;
        internal Region2DCollection(object Region2DCollection_object)
        {
            this._i = Region2DCollection_object as Renga.IRegion2DCollection;
        }
        public Region2D Get(int index) => new Region2D(this._i.Get(index));
        public int Count => this._i.Count;
        public List<Region2D> GetRegions()
        {
            List<Region2D> regs = new List<Region2D>();
            for (int i = 0; i < this._i.Count; i++)
            {
                regs.Add(new Region2D(this._i.Get(i)));
            }
            return regs;
        }
    }
}
