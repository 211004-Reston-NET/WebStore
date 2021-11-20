using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class ResponseModel
    {
        public string Message {get;set;}
        public bool IsError { get; set; }
        public int Id { get; set; }
    }
}
