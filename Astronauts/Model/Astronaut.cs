using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astronauts.Model
{
    public class Astronaut
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        public string Superpower { get; set; }

    }
}
