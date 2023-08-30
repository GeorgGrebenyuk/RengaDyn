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
    /// Класс для работы с интерфейсом Renga.IBuildingInfo, свойствами здания
    /// </summary>
    public class BuildingInfo
    {
        public Renga.IBuildingInfo _i;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IBuildingInfo
        /// </summary>
        /// <param name="BuildingInfo_com"></param>
        internal BuildingInfo(object BuildingInfo_com)
        {
            this._i = BuildingInfo_com as Renga.IBuildingInfo;
        }
        /// <summary>
        /// Получение строкового представления номера здания
        /// </summary>
        /// <returns></returns>
        public string Number => this._i.Number;
        /// <summary>
        /// Присвоение номера здания из строкового представления
        /// </summary>
        /// <param name="number_string"></param>
        public void SetNumber(string number_string)
        {
            this._i.Number = number_string;
        }
        /// <summary>
        /// Получение строкового представления имени здания
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Присвоение наименования здания из строкового представления
        /// </summary>
        /// <param name="name_string"></param>
        public void SetName(string name_string)
        {
            this._i.Name = name_string;
        }
        /// <summary>
        /// Получение строкового представления описания здания
        /// </summary>
        /// <returns></returns>
        public string Description => this._i.Description;
        /// <summary>
        /// Присвоение описания здания из строкового представления
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
        /// Получение интерфейса Renga.IPostalAddress
        /// </summary>
        /// <returns></returns>
        public PostalAddress GetAddress => new PostalAddress( this._i.GetAddress());
    }
}
