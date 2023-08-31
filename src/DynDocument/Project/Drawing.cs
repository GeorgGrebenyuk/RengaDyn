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
    /// Класс для работы с чертежом (интерфейсом Renga.IDrawing)
    /// </summary>
    public class Drawing
    {
        public Renga.IDrawing _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IDrawing
        /// </summary>
        /// <param name="Drawing_object"></param>
        internal Drawing(object Drawing_object)
        {
            this._i = Drawing_object as Renga.IDrawing;
        }
        //properties
        /// <summary>
        /// Наименование чертежа
        /// </summary>
        public string Name => this._i.Name;
        /// <summary>
        /// Идентификатор чертежа
        /// </summary>
        public Guid Id => this._i.Id;
        //functions
        /// <summary>
        /// Получение спецификаций на листе (интерфейс Renga.TitleBlockInstance)
        /// </summary>
        /// <returns></returns>
        public List<TitleBlockInstance> GetTitleBlockInstances()
        {
            List<TitleBlockInstance> os = new List<TitleBlockInstance>();
            for (int i = 0; i < this._i.TitleBlockInstanceCount; i++)
            {
                os.Add(new TitleBlockInstance(this._i.GetTitleBlockInstance(i)));
            }
            return os;
        }
    }
}
