using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class AirplanesClass
    {
        public AirplanesClass()
        {
            AirplaneClassFlights = new HashSet<AirplaneClassFlight>();
            Airplanes = new HashSet<Airplane>();
        }

        public int AirplaneClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual ICollection<AirplaneClassFlight> AirplaneClassFlights { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; }
    }
}
