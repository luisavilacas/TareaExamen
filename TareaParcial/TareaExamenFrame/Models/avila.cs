using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TareaExamenFrame.Models
{
    public class avila
    {
        public enum Lugares
        {
            restaurante,
            cine,
            mall,
            cafeteria,
            coliseo
        }
        [Key]
        public int avilaID { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        [StringLength(24, ErrorMessage = "Espacio requerido entre 2 y 24 caracteres", MinimumLength = 2)]  // para definir el tamano

        public string Friendofavila { get; set; }

        [Required]
        public Lugares Place { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [DisplayName("Cumpleanos")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }



    }
}
