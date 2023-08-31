using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynObjects;

namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IModel (модель Проекта)
    /// </summary>
    public class Model
    {
        public Renga.IModel _i;
        /// <summary>
        /// Инициализация класса через свойство Проекта (класса Project)
        /// </summary>
        /// <param name="_i"></param>
        public Model(Project.Project renga_project)
        {
            this._i = renga_project._i.Model;
        }
        /// <summary>
        /// Приведение Сборки к данному классу
        /// </summary>
        /// <param name="renga_model_object_assembly"></param>
        public Model(ModelObject renga_model_object_assembly)
        {
            if (renga_model_object_assembly._i.ObjectType == ObjectTypes.AssemblyInstance)
                this._i = renga_model_object_assembly._i as Renga.IModel;
            else this._i = null;
        }
        /// <summary>
        /// Получение внутреннего челочисленного идентификатора объекта из его Guid-идентификатора
        /// </summary>
        /// <param name="internal_model_guid"></param>
        /// <returns></returns>
        public int GetIdFromUniqueId(Guid internal_model_guid)
        {
            return this._i.GetIdFromUniqueId(internal_model_guid);
        }
        /// <summary>
        /// Получение внутреннего Guid-идентификатора объекта из его целочисленного идентификатора
        /// </summary>
        /// <param name="internal_model_id"></param>
        /// <returns></returns>
        public Guid GetUniqueIdFromId(int internal_model_id)
        {
            return this._i.GetUniqueIdFromId(internal_model_id);
        }
    }
}
