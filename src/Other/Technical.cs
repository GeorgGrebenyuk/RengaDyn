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
    public class Technical
    {
        private Technical() { }
        /// <summary>
        /// Проверяет на существование (!= null) внутреннего интерфейса для данного класса
        /// </summary>
        /// <param name="ClassForCheck"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CheckIsNotNull (dynamic ClassForCheck)
        {
            bool status = false;
            try
            {
                var internal_interface = ClassForCheck._i;
                if (internal_interface == null) status = false;
                else status = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Object has not _i field");
            }
            return status;
        }
    }
}
