using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace MigrationSamples.Data.EFCore.Entities
{
    public partial class Department {

        public Department()
        {
            this.Employees = new List<Employee>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Employee> Employees { get; set; }
    }

}
