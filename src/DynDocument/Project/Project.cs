using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument.Project
{
    /// <summary>
    /// Класс для работы с проектом Renga, интерфейсом Renga.IProject
    /// </summary>
    public class Project
    {
        public Renga.IProject _i;
        /// <summary>
        /// Получает текущий проект (интерфейс Renga.Project) от интерфейса Renga.IApplication
        /// </summary>
        /// <param name="renga_application"></param>
        public Project(Application renga_application)
        {
            this._i = renga_application._i.Project;
        }
        /// <summary>
        /// Получение файлового пути, по которому сохранен текущий проект или null если он не сохранен
        /// </summary>
        /// <returns>Строковый файловый путь</returns>
        public string FilePath => this._i.FilePath;
        /// <summary>
        /// Получение инфрмации о проекте ProjectInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public ProjectInfo IProjectInfo => new ProjectInfo(this._i.ProjectInfo);
        /// <summary>
        /// Получение инфрмации о здании BuildingInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public BuildingInfo IBuildingInfo => new BuildingInfo( this._i.BuildingInfo);
        /// <summary>
        /// Получение инфрмации об участке LandPlotInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public LandPlotInfo ILandPlotInfo => new LandPlotInfo(this._i.LandPlotInfo);
        /// <summary>
        /// Стили аксессуаров для труб.
        /// </summary>
        public EntityCollection PipeAccessoryStyles => new EntityCollection(this._i.PipeAccessoryStyles);
        /// <summary>
        /// Стили труб
        /// </summary>
        public EntityCollection PipeStyles => new EntityCollection(this._i.PipeStyles);
        /// <summary>
        /// Стили трубопроводных фитингов
        /// </summary>
        public EntityCollection PipeFittingStyles => new EntityCollection(this._i.PipeFittingStyles);
        /// <summary>
        /// Стили механического оборудования
        /// </summary>
        public EntityCollection MechanicalEquipmentStyles => new EntityCollection(this._i.MechanicalEquipmentStyles);
        /// <summary>
        /// Сттили воздуховодов
        /// </summary>
        public EntityCollection DuctStyles => new EntityCollection(this._i.DuctStyles);
        /// <summary>
        /// Стили фитингов воздуховодов
        /// </summary>
        public EntityCollection DuctFittingStyles => new EntityCollection(this._i.DuctFittingStyles);
        /// <summary>
        /// Стили аксесуаров воздуховодов
        /// </summary>
        public EntityCollection DuctAccessoryStyles => new EntityCollection(this._i.DuctAccessoryStyles);
        /// <summary>
        /// Стили осветительных приборов
        /// </summary>
        public EntityCollection LightFixtureStyles => new EntityCollection(this._i.LightFixtureStyles);
        /// <summary>
        /// Стили аксессуаров электрического оборудования
        /// </summary>
        public EntityCollection WiringAccessoryStyles => new EntityCollection(this._i.WiringAccessoryStyles);
        /// <summary>
        /// Стили электрических распределительных щитков
        /// </summary>
        public EntityCollection ElectricDistributionBoardStyles => new EntityCollection(this._i.ElectricDistributionBoardStyles);
        /// <summary>
        /// Стили электрических проводников
        /// </summary>
        public EntityCollection ElectricalConductorStyles => new EntityCollection(this._i.ElectricalConductorStyles);
        /// <summary>
        /// Стили линий электрических
        /// </summary>
        public EntityCollection ElectricalCircuitLineStyles => new EntityCollection(this._i.ElectricalCircuitLineStyles);
        /// <summary>
        /// Стили инженерных систем
        /// </summary>
        public EntityCollection SystemStyles => new EntityCollection(this._i.SystemStyles);
        /// <summary>
        /// Стили сантехнических приспособлений
        /// </summary>
        public EntityCollection PlumbingFixtureStyles => new EntityCollection(this._i.PlumbingFixtureStyles);
        /// <summary>
        /// Стили оборудования
        /// </summary>
        public EntityCollection EquipmentStyles => new EntityCollection(this._i.EquipmentStyles);
        /// <summary>
        /// Сборки
        /// </summary>
        public EntityCollection Assemblies => new EntityCollection(this._i.Assemblies);
        /// <summary>
        /// Чертежи
        /// </summary>
        public EntityCollection Drawings2 => new EntityCollection(this._i.Drawings2);
        /// <summary>
        /// Стили элементов
        /// </summary>
        public EntityCollection ElementStyles => new EntityCollection(this._i.ElementStyles);
        /// <summary>
        /// Стили балок
        /// </summary>
        public EntityCollection BeamStyles => new EntityCollection(this._i.BeamStyles);
        /// <summary>
        /// Стили колонн
        /// </summary>
        public EntityCollection ColumnStyles => new EntityCollection(this._i.ColumnStyles);
        /// <summary>
        /// Стили пластин
        /// </summary>
        public EntityCollection PlateStyles => new EntityCollection(this._i.PlateStyles);
        /// <summary>
        /// Материалы
        /// </summary>
        public EntityCollection Materials => new EntityCollection(this._i.Materials);
        /// <summary>
        /// Стили окон
        /// </summary>
        public EntityCollection WindowStyles => new EntityCollection(this._i.WindowStyles);
        /// <summary>
        /// Стили дверей
        /// </summary>
        public EntityCollection DoorStyles => new EntityCollection(this._i.DoorStyles);
        /// <summary>
        /// Список многослойных материалов
        /// </summary>
        public EntityCollection LayeredMaterials => new EntityCollection(this._i.LayeredMaterials);
        /// <summary>
        /// Профили
        /// </summary>
        public EntityCollection Profiles => new EntityCollection(this._i.Profiles);
        /// <summary>
        /// Спецификации
        /// </summary>
        public EntityCollection Topics => new EntityCollection(this._i.Topics);
        /// <summary>
        /// Стили листов
        /// </summary>
        public EntityCollection LayoutStyles => new EntityCollection(this._i.LayoutStyles);
        /// <summary>
        /// Стили номеров страниц
        /// </summary>
        public EntityCollection PageFormatStyles => new EntityCollection(this._i.PageFormatStyles);
        public EntityCollection Drawings => new EntityCollection(this._i.Drawings);
    }
    
}
