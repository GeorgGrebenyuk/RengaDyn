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
    /// Класс со вспомогательными методами разного плана
    /// </summary>
    public class RengaSimpleInterfaces
    {
        private RengaSimpleInterfaces() { }
        /// <summary>
        /// Расшифровка значения типа Logical в Renga (встречается в свойствах)
        /// </summary>
        /// <param name="Logical_obj"></param>
        /// <returns></returns>
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
        public static Guid GuidByString(string guid_str)
        {
            return Guid.Parse(guid_str);
        }
        /// <summary>
        /// Преобразование Guid в строку (Guid.ToString())
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string StringByGuid (Guid guid)
        {
            return guid.ToString();
        }
    }
}
