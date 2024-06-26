using Pexeso.Core.Helpers;
using Pexeso.Core.Models;

namespace Pexeso.Core;

public class GemeManager
{
    private readonly Dictionary<(int x, int y), Card> board;

    public GemeManager()
    {
        board = BoardHelper.CreateBoard();
    }




}
