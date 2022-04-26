using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class Response
    {
        public String ErrorMessage { get; set; }
        public Object ReturnValue { get; set; }
        public Response() {}
        public Response(String ErrorMessage, Object ReturnValue)
        {
            this.ErrorMessage = ErrorMessage;
            this.ReturnValue = ReturnValue;
        }
    }
}
