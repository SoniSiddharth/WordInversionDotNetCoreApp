using WordInversionApi.Models;

namespace WordInversionApi.Services;

public interface IWordInversionService
{
    Task<string> InvertWordsAsync(string sentence);
    Task<WordInversion> SaveInversionAsync(string request, string response);
    Task<List<WordInversion>> GetAllAsync();
    Task<List<WordInversion>> FindByWordAsync(string word);
}
