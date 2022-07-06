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
    /// Класс для работы с интерфейсом Renga.IProjectInfo
    /// </summary>
    public class ProjectInfo
    {
        public Renga.IProjectInfo p_info;
        /// <summary>
        /// Инициализация интерфейса Renga.ProjectInfo из com-объекта
        /// </summary>
        /// <param name="ProjectInfo_com"></param>
        public ProjectInfo(object ProjectInfo_com)
        {
            this.p_info = ProjectInfo_com as Renga.IProjectInfo;
        }
        //Getting properties
        /// <summary>
        /// Получение строкового представления параметра "Обозначение проекта"
        /// </summary>
        /// <returns></returns>
        public string Code()
        {
            return this.p_info.Code;
        }
        /// <summary>
        /// Получение строкового представления параметра "Наименование проекта"
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return this.p_info.Name;
        }
        /// <summary>
        /// Получение строкового представления параметра "Стадия"
        /// </summary>
        /// <returns></returns>
        public string Stage()
        {
            return this.p_info.Stage;
        }

        //Set properties
        /// <summary>
        /// Заполнение параметра "Обозначение проекта" из строкового представления
        /// </summary>
        /// <param name="code_string"></param>
        public void SetCode(string code_string)
        {
            this.p_info.Code = code_string;
        }
        /// <summary>
        /// Заполнение параметра "Наименования проекта" из строкового представления
        /// </summary>
        /// <param name="name_string"></param>
        public void SetName(string name_string)
        {
            this.p_info.Name = name_string;
        }
        /// <summary>
        /// Заполнение параметра "Стадия" из строкового представления
        /// </summary>
        /// <param name="stage_string"></param>
        public void SetStage(string stage_string)
        {
            this.p_info.Stage = stage_string;
        }
        /// <summary>
        /// Заполнение параметра "Описание проекта" из строкового представления
        /// </summary>
        /// <param name="description_string"></param>
        public void SetDescription(string description_string)
        {
            this.p_info.Description = description_string;
        }
        /// <summary>
        /// Получение интерфейса (com-объекта) Renga.IPropertyContainer 
        /// со свойствами BuildingInfo
        /// </summary>
        /// <returns></returns>
        public object GetProperties()
        {
            return this.p_info.GetProperties();
        }
    }
}
