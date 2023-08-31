using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument.Project
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IDrawingCollection (коллекцией чертежей IDrawings)
    /// </summary>
    public class DrawingCollection
    {
        public Renga.IDrawingCollection _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IDrawingCollection
        /// </summary>
        /// <param name="DrawingCollection_object"></param>
        internal DrawingCollection (object DrawingCollection_object)
        {
            this._i = DrawingCollection_object as Renga.IDrawingCollection;
        }
        /// <summary>
        /// Получение всех чертежей
        /// </summary>
        /// <returns></returns>
        public List<Drawing> Drawings()
        {
            List<Drawing> os = new List<Drawing>();
            for (int i = 0; i < this._i.Count; i++)
            {
                os.Add(new Drawing(this._i.Get(i)));
            }
            return os;
        }
    }
    
}
