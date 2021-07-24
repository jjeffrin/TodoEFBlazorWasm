using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoEFBlazorWasm.Shared.Models
{
    public class Todo : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }

    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        
        public string UpdatedUser
        {
            get
            {
                return "JEFF_USER";
            }
        }
    }
}
