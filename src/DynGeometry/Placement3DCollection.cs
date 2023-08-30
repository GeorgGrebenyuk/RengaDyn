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
    /// Класс для работы с интерфейсом Renga.IPlacement3DCollection, 
    /// коллекцией отдельных Renga.IPlacement3D
    /// </summary>
    public class Placement3DCollection
    {
        public Renga.IPlacement3DCollection _i;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IPlacement3DCollection
        /// </summary>
        /// <param name="Placement3DCollection_object"></param>
        internal Placement3DCollection (object Placement3DCollection_object)
        {
            this._i = Placement3DCollection_object as Renga.IPlacement3DCollection;
        }
        /// <summary>
        /// Получение числа элементов в составе коллекции
        /// </summary>
        /// <returns></returns>
        public int Count => this._i.Count;
        /// <summary>
        /// Получение отдельного интерфейса Renga.IPlacement3D
        /// по его внутреннему идентификатору в этой коллекции
        /// </summary>
        /// <param name="placement3d_index"></param>
        /// <returns></returns>
        public Placement3D Get(int placement3d_index)
        {
            return new Placement3D(this._i.Get(placement3d_index));
        }
        /// <summary>
        /// Получение списка интерфейсов Renga.IPlacement3D
        /// </summary>
        /// <returns></returns>
        public List<Placement3D> GetAll()
        {
            List<Placement3D> objects = new List<Placement3D>();
            for (int i = 0; i < this._i.Count; i++)
            {
                objects.Add(new Placement3D(this._i.Get(i)));
            }
            return objects;
        }
    }
}
