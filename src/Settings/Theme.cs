using MudBlazor;
using MudBlazor.Utilities;

namespace Console.Settings;

public static class Theme
{
    private static readonly Typography DefaultTypography = new Typography()
    {
        Default = new DefaultTypography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },
        H1 = new H1Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "6rem",
            FontWeight = "300",
            LineHeight = "1.167",
            LetterSpacing = "-.01562em"
        },
        H2 = new H2Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "3.75rem",
            FontWeight = "300",
            LineHeight = "1.2",
            LetterSpacing = "-.00833em"
        },
        H3 = new H3Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "3rem",
            FontWeight = "400",
            LineHeight = "1.167",
            LetterSpacing = "0"
        },
        H4 = new H4Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "2.125rem",
            FontWeight = "400",
            LineHeight = "1.235",
            LetterSpacing = ".00735em"
        },
        H5 = new H5Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "1.5rem",
            FontWeight = "400",
            LineHeight = "1.334",
            LetterSpacing = "0"
        },
        H6 = new H6Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "1.25rem",
            FontWeight = "400",
            LineHeight = "1.6",
            LetterSpacing = ".0075em"
        },
        Button = new ButtonTypography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.75",
            LetterSpacing = ".02857em"
        },
        Body1 = new Body1Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = "1rem",
            FontWeight = "400",
            LineHeight = "1.5",
            LetterSpacing = ".00938em"
        },
        Body2 = new Body2Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },
        Caption = new CaptionTypography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = ".75rem",
            FontWeight = "400",
            LineHeight = "1.66",
            LetterSpacing = ".03333em"
        },
        Subtitle2 = new Subtitle2Typography()
        {
            FontFamily = new[] { "Inter", "Roboto", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.57",
            LetterSpacing = ".00714em"
        }
    };

    public static LayoutProperties DefaultLayoutProperties = new LayoutProperties
    {
        DefaultBorderRadius = "6px",

        DrawerWidthLeft = "260px",
        DrawerWidthRight = "260px",

        AppbarHeight = "64px",

        DrawerMiniWidthLeft = "64px",
        DrawerMiniWidthRight = "64px",
    };

    public static MudTheme ConsoleTheme = new MudTheme
    {
        PaletteLight = new PaletteLight
        {
            // -------------------------------------------------
            // Brand
            // -------------------------------------------------
            Primary = new MudColor("#C62828"),
            PrimaryContrastText = new MudColor("#FFFFFF"),

            Secondary = new MudColor("#455A64"),
            SecondaryContrastText = new MudColor("#FFFFFF"),

            Tertiary = new MudColor("#78909C"),
            TertiaryContrastText = new MudColor("#FFFFFF"),

            // -------------------------------------------------
            // Backgrounds
            // -------------------------------------------------
            Background = new MudColor("#F5F5F5"),
            BackgroundGray = new MudColor("#EEEEEE"),

            Surface = new MudColor("#FFFFFF"),

            DrawerBackground = new MudColor("#FFFFFF"),
            DrawerText = new MudColor("#263238"),
            DrawerIcon = new MudColor("#607D8B"),

            AppbarBackground = new MudColor("#C62828"),
            AppbarText = new MudColor("#FFFFFF"),

            // -------------------------------------------------
            // Text
            // -------------------------------------------------
            TextPrimary = new MudColor("#212121"),
            TextSecondary = new MudColor("#666666"),
            TextDisabled = new MudColor("#9E9E9E"),

            // -------------------------------------------------
            // Actions
            // -------------------------------------------------
            ActionDefault = new MudColor("#616161"),
            ActionDisabled = new MudColor("#BDBDBD"),
            ActionDisabledBackground = new MudColor("#EEEEEE"),

            // -------------------------------------------------
            // Dividers / Borders
            // -------------------------------------------------
            Divider = new MudColor("#E0E0E0"),
            DividerLight = new MudColor("#EEEEEE"),

            // -------------------------------------------------
            // Status
            // -------------------------------------------------
            Success = new MudColor("#2E7D32"),
            SuccessContrastText = new MudColor("#FFFFFF"),

            Warning = new MudColor("#ED6C02"),
            WarningContrastText = new MudColor("#FFFFFF"),

            Error = new MudColor("#C62828"),
            ErrorContrastText = new MudColor("#FFFFFF"),

            Info = new MudColor("#0288D1"),
            InfoContrastText = new MudColor("#FFFFFF"),

            // -------------------------------------------------
            // Hover / Overlay
            // -------------------------------------------------
            HoverOpacity = 0.08,

            // -------------------------------------------------
            // Table
            // -------------------------------------------------
            TableHover = new MudColor("#FAFAFA"),
            TableStriped = new MudColor("#FAFAFA"),
            TableLines = new MudColor("#E0E0E0"),

            // -------------------------------------------------
            // Other
            // -------------------------------------------------
            LinesDefault = new MudColor("#E0E0E0"),
            LinesInputs = new MudColor("#BDBDBD"),
            Skeleton = new MudColor("#E0E0E0")
        },

        PaletteDark = new PaletteDark
        {
            // -------------------------------------------------
            // Brand
            // -------------------------------------------------
            Primary = new MudColor("#C62828"),
            PrimaryContrastText = new MudColor("#FFFFFF"),

            Secondary = new MudColor("#90A4AE"),
            SecondaryContrastText = new MudColor("#080B12"),

            Tertiary = new MudColor("#B0BEC5"),
            TertiaryContrastText = new MudColor("#080B12"),

            // -------------------------------------------------
            // Backgrounds
            // -------------------------------------------------
            Background = new MudColor("#080B12"),
            BackgroundGray = new MudColor("#0D1117"),

            Surface = new MudColor("#10151D"),

            DrawerBackground = new MudColor("#0B0F16"),
            DrawerText = new MudColor("#ECEFF1"),
            DrawerIcon = new MudColor("#90A4AE"),

            AppbarBackground = new MudColor("#C62828"),
            AppbarText = new MudColor("#FFFFFF"),

            // -------------------------------------------------
            // Text
            // -------------------------------------------------
            TextPrimary = new MudColor("#ECEFF1"),
            TextSecondary = new MudColor("#CFD8DC"),
            TextDisabled = new MudColor("#607D8B"),

            // -------------------------------------------------
            // Actions
            // -------------------------------------------------
            ActionDefault = new MudColor("#B0BEC5"),
            ActionDisabled = new MudColor("#546E7A"),
            ActionDisabledBackground = new MudColor("#263238"),

            // -------------------------------------------------
            // Dividers / Borders
            // -------------------------------------------------
            Divider = new MudColor("#263238"),
            DividerLight = new MudColor("#1B242D"),

            // -------------------------------------------------
            // Status
            // -------------------------------------------------
            Success = new MudColor("#66BB6A"),
            SuccessContrastText = new MudColor("#000000"),

            Warning = new MudColor("#FFA726"),
            WarningContrastText = new MudColor("#000000"),

            Error = new MudColor("#EF5350"),
            ErrorContrastText = new MudColor("#000000"),

            Info = new MudColor("#29B6F6"),
            InfoContrastText = new MudColor("#000000"),

            // -------------------------------------------------
            // Hover / Overlay
            // -------------------------------------------------
            HoverOpacity = 0.12,

            // -------------------------------------------------
            // Table
            // -------------------------------------------------
            TableHover = new MudColor("#151C25"),
            TableStriped = new MudColor("#0D131A"),
            TableLines = new MudColor("#263238"),

            // -------------------------------------------------
            // Other
            // -------------------------------------------------
            LinesDefault = new MudColor("#263238"),
            LinesInputs = new MudColor("#455A64"),
            Skeleton = new MudColor("#263238")
        },

        Typography = DefaultTypography,

        LayoutProperties = DefaultLayoutProperties
    };
}