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
    public class RengaSimpleInterfaces
    {
        private RengaSimpleInterfaces() { }
        /// <summary>
        /// Получение цветового кода из объекта Renga.COlor
        /// </summary>
        /// <param name="renga_color_obj"></param>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Red", "Green", "Blue", "Alpha" })]
        public static Dictionary<string,int> GetColorDataByRengaColor (object renga_color_obj)
        {
            return new Dictionary<string, int>()
            {
                {"Red",((Renga.Color)renga_color_obj).Red },
                {"Green",((Renga.Color)renga_color_obj).Green },
                {"Blue",((Renga.Color)renga_color_obj).Blue },
                {"Alpha",((Renga.Color)renga_color_obj).Alpha }
            };
        }
        public static string GetLogicalValue(object Logical_obj)
        {
            string value = null;
            switch ((Renga.Logical)Logical_obj)
            {
                case Logical.Logical_False: 
                    value = "False";
                    break;
                case Logical.Logical_True:
                    value = "True";
                    break;
                case Logical.Logical_Indeterminate:
                    value = "Indeterminate";
                    break;
            }
            return value;
        }
        /// <summary>
        /// Генерация нового GUID
        /// </summary>
        /// <returns></returns>
        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// Получение Guid из строки (Guid.Parse(string))
        /// </summary>
        /// <param name="guid_str"></param>
        /// <returns></returns>
        public static Guid ByString(string guid_str)
        {
            return Guid.Parse(guid_str);
        }
        /// <summary>
        /// Преобразование Guid в строку (Guid.ToString())
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string ByGuid (Guid guid)
        {
            return guid.ToString();
        }
    }
}
