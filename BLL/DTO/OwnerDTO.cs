﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class OwnerDTO: IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string? IdUser { get; set; }

        public  ICollection<PetDTO> Pets { get; set; }
        public  ICollection<ReceptionDTO> Receptions { get; set; }
    }
}
