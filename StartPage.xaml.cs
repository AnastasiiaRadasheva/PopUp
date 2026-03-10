using Microsoft.Maui.Storage;

namespace PopUpEE;

public partial class StartPage : ContentPage
{
    VerticalStackLayout vst;
    ScrollView sv;

    // Флаг чтобы код выполнялся только 1 раз
    static bool nameChecked = false;

    public List<ContentPage> Lehed = new List<ContentPage>()
    {
        new popUp(),
        new popUpENG()
    };

    public List<string> LeheNimed = new List<string>()
    {
        "Teade - EE",
        "Teade - RUS"
    };

    public StartPage()
    {
        Title = "Avaleht";

        vst = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15
        };

        for (int i = 0; i < Lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = LeheNimed[i],
                FontSize = 18,
                BackgroundColor = Colors.AliceBlue,
                TextColor = Colors.Black,
                ZIndex = i,
                HeightRequest = 50,
                CornerRadius = 10
            };

            vst.Add(nupp);

            nupp.Clicked += (sender, e) =>
            {
                var valik = Lehed[nupp.ZIndex];
                Navigation.PushAsync(valik);
            };
        }

        sv = new ScrollView { Content = vst };
        Content = sv;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Если уже проверяли имя — ничего не делаем
        if (nameChecked)
            return;

        nameChecked = true;

        string playerName = Preferences.Get("PlayerName", null);

        if (!string.IsNullOrEmpty(playerName))
        {
            bool isUser = await DisplayAlert(
                "Tere!",
                $"Kas see oled sina, {playerName}?",
                "Jah",
                "Ei"
            );

            if (!isUser)
            {
                playerName = await DisplayPromptAsync("Uus nimi", "Mis on sinu nimi?");
            }
        }
        else
        {
            playerName = await DisplayPromptAsync("Tere!", "Mis on sinu nimi?");
        }

        if (string.IsNullOrWhiteSpace(playerName))
            playerName = "Seikleja";

        Preferences.Set("PlayerName", playerName);
    }
}