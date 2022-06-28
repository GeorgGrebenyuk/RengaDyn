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
    public  class Grid
    {
        public Renga.IGrid grid;
        public Grid(object grid_obj)
        {
            this.grid = grid_obj as Renga.IGrid;
        }
        //Properties
        public int TriangleCount()
        {
            return this.grid.TriangleCount;
        }
        public int VertexCount()
        {
            return this.grid.VertexCount;
        }
        public int NormalCount()
        {
            return this.grid.NormalCount;
        }
        public int TextureCoordinateCount()
        {
            return this.grid.TextureCoordinateCount;
        }
        public object GridType()
        {
            return this.grid.GridType;
        }
        public bool DoubleSided()
        {
            return this.grid.DoubleSided;
        }
        //Triangle
        public object GetTriangle(int triangle_index)
        {
            if (triangle_index < 0 | triangle_index > this.grid.TriangleCount) return null;
            else return this.grid.GetTriangle(triangle_index);
        }
        public static dg.IndexGroup GetDynamoIndexGroupByTriangle(object triangle_obj)
        {
            return dg.IndexGroup.ByIndices(
                ((Renga.Triangle)triangle_obj).V0,
                ((Renga.Triangle)triangle_obj).V1,
                 ((Renga.Triangle)triangle_obj).V2);
        }
        public static List<int> GetTriangleComponentsByTriangle(object triangle_obj)
        {
            return new List<int>(3) {
                (int)((Renga.Triangle)triangle_obj).V0,
                (int)((Renga.Triangle)triangle_obj).V1,
                (int)((Renga.Triangle)triangle_obj).V2 };
        }
        public List<int> GetTriangleComponents(int triangle_index)
        {
            if (triangle_index < 0 | triangle_index > this.grid.TriangleCount) return null;
            else 
            {
                Renga.Triangle tr = this.grid.GetTriangle(triangle_index);
                return new List<int>(3) { (int)tr.V0, (int)tr.V1, (int)tr.V2 };
            }
        }
        //Vertex
        public object GetVertex(int vertex_index)
        {
            if (vertex_index < 0 | vertex_index > this.grid.VertexCount) return null;
            else return this.grid.GetVertex(vertex_index);
        }
        public static dg.Point GetDynamoPointByVertex (object vertex_obj)
        {
            return dg.Point.ByCoordinates(
                ((Renga.FloatPoint3D)vertex_obj).X,
                ((Renga.FloatPoint3D)vertex_obj).Y,
                ((Renga.FloatPoint3D)vertex_obj).Z);
        }
        public List<double> GetVertexComponents(int vertex_index)
        {
            Renga.FloatPoint3D p = this.grid.GetVertex(vertex_index);
            return new List<double>(3) { p.X, p.Y, p.Z };
        }
        //Normal

        
        /// <summary>
        /// GridTypes типы
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Wall_Undefined", "Wall_FrontSide", "Wall_BackSide", "Wall_Bottom", "Wall_Top", "Wall_FirstButt", 
            "Wall_SecondButt", "Wall_Reveal", "Wall_Cut", "Column_Undefined", "Column_Side", "Column_Bottom", "Column_Top", 
            "Column_Cut", "Beam_Undefined", "Beam_Side", "Beam_FirstButt", "Beam_SecondButt", "Beam_Cut", "Floor_Undefined", 
            "Floor_Side", "Floor_Bottom", "Floor_Top", "Floor_OpeningSide", "Floor_OpeningBottom", "Floor_OpeningTop",
            "Floor_Cut", "Roof_Undefined", "Roof_Side", "Roof_Bottom", "Roof_Top", "Roof_OpeningSide", "Roof_OpeningBottom", 
            "Roof_OpeningTop", "Roof_Cut", "Ramp_Undefined", "Ramp_Top", "Ramp_Bottom", "Ramp_FrontSide", "Ramp_BackSide", 
            "Ramp_LeftSide", "Ramp_RightSide", "Ramp_Cut", "Stairway_Undefined", "Stairway_Top", "Stairway_Bottom", "Stairway_LeftSide", 
            "Stairway_RightSide", "Stairway_Cut", "Window_Undefined", "Window_Frame", "Window_Glass", "Window_Sill", "Window_OutwardSill", 
            "Window_Reveal", "Door_Undefined", "Door_Frame", "Door_Solid", "Door_Glass", "Door_Reveal", "Door_DoorLining", "Door_Threshold", 
            "Door_Platband", "Railing_Undefined", "Railing_Handrail", "Railing_Filling", "Railing_Baluster", "Railing_Cut", "SingleFooting_Undefined",
            "SingleFooting_Side", "SingleFooting_Bottom", "SingleFooting_Top", "SingleFooting_Cut", "WallFooting_Undefined", "WallFooting_Any", 
            "Rebar_Undefined", "Rebar_Any", "Room_Undefined", "Room_Floor", "Room_Ceiling", "Room_Wall", "PlumbingFixture_Undefined", 
            "PlumbingFixture_Any", "Pipe_Undefined", "Pipe_Any", "PipeFitting_Undefined", "Plate_Undefined", "Plate_Any" })]
        [dr.IsVisibleInDynamoLibrary(true)]
        public static Dictionary <string, object> GridTypes ()
        {
            return new Dictionary<string, object>
            {
                {"Wall_Undefined",Renga.GridTypes.Wall.Undefined },
                {"Wall_FrontSide",Renga.GridTypes.Wall.FrontSide },
                {"Wall_BackSide",Renga.GridTypes.Wall.BackSide },
                {"Wall_Bottom",Renga.GridTypes.Wall.Bottom },
                {"Wall_Top",Renga.GridTypes.Wall.Top },
                {"Wall_FirstButt",Renga.GridTypes.Wall.FirstButt },
                {"Wall_SecondButt",Renga.GridTypes.Wall.SecondButt },
                {"Wall_Reveal",Renga.GridTypes.Wall.Reveal},
                {"Wall_Cut",Renga.GridTypes.Wall.Cut },
                {"Column_Undefined",Renga.GridTypes.Column.Undefined },
                {"Column_Side",Renga.GridTypes.Column.Side },
                {"Column_Bottom",Renga.GridTypes.Column.Bottom },
                {"Column_Top",Renga.GridTypes.Column.Top},
                {"Column_Cut",Renga.GridTypes.Column.Cut },
                {"Beam_Undefined",Renga.GridTypes.Beam.Undefined },
                {"Beam_Side",Renga.GridTypes.Beam.Side },
                {"Beam_FirstButt",Renga.GridTypes.Beam.FirstButt  },
                {"Beam_SecondButt",Renga.GridTypes.Beam.SecondButt },
                {"Beam_Cut",Renga.GridTypes.Beam.Cut },
                {"Floor_Undefined",Renga.GridTypes.Floor.Undefined },
                {"Floor_Side",Renga.GridTypes.Floor.Side },
                {"Floor_Bottom",Renga.GridTypes.Floor.Bottom },
                {"Floor_Top",Renga.GridTypes.Floor.Top},
                {"Floor_OpeningSide",Renga.GridTypes.Floor.OpeningSide },
                {"Floor_OpeningBottom",Renga.GridTypes.Floor.OpeningBottom },
                {"Floor_OpeningTop",Renga.GridTypes.Floor.OpeningTop },
                {"Floor_Cut",Renga.GridTypes.Floor.Cut },
                {"Roof_Undefined",Renga.GridTypes.Roof.Undefined },
                {"Roof_Side",Renga.GridTypes.Roof.Side },
                {"Roof_Bottom",Renga.GridTypes.Roof.Bottom },
                {"Roof_Top",Renga.GridTypes.Roof.Top },
                {"Roof_OpeningSide",Renga.GridTypes.Roof.OpeningSide },
                {"Roof_OpeningBottom",Renga.GridTypes.Roof.OpeningBottom },
                {"Roof_OpeningTop",Renga.GridTypes.Roof.OpeningTop },
                {"Roof_Cut",Renga.GridTypes.Roof.Cut },
                {"Ramp_Undefined",Renga.GridTypes.Ramp.Undefined },
                {"Ramp_Top",Renga.GridTypes.Ramp.Top },
                {"Ramp_Bottom",Renga.GridTypes.Ramp.Bottom },
                {"Ramp_FrontSide",Renga.GridTypes.Ramp.FrontSide },
                {"Ramp_BackSide",Renga.GridTypes.Ramp.BackSide },
                {"Ramp_LeftSide",Renga.GridTypes.Ramp.LeftSide },
                {"Ramp_RightSide",Renga.GridTypes.Ramp.RightSide },
                {"Ramp_Cut",Renga.GridTypes.Ramp.Cut },
                {"Stairway_Undefined",Renga.GridTypes.Stairway.Undefined },
                {"Stairway_Top",Renga.GridTypes.Stairway.Top },
                {"Stairway_Bottom",Renga.GridTypes.Stairway.Bottom },
                {"Stairway_LeftSide",Renga.GridTypes.Stairway.LeftSide },
                {"Stairway_RightSide",Renga.GridTypes.Stairway.RightSide },
                {"Stairway_Cut",Renga.GridTypes.Stairway.Cut },
                {"Window_Undefined",Renga.GridTypes.Window.Undefined },
                {"Window_Frame",Renga.GridTypes.Window.Frame },
                {"Window_Glass",Renga.GridTypes.Window.Glass },
                {"Window_Sill",Renga.GridTypes.Window.Sill },
                {"Window_OutwardSill",Renga.GridTypes.Window.OutwardSill },
                {"Window_Reveal",Renga.GridTypes.Window.Reveal },
                {"Door_Undefined",Renga.GridTypes.Door.Undefined },
                {"Door_Frame",Renga.GridTypes.Door.Frame },
                {"Door_Solid",Renga.GridTypes.Door.Solid },
                {"Door_Glass",Renga.GridTypes.Door.Glass },
                {"Door_Reveal",Renga.GridTypes.Door.Reveal },
                {"Door_DoorLining",Renga.GridTypes.Door.DoorLining },
                {"Door_Threshold",Renga.GridTypes.Door.Threshold },
                {"Door_Platband",Renga.GridTypes.Door.Platband },
                {"Railing_Undefined",Renga.GridTypes.Railing.Undefined },
                {"Railing_Handrail",Renga.GridTypes.Railing.Handrail },
                {"Railing_Filling",Renga.GridTypes.Railing.Filling },
                {"Railing_Baluster",Renga.GridTypes.Railing.Baluster },
                {"Railing_Cut",Renga.GridTypes.Railing.Cut },
                {"SingleFooting_Undefined",Renga.GridTypes.SingleFooting.Undefined },
                {"SingleFooting_Side",Renga.GridTypes.SingleFooting.Side},
                {"SingleFooting_Bottom",Renga.GridTypes.SingleFooting.Bottom },
                {"SingleFooting_Top",Renga.GridTypes.SingleFooting.Top },
                {"SingleFooting_Cut",Renga.GridTypes.SingleFooting.Cut },
                {"WallFooting_Undefined",Renga.GridTypes.WallFooting.Undefined },
                {"WallFooting_Any",Renga.GridTypes.WallFooting.Any },
                {"Rebar_Undefined",Renga.GridTypes.Rebar.Undefined },
                {"Rebar_Any",Renga.GridTypes.Rebar.Any },
                {"Room_Undefined",Renga.GridTypes.Room.Undefined },
                {"Room_Floor",Renga.GridTypes.Room.Floor },
                {"Room_Ceiling",Renga.GridTypes.Room.Ceiling },
                {"Room_Wall",Renga.GridTypes.Room.Wall },
                {"PlumbingFixture_Undefined",Renga.GridTypes.PlumbingFixture.Undefined },
                {"PlumbingFixture_Any",Renga.GridTypes.PlumbingFixture.Any },
                {"Pipe_Undefined",Renga.GridTypes.Pipe.Undefined },
                {"Pipe_Any",Renga.GridTypes.Pipe.Any },
                {"PipeFitting_Undefined",Renga.GridTypes.PipeFitting.Undefined },
                {"Plate_Undefined",Renga.GridTypes.Plate.Undefined },
                {"Plate_Any",Renga.GridTypes.Plate.Any },
            };
        }

        /// <summary>
        /// Полученеи геометрии Dynamo из объекта
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Grid_mesh", "BoundingBox" })]
        public Dictionary<string, object> GetDynamoGeometry()
        {
            //List<dg.Mesh> meshes = new List<dg.Mesh>();
            dg.Point min = dg.Point.ByCoordinates(100000000000.0, 100000000000.0, 100000000000.0);
            dg.Point max = dg.Point.ByCoordinates(-100000000000.0, -100000000000.0, -100000000000.0);

            int counter_points = 0;
            List<dg.Point> points = new List<dg.Point>();
            List<dg.IndexGroup> indexes = new List<dg.IndexGroup>();

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

            return new Dictionary<string, object>()
            {
                {"Grid_mesh", dg.Mesh.ByPointsFaceIndices(points,indexes) },
                {"BoundingBox", dg.BoundingBox.ByGeometry(new List<dg.Point>{min,max }) }
            };

        }



    }
}

