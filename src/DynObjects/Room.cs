using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;
using Renga;

namespace DynRenga.DynObjects
{
    /// <summary>
    /// Класс для работы с интерфейсом Renga.IRoom (комнатой)
    /// </summary>
    public class Room
    {
        public Renga.IRoom room;
        /// <summary>
        /// Инициация класса из объекта модели ModelObject
        /// </summary>
        /// <param name="ModelObject_Room"></param>
        public Room (object ModelObject_Room)
        {
            this.room = ModelObject_Room as Renga.IRoom;
        }
        /// <summary>
        /// Получение строкового наименования комнаты
        /// </summary>
        public string RoomName => this.room.RoomName;
        /// <summary>
        /// Получение строкового номера комнаты
        /// </summary>
        public string RoomNumber => this.room.RoomNumber;
        /// <summary>
        /// Получение маркера-идентификатора помещения (Point2D)
        /// </summary>
        public dg.Point MarkerPosition => dg.Point.ByCoordinates( this.room.MarkerPosition.X, this.room.MarkerPosition.Y, 0);
    }
}
