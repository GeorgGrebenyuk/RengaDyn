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
    public class Parameter
    {
        public Renga.IParameter _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IParameter
        /// </summary>
        /// <_i name="Parameter_obj_com"></_i>
        internal Parameter (object Parameter_obj_com)
        {
            this._i = Parameter_obj_com as Renga.IParameter;
        }
        /// <summary>
        /// Проверка, есть ли какое-либо значение у параметра
        /// </summary>
        /// <returns></returns>
        public bool HasValue => this._i.HasValue();
        //getting data
        /// <summary>
        /// Получает булево значение параметра
        /// </summary>
        /// <returns></returns>
        public bool GetBoolValue()
        {
            if (this._i.HasValue()) return this._i.GetBoolValue();
            else return false;
        }
        /// <summary>
        /// Получает хначение параметра в виде целого числа
        /// </summary>
        /// <returns></returns>
        public int GetIntValue()
        {
            if (this._i.HasValue()) return this._i.GetIntValue();
            else return -1;
        }
        /// <summary>
        /// Получает значение параметра в виде дробного числа
        /// </summary>
        /// <returns></returns>
        public double GetDoubleValue()
        {
            if (this._i.HasValue()) return this._i.GetDoubleValue();
            else return -1d;
        }
        /// <summary>
        /// Получает значение параметра в виде строки
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            if (this._i.HasValue()) return this._i.GetStringValue();
            else return null;
        }
        //setting data
        /// <summary>
        /// Устаналивает значение параметра в виде булева значения
        /// </summary>
        /// <_i name="value_bool"></_i>
        public void SetBoolValue(bool value_bool)
        {
            this._i.SetBoolValue(value_bool);
        }
        /// <summary>
        /// Устаналивает значение параметра в виде целочисленного числа
        /// </summary>
        /// <_i name="value_int"></_i>
        public void SetIntValue (int value_int)
        {
            this._i.SetIntValue(value_int);
        }
        /// <summary>
        /// Устаналивает значение параметра в виде числа double
        /// </summary>
        /// <_i name="value_double"></_i>
        public void SetDoubleValue (double value_double)
        {
            this._i.SetDoubleValue(value_double);
        }
        /// <summary>
        /// Устаналивает строкое значение параметра по входной строке
        /// </summary>
        /// <_i name="value_string"></_i>
        public void SetStringValue (string value_string)
        {
            this._i.SetStringValue(value_string);
        }
        //properties
        /// <summary>
        /// Получение Guid-идентификатора параметра
        /// </summary>
        /// <returns></returns>
        public Guid Id => this._i.Id;
        /// <summary>
        /// Получение интерфейса Renga.IParameterDefinition
        /// </summary>
        /// <returns></returns>
        public ParameterDefinition Definition => new ParameterDefinition(this._i.Definition);
        /// <summary>
        /// Получение численного значения типа параметра Renga.ParameterValueType
        /// </summary>
        /// <returns></returns>
        public object ValueType => this._i.ValueType;
        //My
        /// <summary>
        /// Присвоение параметру значению по его типу (значение типа)
        /// </summary>
        /// <_i name="assigned_value">Значение для присваивания</_i>
        /// <returns></returns>
        public void SetValue(object assigned_value)
        {
            switch (this._i.ValueType)
            {
                case ParameterValueType.ParameterValueType_Bool:
                    {
                        this._i.SetBoolValue(Convert.ToBoolean(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_Int:
                    {
                        this._i.SetIntValue(Convert.ToInt32(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_Double:
                    {
                        this._i.SetDoubleValue(Convert.ToDouble(assigned_value));
                        break;
                    }
                case ParameterValueType.ParameterValueType_String:
                    {
                        this._i.SetStringValue(Convert.ToString(assigned_value));
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
            switch (this._i.ValueType)
            {
                case ParameterValueType.ParameterValueType_Bool:
                    {
                        return this._i.GetBoolValue();
                    }
                case ParameterValueType.ParameterValueType_Int:
                    {
                        return this._i.GetIntValue();
                    }
                case ParameterValueType.ParameterValueType_Double:
                    {
                        return this._i.GetDoubleValue();
                    }
                case ParameterValueType.ParameterValueType_String:
                    {
                        return this._i.GetStringValue();
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
                Where(a => (Renga.ParameterValueType)a.Value == this._i.ValueType);
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
