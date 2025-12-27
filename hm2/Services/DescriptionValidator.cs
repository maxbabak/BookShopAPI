namespace hm2.Services;

public class DescriptionValidator : IDescriptionValidator
{
    private readonly string[] _bannedWords =
    {
        "nigger",
        "fake",
        "banned"
    };

    public void Validate(string description)
    {
        foreach (var word in _bannedWords)
        {
            if (description.Contains(word, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException($"Опис містить заборонене слово: {word}");
        }
    }
}