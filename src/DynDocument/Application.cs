using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;


namespace DynRenga.DynDocument
{
    /// <summary>
    /// Класс для работы с приложением Renga (интерфейсом Renga.IApplication)
    /// </summary>
    public  class Application
    {
        public Renga.IApplication renga_app;
        /// <summary>
        /// Получает первый запущенный процесс Renga в системе и фиксирует интерфейс Renga.IApplication
        /// </summary>
        [dr.IsVisibleInDynamoLibrary(true)]
        public Application()
        {
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);

            var rengaMonikers = GetRengaMonikers();
            if (rengaMonikers.Count > 0)
            {
                object comObject;
                // Get first Renga moniker in list
                rot.GetObject(rengaMonikers[0], out comObject);
                this.renga_app = comObject as Renga.IApplication;
            }
        }

        /// <summary>
        /// Получает запущенный процесс Renga или создает его если такого нет, 
        /// и открывает проект по файловому пути к нему
        /// </summary>
        /// <param name="project_path">Файловый путь к проекту Renga</param>
        [dr.IsVisibleInDynamoLibrary(false)]
        public Application(string project_path)
        {
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);

            var rengaMonikers = GetRengaMonikers();
            if (rengaMonikers.Count() > 0)
            {
                object comObject;
                for (int i1 = 0; i1 < rengaMonikers.Count(); i1++)
                {
                    rot.GetObject(rengaMonikers[i1], out comObject);
                    var renga = comObject as Renga.Application;
                    if (renga.HasProject() && renga.Project.FilePath == project_path)
                    {
                        renga_app = renga;
                        renga_app.Visible = true;
                    }
                }
            }
            if (rengaMonikers.Count() > 0)
            {
                object comObject;
                rot.GetObject(rengaMonikers[0], out comObject);
                this.renga_app = comObject as Renga.Application;
                this.renga_app.OpenProject(project_path);
                this.renga_app.Visible = true;
                
            }

            else
            {
                InitRengaAppAsNew(project_path);
            }
        }
        private int InitRengaAppAsNew(string PathToProject, bool IsIfc = false)
        {
            this.renga_app = new Renga.Application();
            this.renga_app.Visible = true;
            int result;
            string file_extension = Path.GetExtension(PathToProject);

            if (IsIfc == true && file_extension.ToLower() == ".ifc") result = renga_app.ImportIfcProject(PathToProject);
            else result = this.renga_app.OpenProject(PathToProject);
            if (result != 0)
            {
                //Smth error
                renga_app.Quit();
                return 1;
            }
            else
            {
                //All right
                this.renga_app.Visible = true;
                return 0;
            }

        }
        [DllImport("ole32.dll")]
        private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);
        private static List<IMoniker> GetRengaMonikers()
        {
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);

            IEnumMoniker monikerEnumerator = null;
            rot.EnumRunning(out monikerEnumerator);
            if (monikerEnumerator == null)
                return null;

            monikerEnumerator.Reset();

            var registries = new List<IMoniker>();

            IntPtr pNumFetched = new IntPtr();
            IMoniker[] monikers = new IMoniker[1];
            while (monikerEnumerator.Next(1, monikers, pNumFetched) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                if (bindCtx == null)
                    continue;

                string displayName;
                monikers[0].GetDisplayName(bindCtx, null, out displayName);
                if (displayName.Contains("!Renga"))
                    registries.Add(monikers[0]);
            }
            return registries;
        }
    }
}
