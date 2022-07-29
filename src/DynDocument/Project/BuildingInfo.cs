using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument.Project
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IBuildingInfo, свойствами здания
    /// </summary>
    public class BuildingInfo
    {
        public Renga.IBuildingInfo b_info;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IBuildingInfo
        /// </summary>
        /// <param name="BuildingInfo_com"></param>
        public BuildingInfo(object BuildingInfo_com)
        {
            this.b_info = BuildingInfo_com as Renga.IBuildingInfo;
        }
        /// <summary>
        /// Получение строкового представления номера здания
        /// </summary>
        /// <returns></returns>
        public string Number()
        {
            return this.b_info.Number;
        }
        /// <summary>
        /// Присвоение номера здания из строкового представления
        /// </summary>
        /// <param name="number_string"></param>
        public void SetNumber(string number_string)
        {
            this.b_info.Number = number_string;
        }
        /// <summary>
        /// Получение строкового представления имени здания
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.b_info.Name;
        }
        /// <summary>
        /// Присвоение наименования здания из строкового представления
        /// </summary>
        /// <param name="name_string"></param>
        public void SetName(string name_string)
        {
            this.b_info.Name = name_string;
        }
        /// <summary>
        /// Получение строкового представления описания здания
        /// </summary>
        /// <returns></returns>
        public string Description()
        {
            return this.b_info.Description;
        }
        /// <summary>
        /// Присвоение описания здания из строкового представления
        /// </summary>
        /// <param name="description_string"></param>
        public void SetDescription(string description_string)
        {
            this.b_info.Description = description_string;
        }
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPropertyContainer 
        /// со свойствами BuildingInfo
        /// </summary>
        /// <returns></returns>
        public object GetProperties()
        {
            return this.b_info.GetProperties();
        }
        /// <summary>
        /// Получение интерфейса Renga.IPostalAddress
        /// </summary>
        /// <returns></returns>
        public object GetAddress()
        {
            return this.b_info.GetAddress();
        }
    }
}
