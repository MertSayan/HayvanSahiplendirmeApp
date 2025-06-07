using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events
{
    public class PetCreatedEvent
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string UserEmail { get; set; }
    }
}
