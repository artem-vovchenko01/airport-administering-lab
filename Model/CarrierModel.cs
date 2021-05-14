using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class CarrierModel : AbstractModel
    {
        public string Name { get; set; } 
        
        public IEnumerable<RouteModel> Routes { get; set; }
        public override string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            error = "Blank value not allowed for the field" + nameof(Name);
                        break;
                }

                return error;
            }
        }
    }
}
