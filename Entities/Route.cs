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
        [Required]
        public Guid AirportDepartId { get; set; }
        [Required]
        public Guid AirportArriveId { get; set; }
        [Required]
        public Guid AirplaneId { get; set; }
        
        public virtual Airport AirportArrive { get; set; }
        public virtual Airport AirportDepart { get; set; }
        public virtual Airplane Airplane { get; set; }
    }
}
