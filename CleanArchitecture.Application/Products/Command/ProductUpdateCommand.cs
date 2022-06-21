using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.Command
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }

        public ProductUpdateCommand(int id)
        {
            Id = id;
        }
    }
}
