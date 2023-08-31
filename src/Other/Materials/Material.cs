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
    /// Класс для работы с объектом Renga.Material. Предсставляет однослойный материал
    /// </summary>
    public class Material
    {
        public Renga.IMaterial _i;
        /// <summary>
        /// Инициация материала Renga через интерфейс
        /// </summary>
        /// <param name="material_obj"></param>
        internal Material(object material_obj)
        {
            this._i = material_obj as Renga.IMaterial;
        }
        /// <summary>
        /// Получает сущность материала по его идентификатору (встречается в GridMaterial)
        /// </summary>
        /// <param name="renga_project">Проект Renga</param>
        /// <param name="material_id">Идентификатор материала</param>
        public Material (DynDocument.Project.Project renga_project, int material_id)
        {
            Renga.IEntityCollection mat_manager = renga_project._i.Materials;
            this._i = mat_manager.GetById(material_id) as Renga.IMaterial;

        }
        /// <summary>
        /// Получение всех материалов (как интерфейсов Renga) из свойств проекта (Материалы)
        /// </summary>
        /// <param name="renga_project">Проект Renga</param>
        /// <returns></returns>
        public static List<Material> GetAllMaterialIds (DynDocument.Project.Project renga_project)
        {
            Renga.IEntityCollection materials_all = renga_project._i.Materials;
            Renga.IMaterialManager manager = renga_project._i.MaterialManager;
            List<Material> mats = new List<Material>();
            foreach (int one_id in materials_all.GetIds())
            {
                mats.Add(new Material(manager.GetMaterial(one_id)));
            }
            return mats;
        }
        /// <summary>
        /// Идентификатор материала
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Наименование материала
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Плотность материала в кг/м3
        /// </summary>
        /// <returns></returns>
        public double Density => this._i.Density;
        /// <summary>
        /// Цвет материала. Ддя получения кода использовать нод RengaSimpleInterfaces.GetColorDataByRengaColor
        /// </summary>
        /// <returns></returns>
        public Renga_Color Color => new Renga_Color(this._i.Color);
    }
    
    
    

}
