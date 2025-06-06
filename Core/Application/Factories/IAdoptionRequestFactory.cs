﻿using Application.Features.MediatR.AdoptionRequests.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IAdoptionRequestFactory
    {
        AdoptionRequest CreateAdoptionRequest(CreateAdoptionRequestCommand request);
    }
}
