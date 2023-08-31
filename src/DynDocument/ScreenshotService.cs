using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;
using System.Threading;

namespace DynRenga.DynDocument
{
	/// <summary>
	/// Класс для работы с менеджером по созданию скриншотов модели
	/// </summary>
	public class ScreenshotService
	{
		public Renga.IScreenshotService _i;
		/// <summary>
		/// Получение менеджера для текущей позиции камеры модели
		/// </summary>
		/// <param name="View"></param>
		public ScreenshotService(Application Application)
		{
			Renga.IView _IView = Application._i.ActiveView;
			this._i = _IView as Renga.IScreenshotService;
		}
		/// <summary>
		/// Установка камеры модели на новую позицию и получение для этой позиции менеджера
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="focus_point"></param>
		/// <param name="position_point"></param>
		/// <param name="up_vector"></param>
		public ScreenshotService(Application Application, double[] focus_point, 
			double[] position_point, double[] up_vector)
		{
			var view_3d = Application._i.ActiveView as Renga.IView3DParams;
			Renga.FloatPoint3D focus = new FloatPoint3D();
			focus.X = Convert.ToSingle(focus_point[0]);
			focus.Y = Convert.ToSingle(focus_point[1]);
			focus.Z = Convert.ToSingle(focus_point[2]);

			Renga.FloatPoint3D pos = new FloatPoint3D();
			pos.X = Convert.ToSingle(position_point[0]);
			pos.Y = Convert.ToSingle(position_point[1]);
			pos.Z = Convert.ToSingle(position_point[2]);

			Renga.FloatVector3D up = new FloatVector3D();
			up.X = Convert.ToSingle(up_vector[0]);
			up.Y = Convert.ToSingle(up_vector[1]);
			up.Z = Convert.ToSingle(up_vector[2]);

			view_3d.Camera.LookAt(focus, pos, up);

			Thread.Sleep(100);
			Renga.IView _i = Application._i.ActiveView;
			Renga.IView3DParams view_params = _i as Renga.IView3DParams;
			var uutt = _i.Type.ToString();
			Renga.IScreenshotService iii = _i as Renga.IScreenshotService;
			int wait = 0;
		}
		/// <summary>
		/// Создает скриншот (картинку) рабочего пространства Renga в файл
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="dir_path"></param>
		/// <param name="file_name"></param>
		/// <param name="ImageFormat"></param>
		public void MakeScreenshot(int width, int height, string dir_path,
			string file_name, Renga.ImageFormat ImageFormat)
		{
			Renga.IScreenshotSettings settings = _i.CreateSettings();
			settings.Width = width;
			settings.Height = height;

			Renga.IImage image = this._i.MakeScreenshot(settings);
			image.SaveToFile(Path.Combine(dir_path, file_name), ImageFormat);
		}

	}

}
