using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class Test
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
