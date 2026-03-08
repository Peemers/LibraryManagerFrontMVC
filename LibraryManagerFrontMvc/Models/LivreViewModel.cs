using System.ComponentModel.DataAnnotations;
using LibraryManagerFrontMvc.Enums;

namespace LibraryManagerFrontMvc.Models;

public class LivreViewModel
{
  public Guid Id { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "Minimum 2 Caracteres")]
  [MaxLength(64, ErrorMessage = "Maximum 64 Caracteres")]
  [Display(Name = "Titre (Requis)")]
  public string Nom { get; set; } = string.Empty;
  
  [Required]
  [MinLength(2, ErrorMessage = "Minimum 2 Caracteres")]
  [MaxLength(64, ErrorMessage = "Maximum 64 Caracteres")]
  [Display(Name = "Auteur (Requis)")]
  public string Auteur { get; set; } = string.Empty;
  
  [Required]
  [Display(Name = "Nombre de pages (Requis)")]
  public int NbPages { get; set; } = 1;
  
  [Required]
  [MinLength(12, ErrorMessage = "Minimum 12 Caracteres")]
  [MaxLength(240, ErrorMessage = "Maximum 240 Caracteres")]
  [Display(Name = "4eme de couverture (Requis)")]
  public string Resume { get; set; } = string.Empty;
  
  [Required]
  [Display(Name = "Disponibilité (Requis)")]
  public LivreStatut StatutLivre { get; set; }
  
  [Required]
  [DataType(DataType.Date)]
  [Display(Name = "Date de Sortie (Requis)")]
  public DateTime DateDeSortie { get; set; }
  
  public string? UrlCouverture { get; set; }
}