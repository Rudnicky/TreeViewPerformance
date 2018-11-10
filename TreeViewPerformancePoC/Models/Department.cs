using System.Collections.Generic;
using TreeViewPerformancePoC.ViewModels;

namespace TreeViewPerformancePoC.Models
{
    public class Department : BaseViewModel
    {
        private List<Position> positions;
        public string DepartmentName { get; set; }

        public Department(string depname)
        {
            DepartmentName = depname;
            positions = new List<Position>()
            {
                new Position("TL"),
                new Position("PM")
            };
        }

        public List<Position> Positions
        {
            get
            {
                return positions;
            }
            set
            {
                positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }
    }
}
