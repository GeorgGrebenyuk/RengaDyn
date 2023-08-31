using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.Other.Materials
{
    /// <summary>
    /// Класс для работы с материалом, свойственным Renga.IGrid
    /// </summary>
    public class GridMaterial
    {
        public Renga.IGridMaterial _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IGridMaterial
        /// </summary>
        /// <param name="GridMaterial_obj"></param>
        internal GridMaterial(object GridMaterial_obj)
        {
            this._i = GridMaterial_obj as Renga.IGridMaterial;
        }
        public int Id => this._i.Id;
        public Renga_Color Color => new Renga_Color(this._i.Color);
    }
}
