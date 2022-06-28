using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.Other.Material
{
    /// <summary>
    /// Класс для работы с объектом Renga.Material. Предсставляет однослойный материал
    /// </summary>
    public class Material
    {
        public Renga.IMaterial material;
        /// <summary>
        /// Инициация материала Renga через интерфейс
        /// </summary>
        /// <param name="material_obj"></param>
        public Material(object material_obj)
        {
            this.material = material_obj as Renga.IMaterial;
        }
        /// <summary>
        /// Получает сущность материала по его идентификатору (встречается в GridMaterial)
        /// </summary>
        /// <param name="renga_project_obj">Интерфейс проекта Renga</param>
        /// <param name="material_id">Идентификатор материала</param>
        public Material (object renga_project_obj, int material_id)
        {
            Renga.IEntityCollection mat_manager = ((Renga.IProject)renga_project_obj).Materials;
            this.material = mat_manager.GetById(material_id) as Renga.IMaterial;

        }
        /// <summary>
        /// Получение всех материалов (как интерфейсов Renga) из свойств проекта (Материалы)
        /// </summary>
        /// <param name="renga_project_obj"></param>
        /// <returns></returns>
        public static List<object> GetAllMaterials (object renga_project_obj)
        {
            Renga.IEntityCollection materials_all = ((Renga.IProject)renga_project_obj).Materials;
            List<object> mats = new List<object>();
            foreach (int one_id in materials_all.GetIds())
            {
                mats.Add(materials_all.GetById(one_id));
            }
            return mats;
        }
        /// <summary>
        /// Идентификатор материала
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.material.Id;
        }
        /// <summary>
        /// Наименование материала
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.material.Name;
        }
        /// <summary>
        /// Плотность материала в кг/м3
        /// </summary>
        /// <returns></returns>
        public double Density()
        {
            return this.material.Density;
        }
        /// <summary>
        /// Цвет материала. ДЛя получения кода использовать нод RengaSimpleInterfaces.GetColorDataByRengaColor
        /// </summary>
        /// <returns></returns>
        public object Color()
        {
            return this.material.Color;
        }
    }
    /// <summary>
    /// Класс для работы с материалом, свойственным Renga.IGrid
    /// </summary>
    public class GridMaterial
    {
        public Renga.IGridMaterial gr_mat;
        public GridMaterial(object GridMaterial_obj)
        {
            this.gr_mat = GridMaterial_obj as Renga.IGridMaterial;
        }
        public int Id()
        {
            return this.gr_mat.Id;
        }
        public object Color()
        {
            return this.gr_mat.Color;
        }
    }
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
        public LayeredMaterial(object LayeredMaterial_obj)
        {
            this.lay_mat = LayeredMaterial_obj as Renga.ILayeredMaterial;
        }
        /// <summary>
        /// Наименование многослойного материала
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.lay_mat.Name;
        }
        /// <summary>
        /// Получение интерфейса Renga.IMaterialLayerCollection, то есть коллекции слоев материалов
        /// </summary>
        /// <returns></returns>
        public object Layers()
        {
            return this.lay_mat.Layers;
        }
        /// <summary>
        /// Получение идентификатора базового слоя
        /// </summary>
        /// <returns></returns>
        public int BaseLayerIndex()
        {
            return this.lay_mat.BaseLayerIndex;
        }
        /// <summary>
        /// Получение идентификатора для класса (интерейса Renga.ILayeredMaterial)
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.lay_mat.Id;
        }
        /// <summary>
        /// Получение группы Renga.MaterialLayer из данного многослойного материала
        /// </summary>
        /// <returns></returns>
        public List<object> GetLayers()
        {
            List<object> MaterialLayers = new List<object>();
            Renga.IMaterialLayerCollection collect = this.lay_mat.Layers;
            for (int i = 0; i < collect.Count; i++)
            {
                MaterialLayers.Add(collect.Get(i));
            }
            return MaterialLayers;
        }
    }
    /// <summary>
    /// Класс для работы с материалом слоя (многослойной конструкции)
    /// </summary>
    public class MaterialLayer
    {
        public Renga.IMaterialLayer lay_mat;
        /// <summary>
        /// ИНициация интерфейса Renga.IMaterialLayer
        /// </summary>
        /// <param name="MaterialLayer_obj"></param>
        public MaterialLayer(object MaterialLayer_obj)
        {
            this.lay_mat = MaterialLayer_obj as Renga.IMaterialLayer;

        }
        /// <summary>
        /// Получение идентификатора для материала Renga.IMaterial
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.lay_mat.Id;
        }
        /// <summary>
        /// Получение толщины материала
        /// </summary>
        /// <returns></returns>
        public double Thickness()
        {
            return this.lay_mat.Thickness;
        }
        /// <summary>
        /// Получает материал (Renga.IMaterial) свойственный данному Renga.IMaterialLayer
        /// </summary>
        /// <returns></returns>
        public object Material()
        {
            return this.lay_mat.Material;
        }
    }

}
