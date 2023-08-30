using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynProperties.Properties;

namespace DynRenga.DynDocument.Project
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.ILandPlotInfo, свойствами участка
    /// </summary>
    public class LandPlotInfo
    {
        public Renga.ILandPlotInfo _i;
        /// <summary>
        /// Инициализация класа из интерфейса Renga.ILandPlotInfo
        /// </summary>
        /// <param name="LandPlotInfo_com"></param>
        internal LandPlotInfo(object LandPlotInfo_com)
        {
            this._i = LandPlotInfo_com as Renga.ILandPlotInfo;
        }
        /// <summary>
        /// Получение строкового представления номера участка
        /// </summary>
        /// <returns></returns>
        public string Number => this._i.Number;
        /// <summary>
        /// Присвоение номера участка из строкового представления
        /// </summary>
        /// <param name="number_string"></param>
        public void SetNumber(string number_string)
        {
            this._i.Number = number_string;
        }
        /// <summary>
        /// Получение строкового представления имени участка
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Присвоение наименования участка из строкового представления
        /// </summary>
        /// <param name="name_string"></param>
        public void SetName(string name_string)
        {
            this._i.Name = name_string;
        }
        /// <summary>
        /// Получение строкового представления описания участка
        /// </summary>
        /// <returns></returns>
        public string Description => this._i.Description;
        /// <summary>
        /// Присвоение описания участка из строкового представления
        /// </summary>
        /// <param name="description_string"></param>
        public void SetDescription(string description_string)
        {
            this._i.Description = description_string;
        }
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPropertyContainer 
        /// со свойствами BuildingInfo
        /// </summary>
        /// <returns></returns>
        public PropertyContainer GetProperties => new PropertyContainer(this._i.GetProperties());
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPostalAddress
        /// </summary>
        /// <returns></returns>
        public PostalAddress GetAddress => new PostalAddress(this._i.GetAddress());
    }
}
