using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IEquipmentStyle, стилем оборудования
    /// </summary>
    public class EquipmentStyle : Other.Technical.ICOM_Tools
    {
        public Renga.IEquipmentStyle eq_style;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IEquipmentStyle
        /// </summary>
        /// <param name="EquipmentStyle_object"></param>
        public EquipmentStyle(object EquipmentStyle_object)
        {
            this.eq_style = EquipmentStyle_object as Renga.IEquipmentStyle;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.eq_style == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение наименования класса
        /// </summary>
        /// <returns></returns>
        public string Name => this.eq_style.Name;
        /// <summary>
        /// Получение строкового типа оборудования (Renga.EquipmentCategory)
        /// </summary>
        /// <returns></returns>
        public string GetCategory()
        {
            return EquipmentCategories().Where(a => (Renga.EquipmentCategory)a.Value == this.eq_style.Category).First().Key;
        }
        /// <summary>
        /// Типы оборудования
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, object> EquipmentCategories()
        {
            return new Dictionary<string, object>()
            {
                {"Unknown",Renga.EquipmentCategory.EquipmentCategory_Other },
                {"Fauset",Renga.EquipmentCategory.EquipmentCategory_Faucet },
                {"Manifold",Renga.EquipmentCategory.EquipmentCategory_Manifold },
                {"Pump",Renga.EquipmentCategory.EquipmentCategory_Pump },
                {"WashingMachine",Renga.EquipmentCategory.EquipmentCategory_WashingMachine },
                {"Radiator",Renga.EquipmentCategory.EquipmentCategory_Radiator },
                {"TowelRadiator",Renga.EquipmentCategory.EquipmentCategory_TowelRadiator },
                {"ExpansionVessel",Renga.EquipmentCategory.EquipmentCategory_ExpansionVessel },
                {"PlateHeatExchanger",Renga.EquipmentCategory.EquipmentCategory_PlateHeatExchanger },
                {"Boiler",Renga.EquipmentCategory.EquipmentCategory_Boiler }
            };

        }
    }
}
