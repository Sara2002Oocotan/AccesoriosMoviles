using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoriosMoviles.EntidadesDeNegocio
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "Categoria es obligatorio")]
        [Display(Name = " Categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Precio es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Imagen es obligatorio")]
        [StringLength(400, ErrorMessage = "Maximo 400 caracteres")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Descripcion 200 caracteres", MinimumLength = 5)]
        public string Descripcion { get; set; }

        

        public Categoria Categoria { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        
    }

    public enum Estatus_Producto
    {
        ACTIVO = 1,
        INACTIVO = 2,
    }
}

