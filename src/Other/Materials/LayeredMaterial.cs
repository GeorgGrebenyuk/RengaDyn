using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.Other.Materials
{
    /// <summary>
    /// Класс для работы с многослойной конструкцией (материалами слоев сложных объектов - Стен, Перекрытий, Крыш)
    /// </summary>
    public class LayeredMaterial
    {
        public Renga.ILayeredMaterial lay_mat;
        /// <summary>
        /// Инициация интерфейса Renga.ILayeredMaterial
        /// 
        /// </summary>
        /// <param name="LayeredMaterial_obj"></param>
        internal LayeredMaterial(object LayeredMaterial_obj)
        {
            this.lay_mat = LayeredMaterial_obj as Renga.ILayeredMaterial;
        }
        /// <summary>
        /// Наименование многослойного материала
        /// </summary>
        /// <returns></returns>
        public string Name => this.lay_mat.Name;
        /// <summary>
        /// Получение интерфейса Renga.IMaterialLayerCollection, то есть коллекции слоев материалов
        /// </summary>
        /// <returns></returns>
        public MaterialLayerCollection Layers => new MaterialLayerCollection( this.lay_mat.Layers);
        /// <summary>
        /// Получение идентификатора базового слоя
        /// </summary>
        /// <returns></returns>
        public int BaseLayerIndex => this.lay_mat.BaseLayerIndex;
        /// <summary>
        /// Получение идентификатора для класса (интерейса Renga.ILayeredMaterial)
        /// </summary>
        /// <returns></returns>
        public int Id => this.lay_mat.Id;
    }
}
