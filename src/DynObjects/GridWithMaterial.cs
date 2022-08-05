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
    /// Класс для работы с интерфейсом Renga.IGridWithMaterial
    /// </summary>
    public class GridWithMaterial : Other.Technical.ICOM_Tools
    {
        private Renga.IGridWithMaterial gr_mat;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IGridWithMaterial
        /// </summary>
        /// <param name="GridWithMaterial_obj"></param>
        public GridWithMaterial (object GridWithMaterial_obj)
        {
            this.gr_mat = GridWithMaterial_obj as Renga.IGridWithMaterial;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.gr_mat == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение IGrid
        /// </summary>
        /// <returns></returns>
        public object IGrid => this.gr_mat.Grid;
        /// <summary>
        /// Получение материала свойственного IGrid
        /// </summary>
        /// <returns></returns>
        public object IGridMaterial => this.gr_mat.Material;
    }

}
