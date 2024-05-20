using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
    public class SystemCodeDetail
    {
        public int Id { get; set; }
        public int SystemCodeId { get; set; }
        public SystemCode SystemCode { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }

        public int? OrderNo { get; set; }
    }
}
