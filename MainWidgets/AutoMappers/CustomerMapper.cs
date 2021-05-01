using AutoMapper;
using MainWidgets.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWidgets.AutoMappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerFilterOne>();
            CreateMap<CustomerFilterOne, Customer>();
        }
    }

    public class MapperTests {
        private IMapper _mapper;
        public MapperTests(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void MapperTestFunction()
        {
            DepartmentFilterOne department = new DepartmentFilterOne { DepartmentInfo="info", DepartmentName="dept name", DepartmentRow=1, Id=1 };
            Department newDepartment = _mapper.Map<Department>(department);
            //....
        }
    }
}
