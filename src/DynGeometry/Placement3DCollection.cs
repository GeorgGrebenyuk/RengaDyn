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
    public class Placement3DCollection : Other.Technical.ICOM_Tools
    {
        public Renga.IPlacement3DCollection coll;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IPlacement3DCollection
        /// </summary>
        /// <param name="Placement3DCollection_object"></param>
        public Placement3DCollection (object Placement3DCollection_object)
        {
            this.coll = Placement3DCollection_object as Renga.IPlacement3DCollection;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.coll == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение числа элементов в составе коллекции
        /// </summary>
        /// <returns></returns>
        public int Count => this.coll.Count;
        /// <summary>
        /// Получение отдельного интерфейса Renga.IPlacement3D
        /// по его внутреннему идентификатору в этой коллекции
        /// </summary>
        /// <param name="placement3d_index"></param>
        /// <returns></returns>
        public object Get(int placement3d_index)
        {
            return this.coll.Get(placement3d_index);
        }
        /// <summary>
        /// Получение списка интерфейсов Renga.IPlacement3D
        /// </summary>
        /// <returns></returns>
        public List<object> GetAll()
        {
            List<object> objects = new List<object>();
            for (int i = 0; i < this.coll.Count; i++)
            {
                objects.Add(this.coll.Get(i));
            }
            return objects;
        }
    }
}
