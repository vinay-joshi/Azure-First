using System;

namespace Azure_First.Web.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }
        public DateTime MessageSent { get; set; }
        public bool Read { get; set; }

        public int RecipientId { get; set; }
        public int ParentId { get; set; }
    }
}