using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynDocument
{
    /// <summary>
    /// Функции и методы для экспорта данных
    /// </summary>
    public class DynExport
    {
        private DynExport() { }
        /// <summary>
        /// Доступные форматы DWG/DXF для экспорта модели
        /// </summary>
        /// <returns>Словарь с форматами</returns>
        [dr.MultiReturn(new[] { "v2000", "v2004", "v2007", "v2010", "v2013", "v2018" })]
        public static Dictionary<string, object> AcadExportFormats()
        {
            return new Dictionary<string, object>
            {
                {"v2000", Renga.AutocadVersion.AutocadVersion_v2000 },
                {"v2004", Renga.AutocadVersion.AutocadVersion_v2004 },
                {"v2007", Renga.AutocadVersion.AutocadVersion_v2007 },
                {"v2010", Renga.AutocadVersion.AutocadVersion_v2010 },
                {"v2013", Renga.AutocadVersion.AutocadVersion_v2013 },
                {"v2018", Renga.AutocadVersion.AutocadVersion_v2018 }
            };
        }
        /// <summary>
        /// Типы файлов для экспорта
        /// </summary>
        /// <returns>Словарь с типами файлов для экспорта</returns>
        [dr.MultiReturn(new[] { "DWG", "DXF", "PDF", "XPS" })]
        public static Dictionary<string, int> ExportFileFormats()
        {
            return new Dictionary<string, int>
            {
                {"DWG",1 },{"DXF",2 },{"PDF",3 },{"XPS",4 }
            };
        }
        /// <summary>
        /// Экспорт чертежей модели в формат DWG/DXF/PDF/XPS заданной версии в папку по именам чертежей. 
        /// С выбором перезаписи существующих документов
        /// </summary>
        /// <param name="renga_project_com">Интерфейс Renga.IProject</param>
        /// <param name="AllDrawings">Выбор, эксортировать все схемы или только Чертежи</param>
        /// <param name="PathToFolderToExport">Путь к папке, куда сохранять чертежи</param>
        /// <param name="ExportFormat_com">Версия для экспорта, нода AcadExportFormats</param>
        /// <param name="FileType">1 = dwg, 2 = dxf, 3 = pdf, 4 = xps</param>
        /// <param name="Overwrite">true для перезаписи файлов с таким же именем</param>
        public static int ExportToAcad(object renga_project_com, string PathToFolderToExport, 
            int ExportFormat_com, bool AllDrawings = true, int FileType = 1, bool Overwrite = true)
        {
            Renga.AutocadVersion ExportFormat = (Renga.AutocadVersion)ExportFormat_com;

            IDrawingCollection renga_progect_drawings;
            if (AllDrawings == false ) renga_progect_drawings = ((Renga.IProject)renga_project_com).Drawings;
            else
            {
                renga_progect_drawings = ((Renga.IProject)renga_project_com).Drawings2 as IDrawingCollection;
            }
            for (int i = 0; i < renga_progect_drawings.Count; ++i)
            {
                var OneDrawing = renga_progect_drawings.Get(i);
                string OneDrawing_Name = OneDrawing.Name;
                string FileExt;
                if (FileType == 1) FileExt = ".dwg";
                else if (FileType == 2) FileExt = ".dxf";
                else if (FileType == 3) FileExt = ".pdf";
                else FileExt = ".xps";
                string OneDrawing_Path = PathToFolderToExport + "\\" + OneDrawing_Name + FileExt;
                if (File.Exists(OneDrawing_Path)) OneDrawing_Path.Replace(FileExt, Guid.NewGuid().ToString() + FileExt);

                if (FileType == 1) OneDrawing.ExportToDwg(OneDrawing_Path, ExportFormat, Overwrite);
                else if (FileType == 2) OneDrawing.ExportToDxf(OneDrawing_Path, ExportFormat, Overwrite);
                else if (FileType == 3) OneDrawing.ExportToPdf(OneDrawing_Path, Overwrite);
                else OneDrawing.ExportToOpenXps(OneDrawing_Path, Overwrite);

            }
            return 0;
        }
        /// <summary>
        /// Экспорт текущего проекта в IFC с выбором папки для экспорта
        /// </summary>
        /// <param name="renga_project">Класс Project</param>
        /// <param name="PathToFolderToExport"></param>
        /// <param name="Overwrite"></param>
        /// <param name="wait_ifcExportSettings">0 = экспорт с настраиваемыми параметрами; остальное - экспорт с параметрами по умолчанию</param>
        public static int ExportToIfc(DynDocument.Project.Project renga_project, string PathToFolderToExport, 
            int wait_ifcExportSettings,  bool Overwrite = true) //
        {
            IIfcExportSettings settings = ifc_settings as IIfcExportSettings;
            string ProjectName;
            if ((renga_project.project).FilePath != null) 
                ProjectName = Path.GetFileNameWithoutExtension((renga_project.project).FilePath);
            ProjectName = Guid.NewGuid().ToString();
            //string export_path = PathToFolderToExport.Replace("\\", "/") + "/" + ProjectName + ".ifc";
            string export_path = PathToFolderToExport.Replace("\\", "/");
            //if (File.Exists(export_path)) export_path.Replace(".ifc", Guid.NewGuid().ToString() + ".ifc");

            if (wait_ifcExportSettings == 0) (renga_project.project).ExportToIfc2(export_path, Overwrite, settings);
            else (renga_project.project).ExportToIfc(export_path, Overwrite);
            
            return 0;
        }
        /// <summary>
        /// Настройки экспорта файла в IFC
        /// </summary>
        /// <param name="renga_application">Класс Application</param>
        /// <param name="file_ValueMappingFilePath">Файловый путь до файла маппинга значений</param>
        /// <param name="file_EntityTypeMappingFilePath">Файловый путь до файла маппинга объектов модели</param>
        /// <param name="file_LayerMappingFilePath">Файловый путь до файла маппинга слоев</param>
        /// <param name="bool_ApproximateCurves">Включение/отключение аппроксимации кривых</param>
        /// <param name="bool_VoidsAsReference">Включение/отключении опции работы со ссылочной геометрией</param>
        /// <param name="bool_SplitObjectsWithLayeredMaterialIntoParts">Включение/отключение опции расчленения объектов на части по материалам слоя</param>
        /// <param name="bool_GeometricRepresentationWithoutCutting">Включение/отключение опции экспорта геометрии без подрезки</param>
        /// <returns></returns>
        public static int CreateIIfcExportSettings (DynDocument.Application renga_application, string file_ValueMappingFilePath,  string file_EntityTypeMappingFilePath,
            string file_LayerMappingFilePath, bool bool_ApproximateCurves, bool bool_VoidsAsReference, bool bool_SplitObjectsWithLayeredMaterialIntoParts, 
            bool bool_GeometricRepresentationWithoutCutting)
        {
            IIfcExportSettings settings = renga_application.renga_app.CreateIfcExportSettings();
            settings.ValueMappingFilePath = file_ValueMappingFilePath;
            settings.Version = IfcVersion.IfcVersion_4;
            settings.EntityTypeMappingFilePath = file_EntityTypeMappingFilePath;
            settings.LayerMappingFilePath = file_LayerMappingFilePath;
            settings.ApproximateCurves = bool_ApproximateCurves;
            settings.VoidsAsReference = bool_VoidsAsReference;
            settings.SplitObjectsWithLayeredMaterialIntoParts = bool_SplitObjectsWithLayeredMaterialIntoParts;
            settings.GeometricRepresentationWithoutCutting = bool_GeometricRepresentationWithoutCutting;

            //renga_project.Save();
            ifc_settings = settings;
            return 0;
        }
        private static object ifc_settings;

        /// <summary>
        /// Экспорт в IFC, выбор формата экспорта
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "IfcVersion_4" })]
        private static Dictionary <string, object> GetIfcVersion ()
        {
            return new Dictionary<string, object>
            {
                {"IfcVersion_4", (int)IfcVersion.IfcVersion_4 }
            };
        }


    }
}
