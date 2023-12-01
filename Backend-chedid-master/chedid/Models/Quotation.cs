using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace chedid.Models
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // [JsonIgnore] // Exclude from serialization

        public int QuotationNumber { get; set; }

        public string PolicyOwner { get; set; }

        public string CarMake { get; set; }

        public int CarYear { get; set; }

        public string QuotationStatus { get; set; }

        [Column(TypeName = "date")] // Use Column attribute to specify the type
        public DateTime CreationDate { get; set; } 
    }
}

