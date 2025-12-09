using Microsoft.EntityFrameworkCore;
using WordInversionApi.Data;
using WordInversionApi.Models;

namespace WordInversionApi.Services;

public class WordInversionService : IWordInversionService
{
    private readonly AppDbContext _context;

    public WordInversionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> InvertWordsAsync(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return string.Empty;

        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var invertedWords = words.Select(word => new string(word.Reverse().ToArray()));
        return string.Join(" ", invertedWords);
    }

    public async Task<WordInversion> SaveInversionAsync(string request, string response)
    {
        var inversion = new WordInversion
        {
            RequestText = request,
            ResponseText = response,
            CreatedDate = DateTime.UtcNow
        };

        _context.WordInversions.Add(inversion);
        await _context.SaveChangesAsync();
        return inversion;
    }

    public async Task<List<WordInversion>> GetAllAsync()
    {
        return await _context.WordInversions
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }

    public async Task<List<WordInversion>> FindByWordAsync(string word)
    {
        return await _context.WordInversions
            .Where(x => x.RequestText.Contains(word) || x.ResponseText.Contains(word))
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }
}
