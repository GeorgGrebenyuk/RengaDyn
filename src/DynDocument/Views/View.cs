using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;



namespace DynRenga.DynDocument.Views
{
    /// <summary>
    /// Класс для работы с отдельными Видами проекта (фасад, модель, чертежи)
    /// </summary>
    public class View : Other.Technical.ICOM_Tools
    {
        public Renga.IView view;
        /// <summary>
        /// Инициализация класса из интерфейса Renga.IView. Используйте нод Application.ActiveView
        /// </summary>
        /// <param name="view_object"></param>
        public View (object view_object)
        {
            this.view = view_object as Renga.IView;
        }
        /// <summary>
        /// Проверка на null полученного интерфейса
        /// </summary>
        /// <returns></returns>
        public bool CheckIsNotNull()
        {
            if (this.view == null) return false;
            else return true;
        }
        //props
        /// <summary>
        /// Получение идентификатора
        /// </summary>
        public int Id => this.view.Id;
        /// <summary>
        /// Все типы видовых пространств
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Not a view", "Project Explorer view", "3D view", "Level view", "Section view",
        "Facade view","Drawing sheet", "Specification", "Section profile editor", "Assembly view", "Pipe system view"})]
        public static Dictionary<string, object> ViewTypes()
        {
            return new Dictionary<string, object>()
            {
                {"Not a view",Renga.ViewType.ViewType_Undefined  },
                {"Project Explorer view",Renga.ViewType.ViewType_ProjectExplorer  },
                {"3D view",Renga.ViewType.ViewType_View3D   },
                {"Level view",Renga.ViewType.ViewType_Level  },
                {"Section view",Renga.ViewType.ViewType_Section  },
                {"Facade view",Renga.ViewType.ViewType_Facade },
                {"Drawing sheet",Renga.ViewType.ViewType_Sheet  },
                {"Specification",Renga.ViewType.ViewType_Specification  },
                {"Section profile editor",Renga.ViewType.ViewType_SectionProfile },
                {"Assembly view",Renga.ViewType.ViewType_Assembly },
                {"Pipe system view",Renga.ViewType.ViewType_PipeSystem  }
            };
        }
        /// <summary>
        /// Получение типа вида
        /// </summary>
        public object Type => this.view.Type;
        /// <summary>
        /// Получение типа вида как строки
        /// </summary>
        public string TypeAsString => ViewTypes().Where(a => a.Value == Type).First().Key;
        /// <summary>
        /// Получение камеры (интерфейса Renga.ICamera3D) из 3д-представления вида. Только для Модели!
        /// </summary>
        public object Camera => (this.view as Renga.IView3DParams).Camera;
    }
}
