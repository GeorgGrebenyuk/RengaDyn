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
        public Renga.IProfile profile;
        /// <summary>
        /// Инициализация интерфейса Renga.IProfile
        /// </summary>
        /// <param name="Profile_object"></param>
        public Profile (object Profile_object)
        {
            this.profile = Profile_object as Renga.IProfile;
        }
        //properties
        /// <summary>
        /// Получение идентификатора описания свойства
        /// </summary>
        /// <returns></returns>
        public int DescriptionId()
        {
            return this.profile.DescriptionId;
        }
        /// <summary>
        /// Получение набора параметров (интерфейса IParameterContainer)
        /// </summary>
        /// <returns></returns>
        public object Parameters()
        {
            return this.profile.Parameters;
        }
        /// <summary>
        /// Получение списка интерфейсов Renga.IRegion2D из данного профиля
        /// </summary>
        /// <returns></returns>
        public List<object> Regions()
        {
            List<object> regs = new List<object>();
            Renga.IRegion2DCollection coll = this.profile.Regions;
            for (int i = 0; i < coll.Count; i++)
            {
                regs.Add(coll.Get(i));
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
            Renga.Point2D p = this.profile.GetCenterOfMass();
            return dg.Point.ByCoordinates(p.X, p.Y, 0d);
        }
    }
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IProfileDescription
    /// </summary>
    public class ProfileDescription
    {
        public Renga.IProfileDescription pr_d;
        /// <summary>
        /// Инициализация интерфейса Renga.IProfileDescription (описание профиля)
        /// </summary>
        /// <param name="ProfileDescription_object"></param>
        public ProfileDescription(object ProfileDescription_object)
        {
            this.pr_d = ProfileDescription_object as Renga.IProfileDescription;
        }
        /// <summary>
        /// Получение и инициализация интерфйеса Renga.IProfileDescription по идентификатору описания
        /// (полученного из свойства IProfile)
        /// </summary>
        /// <param name="renga_project"></param>
        /// <param name="ProfileDescription_id"></param>
        public ProfileDescription(DynDocument.Project.Project renga_project, int ProfileDescription_id)
        {
            Renga.IProfileDescriptionManager man = renga_project.project.ProfileDescriptionManager;
            this.pr_d = man.GetProfileDescription(ProfileDescription_id);
        }
        /// <summary>
        /// Получение всех интерфейсов Renga.IProfileDescription из проекта
        /// </summary>
        /// <param name="renga_project"></param>
        /// <returns></returns>
        public static List<object> GetAllProfileDescriptions(DynDocument.Project.Project renga_project)
        {
            List<object> objs = new List<object>();
            Renga.IProfileDescriptionManager man = renga_project.project.ProfileDescriptionManager;
            List<int> ids = man.GetIds().OfType<int>().ToList();
            foreach (int id in ids)
            {
                objs.Add(man.GetProfileDescription(id));
            }
            return objs;
        }
        //properties
        /// <summary>
        /// Получение целочисленного идентификатора данного описания профиля
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return this.pr_d.Id;
        }
        /// <summary>
        /// Получение строкого наименования данного описания профиля
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.pr_d.Name;
        }
    }
}
