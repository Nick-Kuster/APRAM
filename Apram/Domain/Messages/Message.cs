using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Domain.Messages
{
    public class Message
    {
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        public MessageType Type { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public DateTime SendDate { get; set; }
    }
}
