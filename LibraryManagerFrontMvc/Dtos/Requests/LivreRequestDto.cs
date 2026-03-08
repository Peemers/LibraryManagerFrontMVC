using LibraryManagerFrontMvc.Enums;

namespace LibraryManagerFrontMvc.Dtos.Requests;

public class LivreRequestDto
{
  public string Nom { get; set; } = string.Empty;
  public string Auteur { get; set; } = string.Empty;
  public int NbPages { get; set; } = 1;
  public string Resume { get; set; } = string.Empty;
  public LivreStatut StatutLivre { get; set; }
  public DateTime DateDeSortie { get; set; }
  public string UrlCouverture { get; set; } = string.Empty;
  
}