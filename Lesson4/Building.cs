using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Building
    {
        private readonly int _id;
        private int _floors;
        private int _height;
        private int _appartments;
        private int _entrances;
        private static int _lastId = 0;

        public Building()
        {
            _id = LastId;
        }

        public int Id 
        { 
            get => _id;
        }

        public int Floors 
        { 
            get => _floors; 
            set => _floors = value; 
        }

        public int Height 
        { 
            get => _height; 
            set => _height = value; 
        }

        public int Appartments 
        { 
            get => _appartments; 
            set => _appartments = value; 
        }

        public int Entrances 
        { 
            get => _entrances; 
            set => _entrances = value; 
        }

        public static int LastId 
        { 
            get
            {
                return ++_lastId;
            }
        }

        public override string ToString()
        {
            return $"Building Id = {Id} Floors = {Floors} Height = {Height} Appartments = {Appartments} Entrances = {Entrances}";
        }
    }

    public class BuildingCreator
    {
        private static readonly Dictionary<int, Building> _buildings = new Dictionary<int, Building>();
        private static readonly BuildingCreator _default = new BuildingCreator();

        private BuildingCreator() { }

        public Building Create()
        {
            Building newBuilding = new Building();

            _buildings.Add(newBuilding.Id, newBuilding);

            return newBuilding;
        }

        public Building GetById(int id)
        {
            Building result;

            if (_buildings.TryGetValue(id, out result))
                return result;

            return null;
        }

        public bool RemoveById(int id)
        {
            return _buildings.Remove(id);
        }

        public static BuildingCreator Default { get => _default; }
    }
}
