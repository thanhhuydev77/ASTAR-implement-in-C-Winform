using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBT3
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class NearPlace
    {
        public Place place;
        public int Distance;

        public NearPlace(Place place, int distance)
        {
            this.place = place;
            Distance = distance;
        }
    }
    public class Place
    {
        public Place Parent;
        public string Name;
        private Point Location;
        private int G;
        private int H;
        private int F;
        List<NearPlace> NearPlaces;

        public Place(string name, int x, int y)
        {
            Name = name;
            Location = new Point(x, y);
   
        }
        
       public void SetG(int g)
        {
            G = g;
            F = G + H;
        }
        public void InitH(Place other)
        {
            H = ((other.GetPoint().X - Location.X) * (other.GetPoint().X - Location.X) + (other.GetPoint().Y - Location.Y) * (other.GetPoint().Y - Location.Y))/100;
        }
        public void Setposition(int x,int y)
        {
            Location.X = x;
            Location.Y = y;
        }
        public void SetRoundPlaces(List<NearPlace> list)
        {
            NearPlaces = list;
        }
        public int GetG() => G;
        public int GetH() => H;
        public List<NearPlace> GetRoundPlace() => NearPlaces;
       public Point GetPoint() => Location;

        public int GetF() => F;
        public int getW(int i)
        {
            return NearPlaces[i].Distance;
        }
        public int GetX() => GetPoint().X;

        public int GetY() => GetPoint().Y;
        public int getW(Place other)
        {
            for(int i = 0;i < NearPlaces.Count();i++)
            {
                if(other == NearPlaces[i].place)
                    return NearPlaces[i].Distance;
            }
            return 0;
        }
    }
}
