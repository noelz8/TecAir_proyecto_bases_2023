using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Cosa.Models
{
    [Table("usuario")]
    public class Rusuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        [Column("apellido")]
        public string Apellido { get; set; } = null!;
        [Column("apellido2")]
        public string Apellido2 { get; set; } = null!;
        [Column("email")]
        public string Email { get; set; } = null!;
        [Column("telefono")]
        public int Telefono { get; set; }
        [Column("contraseña")]
        public string Password { get; set; } = null!;
        [Column("universidad")]
        public string Universidad { get; set; }
        [Column("carnet")]
        public string Carnet { get; set; }
        [Column("rol")]
        public string Rol { get; set; } = null!;
    }
}
