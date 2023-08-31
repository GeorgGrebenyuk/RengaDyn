using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynProperties.Quantities;
using DynRenga.DynGeometry;
using DynRenga.DynProperties.Parameters.ObjectsParam;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IReinforcementUnitStyle, стилем арматурного элемента
    /// </summary>
    public class ReinforcementUnitStyle
    {
        public Renga.IReinforcementUnitStyle _i;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IReinforcementUnitStyle
        /// </summary>
        /// <param name="ReinforcementUnitStyle_object"></param>
        internal ReinforcementUnitStyle(object ReinforcementUnitStyle_object)
        {
            this._i = ReinforcementUnitStyle_object as Renga.IReinforcementUnitStyle;
        }
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
        /// Получение типа (Renga.ReinforcementUnitType)
        /// </summary>
        /// <returns></returns>
        public string GetUnitType()
        {
            return ReinforcementUnitTypes().Where(a => (Renga.ReinforcementUnitType)a.Value == this._i.UnitType).First().Key;
        }
        private static Dictionary<string,object> ReinforcementUnitTypes()
        {
            return new Dictionary<string, object>()
            {
                {"Undefined type of reinforcement unit", Renga.ReinforcementUnitType.ReinforcementUnitType_Undefined },
                {"Reinforcing mesh", Renga.ReinforcementUnitType.ReinforcementUnitType_Mesh  },
                {"Reinforcing cage", Renga.ReinforcementUnitType.ReinforcementUnitType_Cage }
            };
        }
        /// <summary>
        /// Получение списка интерфейсов IRebarUsage
        /// </summary>
        /// <returns></returns>
        public List<RebarUsage> GetRebarUsages()
        {
            List<RebarUsage> rebars = new List<RebarUsage>();
            Renga.IRebarUsageCollection coll = this._i.GetRebarUsages();
            for (int i = 0; i < coll.Count; i++)
            {
                rebars.Add(new RebarUsage(coll.Get(i)));
            }
            return rebars;
        }

    }
}
