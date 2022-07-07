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
    /// Общие методы по работе с объектами как со структурами
    /// </summary>
    public class General
    {
        private General() { }
        
        /// <summary>
        /// Получение всех объектных идентификаторов
        /// </summary>
        /// <returns></returns>
        public static List<Guid> AllObjectTypes()
        {
            return ObjectTypes().Select(a => a.Value).ToList();
        }
        /// <summary>
        /// Типы объектов (перечисление)
        /// </summary>
        /// <returns>Словарь с типами объектов</returns>
        [dr.MultiReturn(new[] { "AssemblyInstance", "Axis", "Beam", "Column", "Dimension", "Door", "Duct", "DuctAccessory", "DuctFitting",
            "ElectricDistributionBoard", "Element", "Elevation", "Equipment", "Floor", "Hatch", "IfcObject", "IsolatedFoundation",
            "Level", "LightFixture", "Line3D", "LineElectricalCircuit", "MechanicalEquipment", "Opening", "Pipe", "PipeAccessory",
            "PipeFitting", "Plate", "PlumbingFixture", "Railing", "Ramp", "Rebar", "Roof", "Room", "Route", "RoutePoint", "Section",
            "Stair", "TextShape", "Undefined", "Wall", "WallFoundation", "Window", "WiringAccessory" })]
        public static Dictionary<string, Guid> ObjectTypes()
        {
            return new Dictionary<string, Guid>
            {
                { "AssemblyInstance",   Renga.ObjectTypes.AssemblyInstance},
                { "Axis",   Renga.ObjectTypes.Axis},
                { "Beam",   Renga.ObjectTypes.Beam},
                { "Column", Renga.ObjectTypes.Column},
                { "Dimension",  Renga.ObjectTypes.Dimension},
                { "Door",   Renga.ObjectTypes.Door},
                { "Duct",   Renga.ObjectTypes.Duct},
                { "DuctAccessory",  Renga.ObjectTypes.DuctAccessory},
                { "DuctFitting", Renga.ObjectTypes.DuctFitting},
                { "ElectricDistributionBoard",  Renga.ObjectTypes.ElectricDistributionBoard},
                { "Element",  Renga.ObjectTypes.Element},
                { "Elevation",  Renga.ObjectTypes.Elevation},
                { "Equipment",  Renga.ObjectTypes.Equipment},
                { "Floor",  Renga.ObjectTypes.Floor},
                { "Hatch",  Renga.ObjectTypes.Hatch},
                { "IfcObject",  Renga.ObjectTypes.IfcObject},
                { "IsolatedFoundation", Renga.ObjectTypes.IsolatedFoundation},
                { "Level",  Renga.ObjectTypes.Level},
                { "LightFixture",   Renga.ObjectTypes.LightFixture},
                { "Line3D", Renga.ObjectTypes.Line3D},
                { "LineElectricalCircuit",  Renga.ObjectTypes.LineElectricalCircuit},
                { "MechanicalEquipment", Renga.ObjectTypes.MechanicalEquipment},
                { "Opening",   Renga.ObjectTypes.Opening},
                { "Pipe",   Renga.ObjectTypes.Pipe},
                { "PipeAccessory",  Renga.ObjectTypes.PipeAccessory},
                { "PipeFitting",  Renga.ObjectTypes.PipeFitting},
                { "Plate",  Renga.ObjectTypes.Plate},
                { "PlumbingFixture",  Renga.ObjectTypes.PlumbingFixture},
                { "Railing", Renga.ObjectTypes.Railing},
                { "Ramp",   Renga.ObjectTypes.Ramp},
                { "Rebar",  Renga.ObjectTypes.Rebar},
                { "Roof",   Renga.ObjectTypes.Roof},
                { "Room",   Renga.ObjectTypes.Room},
                { "Route",  Renga.ObjectTypes.Route},
                { "RoutePoint", Renga.ObjectTypes.RoutePoint},
                { "Section", Renga.ObjectTypes.Section},
                { "Stair",  Renga.ObjectTypes.Stair},
                { "TextShape",  Renga.ObjectTypes.TextShape},
                { "Undefined",  Renga.ObjectTypes.Undefined},
                { "Wall",   Renga.ObjectTypes.Wall},
                { "WallFoundation", Renga.ObjectTypes.WallFoundation},
                { "Window", Renga.ObjectTypes.Window},
                { "WiringAccessory",Renga.ObjectTypes.WiringAccessory},
            };
        }
        /// <summary>
        /// ВОзвращает тип объекта модели по его уникальному индентифакатору (Guid)
        /// </summary>
        /// <param name="obj_type_guid"></param>
        /// <returns></returns>
        public static string GetObjectIdAsString(Guid obj_type_guid)
        {
            Dictionary<string,Guid> data = new Dictionary<string, Guid>
            {
                { "AssemblyInstance",   Renga.ObjectTypes.AssemblyInstance},
                { "Axis",   Renga.ObjectTypes.Axis},
                { "Beam",   Renga.ObjectTypes.Beam},
                { "Column", Renga.ObjectTypes.Column},
                { "Dimension",  Renga.ObjectTypes.Dimension},
                { "Door",   Renga.ObjectTypes.Door},
                { "Duct",   Renga.ObjectTypes.Duct},
                { "DuctAccessory",  Renga.ObjectTypes.DuctAccessory},
                { "DuctFitting", Renga.ObjectTypes.DuctFitting},
                { "ElectricDistributionBoard",  Renga.ObjectTypes.ElectricDistributionBoard},
                { "Element",  Renga.ObjectTypes.Element},
                { "Elevation",  Renga.ObjectTypes.Elevation},
                { "Equipment",  Renga.ObjectTypes.Equipment},
                { "Floor",  Renga.ObjectTypes.Floor},
                { "Hatch",  Renga.ObjectTypes.Hatch},
                { "IfcObject",  Renga.ObjectTypes.IfcObject},
                { "IsolatedFoundation", Renga.ObjectTypes.IsolatedFoundation},
                { "Level",  Renga.ObjectTypes.Level},
                { "LightFixture",   Renga.ObjectTypes.LightFixture},
                { "Line3D", Renga.ObjectTypes.Line3D},
                { "LineElectricalCircuit",  Renga.ObjectTypes.LineElectricalCircuit},
                { "MechanicalEquipment", Renga.ObjectTypes.MechanicalEquipment},
                { "Opening",   Renga.ObjectTypes.Opening},
                { "Pipe",   Renga.ObjectTypes.Pipe},
                { "PipeAccessory",  Renga.ObjectTypes.PipeAccessory},
                { "PipeFitting",  Renga.ObjectTypes.PipeFitting},
                { "Plate",  Renga.ObjectTypes.Plate},
                { "PlumbingFixture",  Renga.ObjectTypes.PlumbingFixture},
                { "Railing", Renga.ObjectTypes.Railing},
                { "Ramp",   Renga.ObjectTypes.Ramp},
                { "Rebar",  Renga.ObjectTypes.Rebar},
                { "Roof",   Renga.ObjectTypes.Roof},
                { "Room",   Renga.ObjectTypes.Room},
                { "Route",  Renga.ObjectTypes.Route},
                { "RoutePoint", Renga.ObjectTypes.RoutePoint},
                { "Section", Renga.ObjectTypes.Section},
                { "Stair",  Renga.ObjectTypes.Stair},
                { "TextShape",  Renga.ObjectTypes.TextShape},
                { "Undefined",  Renga.ObjectTypes.Undefined},
                { "Wall",   Renga.ObjectTypes.Wall},
                { "WallFoundation", Renga.ObjectTypes.WallFoundation},
                { "Window", Renga.ObjectTypes.Window},
                { "WiringAccessory",Renga.ObjectTypes.WiringAccessory},
            };
            return data.Where(a => a.Value == obj_type_guid).First().Key;
        }


    }
}
