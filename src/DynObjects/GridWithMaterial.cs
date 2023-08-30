using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.Other.Material;

namespace DynRenga.DynObjects
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IGridWithMaterial
    /// </summary>
    public class GridWithMaterial
    {
        private Renga.IGridWithMaterial _i;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IGridWithMaterial
        /// </summary>
        /// <param name="GridWithMaterial_obj"></param>
        internal GridWithMaterial (object GridWithMaterial_obj)
        {
            this._i = GridWithMaterial_obj as Renga.IGridWithMaterial;
        }
        /// <summary>
        /// Получение IGrid
        /// </summary>
        /// <returns></returns>
        public object IGrid => this._i.Grid;
        /// <summary>
        /// Получение материала свойственного IGrid
        /// </summary>
        /// <returns></returns>
        public GridMaterial IGridMaterial => new GridMaterial(this._i.Material);
    }

}
