﻿using AMSS.Aggregates;
using AMSS.Dto.Requests.Orders;
using AMSS.Enums;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AMSS.Models.OrderHeaders
{
    public partial class OrderHeader : IAggregateRoot
    {
        public OrderHeader()
        {
            
        }

        public OrderHeader(CreateOrderRequest request, Guid userId, Guid locationId)
        {
            Id = Guid.NewGuid();
            ApplicationUserId = userId;
            PickupName = request.PickupName?.Trim();
            PickupEmail = request.PickupEmail?.Trim();
            PickupPhoneNumber = request.PickupPhoneNumber?.Trim();
            OrderTotal = request.OrderTotal;
            CouponCode = !string.IsNullOrEmpty(request.CouponCode) ? request.CouponCode.Trim() : string.Empty;
            DiscountAmount = request.DiscountAmount;
            OrderDate = DateTime.Now;
            Status = request.Status;
            LocationId = locationId;
            TotalItems = request.TotalItems;
            StripePaymentIntentID = request.StripePaymentIntentID;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateOrderRequest request)
        {
            PickupName = !string.IsNullOrWhiteSpace(request.PickupName) ? request.PickupName.Trim() : PickupName;
            PickupEmail = !string.IsNullOrWhiteSpace(request.PickupEmail) ? request.PickupEmail.Trim() : PickupEmail;
            PickupPhoneNumber = !string.IsNullOrWhiteSpace(request.PickupPhoneNumber) ? request.PickupPhoneNumber.Trim() : PickupPhoneNumber;
            Status = request.Status; 
            UpdatedAt = DateTime.Now;
        }
    }
}
