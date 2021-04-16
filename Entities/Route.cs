using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Route : AbstractEntity
    {
        [Required]
        public string Carrier { get; set; }
        [Required]
        public string Code { get; set;}
        public Guid? AirportDepartId { get; set; }
        public Guid? AirportArriveId { get; set; }
        [Required]
        public Guid AirplaneId { get; set; }
        
        #nullable enable
        public virtual Airport? AirportArrive { get; set; }
        public virtual Airport? AirportDepart { get; set; }
        #nullable disable
        public virtual Airplane Airplane { get; set; }
    }
}
