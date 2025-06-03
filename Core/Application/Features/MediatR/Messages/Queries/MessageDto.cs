using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Messages.Queries
{
    public class MessageDto
    {
        public int SenderId { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
