using System;

namespace covise.networking
{
    public class MessageEventArgs : EventArgs
    {
        public Message message { get; protected set; }

        public MessageEventArgs(Message message)
        {
            this.message = message;
        }

    }
}