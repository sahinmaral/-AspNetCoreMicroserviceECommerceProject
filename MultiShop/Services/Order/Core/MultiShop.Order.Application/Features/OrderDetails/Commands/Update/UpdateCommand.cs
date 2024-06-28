﻿using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Update
{
    public class UpdateCommand: IRequest
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmont { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string OrderingId { get; set; }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public UpdateCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(new OrderDetail()
                {
                    Id = request.Id,
                    ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductAmont = request.ProductAmont,
                    ProductTotalPrice = request.ProductTotalPrice,
                    OrderingId = request.OrderingId
                });
            }
        }
    }
}
