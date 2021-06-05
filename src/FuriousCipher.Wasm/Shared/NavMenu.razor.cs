namespace FuriousCipher.Wasm.Shared
{
    public partial class NavMenu
    {

        struct MenuItem
        {
            public string Label { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
        }

        private MenuItem[] menuItems = new MenuItem[]
        {
            new MenuItem{Label="Home",Url="/",Icon="oi oi-home"},
            new MenuItem{Label="Ceaser Cipher",Url="/ceaser-cipher",Icon="oi oi-key"},
        };
        private bool collapseNavMenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}