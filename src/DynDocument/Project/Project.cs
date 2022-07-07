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
    /// Рабочий проект
    /// </summary>
    public class Project
    {
        public Renga.IProject project;// = Main.renga_project;
        /// <summary>
        /// Получает текущий проект (интерфейс Renga.Project) от интерфейса Renga.IApplication
        /// </summary>
        /// <param name="renga_application"></param>
        public Project(Application renga_application)
        {

            this.project = renga_application.renga_app.Project;
        }
        /// <summary>
        /// Получение файлового пути, по которому сохранен текущий проект или null если он не сохранен
        /// </summary>
        /// <returns>Строковый файловый путь</returns>
        public string FilePath()
        {
            return this.project.FilePath;
        }
        /// <summary>
        /// Получение инфрмации о проекте ProjectInfo, в виде IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object IProjectInfo()
        {
            return this.project.ProjectInfo;
        }
        /// <summary>
        /// Получение инфрмации о здании BuildingInfo, в виде IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object IBuildingInfo()
        {
            return this.project.BuildingInfo;
        }
        /// <summary>
        /// Получение инфрмации об участке LandPlotInfo, в виде IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object ILandPlotInfo()
        {
            return this.project.LandPlotInfo;
        }
        /// <summary>
        /// Получение интерфейса Renga.IModel
        /// </summary>
        /// <returns>Интерфейс Renga.IModel</returns>
        public object IModel()
        {
            return this.project.Model;
        }



    }
    
}
