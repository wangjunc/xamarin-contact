using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Schema
{
    public class Weather
    {
        public List<Wrapper> HeWeather6 { get; set; }
    }

    public class Wrapper
    {
        public Now now { get; set; }
    }

    public class Now
    {
        public string tmp { get; set; }
    }
}
