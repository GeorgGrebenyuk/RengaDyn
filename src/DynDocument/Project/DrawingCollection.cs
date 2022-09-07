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
        public Renga.IDrawingCollection collection;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IDrawingCollection
        /// </summary>
        /// <param name="DrawingCollection_object"></param>
        public DrawingCollection (object DrawingCollection_object)
        {
            this.collection = DrawingCollection_object as Renga.IDrawingCollection;
        }
        /// <summary>
        /// Получение всех чертежей
        /// </summary>
        /// <returns></returns>
        public List<object> Drawings()
        {
            List<object> os = new List<object>();
            for (int i = 0; i < this.collection.Count; i++)
            {
                os.Add(this.collection.Get(i));
            }
            return os;
        }
    }
    /// <summary>
    /// Класс для работы с чертежом (интерфейсом Renga.IDrawing)
    /// </summary>
    public class Drawing
    {
        public Renga.IDrawing drawing;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IDrawing
        /// </summary>
        /// <param name="Drawing_object"></param>
        public Drawing(object Drawing_object)
        {
            this.drawing = Drawing_object as Renga.IDrawing;
        }
        //properties
        /// <summary>
        /// Наименование чертежа
        /// </summary>
        public string Name => this.drawing.Name;
        /// <summary>
        /// Идентификатор чертежа
        /// </summary>
        public Guid Id => this.drawing.Id;
        //functions
        /// <summary>
        /// Получение спецификаций на листе (интерфейс Renga.TitleBlockInstance)
        /// </summary>
        /// <returns></returns>
        public List<object> GetTitleBlockInstances ()
        {
            List<object> os = new List<object>();
            for (int i = 0; i < this.drawing.TitleBlockInstanceCount; i++)
            {
                os.Add(this.drawing.GetTitleBlockInstance(i));
            }
            return os;
        }
    }
}
