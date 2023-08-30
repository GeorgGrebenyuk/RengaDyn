using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynProperties.Properties
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IProperty - одиночным свойством объекта
    /// </summary>
    public class Property
    {
        public Renga.IProperty _i;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IProperty (получение свойства)
        /// </summary>
        /// <param name="Property_obj"></param>
        internal Property(object Property_obj)
        {
            this._i = Property_obj as Renga.IProperty;
        }
        /// <summary>
        /// Типы данных свойств (единицы измерения)
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "AngleUnit.AngleUnit_Degrees", "AngleUnit.AngleUnit_Degrees", "AreaUnit.AreaUnit_Unknown", "AreaUnit.AreaUnit_Millimeters2",
            "AreaUnit.AreaUnit_Centimeters2", "AreaUnit.AreaUnit_Meters2", "AngleUnit.AngleUnit_Degrees", "LengthUnit.LengthUnit_Inches","LengthUnit.LengthUnit_Millimeters",
            "LengthUnit.LengthUnit_Meters", "MassUnit.MassUnit_Unknown", "MassUnit.MassUnit_Tons","MassUnit.MassUnit_Kilograms","MassUnit.MassUnit_Grams",
            "VolumeUnit.VolumeUnit_Centimeters3","VolumeUnit.VolumeUnit_Unknown","VolumeUnit.VolumeUnit_Millimeters3","VolumeUnit.VolumeUnit_Meters3"})]
        public static Dictionary<string, object> PropertyUnitTypes()
        {
            return new Dictionary<string, object>
                {
                    {"AngleUnit.AngleUnit_Degrees",AngleUnit.AngleUnit_Degrees },
                    {"AngleUnit.AngleUnit_Degrees",AngleUnit.AngleUnit_Unknown },
                    {"AreaUnit.AreaUnit_Unknown",AreaUnit.AreaUnit_Unknown },
                    {"AreaUnit.AreaUnit_Millimeters2",AreaUnit.AreaUnit_Millimeters2 },
                    {"AreaUnit.AreaUnit_Centimeters2",AreaUnit.AreaUnit_Centimeters2 },
                    {"AreaUnit.AreaUnit_Meters2",AreaUnit.AreaUnit_Meters2 },
                    {"AngleUnit.AngleUnit_Degrees",LengthUnit.LengthUnit_Unknown },
                    {"LengthUnit.LengthUnit_Inches",LengthUnit.LengthUnit_Inches },
                    {"LengthUnit.LengthUnit_Millimeters",LengthUnit.LengthUnit_Millimeters },
                    {"LengthUnit.LengthUnit_Meters",LengthUnit.LengthUnit_Meters },
                    {"MassUnit.MassUnit_Unknown",MassUnit.MassUnit_Unknown },
                    {"MassUnit.MassUnit_Tons",MassUnit.MassUnit_Tons },
                    {"MassUnit.MassUnit_Kilograms",MassUnit.MassUnit_Kilograms},
                    {"MassUnit.MassUnit_Grams",MassUnit.MassUnit_Grams },
                    {"VolumeUnit.VolumeUnit_Centimeters3",VolumeUnit.VolumeUnit_Centimeters3 },
                    {"VolumeUnit.VolumeUnit_Unknown",VolumeUnit.VolumeUnit_Unknown },
                    {"VolumeUnit.VolumeUnit_Millimeters3",VolumeUnit.VolumeUnit_Millimeters3},
                    {"VolumeUnit.VolumeUnit_Meters3",VolumeUnit.VolumeUnit_Meters3 }
                };
        }
        /// <summary>
        /// Все типы свойств Renga
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new [] { "PropertyType_Undefined", "PropertyType_Double", "PropertyType_String",
        "PropertyType_Angle", "PropertyType_Area","PropertyType_Boolean","PropertyType_Enumeration",
        "PropertyType_Integer","PropertyType_Length","PropertyType_Logical","PropertyType_Mass","PropertyType_Volume"})]
        public static Dictionary<string,object> PropertyTypes()
        {
            return new Dictionary<string, object>()
            {
                {"PropertyType_Undefined",PropertyType.PropertyType_Undefined },
                {"PropertyType_Double",PropertyType.PropertyType_Double },
                {"PropertyType_String",PropertyType.PropertyType_String },
                {"PropertyType_Angle",PropertyType.PropertyType_Angle },
                {"PropertyType_Area",PropertyType.PropertyType_Area },
                {"PropertyType_Boolean",PropertyType.PropertyType_Boolean },
                {"PropertyType_Enumeration",PropertyType.PropertyType_Enumeration },
                {"PropertyType_Integer",PropertyType.PropertyType_Integer },
                {"PropertyType_Length",PropertyType.PropertyType_Length },
                {"PropertyType_Logical",PropertyType.PropertyType_Logical },
                {"PropertyType_Mass",PropertyType.PropertyType_Mass },
                {"PropertyType_Volume",PropertyType.PropertyType_Volume }
            };
        }
        /// <summary>
        /// Получает тип свойства (Renga.PropertyType) по его строковому наименованию
        /// </summary>
        /// <param name="prop_type"></param>
        /// <returns></returns>
        public static object GetPropertyTypeByString(string prop_type)
        {
            return PropertyTypes().Where(a => (a.Key) == prop_type).First().Value;
        }
        /// <summary>
        /// Получение строковой расшифровки свойства Renga
        /// </summary>
        /// <returns></returns>
        public string GetTypeAsString()
        {
           return PropertyTypes().Where(a => ((Renga.PropertyType)a.Value) == this._i.Type).First().Key;           
        }
        /// <summary>
        /// Получение строковой расшифровки свойства Renga по его Guid-представлению
        /// </summary>
        /// <param name="renga_property_type">Guid-представление свойства</param>
        /// <returns></returns>
        public static string GetTypeAsString(object renga_property_type)
        {
            return PropertyTypes().Where(a => ((Renga.PropertyType)a.Value) == 
            (Renga.PropertyType)renga_property_type).First().Key;
        }

        /// <summary>
        /// Получение типа свойства
        /// </summary>
        /// <returns></returns>
        public object Type => this._i.Type;
        /// <summary>
        /// Получение значения свойства для фиксированных типов СИ (метры, кв.м, кг)
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            object value = null;
            if (this._i.HasValue())
            {
                switch (this._i.Type)
                {
                    case PropertyType.PropertyType_Undefined:
                        value = this._i.GetStringValue();
                    break;
                    case PropertyType.PropertyType_Double:
                        value = this._i.GetDoubleValue();
                        break;
                    case PropertyType.PropertyType_String:
                        value = this._i.GetStringValue();
                        break;
                    case PropertyType.PropertyType_Angle:
                        value = this._i.GetAngleValue(Renga.AngleUnit.AngleUnit_Degrees);
                        break;
                    case PropertyType.PropertyType_Area:
                        value = this._i.GetAreaValue(Renga.AreaUnit.AreaUnit_Meters2);
                        break;
                    case PropertyType.PropertyType_Boolean:
                        value = this._i.GetBooleanValue();
                        break;
                    case PropertyType.PropertyType_Enumeration:
                        value = this._i.GetEnumerationValue();
                        break;
                    case PropertyType.PropertyType_Integer:
                        value = this._i.GetIntegerValue();
                        break;
                    case PropertyType.PropertyType_Length:
                        value = this._i.GetLengthValue(Renga.LengthUnit.LengthUnit_Meters);
                        break;
                    case PropertyType.PropertyType_Logical:
                        value = this._i.GetLogicalValue();
                        break;
                    case PropertyType.PropertyType_Mass:
                        value = this._i.GetMassValue(Renga.MassUnit.MassUnit_Kilograms);
                        break;
                    case PropertyType.PropertyType_Volume:
                        value = this._i.GetVolumeValue(Renga.VolumeUnit.VolumeUnit_Meters3);
                        break;
                }
                return value;
            }
            else return null;
            

        }
        /// <summary>
        /// Получение строкового наименования свойства
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение Guid-идентификатора свойства
        /// </summary>
        /// <returns></returns>
        public Guid Id => this._i.Id;
        /// <summary>
        /// Получение значения свойства как дробного числа double
        /// </summary>
        /// <returns></returns>
        public double GetDoubleValue()
        {
            if (this._i.HasValue()) return this._i.GetDoubleValue();
            else return double.NaN;
        }
        /// <summary>
        /// Получение значения свойства как строкового представления
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            if (this._i.HasValue()) return this._i.GetStringValue();
            else return null;
        }
        /// <summary>
        /// Сброс значения свойства
        /// </summary>
        public void ResetValue() => this._i.ResetValue();
        /// <summary>
        /// Проверка, имеет ли свойство какое-либо значение
        /// </summary>
        /// <returns></returns>
        public bool HasValue => this._i.HasValue();
        /// <summary>
        /// Получение значения свойства как величины угла
        /// </summary>
        /// <param name="AngleUnit">Параметр Renga.AngleUnit как единица измерения угловой меры</param>
        /// <returns></returns>
        public double GetAngleValue(object AngleUnit)
        {
            if (this._i.HasValue()) return this._i.GetAngleValue((Renga.AngleUnit)AngleUnit);
            else return double.NaN;
        }
        /// <summary>
        /// Получение булева значения свойства
        /// </summary>
        /// <returns></returns>
        public object GetBooleanValue()
        {
            if (this._i.HasValue()) return this._i.GetBooleanValue();
            else return null;
        }
        /// <summary>
        /// Получение строкового представления свойства как одного из заложенных значений Enumaration
        /// </summary>
        /// <returns></returns>
        public string GetEnumerationValue()
        {
            if (this._i.HasValue()) return this._i.GetEnumerationValue();
            else return null;
        }
        /// <summary>
        /// Получение целочисленного значения свойства
        /// </summary>
        /// <returns></returns>
        public int GetIntegerValue()
        {
            if (this._i.HasValue()) return this._i.GetIntegerValue();
            else return -1000000;
        }
        /// <summary>
        /// Получение значения свойства как меры длины
        /// </summary>
        /// <param name="LengthUnit">Параметр Renga.LengthUnit как единица измерения длины</param>
        /// <returns></returns>
        public double GetLengthValue(object LengthUnit)
        {
            if (this._i.HasValue()) return this._i.GetLengthValue((Renga.LengthUnit)LengthUnit);
            else return double.NaN;
        }
        /// <summary>
        /// Получение логического значения свойства. Смотри нод Other.RengaSimpleInterfaces.GetLogicalValue
        /// </summary>
        /// <returns></returns>
        public object GetLogicalValue()
        {
            if (this._i.HasValue()) return this._i.GetLogicalValue();
            else return null;
        }
        /// <summary>
        /// Получение значения свойства как массы
        /// </summary>
        /// <param name="MassUnit">Параметр Renga.MassUnit как единица измерения массы</param>
        /// <returns></returns>
        public double GetMassValue(object MassUnit)
        {
            if (this._i.HasValue()) return this._i.GetMassValue((Renga.MassUnit)MassUnit);
            else return double.NaN;
        }
        public double GetVolumeValue(object VolumeUnit)
        {
            if (this._i.HasValue()) return this._i.GetVolumeValue((Renga.VolumeUnit)VolumeUnit);
            else return double.NaN;
        }
        //Setting
        public void SetDoubleValue(double value_double)
        {
            this._i.SetDoubleValue(value_double);
        }
        public void SetStringValue(string value_string)
        {
            this._i.SetStringValue(value_string);
        }
        public void SetAngleValue (Renga.AngleUnit angle_unit, double angle_double)
        {
            this._i.SetAngleValue(angle_double, angle_unit);
        }
        public void SetAreaValue (Renga.AreaUnit area_unit, double area_double)
        {
            this._i.SetAreaValue(area_double, area_unit);
        }
        public void SetBooleanValue (bool value_bool)
        {
            this._i.SetBooleanValue(value_bool);
        }
        public void SetEnumerationValue (string value_string)
        {
            this._i.SetEnumerationValue(value_string);
        }
        public void SetIntegerValue (int value_int)
        {
            this._i.SetIntegerValue(value_int);
        }
        public void SetLengthValue (Renga.LengthUnit length_unit, double value_double)
        {
            this._i.SetLengthValue(value_double, length_unit);
        }
        public void SetLogicalValue (bool logic_value)
        {
            if (logic_value == true) this._i.SetLogicalValue(Renga.Logical.Logical_True);
            else this._i.SetLogicalValue(Renga.Logical.Logical_False);
        }
        public void SetMassValue (Renga.MassUnit mass_unit, double value_double)
        {
            this._i.SetMassValue(value_double, mass_unit);
        }
        public void SetVolumeValue (Renga.VolumeUnit volume_unit, double value_double)
        {
            this._i.SetVolumeValue(value_double, volume_unit);
        }
    }
}
