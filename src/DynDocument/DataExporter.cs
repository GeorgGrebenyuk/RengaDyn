using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IDataExporter
    /// (предоставлением информации о геометрии объектов)
    /// </summary>
    [dr.IsVisibleInDynamoLibrary(true)]
    public class DataExporter
    {
        public Renga.IDataExporter data_exporter;
        /// <summary>
        /// Инициализация класса через получение Renga.IDataExporter
        /// из сущности проекта Renga (класса Project)
        /// </summary>
        /// <param name="renga_project"></param>
        [dr.IsVisibleInDynamoLibrary(true)]
        public DataExporter(DynRenga.DynDocument.Project.Project renga_project)
        {
            this.data_exporter = renga_project.project.DataExporter;
        }
        /// <summary>
        /// Получение списка объектов (интерфейсов Renga.IExportedObject3D)
        /// </summary>
        /// <returns>Список объектов (интерфейсов ExportedObject3D)</returns>
        public List<object> GetExportedObjects3D()
        {
            IExportedObject3DCollection collection = this.data_exporter.GetObjects3D();
            List<object> objects = new List<object>();
            for (int i = 0; i < collection.Count; i++)
            {
                objects.Add(collection.Get(i));

            }
            return objects;
        }
        /// <summary>
        /// Получение списка объектов (интерфейсов Renga.IGridWithMaterial) 
        /// </summary>
        /// <returns>Список объектов (интерфейсов IGridWithMaterial)</returns>
        [dr.IsVisibleInDynamoLibrary(true)]
        public List<object> GetIGridsWithMaterial()
        {
            IGridWithMaterialCollection collection = this.data_exporter.GetGrids();
            List<object> objects = new List<object>();
            for (int i = 0; i < collection.Count; i++)
            {
                objects.Add(collection.Get(i));

            }
            return objects;
        }
    }
}
