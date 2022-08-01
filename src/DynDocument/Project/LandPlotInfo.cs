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
    /// Класс для работы с интерфейсом Renga.ILandPlotInfo, свойствами участка
    /// </summary>
    public class LandPlotInfo : Other.Technical.ICOM_Tools
    {
        public Renga.ILandPlotInfo l_info;
        /// <summary>
        /// Инициализация класа из интерфейса Renga.ILandPlotInfo
        /// </summary>
        /// <param name="LandPlotInfo_com"></param>
        public LandPlotInfo(object LandPlotInfo_com)
        {
            this.l_info = LandPlotInfo_com as Renga.ILandPlotInfo;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.l_info == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение строкового представления номера участка
        /// </summary>
        /// <returns></returns>
        public string Number()
        {
            return this.l_info.Number;
        }
        /// <summary>
        /// Присвоение номера участка из строкового представления
        /// </summary>
        /// <param name="number_string"></param>
        public void SetNumber(string number_string)
        {
            this.l_info.Number = number_string;
        }
        /// <summary>
        /// Получение строкового представления имени участка
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.l_info.Name;
        }
        /// <summary>
        /// Присвоение наименования участка из строкового представления
        /// </summary>
        /// <param name="name_string"></param>
        public void SetName(string name_string)
        {
            this.l_info.Name = name_string;
        }
        /// <summary>
        /// Получение строкового представления описания участка
        /// </summary>
        /// <returns></returns>
        public string Description()
        {
            return this.l_info.Description;
        }
        /// <summary>
        /// Присвоение описания участка из строкового представления
        /// </summary>
        /// <param name="description_string"></param>
        public void SetDescription(string description_string)
        {
            this.l_info.Description = description_string;
        }
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPropertyContainer 
        /// со свойствами BuildingInfo
        /// </summary>
        /// <returns></returns>
        public object GetProperties()
        {
            return this.l_info.GetProperties();
        }
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPostalAddress
        /// </summary>
        /// <returns></returns>
        public object GetAddress()
        {
            return this.l_info.GetAddress();
        }
    }
}
