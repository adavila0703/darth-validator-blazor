using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarthValidatorBlazor.Models.Models
{
    [Table("validations_table")]
    public class Validations
    {
        [Column("validation_id")]
        public int ValidationsId { get; set; }

        [Column("first_file_name")]
        public string FirstFileName { get; set; }

        [Column("second_file_name")]
        public string SecondFileName { get; set; }

        [Column("first_matching_percentage")]
        public float FirstMatchingPercentage { get; set; }

        [Column("second_matching_percentage")]
        public float SecondMatchingPercentage { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
