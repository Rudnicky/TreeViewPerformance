using System.Collections.Generic;
using TreeViewPerformancePoC.ViewModels;

namespace TreeViewPerformancePoC.Models
{
    public class Position : BaseViewModel
    {
        private List<Employee> employees;
        public string PositionName { get; set; }

        public Position(string positionname)
        {
            PositionName = positionname;
            employees = new List<Employee>()
            {
                new Employee("Employee1"),
                new Employee("Employee2"),
                new Employee("Employee3")
            };
        }

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
    }
}
