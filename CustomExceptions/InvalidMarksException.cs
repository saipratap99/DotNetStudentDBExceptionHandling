using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class InvalidMarksException:  Exception
    {
        public InvalidMarksException(): base(){}

        public InvalidMarksException(string message):base(message){
        }

        public InvalidMarksException(string message, Exception ex) : base(message, ex) {
            
        }

    }
}
