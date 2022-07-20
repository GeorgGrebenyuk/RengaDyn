using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynStyles
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IPlumbingFixtureStyle, стиля сантехнического оборудования
    /// </summary>
    public class PlumbingFixtureStyle
    {
        public Renga.IPlumbingFixtureStyle pl_style;
        /// <summary>
        /// Инициация класса через интерфейс Renga.IPlumbingFixtureStyle
        /// </summary>
        /// <param name="PlumbingFixtureStyle_object"></param>
        public PlumbingFixtureStyle (object PlumbingFixtureStyle_object)
        {
            this.pl_style = PlumbingFixtureStyle_object as Renga.IPlumbingFixtureStyle;
        }
        /// <summary>
        /// Получение имени стиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.pl_style.Name;
        }
        /// <summary>
        /// Получение строкового типа оборудования (Renga.PlumbingFixtureCategory)
        /// </summary>
        /// <returns></returns>
        public string GetCategory()
        {
            return PlumbingFixtureCategoies().Where(a => (Renga.PlumbingFixtureCategory)a.Value == this.pl_style.Category).First().Key;
        }
        /// <summary>
        /// Типы сантехнического оборудования
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string,object> PlumbingFixtureCategoies()
        {
            return new Dictionary<string, object>()
            {
                {"Unknown", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Other  },
                {"ToiletPan", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_ToiletPan  },
                {"WashBasin", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_WashBasin  },
                {"Bath", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Bath  },
                {"Sink", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Sink  },
                {"Shower", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Shower  },
                {"FloorDrain", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_FloorDrain  },
                {"RoofDrain", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_RoofDrain  },
                {"Bidet", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Bidet  },
                {"Urinal", Renga.PlumbingFixtureCategory.PlumbingFixtureCategory_Urinal  }
            };
        }
    }
}
