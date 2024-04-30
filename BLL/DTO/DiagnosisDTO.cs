using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DiagnosisDTO: IDTO
    {
        public int Id { get; set ; }
        public string Title { get; set; }
    }
}
