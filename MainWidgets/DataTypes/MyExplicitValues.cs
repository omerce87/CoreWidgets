using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWidgets.DataTypes
{
    class MyExplicitValues
    {
        private Department _Department;
        private DepartmentFilterOne _DepartmentFilterOne;
        private DepartmentFilterSecond _DepartmentFilterSecond;
        public MyExplicitValues()
        {
            _DepartmentFilterOne = new DepartmentFilterOne
            {
                Id = 1,
                DepartmentName = "Bla",
                DepartmentRow = 4,
                DepartmentInfo = "my Department info"
            };

            _DepartmentFilterSecond = new DepartmentFilterSecond
            {
                CreatedDate = DateTime.Now,
                DepartmentName = "Blala",
                IsActive = true,
                Id = 2,
                ModifiedDate = DateTime.Now
            };

            _Department = new Department
            {
                CreatedDate = DateTime.Now,
                DepartmentInfo = "My Info",
                DepartmentName = "Blabla",
                DepartmentRow= 5,
                Id = 123,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now
            };


            #region Stage One - Test
            _Department = (Department)_DepartmentFilterOne;
            _DepartmentFilterOne = (DepartmentFilterOne)_Department;
            #endregion

            #region Stage Two - Test
            _Department = (Department)_DepartmentFilterSecond;
            _DepartmentFilterSecond = (DepartmentFilterSecond)_Department;
            #endregion
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInfo { get; set; }
        public int DepartmentRow { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        #region Stage One
        public static explicit operator DepartmentFilterOne(Department department)
        {
            return new DepartmentFilterOne
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                DepartmentInfo = department.DepartmentInfo,
                DepartmentRow = department.DepartmentRow
            };
        }

        public static explicit operator Department(DepartmentFilterOne department)
        {
            return new Department
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                DepartmentInfo = department.DepartmentInfo,
                DepartmentRow = department.DepartmentRow
            };
        }
        #endregion

        #region Stage Two
        public static explicit operator DepartmentFilterSecond(Department department)
        {
            return new DepartmentFilterSecond
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive,
                CreatedDate = department.CreatedDate,
                ModifiedDate = department.ModifiedDate
            };
        }

        public static explicit operator Department(DepartmentFilterSecond department)
        {
            return new Department
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive,
                CreatedDate = department.CreatedDate,
                ModifiedDate = department.ModifiedDate
            };
        }
        #endregion
    }

    public class DepartmentFilterOne
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInfo { get; set; }
        public int DepartmentRow { get; set; }
    }

    public class DepartmentFilterSecond
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
