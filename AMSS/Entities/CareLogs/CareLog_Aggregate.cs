using AMSS.Aggregates;
using AMSS.Dto.Requests.CareLogs;

namespace AMSS.Entities.CareLogs
{
    public partial class CareLog : IAggregateRoot
    {
        public CareLog()
        {
            
        }

        public CareLog(CreateCareLogRequest request, Guid createById)
        {
            Id = Guid.NewGuid();
            Type = request.Type;
            Description = request.Description;
            Date = request.Date;
            CropId = request.CropId;
            FieldId = request.FieldId;
            CreatedById = createById.ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
