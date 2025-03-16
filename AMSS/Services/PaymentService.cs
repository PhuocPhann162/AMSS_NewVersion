using AMSS.Dto.Responses.Payment;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<APIResponse<MakePaymentResponse>> MakePaymentAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
