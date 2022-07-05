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
    [dr.IsVisibleInDynamoLibrary(true)]
    public class ExportedObject3D
    {
        private Renga.IExportedObject3D obj;
        /// <summary>
        /// ПРиведение к интерфейсу Renga.IExportedObject3D полученного объекта
        /// </summary>
        /// <param name="ExportedObject3D_obj"></param>
        [dr.IsVisibleInDynamoLibrary(true)]
        public ExportedObject3D (object ExportedObject3D_obj)
        {
            this.obj = ExportedObject3D_obj as IExportedObject3D;
        }
        /// <summary>
        /// Получение интерфейса Renga.IExportedObject3D по идентификатору объекта модели (Renga.IModelObject)
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
        [dr.IsVisibleInDynamoLibrary(true)]
        public int ModelObjectId()
        {
            return this.obj.ModelObjectId;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public int MeshCount()
        {
            return this.obj.MeshCount;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public Guid ModelObjectType()
        {
            return this.obj.ModelObjectType;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public string ModelObjectTypeS()
        {
            return this.obj.ModelObjectTypeS;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public object GetMesh(int mesh_index)
        {
            if (mesh_index < 0 | mesh_index > this.obj.MeshCount) return null;
            else return this.obj.GetMesh(mesh_index);
        }
        /// <summary>
        /// Получение списка интерейсов Renga.IMesh
        /// </summary>
        /// <returns></returns>
        [dr.IsVisibleInDynamoLibrary(true)]
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
                int counter_points = 0;
                List<dg.Point> points = new List<dg.Point>();
                List<dg.IndexGroup> indexes = new List<dg.IndexGroup>();


                for (int counter_grids = 0; counter_grids < mesh.GridCount; counter_grids++)
                {
                    Renga.IGrid grid = mesh.GetGrid(counter_grids);

                    for (int j = 0; j < grid.TriangleCount; j++)
                    {
                        Renga.Triangle tr = grid.GetTriangle(j);
                        Renga.FloatPoint3D p1 = grid.GetVertex((int)tr.V0);
                        Renga.FloatPoint3D p2 = grid.GetVertex((int)tr.V1);
                        Renga.FloatPoint3D p3 = grid.GetVertex((int)tr.V2);

                        int get_pnt(Renga.FloatPoint3D p)
                        {
                            dg.Point point_new = dg.Point.ByCoordinates(p.X, p.Y, p.Z);
                            if (point_new.X <= min.X && point_new.Y <= min.Y && point_new.Z <= min.Z) min = point_new;
                            if (point_new.X >= max.X && point_new.Y >= max.Y && point_new.Z >= max.Z) max = point_new;

                            if (points.Contains(point_new))
                            //points.Where(a=>a.X == p.X && a.Y == p.Y && a.Z == p.Z).Any()
                            {
                                return points.IndexOf(point_new);
                            }
                            else
                            {
                                points.Add(point_new);
                                counter_points++;
                                return counter_points - 1;
                            }
                        }

                        indexes.Add(dg.IndexGroup.ByIndices((uint)get_pnt(p1), (uint)get_pnt(p2), (uint)get_pnt(p3)));
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
        

    }
}
