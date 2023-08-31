using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.Other;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с описанием инженерной системы, интерфейсом Renga.ISystemStyle
    /// </summary>
    public class SystemStyle 
    {
        public Renga.ISystemStyle _i;
        /// <summary>
        /// Инициализация класса через интерфейс Renga.ISystemStyle
        /// </summary>
        /// <param name="SystemStyle_object"></param>
        internal SystemStyle(object SystemStyle_object)
        {
            this._i = SystemStyle_object as Renga.ISystemStyle;
        }
        //properties
        /// <summary>
        /// Получение строкого типа системы снабжения
        /// </summary>
        /// <returns></returns>
        public string GetSystemType()
        {
            return SystemTypes().Where(a => (Renga.SystemType)a.Value == this._i.SystemType).First().Key;
        }
        /// <summary>
        /// Получение строкового обозначения системы
        /// </summary>
        /// <returns></returns>
        public string Designation => this._i.Designation;
        /// <summary>
        /// Получение идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение цвета стиля, используйте нод Other.RengaSimpleInterfaces.GetColorDataByRengaColor
        /// </summary>
        /// <returns></returns>
        public Renga_Color Color => new Renga_Color(this._i.Color);

        private static Dictionary<string, object> SystemTypes()
        {
            return new Dictionary<string, object>()
            {
                {"SystemType_Unknown",0 },
                {"SystemType_DomesticColdWater",2 },
                {"SystemType_DomesticHotWater",3 },
                {"SystemType_DomesticSewerage",4 },
                {"SystemType_DomesticGasSupply",5 },
                {"SystemType_WaterFireExtinguishing",6 },
                {"SystemType_WaterHeating",7 },
                {"SystemType_GasFireExtinguishing",8 },
                {"SystemType_StormDrain",9 },
                {"SystemType_IndustrialColdWater",10 },
                {"SystemType_IndustrialHotWater",11 },
                {"SystemType_IndustrialSewerage",12 }
            };
        }
    }
}
