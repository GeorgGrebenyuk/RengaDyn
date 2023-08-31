using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using DynRenga.DynProperties.Parameters;

namespace DynRenga.DynGeometry
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IProfile (свойственного балке и пластине)
    /// </summary>
    public class Profile
    {
        public Renga.IProfile _i;
        /// <summary>
        /// Инициализация интерфейса Renga.IProfile
        /// </summary>
        /// <param name="Profile_object"></param>
        internal Profile (object Profile_object)
        {
            this._i = Profile_object as Renga.IProfile;
        }
        //properties
        /// <summary>
        /// Получение идентификатора описания свойства
        /// </summary>
        /// <returns></returns>
        public int DescriptionId => this._i.DescriptionId;
        /// <summary>
        /// Получение набора параметров (интерфейса IParameterContainer)
        /// </summary>
        /// <returns></returns>
        public ParameterContainer Parameters => new ParameterContainer(this._i.Parameters);
        /// <summary>
        /// Получение списка интерфейсов Renga.IRegion2D из данного профиля
        /// </summary>
        /// <returns></returns>
        public Region2DCollection Regions => new Region2DCollection(this._i.Regions);
        //functions
        /// <summary>
        /// Получение центра масс профиля
        /// </summary>
        /// <returns></returns>
        public dg.Point GetCenterOfMass()
        {
            Renga.Point2D p = this._i.GetCenterOfMass();
            return dg.Point.ByCoordinates(p.X, p.Y, 0d);
        }
    }
    
}
