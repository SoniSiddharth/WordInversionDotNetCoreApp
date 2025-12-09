namespace WordInversionApi.Models;

public class WordInversion
{
    public int Id { get; set; }
    public string RequestText { get; set; } = string.Empty;
    public string ResponseText { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
