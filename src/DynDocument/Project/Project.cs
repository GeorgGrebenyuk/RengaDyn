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
    /// <summary>
    /// Представляет класс Renga.IModel
    /// </summary>
    public class Model
    {
        public Renga.IModel model;
        /// <summary>
        /// Получение Renga.IModel из проекта Renga (нод Project)
        /// </summary>
        /// <param name="project"></param>
        public Model (Project project)
        {
            this.model = project.project.Model;
        }
        /// <summary>
        /// Сведение к интерфейсу Renga.IModel объекта модели "Сборка"
        /// </summary>
        /// <param name="renga_model_object_assembly"></param>
        public Model (object renga_model_object_assembly)
        {
            if ((renga_model_object_assembly as Renga.IModelObject).ObjectType == ObjectTypes.AssemblyInstance)
                this.model = (Renga.IModelObject)renga_model_object_assembly as Renga.IModel;
            else this.model = null;
        }
        /// <summary>
        /// Получение внутреннего челочисенного идентификатора объекта из его Guid-идентификатора
        /// </summary>
        /// <param name="internal_model_guid"></param>
        /// <returns></returns>
        public int GetIdFromUniqueId (Guid internal_model_guid)
        {
            return this.model.GetIdFromUniqueId(internal_model_guid);
        }
        /// <summary>
        /// Получение внутреннего Guid-идентификатора объекта из его целочисленного идентификатора
        /// </summary>
        /// <param name="internal_model_id"></param>
        /// <returns></returns>
        public Guid GetUniqueIdFromId (int internal_model_id)
        {
            return this.model.GetUniqueIdFromId(internal_model_id);
        }
    }
}
