using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IModel (модель Проекта)
    /// </summary>
    public class Model
    {
        public Renga.IModel model;
        /// <summary>
        /// Инициализация класса через свойство Проекта (класса Project)
        /// </summary>
        /// <param name="project"></param>
        public Model(Project.Project project)
        {
            this.model = project.project.Model;
        }
        /// <summary>
        /// Сведение к интерфейсу Renga.IModel объекта модели "Сборка"
        /// </summary>
        /// <param name="renga_model_object_assembly"></param>
        public Model(object renga_model_object_assembly)
        {
            if ((renga_model_object_assembly as Renga.IModelObject).ObjectType == ObjectTypes.AssemblyInstance)
                this.model = (Renga.IModelObject)renga_model_object_assembly as Renga.IModel;
            else this.model = null;
        }
        /// <summary>
        /// Получение внутреннего челочисленного идентификатора объекта из его Guid-идентификатора
        /// </summary>
        /// <param name="internal_model_guid"></param>
        /// <returns></returns>
        public int GetIdFromUniqueId(Guid internal_model_guid)
        {
            return this.model.GetIdFromUniqueId(internal_model_guid);
        }
        /// <summary>
        /// Получение внутреннего Guid-идентификатора объекта из его целочисленного идентификатора
        /// </summary>
        /// <param name="internal_model_id"></param>
        /// <returns></returns>
        public Guid GetUniqueIdFromId(int internal_model_id)
        {
            return this.model.GetUniqueIdFromId(internal_model_id);
        }
    }
}
