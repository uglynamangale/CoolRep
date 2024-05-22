using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Shablon
    {
        public Shablon(int ticketrespID, string templatename, string content)
        {
            TicketRespID = ticketrespID;
            TemplateName = templatename;
            Content = content;
            
        }
        public int TicketRespID { get; set; }
        public string TemplateName { get; set; }
        public string Content { get; set; }

    }
}
