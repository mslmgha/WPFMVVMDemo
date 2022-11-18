using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class User
    {
        public User(Guid id,string name, bool isActive, bool isWorking)
        {
            Name = name;
            this.isActive = isActive;
            this.isWorking = isWorking;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; }
        public bool isActive { get; }
        public bool isWorking { get; }

    }
}
