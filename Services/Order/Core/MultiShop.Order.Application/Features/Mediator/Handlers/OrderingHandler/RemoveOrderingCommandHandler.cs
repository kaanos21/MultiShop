﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderinCommand>
    {
        private readonly IRepository<Ordering> _repository;
        public async Task Handle(RemoveOrderinCommand request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
