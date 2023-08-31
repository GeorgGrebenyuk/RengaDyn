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
    /// Класс для работы с материалом слоя (многослойной конструкции)
    /// </summary>
    public class MaterialLayer
    {
        public Renga.IMaterialLayer _i;
        /// <summary>
        /// ИНициация интерфейса Renga.IMaterialLayer
        /// </summary>
        /// <param name="MaterialLayer_obj"></param>
        internal MaterialLayer(object MaterialLayer_obj)
        {
            this._i = MaterialLayer_obj as Renga.IMaterialLayer;

        }
        /// <summary>
        /// Получение идентификатора для материала Renga.IMaterial
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение толщины материала
        /// </summary>
        /// <returns></returns>
        public double Thickness => this._i.Thickness;
        /// <summary>
        /// Получает материал (Renga.IMaterial) свойственный данному Renga.IMaterialLayer
        /// </summary>
        /// <returns></returns>
        public Material Material => new Material(this._i.Material);
    }
}
