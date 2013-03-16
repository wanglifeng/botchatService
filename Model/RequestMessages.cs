using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.Model
{
    public abstract class RequestMessage : Message
    {
        public MessageType MsgType { get; set; }

        public enum MessageType
        {
            text,
            image,
            location,
            link,
            @event
        }
    }

    public class RequestTextMessage : RequestMessage
    {
        public String Content { get; set; }
    }

    public class RequestImageMessage : RequestMessage
    {
        public String PicUrl { get; set; }
    }

    public class RequestLocationMessage : RequestMessage
    {
        public String Location_X { get; set; }
        public String Location_Y { get; set; }
        public String Scale { get; set; }
        public String Label { get; set; }
    }

    public class RequestEventMessage : RequestMessage
    {
        public String Event { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String Precision { get; set; }
    }
}
