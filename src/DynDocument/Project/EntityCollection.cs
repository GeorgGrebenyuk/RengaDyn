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
    /// Класс для работы с коллекциями сущностей объектов (получаются как свойства Проекта -- стили, элементы оформления и пр.)
    /// </summary>
    public class EntityCollection
    {
        public Renga.IEntityCollection _i;
        /// <summary>
        /// Инициация класса из com-объекта Renga.IEntityCollection
        /// </summary>
        /// <param name="EntityCollection_object"></param>
        internal EntityCollection(object EntityCollection_object)
        {
            this._i = EntityCollection_object as Renga.IEntityCollection;
        }
        /// <summary>
        /// Получение всех Entity в коллекции
        /// </summary>
        /// <returns></returns>
        public List<Entity> GetEntities()
        {
            List<Entity> objs = new List<Entity>();
            var ids = this._i.GetIds().OfType<int>();
            foreach (int i in ids)
            {
                objs.Add( new Entity(this._i.GetById(i)));
            }
            return objs;
        }
        /// <summary>
        /// Возвращает объект по идентификатору (актуально для приведения к других классов к Entity путем запроса ObjectId)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity GetById(int id)
        {
            return new Entity(this._i.GetById(id));
        }

    }
    
}
