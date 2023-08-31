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
    public class GuidCollection
    {
        public Renga.IGuidCollection _i;
        /// <summary>
        /// Инициация интерфейса
        /// </summary>
        /// <param name="GuidCollection_obj"></param>
        internal GuidCollection(object GuidCollection_obj)
        {
            this._i = GuidCollection_obj as Renga.IGuidCollection;
        }
        /// <summary>
        /// Количество вложенных элементов
        /// </summary>
        /// <returns></returns>
        public int Count => this._i.Count;
        /// <summary>
        /// Получение списка идентификаторов в форме Guid
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetGuids()
        {
            List<Guid> guids = new List<Guid>();
            for (int i =0; i< this._i.Count; i++)
            {
                guids.Add(_i.Get(i));
            }
            return guids;
        }
    }
}
