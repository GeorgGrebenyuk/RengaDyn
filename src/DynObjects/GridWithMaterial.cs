using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynObjects
{
    /// <summary>
    /// Представляет класс Renga.IGridWithMaterial
    /// </summary>
    public class GridWithMaterial
    {
        private Renga.IGridWithMaterial gr_mat;
        /// <summary>
        /// Инициализация Renga.IGridWithMaterial от объекта
        /// </summary>
        /// <param name="GridWithMaterial_obj"></param>
        public GridWithMaterial (object GridWithMaterial_obj)
        {
            this.gr_mat = GridWithMaterial_obj as Renga.IGridWithMaterial;
        }
        /// <summary>
        /// Получение IGrid
        /// </summary>
        /// <returns></returns>
        public object IGrid()
        {
            return this.gr_mat.Grid;
        }
        /// <summary>
        /// Получение материала свойственного IGrid
        /// </summary>
        /// <returns></returns>
        public object IGridMaterial()
        {
            return this.gr_mat.Material;
        }
    }

}
