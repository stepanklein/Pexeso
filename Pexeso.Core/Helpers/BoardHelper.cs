using Pexeso.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pexeso.Core.Helpers;

public static class BoardHelper
{
    public static Dictionary<(int x, int y), Card> CreateBoard()
    {
        var numbers = GetNubers().ToList();
        var cards = LoadCard();
        Shuffle(numbers);
        Dictionary<(int x, int y), Card> board = new();


        var index = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4 ; j++)
            {
                board.Add((i, j), cards[numbers[index]]);
                index++;
            }
        }

        return board;

    }

    private static IEnumerable<int> GetNubers()
    {
        for (int i = 0; i < 12; i++)
        {
            yield return i;
            yield return i;
        }
    }

    private static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    private static List<Card> LoadCard()
    {
        var sb = new StringBuilder();
        using (FileStream fileStream = new FileStream("Resources\\cards.json", FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fileStream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }
        }
        var file = sb.ToString();
        var list = JsonSerializer.Deserialize<CardList>(file, options: new()
        {
            PropertyNameCaseInsensitive = true
        });

        return list.Cards;
    }

    class CardList
    {
        public List<Card> Cards { get; set; }
    }

}
