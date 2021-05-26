using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace MigrationSamples.Data.EFCore.Entities
{
    public partial class ContactInfo {

        public ContactInfo()
        { 
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Phone { get; set; }
    }

}
