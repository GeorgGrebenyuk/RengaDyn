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
    [dr.IsVisibleInDynamoLibrary(false)]
    public static class Technical
    {
        //public static string GetStrFromDictionary (Dictionary<string,object> dict, object to_find)
        //{
        //    IEnumerable<KeyValuePair<string, object>> data = dict.Where(a => a.Value == to_find);
        //    if (data.Any()) return data.First().Key;
        //    else return null;
        //}
    }
}
