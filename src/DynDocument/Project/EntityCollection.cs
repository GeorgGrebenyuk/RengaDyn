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
    /// Класс для работы с коллекциями сущностей объектов (получаются как свойства Проекта -- стили, элементы оформления и пр.)
    /// </summary>
    public class EntityCollection
    {
        public Renga.IEntityCollection collection;
        /// <summary>
        /// Инициация класса из com-объекта Renga.IEntityCollection
        /// </summary>
        /// <param name="EntityCollection_object"></param>
        public EntityCollection(object EntityCollection_object)
        {
            this.collection = EntityCollection_object as Renga.IEntityCollection;
        }
        /// <summary>
        /// Получение всех Entity в коллекции
        /// </summary>
        /// <returns></returns>
        public List<object> GetEntities()
        {
            List<object> objs = new List<object>();
            var ids = this.collection.GetIds().OfType<int>();
            foreach (int i in ids)
            {
                objs.Add(this.collection.GetById(i));
            }
            return objs;
        }

    }
    /// <summary>
    /// Класс для работы с одиночной сущностью проекта
    /// </summary>
    public class Entity
    {
        public Renga.IEntity entity;
        /// <summary>
        /// Инициация класса из com-объекта Entity
        /// </summary>
        /// <param name="Entity_object"></param>
        public Entity (object Entity_object)
        {
            this.entity = Entity_object as Renga.IEntity;
        }
        //properties
        /// <summary>
        /// Получение идентификатора объекта (int)
        /// </summary>
        public int Id => this.entity.Id;
        /// <summary>
        /// Получение наименования объекта
        /// </summary>
        public string Name => this.entity.Name;
        /// <summary>
        /// Получение внутреннего идентификатора (Guid)
        /// </summary>
        public Guid UniqueId => this.entity.uniqueId;
        /// <summary>
        /// Получение типа объекта (что это за Entity)
        /// </summary>
        public Guid TypeId => this.entity.TypeId;

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
            Guid type = this.entity.TypeId;
            string type_s = TypeIds().Where(a => a.Value == type).First().Key;
            return type_s;
        }
    }
}
