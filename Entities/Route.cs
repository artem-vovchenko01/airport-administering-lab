using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Route : AbstractEntity
    {
        [Required]
        public Guid CarrierId { get; set; }
        public Guid? AirportDepartId { get; set; }
        public Guid? AirportArriveId { get; set; }
        
        #nullable enable
        public virtual Airport? AirportArrive { get; set; }
        public virtual Airport? AirportDepart { get; set; }
        #nullable disable
        public virtual Carrier Carrier { get; set; }
    }
}
