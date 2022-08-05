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
    public class Property : Other.Technical.ICOM_Tools
    {
        public Renga.IProperty prop;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IProperty (получение свойства)
        /// </summary>
        /// <param name="Property_obj"></param>
        public Property(object Property_obj)
        {
            this.prop = Property_obj as Renga.IProperty;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.prop == null) return false;
            else return true;
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
        /// Получение строковой расшифровки свойства Renga
        /// </summary>
        /// <returns></returns>
        public string GetTypeAsString()
        {
           return PropertyTypes().Where(a => ((Renga.PropertyType)a.Value) == this.prop.Type).First().Key;           
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
        public object Type => this.prop.Type;
        /// <summary>
        /// Получение значения свойства для фиксированных типов СИ (метры, кв.м, кг)
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            object value = null;
            if (this.prop.HasValue())
            {
                switch (this.prop.Type)
                {
                    case PropertyType.PropertyType_Undefined:
                        value = this.prop.GetStringValue();
                    break;
                    case PropertyType.PropertyType_Double:
                        value = this.prop.GetDoubleValue();
                        break;
                    case PropertyType.PropertyType_String:
                        value = this.prop.GetStringValue();
                        break;
                    case PropertyType.PropertyType_Angle:
                        value = this.prop.GetAngleValue(Renga.AngleUnit.AngleUnit_Degrees);
                        break;
                    case PropertyType.PropertyType_Area:
                        value = this.prop.GetAreaValue(Renga.AreaUnit.AreaUnit_Meters2);
                        break;
                    case PropertyType.PropertyType_Boolean:
                        value = this.prop.GetBooleanValue();
                        break;
                    case PropertyType.PropertyType_Enumeration:
                        value = this.prop.GetEnumerationValue();
                        break;
                    case PropertyType.PropertyType_Integer:
                        value = this.prop.GetIntegerValue();
                        break;
                    case PropertyType.PropertyType_Length:
                        value = this.prop.GetLengthValue(Renga.LengthUnit.LengthUnit_Meters);
                        break;
                    case PropertyType.PropertyType_Logical:
                        value = this.prop.GetLogicalValue();
                        break;
                    case PropertyType.PropertyType_Mass:
                        value = this.prop.GetMassValue(Renga.MassUnit.MassUnit_Kilograms);
                        break;
                    case PropertyType.PropertyType_Volume:
                        value = this.prop.GetVolumeValue(Renga.VolumeUnit.VolumeUnit_Meters3);
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
        public string Name => this.prop.Name;
        /// <summary>
        /// Получение Guid-идентификатора свойства
        /// </summary>
        /// <returns></returns>
        public Guid Id => this.prop.Id;
        /// <summary>
        /// Получение значения свойства как дробного числа double
        /// </summary>
        /// <returns></returns>
        public double GetDoubleValue()
        {
            if (this.prop.HasValue()) return this.prop.GetDoubleValue();
            else return double.NaN;
        }
        /// <summary>
        /// Получение значения свойства как строкового представления
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            if (this.prop.HasValue()) return this.prop.GetStringValue();
            else return null;
        }
        /// <summary>
        /// Сброс значения свойства
        /// </summary>
        public void ResetValue() => this.prop.ResetValue();
        /// <summary>
        /// Проверка, имеет ли свойство какое-либо значение
        /// </summary>
        /// <returns></returns>
        public bool HasValue => this.prop.HasValue();
        /// <summary>
        /// Получение значения свойства как величины угла
        /// </summary>
        /// <param name="AngleUnit">Параметр Renga.AngleUnit как единица измерения угловой меры</param>
        /// <returns></returns>
        public double GetAngleValue(object AngleUnit)
        {
            if (this.prop.HasValue()) return this.prop.GetAngleValue((Renga.AngleUnit)AngleUnit);
            else return double.NaN;
        }
        /// <summary>
        /// Получение булева значения свойства
        /// </summary>
        /// <returns></returns>
        public object GetBooleanValue()
        {
            if (this.prop.HasValue()) return this.prop.GetBooleanValue();
            else return null;
        }
        /// <summary>
        /// Получение строкового представления свойства как одного из заложенных значений Enumaration
        /// </summary>
        /// <returns></returns>
        public string GetEnumerationValue()
        {
            if (this.prop.HasValue()) return this.prop.GetEnumerationValue();
            else return null;
        }
        /// <summary>
        /// Получение целочисленного значения свойства
        /// </summary>
        /// <returns></returns>
        public int GetIntegerValue()
        {
            if (this.prop.HasValue()) return this.prop.GetIntegerValue();
            else return -1000000;
        }
        /// <summary>
        /// Получение значения свойства как меры длины
        /// </summary>
        /// <param name="LengthUnit">Параметр Renga.LengthUnit как единица измерения длины</param>
        /// <returns></returns>
        public double GetLengthValue(object LengthUnit)
        {
            if (this.prop.HasValue()) return this.prop.GetLengthValue((Renga.LengthUnit)LengthUnit);
            else return double.NaN;
        }
        /// <summary>
        /// Получение логического значения свойства. Смотри нод Other.RengaSimpleInterfaces.GetLogicalValue
        /// </summary>
        /// <returns></returns>
        public object GetLogicalValue()
        {
            if (this.prop.HasValue()) return this.prop.GetLogicalValue();
            else return null;
        }
        /// <summary>
        /// Получение значения свойства как массы
        /// </summary>
        /// <param name="MassUnit">Параметр Renga.MassUnit как единица измерения массы</param>
        /// <returns></returns>
        public double GetMassValue(object MassUnit)
        {
            if (this.prop.HasValue()) return this.prop.GetMassValue((Renga.MassUnit)MassUnit);
            else return double.NaN;
        }
        public double GetVolumeValue(object VolumeUnit)
        {
            if (this.prop.HasValue()) return this.prop.GetVolumeValue((Renga.VolumeUnit)VolumeUnit);
            else return double.NaN;
        }
        //Setting
        public void SetDoubleValue(double value_double)
        {
            this.prop.SetDoubleValue(value_double);
        }
        public void SetStringValue(string value_string)
        {
            this.prop.SetStringValue(value_string);
        }
        public void SetAngleValue (Renga.AngleUnit angle_unit, double angle_double)
        {
            this.prop.SetAngleValue(angle_double, angle_unit);
        }
        public void SetAreaValue (Renga.AreaUnit area_unit, double area_double)
        {
            this.prop.SetAreaValue(area_double, area_unit);
        }
        public void SetBooleanValue (bool value_bool)
        {
            this.prop.SetBooleanValue(value_bool);
        }
        public void SetEnumerationValue (string value_string)
        {
            this.prop.SetEnumerationValue(value_string);
        }
        public void SetIntegerValue (int value_int)
        {
            this.prop.SetIntegerValue(value_int);
        }
        public void SetLengthValue (Renga.LengthUnit length_unit, double value_double)
        {
            this.prop.SetLengthValue(value_double, length_unit);
        }
        public void SetLogicalValue (bool logic_value)
        {
            if (logic_value == true) this.prop.SetLogicalValue(Renga.Logical.Logical_True);
            else this.prop.SetLogicalValue(Renga.Logical.Logical_False);
        }
        public void SetMassValue (Renga.MassUnit mass_unit, double value_double)
        {
            this.prop.SetMassValue(value_double, mass_unit);
        }
        public void SetVolumeValue (Renga.VolumeUnit volume_unit, double value_double)
        {
            this.prop.SetVolumeValue(value_double, volume_unit);
        }
    }
}
