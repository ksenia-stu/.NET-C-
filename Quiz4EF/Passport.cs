using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz4EF
{
    public class Passport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string PassportNo { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public Person Person { get; set; }
    }
}
