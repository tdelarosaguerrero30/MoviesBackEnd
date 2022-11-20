using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Library.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string User { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        [Range(1, 10, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Starts { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
