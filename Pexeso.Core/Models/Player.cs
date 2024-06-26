namespace Pexeso.Core.Models;

public class Player
{
    public string Name { get; set; } = string.Empty;

    public List<Card> Cards { get; set; } = new();
}
