using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDto.UserDtos
{
    public class GetUserStatsDto
    {

        public int TotalPets { get; set; }
        public int TotalLikes { get; set; }
        public int SuccessfulAdoptions { get; set; }


    }
}
