using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using Autodesk.DesignScript.Geometry.Core;
using DynRenga.DynProperties.Properties;

namespace DynRenga.DynDocument.Project
{
    /// <summary>
    /// Класс для работы с одиночной сущностью проекта
    /// </summary>
    public class Entity
    {
        public Renga.IEntity _i;
        /// <summary>
        /// Инициация класса из com-объекта Entity
        /// </summary>
        /// <param name="Entity_object"></param>
        internal Entity(object Entity_object)
        {
            this._i = Entity_object as Renga.IEntity;
        }
        /// <summary>
        /// Возвращает свойства связанные с объектом, если их возможно получить
        /// </summary>
        /// <returns></returns>
        public PropertyContainer GetProperties()
        {
            var cont = this._i.GetInterfaceByName("IPropertyContainer");
            if (cont != null)
            {
                return new PropertyContainer(cont);
            }
            else return null;
        }
        //properties
        /// <summary>
        /// Получение идентификатора объекта (int)
        /// </summary>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение наименования объекта
        /// </summary>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение внутреннего идентификатора (Guid)
        /// </summary>
        public Guid UniqueId => this._i.UniqueId;
        /// <summary>
        /// Получение типа объекта (что это за Entity)
        /// </summary>
        public Guid TypeId => this._i.TypeId;

        /// <summary>
        /// Типы Entity
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Root", "Building", "Layer", "MaterialLayer",
        "Project", "Schedule", "Sheet", "Site", "Table"})]
        public static Dictionary<string, Guid> TypeIds()
        {
            return new Dictionary<string, Guid>()
            {
                {"Root", Renga.EntityTypes.Root },
                {"Building", Renga.EntityTypes.Building },
                {"Layer", Renga.EntityTypes.Layer },
                {"MaterialLayer", Renga.EntityTypes.MaterialLayer },
                {"Project", Renga.EntityTypes.Project },
                {"Schedule", Renga.EntityTypes.Schedule },
                {"Sheet", Renga.EntityTypes.Sheet },
                {"Site", Renga.EntityTypes.Site },
                {"Table", Renga.EntityTypes.Table }
            };
        }
        /// <summary>
        /// Получение типа Entity в строчном виде
        /// </summary>
        /// <returns></returns>
        public string GetTypeAsString()
        {
            Guid type = this._i.TypeId;
            string type_s = TypeIds().Where(a => a.Value == type).First().Key;
            return type_s;
        }
    }
}
