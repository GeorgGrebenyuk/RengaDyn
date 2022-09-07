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
    public class Project : Other.Technical.ICOM_Tools
    {
        public Renga.IProject project;
        /// <summary>
        /// Получает текущий проект (интерфейс Renga.Project) от интерфейса Renga.IApplication
        /// </summary>
        /// <param name="renga_application"></param>
        public Project(Application renga_application)
        {

            this.project = renga_application.renga_app.Project;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.project == null) return false;
            else return true;
        }
        /// <summary>
        /// Получение файлового пути, по которому сохранен текущий проект или null если он не сохранен
        /// </summary>
        /// <returns>Строковый файловый путь</returns>
        public string FilePath => this.project.FilePath;
        /// <summary>
        /// Получение инфрмации о проекте ProjectInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object IProjectInfo => this.project.ProjectInfo;
        /// <summary>
        /// Получение инфрмации о здании BuildingInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object IBuildingInfo => this.project.BuildingInfo;
        /// <summary>
        /// Получение инфрмации об участке LandPlotInfo, в виде интерфейса IPropertyContainer
        /// </summary>
        /// <returns></returns>
        public object ILandPlotInfo => this.project.LandPlotInfo;
        /// <summary>
        /// Стили аксессуаров для труб.
        /// </summary>
        public object PipeAccessoryStyles => this.project.PipeAccessoryStyles;
        /// <summary>
        /// Стили труб
        /// </summary>
        public object PipeStyles => this.project.PipeStyles;
        /// <summary>
        /// Стили трубопроводных фитингов
        /// </summary>
        public object PipeFittingStyles => this.project.PipeFittingStyles;
        /// <summary>
        /// Стили механического оборудования
        /// </summary>
        public object MechanicalEquipmentStyles => this.project.MechanicalEquipmentStyles;
        /// <summary>
        /// Сттили воздуховодов
        /// </summary>
        public object DuctStyles => this.project.DuctStyles;
        /// <summary>
        /// Стили фитингов воздуховодов
        /// </summary>
        public object DuctFittingStyles => this.project.DuctFittingStyles;
        /// <summary>
        /// Стили аксесуаров воздуховодов
        /// </summary>
        public object DuctAccessoryStyles => this.project.DuctAccessoryStyles;
        /// <summary>
        /// Стили осветительных приборов
        /// </summary>
        public object LightFixtureStyles => this.project.LightFixtureStyles;
        /// <summary>
        /// Стили аксессуаров электрического оборудования
        /// </summary>
        public object WiringAccessoryStyles => this.project.WiringAccessoryStyles;
        /// <summary>
        /// Стили электрических распределительных щитков
        /// </summary>
        public object ElectricDistributionBoardStyles => this.project.ElectricDistributionBoardStyles;
        /// <summary>
        /// Стили электрических проводников
        /// </summary>
        public object ElectricalConductorStyles => this.project.ElectricalConductorStyles;
        /// <summary>
        /// Стили линий электрических
        /// </summary>
        public object ElectricalCircuitLineStyles => this.project.ElectricalCircuitLineStyles;
        /// <summary>
        /// Стили инженерных систем
        /// </summary>
        public object SystemStyles => this.project.SystemStyles;
        /// <summary>
        /// Стили сантехнических приспособлений
        /// </summary>
        public object PlumbingFixtureStyles => this.project.PlumbingFixtureStyles;
        /// <summary>
        /// Стили оборудования
        /// </summary>
        public object EquipmentStyles => this.project.EquipmentStyles;
        /// <summary>
        /// Сборки
        /// </summary>
        public object Assemblies => this.project.Assemblies;
        /// <summary>
        /// Чертежи
        /// </summary>
        public object Drawings2 => this.project.Drawings2;
        /// <summary>
        /// Стили элементов
        /// </summary>
        public object ElementStyles => this.project.ElementStyles;
        /// <summary>
        /// Стили балок
        /// </summary>
        public object BeamStyles => this.project.BeamStyles;
        /// <summary>
        /// Стили колонн
        /// </summary>
        public object ColumnStyles => this.project.ColumnStyles;
        /// <summary>
        /// Стили пластин
        /// </summary>
        public object PlateStyles => this.project.PlateStyles;
        /// <summary>
        /// Материалы
        /// </summary>
        public object Materials => this.project.Materials;
        /// <summary>
        /// Стили окон
        /// </summary>
        public object WindowStyles => this.project.WindowStyles;
        /// <summary>
        /// Стили дверей
        /// </summary>
        public object DoorStyles => this.project.DoorStyles;
        /// <summary>
        /// Список многослойных материалов
        /// </summary>
        public object LayeredMaterials => this.project.LayeredMaterials;
        /// <summary>
        /// Профили
        /// </summary>
        public object Profiles => this.project.Profiles;
        /// <summary>
        /// Спецификации
        /// </summary>
        public object Topics => this.project.Topics;
        /// <summary>
        /// Стили листов
        /// </summary>
        public object LayoutStyles => this.project.LayoutStyles;
        /// <summary>
        /// Стили номеров страниц
        /// </summary>
        public object PageFormatStyles => this.project.PageFormatStyles;
        public object Drawings => this.project.Drawings;
    }
    
}
