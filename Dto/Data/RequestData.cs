using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.Data
{
    public class RequestData<T>
    {
        public List<T> data {get; set;}
    }
}