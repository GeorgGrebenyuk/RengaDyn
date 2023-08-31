using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynRenga.DynObjects
{
    /// <summary>
    /// Класс для представления объекта модели как объекта на уровне
    /// </summary>
    public class LevelObject
    {
        public Renga.ILevelObject _i;
        public LevelObject (ModelObject ModelObject)
        {
            this._i = ModelObject._i as Renga.ILevelObject;
        }
        public int LevelId => this._i.LevelId;
        public double VerticalOffset => this._i.VerticalOffset;
        public double PlacementElevation => this._i.PlacementElevation;
        public double ElevationAboveLevel => this._i.ElevationAboveLevel;
    }
}
