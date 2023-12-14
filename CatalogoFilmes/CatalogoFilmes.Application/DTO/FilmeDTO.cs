using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CustomConverter = CatalogoFilmes.Application.Converters;

namespace CatalogoFilmes.Application.DTO
{ 
    public class FilmeDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(150)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(50)]
        public string Diretor { get;  set; }
        [Required]
        [JsonConverter(typeof(CustomConverter.DateTimeConverter))]
        public DateTime Lancamento { get; set; }
    }
}
