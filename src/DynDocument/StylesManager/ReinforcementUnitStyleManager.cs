using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynStyles;

namespace DynRenga.DynDocument.StylesManager
{
    /// <summary>
    /// Класс для работы с менеджером свойств арматуры и арматурных блоков, 
    /// интерфейсом Renga.IReinforcementUnitStyleManager
    /// </summary>
    public class ReinforcementUnitStyleManager
    {
        public Renga.IReinforcementUnitStyleManager _i;
        /// <summary>
        /// Инициализация класса (получение менеджера свойств) из Проекта
        /// </summary>
        /// <param name="renga_project"></param>
        public ReinforcementUnitStyleManager(DynDocument.Project.Project renga_project)
        {
            this._i = renga_project._i.ReinforcementUnitStyleManager;
        }
        /// <summary>
        /// Получение интерфейса Renga.IRebarStyle по его численному (int) идентификатору
        /// </summary>
        /// <param name="rebar_style_id">Численный (int) идентификатор стиля арматуры</param>
        /// <returns></returns>
        public RebarStyle GetRebarStyle(int rebar_style_id)
        {
            return new RebarStyle(this._i.GetRebarStyle(rebar_style_id));
        }
        /// <summary>
        /// Получение всех стилей арматуры проекта как списка чисел (int)
        /// </summary>
        /// <returns>int-идентификаторы в списке</returns>
        public List<int> GetRebarStyleIds()
        {
            return this._i.GetRebarStyleIds().OfType<int>().ToList();
        }
        /// <summary>
        /// Проверка, существует ли в проекте стиль с таким числовым (int) идентификатором
        /// </summary>
        /// <param name="rebar_style_id"></param>
        /// <returns></returns>
        public bool RebarStyleExists (int rebar_style_id)
        {
            return this._i.RebarStyleExists(rebar_style_id);
        }
        //uints
        /// <summary>
        /// Получение интерфейса Renga.IReinforcementUnitStyle 
        /// по его численному (int) идентификатору
        /// </summary>
        /// <param name="reinfircment_unit_style_id"></param>
        /// <returns></returns>
        public ReinforcementUnitStyle GetUnitStyle(int reinfircment_unit_style_id)
        {
            return new ReinforcementUnitStyle(this._i.GetUnitStyle(reinfircment_unit_style_id));
        }
        /// <summary>
        /// Проверка, существует ли в проекте стиль с таким числовым (int) идентификатором
        /// </summary>
        /// <param name="reinfircment_unit_style_id"></param>
        /// <returns></returns>
        public bool UnitStyleExists(int reinfircment_unit_style_id)
        {
            return this._i.UnitStyleExists(reinfircment_unit_style_id);
        }
        /// <summary>
        /// Получение всех стилей арматурных блоков проекта как списка чисел (int)
        /// </summary>
        /// <returns></returns>
        public List<int> GetReinforcementUnitStyleIds()
        {
            return this._i.GetReinforcementUnitStyleIds().OfType<int>().ToList();
        }

    }
}
