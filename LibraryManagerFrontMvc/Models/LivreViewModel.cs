using System.ComponentModel.DataAnnotations;
using LibraryManagerFrontMvc.Enums;

namespace LibraryManagerFrontMvc.Models;

public class LivreViewModel
{
  public Guid Id { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "Minimum 2 Caracteres")]
  [MaxLength(64, ErrorMessage = "Maximum 64 Caracteres")]
  [Display(Name = "Titre")]
  public string Nom { get; set; } = string.Empty;
  
  [Required]
  [MinLength(2, ErrorMessage = "Minimum 2 Caracteres")]
  [MaxLength(64, ErrorMessage = "Maximum 64 Caracteres")]
  [Display(Name = "Auteur")]
  public string Auteur { get; set; } = string.Empty;
  
  [Required]
  public int NbPages { get; set; } = 1;
  
  [Required]
  [MinLength(12, ErrorMessage = "Minimum 12 Caracteres")]
  [MaxLength(240, ErrorMessage = "Maximum 240 Caracteres")]
  [Display(Name = "4eme de couverture")]
  public string Resume { get; set; } = string.Empty;
  
  [Required]
  public LivreStatut StatutLivre { get; set; }
  
  [Required]
  [DataType(DataType.Date)]
  public DateTime DateDeSortie { get; set; }
}