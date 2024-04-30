using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ServiceVisitDTO : IDTO
    {
        public int Id { get; set; }
        public int IdService { get; set; }
        public int IdVisit { get; set; }
    }
}
