using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynObjects.Geometry
{
    [dr.IsVisibleInDynamoLibrary(true)]
    public class Mesh
    {
        private Renga.IMesh mesh;
        [dr.IsVisibleInDynamoLibrary(true)]
        public Mesh(object mesh_obj)
        {
            this.mesh = mesh_obj as Renga.IMesh;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public int GridCount()
        {
            return this.mesh.GridCount;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public Guid MeshType()
        {
            return this.mesh.MeshType;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public string MeshTypeS()
        {
            return this.mesh.MeshTypeS;
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public object GetGrid(int grid_index)
        {
            if (grid_index < 0 | grid_index > this.mesh.GridCount) return null;
            else return this.mesh.GetGrid(grid_index);
        }
        [dr.IsVisibleInDynamoLibrary(true)]
        public List<object> GetGrids()
        {
            List<object> grids = new List<object>();
            for (int i = 0; i < this.mesh.GridCount; i++)
            {
                grids.Add(this.mesh.GetGrid(i));
            }
            return grids;
        }
        
        /// <summary>
        /// Типы MeshType
        /// </summary>
        /// <returns>Словарь с типами MeshType</returns>
        [dr.MultiReturn(new[] { "DoorReveal", "DoorPanel", "DoorTransom",
        "DoorLining","DoorThreshold","DoorPlatband","WindowReveal", "WindowPanel",
            "WindowSill", "WindowOutwardSill","Undefined" })]
        [dr.IsVisibleInDynamoLibrary(true)]
        public static Dictionary<string, object> MeshTypes()
        {
            return new Dictionary<string, object>
            {
                {"DoorReveal",Renga.MeshTypes.DoorReveal},
                {"DoorPanel",Renga.MeshTypes.DoorPanel},
                {"DoorTransom",Renga.MeshTypes.DoorTransom},
                {"DoorLining",Renga.MeshTypes.DoorLining},
                {"DoorThreshold",Renga.MeshTypes.DoorThreshold},
                {"DoorPlatband",Renga.MeshTypes.DoorPlatband},
                {"WindowReveal", Renga.MeshTypes.WindowReveal },
                {"WindowPanel", Renga.MeshTypes.WindowPanel },
                {"WindowSill", Renga.MeshTypes.WindowSill },
                {"WindowOutwardSill", Renga.MeshTypes.WindowOutwardSill},
                {"Undefined",Renga.MeshTypes.Undefined }
            };
        }

    }
}
