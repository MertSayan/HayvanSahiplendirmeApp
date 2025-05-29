using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDto.PetImageDtos
{
    public class GetAllPetImageByPetIdDto
    {
        public int PetImageId { get; set; }
        public string PetImageUrl { get; set; }
    }
}
