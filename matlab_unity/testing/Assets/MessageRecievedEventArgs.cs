using System;
using System.Collections.Generic;
using System.Text;

namespace Assets
{
    public class MessageRecievedEventArgs: EventArgs
    {
        public CustomMessages Msg {get; private set;} 
        public int WParam { get; private set; }
        public int LParam { get; private set; }

        public MessageRecievedEventArgs(CustomMessages msg, int WParam, int LParam)
        {
            Msg = msg;
            this.WParam = WParam;
            this.LParam = LParam;
        }
    }
}
