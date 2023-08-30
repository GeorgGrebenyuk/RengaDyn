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
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IMesh
    /// </summary>
    public class Mesh
    {
        private Renga.IMesh _i;
        /// <summary>
        /// Инициализация класса через интерфейс Renga.IMesh
        /// </summary>
        /// <param name="mesh_obj"></param>
        internal Mesh(object mesh_obj)
        {
            this._i = mesh_obj as Renga.IMesh;
        }
        /// <summary>
        /// Получение количества Grid
        /// </summary>
        /// <returns></returns>
        public int GridCount => this._i.GridCount;
        /// <summary>
        /// Получение типа Мэша
        /// </summary>
        /// <returns></returns>
        public Guid MeshType => this._i.MeshType;
        /// <summary>
        /// Получение отдельной Grid по её порядковому номеру в составе Мэша
        /// </summary>
        /// <param name="grid_index"></param>
        /// <returns></returns>
        public Grid GetGrid(int grid_index)
        {
            if (grid_index < 0 | grid_index > this._i.GridCount) return null;
            else return new Grid(this._i.GetGrid(grid_index));
        }
        /// <summary>
        /// Получение всех Grids
        /// </summary>
        /// <returns></returns>
        public List<Grid> GetGrids()
        {
            List<Grid> grids = new List<Grid>();
            for (int i = 0; i < this._i.GridCount; i++)
            {
                grids.Add(new Grid(this._i.GetGrid(i)));
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
