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
    /// Класс для описания штампа
    /// </summary>
    public class TitleBlockInstance
    {
        public Renga.ITitleBlockInstance _i;
        internal TitleBlockInstance (object TitleBlockInstance_object)
        {
            this._i = TitleBlockInstance_object as Renga.ITitleBlockInstance;
        }
        //properties
        public string Name => this._i.Name;
        public int RowCount => this._i.RowCount;
        public int ColumnCount => this._i.ColumnCount;

        //functions
        /// <summary>
        /// Получение значения из таблицы по координатам ячейки
        /// </summary>
        /// <param name="ColumnIndex">Индекс колонны</param>
        /// <param name="RowIndex">Индекс строки</param>
        /// <returns></returns>
        public string GetCellValue (int ColumnIndex, int RowIndex)
        {
            if (ColumnIndex <= ColumnCount && RowIndex <= RowCount)
            {
                return this._i.GetCellValue(ColumnIndex, RowIndex);
            }
            else return "";
        }
        /// <summary>
        /// Получение всех ячеек таблицы
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetCellValues()
        {
            List<List<string>> table_data = new List<List<string>>();
            for (int r = 0; r < RowCount; r++)
            {
                List<string> row_data = new List<string>();
                for (int c = 0; c < ColumnCount; c++)
                {
                    row_data.Add(this._i.GetCellValue(c, r));
                }
                table_data.Add(row_data);
            }
            return table_data;
        }

    }
}
