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
    /// Класс для работы с интерфейсом Renga.IDataExporter
    /// (предоставлением информации о геометрии объектов)
    /// </summary>
    public class DataExporter 
    {
        public Renga.IDataExporter _i;
        /// <summary>
        /// Инициализация класса через получение Renga.IDataExporter
        /// из сущности проекта Renga (класса Project)
        /// </summary>
        /// <param name="renga_project"></param>
        [dr.IsVisibleInDynamoLibrary(true)]
        public DataExporter(DynRenga.DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.DataExporter;
        }
        /// <summary>
        /// Получение списка объектов (интерфейсов Renga.IExportedObject3D)
        /// </summary>
        /// <returns>Список объектов (интерфейсов ExportedObject3D)</returns>
        public List<ExportedObject3D> GetExportedObjects3D()
        {
            IExportedObject3DCollection _i = this._i.GetObjects3D();
            List<ExportedObject3D> objects = new List<ExportedObject3D>();
            for (int i = 0; i < _i.Count; i++)
            {
                objects.Add(new ExportedObject3D(_i.Get(i)));

            }
            return objects;
        }
        /// <summary>
        /// Получение списка объектов (интерфейсов Renga.IGridWithMaterial) 
        /// </summary>
        /// <returns>Список объектов (интерфейсов IGridWithMaterial)</returns>
        [dr.IsVisibleInDynamoLibrary(true)]
        public List<GridWithMaterial> GetIGridsWithMaterial()
        {
            IGridWithMaterialCollection _i = this._i.GetGrids();
            List<GridWithMaterial> objects = new List<GridWithMaterial>();
            for (int i = 0; i < _i.Count; i++)
            {
                objects.Add(new GridWithMaterial(_i.Get(i)));

            }
            return objects;
        }
    }
}
