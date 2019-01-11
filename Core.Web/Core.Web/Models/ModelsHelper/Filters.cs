using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ModelsHelper
{
    public class Filters
    {
        public string Attribute { get; set; }
        public Operator Operator { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
    public enum Operator
    {
        Equals = 0,
        NotEquals = 1,
        GreaterThanOrEquals = 2,
        LowerThanOrEuqals = 3,
        GreaterThan = 4,
        LowerThan = 5,
        In = 6,
        NotIn = 7,
        Empty = 8,
        NotEmpty = 9,
        Between = 10,
        NotBetween = 11,
    }
}
