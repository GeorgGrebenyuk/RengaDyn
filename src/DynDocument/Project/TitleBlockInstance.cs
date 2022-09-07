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
    public class TitleBlockInstance
    {
        public Renga.ITitleBlockInstance block;
        public TitleBlockInstance (object TitleBlockInstance_object)
        {
            this.block = TitleBlockInstance_object as Renga.ITitleBlockInstance;
        }
        //properties
        public string Name => this.block.Name;
        public int RowCount => this.block.RowCount;
        public int ColumnCount => this.block.ColumnCount;

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
                return this.block.GetCellValue(ColumnIndex, RowIndex);
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
                    row_data.Add(this.block.GetCellValue(c, r));
                }
                table_data.Add(row_data);
            }
            return table_data;
        }

    }
}
