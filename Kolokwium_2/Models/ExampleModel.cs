namespace Kolokwium_2.Models;

// [PrimaryKey(nameof(IdPrescription), nameof(IdMedicament))]
// [Table("Prescription_Medicament")]
public class ExampleModel
{
    // [ForeignKey(nameof(Prescription))] lub dla pojedynczego [Key]
    // public int IdPrescription { get; set; }
    // [ForeignKey(nameof(Medicament))]
    // public int IdMedicament { get; set; }
    // public int? Dose { get; set; }
    // [MaxLength(100)]
    // public string Details { get; set; }
    //
    // public Prescription Prescription { get; set; }
    // public Medicament Medicament { get; set; }
    
    // [Column(TypeName = "numeric")]  dla numeric lub decimal
    // [Precision(10, 2)]
}