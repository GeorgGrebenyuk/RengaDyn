using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynObjects
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IExportedObject3D (трехмерным представлением объекта)
    /// </summary>
    public class ExportedObject3D : Other.Technical.ICOM_Tools
    {
        private Renga.IExportedObject3D obj;
        /// <summary>
        /// Инициализация класса через интерфейс Renga.IExportedObject3D
        /// </summary>
        /// <param name="ExportedObject3D_obj"></param>
        public ExportedObject3D (object ExportedObject3D_obj)
        {
            this.obj = ExportedObject3D_obj as IExportedObject3D;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.obj == null) return false;
            else return true;
        }
        /// <summary>
        /// Инициализация класса через интерфейс Renga.IExportedObject3D по идентификатору объекта модели (Renga.IModelObject)
        /// </summary>
        /// <param name="data_exporter">Класс DataExporter</param>
        /// <param name="modelobject_id">int ModelObjectId (Renga.IModelObject.Id)</param>
        /// <returns></returns>
        public ExportedObject3D (DynDocument.DataExporter data_exporter, int modelobject_id)
        {
            IExportedObject3DCollection collection = data_exporter.data_exporter.GetObjects3D();
            
            for (int i = 0; i < collection.Count; i++)
            {
                Renga.IExportedObject3D obj = collection.Get(i);
                if (obj.ModelObjectId == modelobject_id) 
                {
                    this.obj = obj;
                    break;
                }
            }
        }
        /// <summary>
        /// Получение численного идентификатора объекта модели, 
        /// свойственного данному трехмерному представлению
        /// </summary>
        /// <returns></returns>
        public int ModelObjectId()
        {
            return this.obj.ModelObjectId;
        }
        /// <summary>
        /// Получение количества мэшей
        /// </summary>
        /// <returns></returns>
        public int MeshCount()
        {
            return this.obj.MeshCount;
        }
        /// <summary>
        /// Получение мэша по внутреннему индексу
        /// </summary>
        /// <param name="mesh_index"></param>
        /// <returns></returns>
        public object GetMesh(int mesh_index)
        {
            if (mesh_index < 0 | mesh_index > this.obj.MeshCount) return null;
            else return this.obj.GetMesh(mesh_index);
        }
        /// <summary>
        /// Получение списка интерейсов Renga.IMesh
        /// </summary>
        /// <returns></returns>

        public List<object> GetMeshes()
        {
            List<object> meshes = new List<object>();
            for (int i =0; i< this.obj.MeshCount; i++)
            {
                meshes.Add(this.obj.GetMesh(i));

            }
            return meshes;
        }
        /// <summary>
        /// Полученеи геометрии Dynamo из объекта
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Meshes_group", "BoundingBox" })]
        public Dictionary<string,object> GetDynamoGeometry ()
        {
            List<dg.Mesh> meshes = new List<dg.Mesh>();
            dg.Point min = dg.Point.ByCoordinates(100000000000.0, 100000000000.0, 100000000000.0);
            dg.Point max = dg.Point.ByCoordinates(-100000000000.0, -100000000000.0, -100000000000.0);

            for (int counter_meshes = 0; counter_meshes < this.obj.MeshCount; counter_meshes++)
            {
                Renga.IMesh mesh = this.obj.GetMesh(counter_meshes);
                
                List<dg.Point> points = new List<dg.Point>();
                List<dg.IndexGroup> indexes = new List<dg.IndexGroup>();
                

                for (int counter_grids = 0; counter_grids < mesh.GridCount; counter_grids++)
                {
                    int counter_points = points.Count();
                    Renga.IGrid grid = mesh.GetGrid(counter_grids);
                    for (int p_counter = 0; p_counter < grid.VertexCount; p_counter++)
                    {
                        Renga.FloatPoint3D p = grid.GetVertex(p_counter);
                        dg.Point point_new = dg.Point.ByCoordinates(p.X / 1000.0, p.Y / 1000.0, p.Z / 1000.0);
                        if (point_new.X <= min.X && point_new.Y <= min.Y && point_new.Z <= min.Z) min = point_new;
                        if (point_new.X >= max.X && point_new.Y >= max.Y && point_new.Z >= max.Z) max = point_new;
                        points.Add(point_new);
                    }
                    for (int j = 0; j < grid.TriangleCount; j++)
                    {
                        Renga.Triangle tr = grid.GetTriangle(j);
                        indexes.Add(dg.IndexGroup.ByIndices(
                            (uint)counter_points + tr.V0, 
                            (uint)counter_points + tr.V1, 
                            (uint)counter_points + tr.V2));

                    }
                }
                meshes.Add(dg.Mesh.ByPointsFaceIndices(points, indexes));
            }
            return new Dictionary<string, object>()
            {
                {"Meshes_group", meshes },
                {"BoundingBox", dg.BoundingBox.ByGeometry(new List<dg.Point>{min,max }) }
            };

        }
        /// <summary>
        /// Получение общего числа граней триангуляции у данного объекта
        /// </summary>
        /// <returns></returns>
        public int GetTrianglesCount()
        {
            int triangles_count = 0;
            for (int mesh_counter = 0; mesh_counter < this.obj.MeshCount; mesh_counter ++)
            {
                Renga.IMesh mesh = this.obj.GetMesh(mesh_counter);
                for (int grid_counter = 0; grid_counter < mesh.GridCount; grid_counter ++)
                {
                    Renga.IGrid grid = mesh.GetGrid(grid_counter);
                    triangles_count += grid.TriangleCount;
                }
            }
            return triangles_count;
        }
        

    }
}
