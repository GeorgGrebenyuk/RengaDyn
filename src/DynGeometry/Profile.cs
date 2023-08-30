using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

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
        public object Parameters => this._i.Parameters;
        /// <summary>
        /// Получение списка интерфейсов Renga.IRegion2D из данного профиля
        /// </summary>
        /// <returns></returns>
        public List<Region2D> Regions()
        {
            List<Region2D> regs = new List<Region2D>();
            Renga.IRegion2DCollection coll = this._i.Regions;
            for (int i = 0; i < coll.Count; i++)
            {
                regs.Add(new Region2D(coll.Get(i)));
            }
            return regs;
        }
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
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IProfileDescription
    /// </summary>
    public class ProfileDescription
    {
        public Renga.IProfileDescription _i;
        /// <summary>
        /// Инициализация интерфейса Renga.IProfileDescription (описание профиля)
        /// </summary>
        /// <param name="ProfileDescription_object"></param>
        internal ProfileDescription(object ProfileDescription_object)
        {
            this._i = ProfileDescription_object as Renga.IProfileDescription;
        }
        /// <summary>
        /// Получение и инициализация интерфйеса Renga.IProfileDescription по идентификатору описания
        /// (полученного из свойства IProfile)
        /// </summary>
        /// <param name="renga_project"></param>
        /// <param name="ProfileDescription_id"></param>
        public ProfileDescription(DynDocument.Project.Project renga_project, int ProfileDescription_id)
        {
            Renga.IProfileDescriptionManager _i = renga_project._i.ProfileDescriptionManager;
            this._i = _i.GetProfileDescription(ProfileDescription_id);
        }
        /// <summary>
        /// Получение всех интерфейсов Renga.IProfileDescription из проекта
        /// </summary>
        /// <param name="renga_project"></param>
        /// <returns></returns>
        public static List<ProfileDescription> GetAllProfileDescriptions(DynDocument.Project.Project renga_project)
        {
            List<ProfileDescription> objs = new List<ProfileDescription>();
            Renga.IProfileDescriptionManager _i = renga_project._i.ProfileDescriptionManager;
            List<int> ids = _i.GetIds().OfType<int>().ToList();
            foreach (int id in ids)
            {
                objs.Add(new ProfileDescription(_i.GetProfileDescription(id)));
            }
            return objs;
        }
        //properties
        /// <summary>
        /// Получение целочисленного идентификатора данного описания профиля
        /// </summary>
        /// <returns></returns>
        public int Id => this._i.Id;
        /// <summary>
        /// Получение строкого наименования данного описания профиля
        /// </summary>
        /// <returns></returns>
        public string Name => this._i.Name;
    }
}
