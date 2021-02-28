using Apram.Domain.Messages;
using System;
using System.Collections.Generic;

namespace Apram.Abstractions.Data
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        Message GetMessageByID(Guid id);
        List<Message> GetMessagesByParentID(Guid parentID);
        List<Message> GetMessagesByRecipient(string recipient);
        List<Message> GetMessagesBySender(string sender);
        int GetMessageCountByParentID(Guid parentID);
    }
}
