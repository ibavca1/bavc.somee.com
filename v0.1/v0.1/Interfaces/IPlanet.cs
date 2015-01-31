using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v0._1.Interfaces
{
    public interface IPlanet
    {
    }

    public interface IPlanets
    {
        public void AddPlanet();
        public bool AddPlanet(string Name);
    }
}