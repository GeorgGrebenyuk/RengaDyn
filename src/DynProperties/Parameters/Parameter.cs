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
    /// Класс для работы с одиночным параметром, интерфейсом Renga.IParameter
    /// </summary>
    public class Parameter : Other.Technical.ICOM_Tools
    {
        public Renga.IParameter param;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IParameter
        /// </summary>
        /// <param name="Parameter_obj_com"></param>
        public Parameter (object Parameter_obj_com)
        {
            this.param = Parameter_obj_com as Renga.IParameter;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.param== null) return false;
            else return true;
        }
        /// <summary>
        /// Проверка, есть ли какое-либо значение у параметра
        /// </summary>
        /// <returns></returns>
        public bool HasValue()
        {
            return this.param.HasValue();
        }
        //getting data
        /// <summary>
        /// Получает булево значение параметра
        /// </summary>
        /// <returns></returns>
        public bool GetBoolValue()
        {
            if (this.param.HasValue()) return this.param.GetBoolValue();
            else return false;
        }
        /// <summary>
        /// Получает хначение параметра в виде целого числа
        /// </summary>
        /// <returns></returns>
        public int GetIntValue()
        {
            if (this.param.HasValue()) return this.param.GetIntValue();
            else return -1;
        }
        /// <summary>
        /// Получает значение параметра в виде дробного числа
        /// </summary>
        /// <returns></returns>
        public double GetDoubleValue()
        {
            if (this.param.HasValue()) return this.param.GetDoubleValue();
            else return -1d;
        }
        /// <summary>
        /// Получает значение параметра в виде строки
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            if (this.param.HasValue()) return this.param.GetStringValue();
            else return null;
        }
        //setting data
        /// <summary>
        /// Устаналивает значение параметра в виде булева значения
        /// </summary>
        /// <param name="value_bool"></param>
        public void SetBoolValue(bool value_bool)
        {
            this.param.SetBoolValue(value_bool);
        }
        /// <summary>
        /// Устаналивает значение параметра в виде целочисленного числа
        /// </summary>
        /// <param name="value_int"></param>
        public void SetIntValue (int value_int)
        {
            this.param.SetIntValue(value_int);
        }
        /// <summary>
        /// Устаналивает значение параметра в виде числа double
        /// </summary>
        /// <param name="value_double"></param>
        public void SetDoubleValue (double value_double)
        {
            this.param.SetDoubleValue(value_double);
        }
        /// <summary>
        /// Устаналивает строкое значение параметра по входной строке
        /// </summary>
        /// <param name="value_string"></param>
        public void SetStringValue (string value_string)
        {
            this.param.SetStringValue(value_string);
        }
        //properties
        /// <summary>
        /// Получение Guid-идентификатора параметра
        /// </summary>
        /// <returns></returns>
        public Guid Id()
        {
            return this.param.Id;
        }
        /// <summary>
        /// Получение интерфейса Renga.IParameterDefinition
        /// </summary>
        /// <returns></returns>
        public object Definition()
        {
            return this.param.Definition;
        }
        /// <summary>
        /// Получение численного значения типа параметра Renga.ParameterValueType
        /// </summary>
        /// <returns></returns>
        public object ValueType()
        {
            return this.param.ValueType;
        }
        //My
        /// <summary>
        /// Присвоение параметру значению по его типу (значение типа)
        /// </summary>
        /// <param name="assigned_value">Значение для присваивания</param>
        /// <returns></returns>
        public void SetValue(object assigned_value)
        {
            switch (this.param.ValueType)
            {
                case ParameterValueType.ParameterValueType_Bool:
                    {
                        this.param.SetBoolValue(Convert.ToBoolean(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_Int:
                    {
                        this.param.SetIntValue(Convert.ToInt32(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_Double:
                    {
                        this.param.SetDoubleValue(Convert.ToDouble(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_String:
                    {
                        this.param.SetStringValue(Convert.ToString(assigned_value));
                        break;
                    }
            }
        }
        /// <summary>
        /// Получение значения параметра того типа, в зависимости от значения 
        /// ValueType (ParameterValueType) параметра
        /// </summary>
        /// <returns>Значение параметра</returns>
        public object GetValue()
        {
            switch (this.param.ValueType)
            {
                case ParameterValueType.ParameterValueType_Bool:
                    {
                        return this.param.GetBoolValue();
                    }
                case ParameterValueType.ParameterValueType_Int:
                    {
                        return this.param.GetIntValue();
                    }
                case ParameterValueType.ParameterValueType_Double:
                    {
                        return this.param.GetDoubleValue();
                    }
                case ParameterValueType.ParameterValueType_String:
                    {
                        return this.param.GetStringValue();
                    }
            }
            return null;
        }
        /// <summary>
        /// Получение типа параметра (формат строка, число и пр) Renga.ParameterValueType
        /// </summary>
        /// <returns></returns>
        public string GetValueTypeAsString()
        {
            IEnumerable<KeyValuePair<string, object>> data = ParameterValueTypes().
                Where(a => (Renga.ParameterValueType)a.Value == this.param.ValueType);
            if (data.Any()) return data.First().Key;
            else return null;
        }
        /// <summary>
        /// Значения Renga.ParameterValueType для типов значений параметров (свойств объектов)
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "ParameterValueType_Undefined", "ParameterValueType_Bool",
            "ParameterValueType_Int","ParameterValueType_Double","ParameterValueType_String"})]
        public static Dictionary<string, object> ParameterValueTypes()
        {
            return new Dictionary<string, object>
                {
                    {"ParameterValueType_Undefined", Renga.ParameterType.ParameterType_Undefined },
                    {"ParameterValueType_Bool", Renga.ParameterType.ParameterType_Bool },
                    {"ParameterValueType_Int", Renga.ParameterType.ParameterType_Int },
                    {"ParameterValueType_Double", Renga.ParameterType.ParameterType_Double },
                    {"ParameterValueType_String", Renga.ParameterType.ParameterType_String }
                };
        }
    }
}
