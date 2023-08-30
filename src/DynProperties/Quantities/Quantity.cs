using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynProperties.Quantities
{
    /// <summary>
    /// Класс для работы с отдельными расчетными свойствами Renga.IQuantity
    /// </summary>
    public class Quantity
    {
        public Renga.IQuantity _i;
        /// <summary>
        /// Инициализация расчетного свойства из интерфейса Renga.IQuantity
        /// </summary>
        /// <param name="renga_Quantity_obj"></param>
        internal Quantity(object renga_Quantity_obj)
        {
            this._i = renga_Quantity_obj as Renga.IQuantity;
        }
        /// <summary>
        /// Получение расшифровки для типа расчетного параметра
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeAsString(object type)
        {
            IEnumerable<KeyValuePair<string, object>> data = 
                QuantityTypes().Where(a => (QuantityType)a.Value == (QuantityType)type);
            if (data.Any())
            {
                return data.First().Key;
            }
            else return null;
        }
        /// <summary>
        /// Получение Guid-идентиикатора расчетного свойства. За расшифровкой 
        /// см. нод Quantity.GetTypeAsString
        /// </summary>
        /// <returns></returns>
        public object Type => this._i.Type;
        /// <summary>
        /// Проверка, имеет ли расчетный параметр значение
        /// </summary>
        /// <returns></returns>
        public bool HasValue => this._i.HasValue();
        /// <summary>
        /// Получение значения расчетного параметра как целочисленного значения (int)
        /// </summary>
        /// <returns></returns>
        public int AsCount()
        {
            if (this._i.HasValue()) return this._i.AsCount();
            else return -1;
        }
        /// <summary>
        /// Получение значения расчетного параметра как длины, с пользовательской мерой длины
        /// </summary>
        /// <param name="length_unit"></param>
        /// <returns></returns>
        public double AsLength(Renga.LengthUnit length_unit)
        {
            if (this._i.HasValue()) return this._i.AsLength(length_unit);
            else return -1d;
        }
        /// <summary>
        /// Получение значения расчетного параметра как площади, с пользовательской мерой площади
        /// </summary>
        /// <param name="area_unit"></param>
        /// <returns></returns>
        public double AsArea(Renga.AreaUnit area_unit)
        {
            if (this._i.HasValue()) return this._i.AsArea(area_unit);
            else return -1d;
        }
        /// <summary>
        /// Получение значения расчетного параметра как объема, с пользовательской мерой объема
        /// </summary>
        /// <param name="volume_unit"></param>
        /// <returns></returns>
        public double AsVolume(Renga.VolumeUnit volume_unit)
        {
            if (this._i.HasValue()) return this._i.AsVolume(volume_unit);
            else return -1d;
        }
        /// <summary>
        /// Получение значения расчетного параметра как массы, с пользовательской мерой массы
        /// </summary>
        /// <param name="mass_unit"></param>
        /// <returns></returns>
        public double AsMass(Renga.MassUnit mass_unit)
        {
            if (this._i.HasValue()) return this._i.AsMass(mass_unit);
            else return -1d;
        }
        /// <summary>
        /// Получает значение расчетного свойства с единицами измерения по умолчанию:
        /// длина - метры, площадь - кв.м., объем - куб.м., масса - кг.
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            QuantityType type = this._i.Type;

            LengthUnit len = LengthUnit.LengthUnit_Meters;
            AreaUnit area = AreaUnit.AreaUnit_Meters2;
            VolumeUnit vol = VolumeUnit.VolumeUnit_Meters3;
            MassUnit mass = MassUnit.MassUnit_Kilograms;

            switch (type)
            {
                case QuantityType.QuantityType_Unknown: return -1d; ;
                case QuantityType.QuantityType_Count: return this._i.AsCount();
                case QuantityType.QuantityType_Length: return this._i.AsLength(len);
                case QuantityType.QuantityType_Area: return this._i.AsArea(area);
                case QuantityType.QuantityType_Volume: return this._i.AsVolume(vol);
                case QuantityType.QuantityType_Mass: return this._i.AsMass(mass);
            }
            return double.NaN;
        }
        //Enums
        /// <summary>
        /// Типы для QuantityType (расчетных параметров)
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "QuantityType_Unknown", "QuantityType_Count", "QuantityType_Length",
            "QuantityType_Area","QuantityType_Volume","QuantityType_Mass"})]
        public static Dictionary<string, object> QuantityTypes()
        {
            return new Dictionary<string, object>
                {
                    {"QuantityType_Unknown", QuantityType.QuantityType_Unknown },
                    {"QuantityType_Count", QuantityType.QuantityType_Count },
                    {"QuantityType_Length", QuantityType.QuantityType_Length },
                    {"QuantityType_Area", QuantityType.QuantityType_Area },
                    {"QuantityType_Volume", QuantityType.QuantityType_Volume },
                    {"QuantityType_Mass", QuantityType.QuantityType_Mass }
                };
        }
        
    }
}
