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
    /// Класс для работы с интерфейсом Renga.IRegion2D 
    /// (область в двумерном пространстве)
    /// Область представляет собой связанный набор двумерных точек, границы которых описываются контурами.
    /// Контуры области представлены PolyCurve, которые замкнуты и не самопересекаются (но могут быть соприкасающимися). 
    /// В произвольной области имеется только один внешний контур 
    /// (положительный обход внешнего контура выполняется против часовой стрелки) 
    /// и несколько внутренних контуров(положительный обход внутреннего контура выполняется по часовой стрелке), 
    /// которые полностью расположены внутри внешнего контура(или могут соприкасаться с ним).
    /// </summary>
    public class Region2D
    {
        public Renga.IRegion2D reg2d;
        /// <summary>
        /// Инициализация интерфейса Renga.IRegion2D из com-объекта
        /// </summary>
        /// <param name="Region2D_object"></param>
        internal Region2D(object Region2D_object)
        {
            this.reg2d = Region2D_object as Renga.IRegion2D;
        }
        //functions
        /// <summary>
        /// Получение внешнего контура профиля как интерфейса Renga.ICurve2D
        /// </summary>
        /// <returns></returns>
        public object GetOuterContour => this.reg2d.GetOuterContour();
        /// <summary>
        /// Получение набора контуров профиля как списка интерфейсов Renga.ICurve2D
        /// </summary>
        /// <returns></returns>
        public List<object> GetContours()
        {
            List<object> cs = new List<object>();
            for (int i = 0; i < this.reg2d.GetContourCount(); i++)
            {
                cs.Add(this.reg2d.GetContour(i));
            }
            return cs;
        }
    }
}
