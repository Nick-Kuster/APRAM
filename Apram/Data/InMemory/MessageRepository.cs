using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class MessageRepository : IMessageRepository
    {
        public List<Message> Messages { get; set; }

        public MessageRepository()
        {
            Messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            message.ID = Guid.NewGuid();
            message.SendDate = DateTime.UtcNow;
            Messages.Add(message);
        }

        public Message GetMessageByID(Guid id)
        {
            return Messages.FirstOrDefault(x => x.ID == id);
        }

        public List<Message> GetMessagesByParentID(Guid parentID)
        {
            return Messages.Where(x => x.ParentID == parentID).ToList();
        }

        public List<Message> GetMessagesByRecipient(string recipient)
        {
            return Messages.Where(x => x.Recipient == recipient).ToList();
        }

        public List<Message> GetMessagesBySender(string sender)
        {
            return Messages.Where(x => x.Sender == sender).ToList();
        }

        public int GetMessageCountByParentID(Guid parentID)
        {
            return Messages.Count(x => x.ParentID == parentID);
        }
    }
}
