using AMSS.Dto.Responses.Payment;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IPaymentService
    {
        Task<APIResponse<MakePaymentResponse>> MakePaymentAsync(Guid userId);
    }
}
