using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Products.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappings
{
    public class DTOToCOmmandMapping : Profile
    {
        public DTOToCOmmandMapping()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();

          
        }

    }
}
