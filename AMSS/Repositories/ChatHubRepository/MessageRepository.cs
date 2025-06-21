using AMSS.Data;
using AMSS.Entities.Messages;

namespace AMSS.Repositories.ChatHubRepository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
