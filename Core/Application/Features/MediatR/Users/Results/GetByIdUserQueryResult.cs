using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Results
{
    public class GetByIdUserQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? AboutMe { get; set; } // Profil açıklaması
    }
}
