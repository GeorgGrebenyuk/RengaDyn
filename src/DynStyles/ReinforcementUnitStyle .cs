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
    /// Класс для работы с интерфейсом Renga.IReinforcementUnitStyle, стилем арматурного элемента
    /// </summary>
    public class ReinforcementUnitStyle : Other.Technical.ICOM_Tools
    {
        public Renga.IReinforcementUnitStyle rein_style;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IReinforcementUnitStyle
        /// </summary>
        /// <param name="ReinforcementUnitStyle_object"></param>
        public ReinforcementUnitStyle(object ReinforcementUnitStyle_object)
        {
            this.rein_style = ReinforcementUnitStyle_object as Renga.IReinforcementUnitStyle;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.rein_style == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение идентификатора стиля
        /// </summary>
        /// <returns></returns>
        public int Id => this.rein_style.Id;
        /// <summary>
        /// Получение наименования стиля
        /// </summary>
        /// <returns></returns>
        public string Name => this.rein_style.Name;
        /// <summary>
        /// Получение типа (Renga.ReinforcementUnitType)
        /// </summary>
        /// <returns></returns>
        public string GetUnitType()
        {
            return ReinforcementUnitTypes().Where(a => (Renga.ReinforcementUnitType)a.Value == this.rein_style.UnitType).First().Key;
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
        public List<object> GetRebarUsages()
        {
            List<object> rebars = new List<object>();
            Renga.IRebarUsageCollection coll = this.rein_style.GetRebarUsages();
            for (int i = 0; i < coll.Count; i++)
            {
                rebars.Add(coll.Get(i));
            }
            return rebars;
        }

    }
}
