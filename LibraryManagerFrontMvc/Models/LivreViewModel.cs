namespace LibraryManagerFrontMvc.Models;

public class LivreViewModel
{
  public string Nom { get; set; } = string.Empty;
  public string Auteur { get; set; } = string.Empty;
  public int NbPages { get; set; } = 1;
  public DateTime DateDeSortie { get; set; }
}