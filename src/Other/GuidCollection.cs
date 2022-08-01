using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.Other
{
    /// <summary>
    /// Класс для работы со списком Guid'ов (Renga.IGuidCollection)
    /// </summary>
    public class GuidCollection : Other.Technical.ICOM_Tools
    {
        private Renga.IGuidCollection collection;
        /// <summary>
        /// Инициация интерфейса
        /// </summary>
        /// <param name="GuidCollection_obj"></param>
        public GuidCollection(object GuidCollection_obj)
        {
            this.collection = GuidCollection_obj as Renga.IGuidCollection;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.collection == null) return false;
            else return true;
        }
        /// <summary>
        /// Количество вложенных элементов
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.collection.Count;
        }
        /// <summary>
        /// Получение списка идентификаторов в форме Guid
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetGuids()
        {
            List<Guid> guids = new List<Guid>();
            for (int i =0; i< this.collection.Count; i++)
            {
                guids.Add(collection.Get(i));
            }
            return guids;
        }
        /// <summary>
        /// Получение списка идентификаторов в строчной форме
        /// </summary>
        /// <returns></returns>
        public List<string> GetGuidsS()
        {
            List<string> guids = new List<string>();
            for (int i = 0; i < this.collection.Count; i++)
            {
                guids.Add(collection.GetS(i));
            }
            return guids;
        }
    }
}
