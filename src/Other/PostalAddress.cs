using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.Other
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IPostalAddress (встречается в BuildingInfo и LandPlotInfo)
    /// </summary>
    public class PostalAddress : Other.Technical.ICOM_Tools
    {
        public Renga.IPostalAddress p_add;
        /// <summary>
        /// Инициация интерфейса Renga.IPostalAddress из com-объекта
        /// </summary>
        /// <param name="PostalAddress_object"></param>
        public PostalAddress(object PostalAddress_object)
        {
            this.p_add = PostalAddress_object as Renga.IPostalAddress;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.p_add == null) return false;
            else return true;
        }
        //Getting properties
        /// <summary>
        /// Получение строкового представления графы "Адресат"
        /// </summary>
        /// <returns></returns>
        public string Addressee => this.p_add.Addressee;
        /// <summary>
        /// Получение строкового представления (списка) графы "Адрес"
        /// </summary>
        /// <returns></returns>
        public List<string> AddressLines => this.p_add.AddressLines.OfType<string>().ToList();
        /// <summary>
        /// Получение строкового представления графы "Абонентский ящик"
        /// </summary>
        /// <returns></returns>
        public string PostalBox => this.p_add.PostalBox;
        /// <summary>
        /// Получение строкового представления графы "Населенный пункт"
        /// </summary>
        /// <returns></returns>
        public string Town => this.p_add.Town;
        /// <summary>
        /// Получение строкового представления графы "Регион"
        /// </summary>
        /// <returns></returns>
        public string Region => this.p_add.Region;
        /// <summary>
        /// Получение строкового представления графы "Почтовый индекс"
        /// </summary>
        /// <returns></returns>
        public string Postcode => this.p_add.Postcode;
        /// <summary>
        /// Получение строкового представления графы "Страна"
        /// </summary>
        /// <returns></returns>
        public string Country => this.p_add.Country;
        //Setting properties
        /// <summary>
        /// Заполнение строкового представления графы "Адресат"
        /// </summary>
        /// <param name="addressee_string"></param>
        public void SetAddressee(string addressee_string)
        {
            this.p_add.Addressee = addressee_string;
        }
        /// <summary>
        /// Заполнение строкового представления (список) графы "Адрес"
        /// </summary>
        /// <param name="addressLines_string_list"></param>
        public void SetAddressLines (List<string> addressLines_string_list)
        {
            this.p_add.AddressLines = addressLines_string_list.ToArray();
        }
        /// <summary>
        /// Заполнение строкового представления графы "Абонентский ящик"
        /// </summary>
        /// <param name="postalBox_string"></param>
        public void SetPostalBox(string postalBox_string)
        {
            this.p_add.PostalBox = postalBox_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Населенный пункт"
        /// </summary>
        /// <param name="town_string"></param>
        public void SetTown(string town_string)
        {
            this.p_add.Town = town_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Регион"
        /// </summary>
        /// <param name="region_string"></param>
        public void SetRegion(string region_string)
        {
            this.p_add.Region = region_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Почтовый индекс"
        /// </summary>
        /// <param name="postcode_string"></param>
        public void SetPostcode(string postcode_string)
        {
            this.p_add.Postcode = postcode_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Страна"
        /// </summary>
        /// <param name="country_string"></param>
        public void SetCountry (string country_string)
        {
            this.p_add.Country = country_string;
        }
    }
}
