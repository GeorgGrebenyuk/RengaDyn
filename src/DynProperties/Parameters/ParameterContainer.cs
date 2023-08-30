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
    /// Класс для работы с группой параметров (интерфейсом Renga.IParameterContainer)
    /// </summary>
    public class ParameterContainer
    {
        public Renga.IParameterContainer _i;
        /// <summary>
        /// Инициация класса из интерфейса Renga.IParameterContainer
        /// </summary>
        /// <param name="ParameterContainer_obj"></param>
        internal ParameterContainer (object ParameterContainer_obj)
        {
            this._i = ParameterContainer_obj as Renga.IParameterContainer;
        }
        /// <summary>
        /// Получение набора идентификаторов отдельных параметров как сущности Renga.IGuidCollection
        /// </summary>
        /// <returns></returns>
        public Other.GuidCollection GetIds => new Other.GuidCollection(this._i.GetIds());
        /// <summary>
        /// Проверка, содержит ли данный набор параметров нужный параметр по его Guid-идентификатору
        /// </summary>
        /// <param name="parameter_guid"></param>
        /// <returns></returns>
        public bool Contains(Guid parameter_guid)
        {
            return this._i.Contains(parameter_guid);
        }
        /// <summary>
        /// Получение отдельного параметра (интерфейса Renga.IParameter) по его Guid-идентификатору
        /// </summary>
        /// <param name="parameter_guid"></param>
        /// <returns></returns>
        public Parameter Get (Guid parameter_guid)
        {
            return new Parameter(this._i.Get(parameter_guid));
        }
        //My
        /// <summary>
        /// Получение всех параметров в виде интерфейсов Renga.IParameter 
        /// включая их Guid-идентификаторы
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Parameters_id", "Parameters_object" })]
        public Dictionary<string, object> GetParameters()
        {
            Renga.IGuidCollection coll = this._i.GetIds();
            List<Guid> ids = new List<Guid>();
            List<Parameter> objs = new List<Parameter>();
            for (int i = 0; i < coll.Count; i++)
            {
                ids.Add(coll.Get(i));
                objs.Add(new Parameter(this._i.Get(coll.Get(i))));
            }
            return new Dictionary<string, object>()
            {
                {"Parameters_id",ids },
                {"Parameters_object",objs }
            };
        }
    }
}
