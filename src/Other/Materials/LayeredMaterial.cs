using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynDocument.Project;

namespace DynRenga.Other.Materials
{
    /// <summary>
    /// Класс для работы с многослойной конструкцией (материалами слоев сложных объектов - Стен, Перекрытий, Крыш)
    /// </summary>
    public class LayeredMaterial
    {
        public Renga.ILayeredMaterial _i;
        /// <summary>
        /// Приведение к классу от Entity
        /// </summary>
        /// <param name="LayeredMaterial_obj"></param>
        public LayeredMaterial(Entity LayeredMaterial_Entity)
        {
            this._i = LayeredMaterial_Entity._i.GetInterfaceByName("ILayeredMaterial") as Renga.ILayeredMaterial;
        }
        internal LayeredMaterial (object LayeredMaterial_object)
        {
            this._i = LayeredMaterial_object as Renga.ILayeredMaterial;
        }
        /// <summary>
        /// Наименование многослойного материала
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение интерфейса Renga.IMaterialLayerCollection, то есть коллекции слоев материалов
        /// </summary>
        /// <returns></returns>
        public MaterialLayerCollection Layers => new MaterialLayerCollection( this._i.Layers);
        /// <summary>
        /// Получение идентификатора базового слоя
        /// </summary>
        /// <returns></returns>
        public int BaseLayerIndex => this._i.BaseLayerIndex;
        /// <summary>
        /// Получение идентификатора для класса (интерейса Renga.ILayeredMaterial)
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
    }
}
