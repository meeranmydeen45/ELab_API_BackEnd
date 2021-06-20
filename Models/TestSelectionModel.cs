using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELab_NetCore_API.Models
{
    public class TestSelectionModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<TestType> TestTypes { get; set; }
    }
}
