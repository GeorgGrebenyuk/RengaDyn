 using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Parameters
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IParameterDefinition 
    /// </summary>
    public class ParameterDefinition
    {
        public Renga.IParameterDefinition _i;
        /// <summary>
        /// Инициализация интерфейса Renga.IParameterDefinition
        /// </summary>
        /// <param name="ParameterDefinition_obj_com"></param>
        internal ParameterDefinition(object ParameterDefinition_obj_com)
        {
            this._i = ParameterDefinition_obj_com as Renga.IParameterDefinition;
        }
        /// <summary>
        /// Получает наименование параметра
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получает тип параметра в виде Enum (числа)
        /// </summary>
        /// <returns></returns>
        public object ParameterType => this._i.ParameterType;
        /// <summary>
        /// Получает строковое наименование типа параметра
        /// </summary>
        /// <returns></returns>
        public string GetParameterTypeAsString()
        {
            IEnumerable<KeyValuePair<string, object>> data = ParameterTypes().
                Where(a => (Renga.ParameterType)a.Value == this._i.ParameterType);
            if (data.Any()) return data.First().Key;
            else return null;
        }
        /// <summary>
        /// Значения Renga.ParameterType для типов параметров (свойств объектов)
        /// </summary>
        /// <returns>Словарь со значениями</returns>
        [dr.MultiReturn(new[] { "ParameterType_Undefined", "ParameterType_Bool", "ParameterType_Int" ,
            "ParameterType_Double","ParameterType_String","ParameterType_Length","ParameterType_Angle",
            "ParameterType_IntEnumeration","ParameterType_IntID" })]
        public static Dictionary<string, object> ParameterTypes()
        {
            return new Dictionary<string, object>
                {
                    {"ParameterType_Undefined",Renga.ParameterType.ParameterType_Undefined },
                    {"ParameterType_Bool",Renga.ParameterType.ParameterType_Bool  },
                    {"ParameterType_Int",Renga.ParameterType.ParameterType_Int },
                    {"ParameterType_Double",Renga.ParameterType.ParameterType_Double },
                    {"ParameterType_String",Renga.ParameterType.ParameterType_String },
                    {"ParameterType_Length",Renga.ParameterType.ParameterType_Length },
                    {"ParameterType_Angle",Renga.ParameterType.ParameterType_Angle },
                    {"ParameterType_IntEnumeration",Renga.ParameterType.ParameterType_IntEnumeration },
                    {"ParameterType_IntID",Renga.ParameterType.ParameterType_IntID }

                };
        }
        
    }
}
