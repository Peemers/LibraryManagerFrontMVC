using System.ComponentModel.DataAnnotations;

namespace LibraryManagerFrontMvc.Enums;

public enum LivreStatut
{
  [Display(Name = "Disponible")]
  Disponible,
  [Display(Name = "Non Disponible")]
  NonDisponible,
  [Display(Name = "La Perdu")]
  Perdu
}