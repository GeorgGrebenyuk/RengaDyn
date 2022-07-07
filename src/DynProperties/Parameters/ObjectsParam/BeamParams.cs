using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynProperties.Parameters.ObjectsParam
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IBeamParams
    /// </summary>
    public class BeamParams
    {
        public Renga.IBeamParams beam_params;
        /// <summary>
        /// Инициация интерфейса Renga.IBeamParams из объекта модели Renga.IModelObject
        /// </summary>
        /// <param name="ModelObject_Beam"></param>
        public BeamParams(object ModelObject_Beam)
        {
            this.beam_params = ModelObject_Beam  as Renga.IBeamParams;
        }
        /// <summary>
        /// Получение базовой линии балки как объекта геометрии Curve3D (см. класс в DynGeometry)
        /// </summary>
        /// <returns></returns>
        public object GetBaseline()
        {
            return this.beam_params.GetBaseline();
        }
        /// <summary>
        /// Получение расположения профиля балки (объект Placement2D)
        /// </summary>
        /// <returns></returns>
        public object GetProfilePlacement()
        {
            return this.beam_params.GetProfilePlacement();
        }
        /// <summary>
        /// Получение трехмерного расположения профиля балки (объект Placement3D) 
        /// по заданному параметру кривой
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public object GetProfilePlacementOnBaseline(double param)
        {
            return this.beam_params.GetProfilePlacementOnBaseline(param);
        }
        //properties
        /// <summary>
        /// Получение целочисленного идентификатора стиля балки
        /// </summary>
        /// <returns></returns>
        public int StyleId()
        {
            return this.beam_params.StyleId;
        }
        /// <summary>
        /// Получение значения вертикального смещения балки
        /// </summary>
        /// <returns></returns>
        public double VerticalOffset()
        {
            return this.beam_params.VerticalOffset;
        }

    }
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IBeamStyle
    /// </summary>
    public class BeamStyle
    {
        public Renga.IBeamStyle beam_style;
        /// <summary>
        /// Инициализация интерфейса Renga.IBeamStyle из com-объекта
        /// </summary>
        /// <param name="BeamStyle_object"></param>
        public BeamStyle(object BeamStyle_object)
        {
            this.beam_style = BeamStyle_object as Renga.IBeamStyle;
        }
        /// <summary>
        /// Получение интерфейса Renga.IBeamStyle из проекта (класса Project) по идентификатору стиля (из IBeamParams)
        /// </summary>
        /// <param name="renga_project"></param>
        /// <param name="BeamStyle_id"></param>
        public BeamStyle(DynDocument.Project.Project renga_project, int BeamStyle_id)
        {
            Renga.IBeamStyleManager st_man = renga_project.project.BeamStyleManager;
            this.beam_style = st_man.GetBeamStyle(BeamStyle_id);
        }
        /// <summary>
        /// Получение целочисленного идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.beam_style.Id;
        }
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.beam_style.Name;
        }
        /// <summary>
        /// Получение интерфейса Renga.IProfile
        /// </summary>
        /// <returns></returns>
        public object Profile()
        {
            return this.beam_style.Profile;
        }
        /// <summary>
        /// Получение всех стилей проекта как com-объектов (Renga.IBeamStyle)
        /// </summary>
        /// <param name="renga_project">Проект Renga (класс из DynDocument.Project)</param>
        /// <returns></returns>
        public static List<object> GetAllStyles(DynDocument.Project.Project renga_project)
        {
            List<object> styles = new List<object>();
            Renga.IBeamStyleManager st_man = renga_project.project.BeamStyleManager;
            List<int> ids = st_man.GetIds().OfType<int>().ToList();
            foreach (int id in ids)
            {
                styles.Add(st_man.GetBeamStyle(id));
            }
            return styles;
        }
    }
}
