using System;
using System.ComponentModel.DataAnnotations;

namespace ControlNobreak.Models
{
    public class Nobreak
    {
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required, StringLength(100)]
        public string Modelo { get; set; }

        [Required]
        public int Potencia { get; set; }

        [Required]
        public int Serie {  get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataManutencao { get; set; }
    }
}
