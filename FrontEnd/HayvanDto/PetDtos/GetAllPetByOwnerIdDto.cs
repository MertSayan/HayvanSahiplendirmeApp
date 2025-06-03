using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDto.PetDtos
{
    public class GetAllPetByOwnerIdDto
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string PetTypeName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public string? Breed { get; set; } // Örn: "Golden Retriever"
        public string MainImageUrl { get; set; }
        public int RequestCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
