using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }


        /*
            DateTime Created Date{get;set;}
            DateTime?ModifiedDate{get;set;}
            string Created By{get;set;}
            string Modified By{get;set;}
         */
    }
}
