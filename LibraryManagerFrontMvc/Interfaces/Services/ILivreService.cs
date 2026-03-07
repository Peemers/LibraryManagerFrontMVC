using LibraryManagerFrontMvc.Models;

namespace LibraryManagerFrontMvc.Interfaces.Services;

public interface ILivreService
{
  Task<List<LivreViewModel>> GetAllLivresAsync();
  Task<LivreViewModel?> GetByIdAsync(Guid id);
  
  Task<LivreViewModel?> CreateLivreAsync(LivreViewModel livre);
}