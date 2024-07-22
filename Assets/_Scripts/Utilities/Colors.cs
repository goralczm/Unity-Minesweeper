public enum TextColors
{
    WHITE,
    BLUE,
    PURPLE,
    ORANGE,
    RED,
    GOLD,
    GREEN,
    DARK_GREEN,
    PINK,
    GREY,
    BLACK,
    DARK_BLUE,
    DARK_RED,
    TURQOISE,
}

public static class Colors
{
    public const string WHITE = "#ffffff";
    public const string BLUE = "#349eeb";
    public const string PURPLE = "#9038cf";
    public const string ORANGE = "#e6aa07";
    public const string RED = "#db2a2a";
    public const string GOLD = "#dbdb58";
    public const string GREEN = "#8ad166";
    public const string PINK = "#db48b0";
    public const string GREY = "#bfbfbf";
    public const string BLACK = "#161616";
    public const string DARK_GREEN = "#8ad166";
    public const string DARK_BLUE = "#1C2D55";
    public const string DARK_RED = "#541B1D";
    public const string TURQOISE = "#469880";

    public static string GetColoredText(TextColors color, string text)
    {
        string hexColor = "";
        switch (color)
        {
            case TextColors.BLUE:
                hexColor = BLUE;
                break;
            case TextColors.PURPLE:
                hexColor = PURPLE;
                break;
            case TextColors.ORANGE:
                hexColor = ORANGE;
                break;
            case TextColors.RED:
                hexColor = RED;
                break;
            case TextColors.GOLD:
                hexColor = GOLD;
                break;
            case TextColors.GREEN:
                hexColor = GREEN;
                break;
            case TextColors.DARK_GREEN:
                hexColor = DARK_GREEN;
                break;
            case TextColors.PINK:
                hexColor = PINK;
                break;
            case TextColors.GREY:
                hexColor = GREY;
                break;
            case TextColors.BLACK:
                hexColor = BLACK;
                break;
            case TextColors.DARK_BLUE:
                hexColor = DARK_BLUE;
                break;
            case TextColors.DARK_RED:
                hexColor = DARK_RED;
                break;
            case TextColors.TURQOISE:
                hexColor = TURQOISE;
                break;
            case TextColors.WHITE:
            default:
                hexColor = WHITE;
                break;
        }

        return $"<color={hexColor}>{text}</color>";
    }

    public static TextColors GetColorByNumber(int number)
    {
        switch (number)
        {
            case 1:
                return TextColors.BLUE;
            case 2:
                return TextColors.GREEN;
            case 3:
                return TextColors.RED;
            case 4:
                return TextColors.DARK_BLUE;
            case 5:
                return TextColors.DARK_RED;
            case 6:
                return TextColors.TURQOISE;
            case 7:
                return TextColors.BLACK;
            case 8:
                return TextColors.GREY;
            default:
                return TextColors.WHITE;
        }
    }
}