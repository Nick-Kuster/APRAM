using Apram.Domain.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Apram.Services.Extensions
{
    public static class MessageTypeExtensions
    {
        public static string GetBrowsePageForType(this MessageType type)
        {
            switch (type)
            {
                case MessageType.Inventory:
                    return "Browse";
                case MessageType.RFQ:
                    return "BrowseRFQ";
                case MessageType.RFL:
                    return "BrowseRFL";
                default:
                    return "";
            }
        }
    }
}
