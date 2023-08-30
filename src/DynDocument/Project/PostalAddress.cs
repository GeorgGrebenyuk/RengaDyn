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
    /// Класс для представления поля для заполнения адреса объекта
    /// </summary>
    public class PostalAddress
    {
        public Renga.IPostalAddress _i;
        internal PostalAddress (object PostalAddress_object)
        {
            this._i = PostalAddress_object as Renga.IPostalAddress;
        }
        //Getting properties
        /// <summary>
        /// Получение строкового представления графы "Адресат"
        /// </summary>
        /// <returns></returns>
        public string Addressee => this._i.Addressee;
        /// <summary>
        /// Получение строкового представления (списка) графы "Адрес"
        /// </summary>
        /// <returns></returns>
        public List<string> AddressLines => this._i.AddressLines.OfType<string>().ToList();
        /// <summary>
        /// Получение строкового представления графы "Абонентский ящик"
        /// </summary>
        /// <returns></returns>
        public string PostalBox => this._i.PostalBox;
        /// <summary>
        /// Получение строкового представления графы "Населенный пункт"
        /// </summary>
        /// <returns></returns>
        public string Town => this._i.Town;
        /// <summary>
        /// Получение строкового представления графы "Регион"
        /// </summary>
        /// <returns></returns>
        public string Region => this._i.Region;
        /// <summary>
        /// Получение строкового представления графы "Почтовый индекс"
        /// </summary>
        /// <returns></returns>
        public string Postcode => this._i.Postcode;
        /// <summary>
        /// Получение строкового представления графы "Страна"
        /// </summary>
        /// <returns></returns>
        public string Country => this._i.Country;
        //Setting properties
        /// <summary>
        /// Заполнение строкового представления графы "Адресат"
        /// </summary>
        /// <param name="addressee_string"></param>
        public void SetAddressee(string addressee_string)
        {
            this._i.Addressee = addressee_string;
        }
        /// <summary>
        /// Заполнение строкового представления (список) графы "Адрес"
        /// </summary>
        /// <param name="addressLines_string_list"></param>
        public void SetAddressLines(List<string> addressLines_string_list)
        {
            this._i.AddressLines = addressLines_string_list.ToArray();
        }
        /// <summary>
        /// Заполнение строкового представления графы "Абонентский ящик"
        /// </summary>
        /// <param name="postalBox_string"></param>
        public void SetPostalBox(string postalBox_string)
        {
            this._i.PostalBox = postalBox_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Населенный пункт"
        /// </summary>
        /// <param name="town_string"></param>
        public void SetTown(string town_string)
        {
            this._i.Town = town_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Регион"
        /// </summary>
        /// <param name="region_string"></param>
        public void SetRegion(string region_string)
        {
            this._i.Region = region_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Почтовый индекс"
        /// </summary>
        /// <param name="postcode_string"></param>
        public void SetPostcode(string postcode_string)
        {
            this._i.Postcode = postcode_string;
        }
        /// <summary>
        /// Заполнение строкового представления графы "Страна"
        /// </summary>
        /// <param name="country_string"></param>
        public void SetCountry(string country_string)
        {
            this._i.Country = country_string;
        }
    }
}
