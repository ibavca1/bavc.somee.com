using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using v0._1.Interfaces;

namespace v0._1.Models.Planets
{
    public class Planet : IPlanet
    {
        private int _id;
        private string _name;
        private int _gravity;
        public Planet()
        {
            _id = 0;
            _name = "Альфа";
            _gravity = 1;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}