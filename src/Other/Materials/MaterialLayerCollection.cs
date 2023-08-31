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
    /// Класс для работы с набором материалов Renga.MaterialLayer
    /// </summary>
    public class MaterialLayerCollection
    {
        public Renga.IMaterialLayerCollection _i;
        internal MaterialLayerCollection (object MaterialLayerCollection_object)
        {
            this._i = MaterialLayerCollection_object as Renga.IMaterialLayerCollection;
        }
        public int Count => this._i.Count;
        /// <summary>
        /// Получение отдельного Renga.MaterialLayer из данного многослойного материала по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MaterialLayer Get(int index) => new MaterialLayer( this._i.Get(index));
        /// <summary>
        /// Получение группы Renga.MaterialLayer из данного многослойного материала
        /// </summary>
        /// <returns></returns>
        public List<MaterialLayer> GetAll()
        {
            List<MaterialLayer> MaterialLayers = new List<MaterialLayer>();
            for (int i = 0; i < this._i.Count; i++)
            {
                MaterialLayers.Add(new MaterialLayer(this._i.Get(i)));
            }
            return MaterialLayers;
        }
    }
}
