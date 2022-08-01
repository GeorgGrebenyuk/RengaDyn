using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Quantities
{
    /// <summary>
    /// Класс для работы с перечнем расчетных свойств
    /// </summary>
    public class QuantityContainer : Other.Technical.ICOM_Tools
    {
        public Renga.IQuantityContainer q_man;
        /// <summary>
        /// Получение набора расчетных свойств из интерфейса Renga
        /// </summary>
        /// <param name="renga_QuantityContainer_obj"></param>
        public QuantityContainer(object renga_QuantityContainer_obj)
        {
            this.q_man = renga_QuantityContainer_obj as Renga.IQuantityContainer;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.q_man == null) return false;
            else return true;
        }
        /// <summary>
        /// Проверка, содержит ли данный набор расчетных свойств указанный Guid-идентификатор
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public bool Contains(Guid prop_id)
        {
            return this.q_man.Contains(prop_id);
        }
        /// <summary>
        /// Получение Renga.IQuantity по его Guid-идентификатору
        /// </summary>
        /// <param name="prop_id"></param>
        /// <returns></returns>
        public object Get (Guid prop_id)
        {
            if (this.q_man.Contains(prop_id)) return this.q_man.Get(prop_id);
            else return null;
        }
        //My
        /// <summary>
        /// Получение всех Guid-идентификаторов расчетных параметров и 
        /// самих параметров в виде интерфейсов Renga.IQuantity
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Quantites id", "Quantities objects (Renga.IQuantity)" })]
        public Dictionary<string, object> GetQuantities()
        {
            List<Guid> guids = new List<Guid>();
            List<object> quanities = new List<object>();
            foreach (KeyValuePair<string,Guid> prop2id in QuantityIdentifiers_Objects())
            {
                if (this.q_man.Contains(prop2id.Value)) 
                {
                    guids.Add(prop2id.Value);
                    quanities.Add(this.q_man.Get(prop2id.Value));
                }
            }
            return new Dictionary<string, object>()
            {
                {"Quantites id",guids },
                {"Quantities objects (Renga.IQuantity)",quanities }
            };

        }
        /// <summary>
        /// Получение наименования расчетного параметра по его Guid-идентификатору
        /// </summary>
        /// <param name="quantity_guid"></param>
        /// <returns></returns>
        public static string GetQuantityNameByGuid(object quantity_guid)
        {
            if (QuantityIdentifiers_Objects().Where(a => a.Value == (Guid)quantity_guid).Any())
            {
                return QuantityIdentifiers_Objects().Where(a => a.Value == (Guid)quantity_guid).First().Key;
            }
            else return null;
        }
        /// <summary>
        /// Типы расчетных свойств для всех категория объектов
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "NominalThickness", "NominalLength", "NominalWidth", "NominalHeight", "Perimeter",
                "OverallWidth", "OverallHeight", "OverallDepth", "OverallLength", "Volume", "NetVolume", "NetMass",
                "OuterSurfaceArea", "CrossSectionOverallWidth", "CrossSectionOverallHeight", "NetCrossSectionArea",
                "GrossCrossSectionArea", "GrossWallArea", "GrossCeilingArea", "Area", "NominalArea", "NetArea",
                "NetFootprintArea", "NetFloorArea", "NetSideArea", "NetPerimeter", "NetWallArea", "NetCeilingArea",
                "InnerSurfaceArea", "InnerSurfaceInternalArea", "InnerSurfaceExternalArea", "GlazingArea",
                "TotalSurfaceArea", "GrossArea", "GrossPerimeter", "GrossFloorArea", "GrossVolume", "NumberOfRiser",
                "NumberOfTreads", "RiserHeight", "TreadLength", "TotalRebarLength", "TotalRebarMass", "RelativeObjectBottomElevation",
                "RelativeObjectTopElevation", "RelativeObjectBaselineBottomElevation", "RelativeObjectBaselineTopElevation", "SlopeAngle" })]
        public static Dictionary<string, Guid> QuantityIdentifiers_Objects()
        {
            return new Dictionary<string, Guid>
                {
                    {"NominalThickness",Renga.QuantityIds.NominalThickness},
                    {"NominalLength",Renga.QuantityIds.NominalLength},
                    {"NominalWidth",Renga.QuantityIds.NominalWidth},
                    {"NominalHeight",Renga.QuantityIds.NominalHeight},
                    {"Perimeter",Renga.QuantityIds.Perimeter},
                    {"OverallWidth",Renga.QuantityIds.OverallWidth},
                    {"OverallHeight",Renga.QuantityIds.OverallHeight},
                    {"OverallDepth",Renga.QuantityIds.OverallDepth},
                    {"OverallLength",Renga.QuantityIds.OverallLength},
                    {"Volume",Renga.QuantityIds.Volume},
                    {"NetVolume",Renga.QuantityIds.NetVolume},
                    {"NetMass",Renga.QuantityIds.NetMass},
                    {"OuterSurfaceArea",Renga.QuantityIds.OuterSurfaceArea},
                    {"CrossSectionOverallWidth",Renga.QuantityIds.CrossSectionOverallWidth},
                    {"CrossSectionOverallHeight",Renga.QuantityIds.CrossSectionOverallHeight},
                    {"NetCrossSectionArea",Renga.QuantityIds.NetCrossSectionArea},
                    {"GrossCrossSectionArea",Renga.QuantityIds.GrossCrossSectionArea},
                    {"GrossWallArea",Renga.QuantityIds.GrossWallArea},
                    {"GrossCeilingArea",Renga.QuantityIds.GrossCeilingArea},
                    {"Area",Renga.QuantityIds.Area},
                    {"NominalArea",Renga.QuantityIds.NominalArea},
                    {"NetArea",Renga.QuantityIds.NetArea},
                    {"NetFootprintArea",Renga.QuantityIds.NetFootprintArea},
                    {"NetFloorArea",Renga.QuantityIds.NetFloorArea},
                    {"NetSideArea",Renga.QuantityIds.NetSideArea},
                    {"NetPerimeter",Renga.QuantityIds.NetPerimeter},
                    {"NetWallArea",Renga.QuantityIds.NetWallArea},
                    {"NetCeilingArea",Renga.QuantityIds.NetCeilingArea},
                    {"InnerSurfaceArea",Renga.QuantityIds.InnerSurfaceArea},
                    {"InnerSurfaceInternalArea",Renga.QuantityIds.InnerSurfaceInternalArea},
                    {"InnerSurfaceExternalArea",Renga.QuantityIds.InnerSurfaceExternalArea},
                    {"GlazingArea",Renga.QuantityIds.GlazingArea},
                    {"TotalSurfaceArea",Renga.QuantityIds.TotalSurfaceArea},
                    {"GrossArea",Renga.QuantityIds.GrossArea},
                    {"GrossPerimeter",Renga.QuantityIds.GrossPerimeter},
                    {"GrossFloorArea",Renga.QuantityIds.GrossFloorArea},
                    {"GrossVolume",Renga.QuantityIds.GrossVolume},
                    {"NumberOfRiser",Renga.QuantityIds.NumberOfRiser},
                    {"NumberOfTreads",Renga.QuantityIds.NumberOfTreads},
                    {"RiserHeight",Renga.QuantityIds.RiserHeight},
                    {"TreadLength",Renga.QuantityIds.TreadLength},
                    {"TotalRebarLength",Renga.QuantityIds.TotalRebarLength},
                    {"TotalRebarMass",Renga.QuantityIds.TotalRebarMass},
                    {"RelativeObjectBottomElevation",Renga.QuantityIds.RelativeObjectBottomElevation},
                    {"RelativeObjectTopElevation",Renga.QuantityIds.RelativeObjectTopElevation},
                    {"RelativeObjectBaselineBottomElevation",Renga.QuantityIds.RelativeObjectBaselineBottomElevation},
                    {"RelativeObjectBaselineTopElevation",Renga.QuantityIds.RelativeObjectBaselineTopElevation},
                    {"SlopeAngle",Renga.QuantityIds.SlopeAngle}
                };
        }

    }
}
