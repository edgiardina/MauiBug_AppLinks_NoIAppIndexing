using System.Xml.Linq;

namespace MauiBug_AppLinks_NoIAppIndexing;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        var url = $"https://en.wikipedia.org/wiki/Steve_Jobs";

        var entry = new AppLinkEntry
        {
            Title = "Steve Jobs",
            Description = "President",
            AppLinkUri = new Uri(url, UriKind.RelativeOrAbsolute),
            IsLinkActive = true,
            Thumbnail = ImageSource.FromUri(new Uri("https://cdn.dribbble.com/users/160522/screenshots/1179084/stevejobs-01.jpg", UriKind.RelativeOrAbsolute))
        };

        entry.KeyValues.Add("contentType", "Employee");
        entry.KeyValues.Add("appName", "MauiBug_AppLinks");
        try
        {
            Application.Current.AppLinks.RegisterLink(entry);
        }
        catch (ArgumentException ex)
        {
            //TODO: resolve "No IAppIndexingProvider was provided" exception
            DisplayAlert("Error", ex.Message, "Cancel");
        }
    }
}

