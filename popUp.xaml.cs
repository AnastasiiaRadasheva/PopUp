using Microsoft.Maui.Storage;

namespace PopUpEE;

public partial class popUp : ContentPage
{
    string playerName = Preferences.Get("PlayerName", "Seikleja");

    Dictionary<string, (string text, Dictionary<string, string> options)> scenes =
        new Dictionary<string, (string, Dictionary<string, string>)>()
        {
            ["start"] = (
            "Sa oled metsas ja hakkab pimedaks minema. Mida sa teed?",
            new Dictionary<string, string>
            {
                {"🔥 Tee lõke", "fire"},
                {"🚶 Mine edasi", "walk"},
                {"📞 Helista abi", "call"}
            }
        ),

            ["fire"] = (
            "Sa tegid lõkke ja sul on nüüd soe.",
            new Dictionary<string, string>
            {
                {"😴 Maga lõkke juures", "win_rescue"},
                {"🚶 Mine pimedasse metsa", "lost"},
                {"🔍 Uuri ümbrust", "bag"}
            }
        ),

            ["walk"] = (
            "Sa kõndisid metsas ja leidsid vana maja.",
            new Dictionary<string, string>
            {
                {"🏠 Mine majja", "house"},
                {"🚪 Mine mööda", "deep_forest"}
            }
        ),

            ["call"] = (
            "Telefonil pole levi.",
            new Dictionary<string, string>
            {
                {"📡 Otsi kõrgemat kohta", "hill"},
                {"🔥 Tee lõke", "fire"}
            }
        ),

            ["house"] = (
            "Majas on väga vaikne...",
            new Dictionary<string, string>
            {
                {"📦 Ava kast", "key"},
                {"🚪 Mine välja", "deep_forest"}
            }
        ),

            ["bag"] = (
            "Sa leidsid koti metsas.",
            new Dictionary<string, string>
            {
                {"🎒 Ava kott", "map"},
                {"🚶 Jäta ja mine edasi", "deep_forest"}
            }
        ),

            ["hill"] = (
            "Sa ronisid mäe otsa.",
            new Dictionary<string, string>
            {
                {"📞 Proovi uuesti helistada", "win_call"},
                {"🚶 Mine alla tagasi", "deep_forest"}
            }
        ),

            ["map"] = (
            "Kotis oli kaart! Sa leidsid tee linnani.",
            new Dictionary<string, string>()
        ),

            ["key"] = (
            "Kastis oli vana telefon ja võti. Sa kutsusid abi!",
            new Dictionary<string, string>()
        ),

            ["lost"] = (
            "Sa eksisid pimedas metsas ära... GAME OVER.",
            new Dictionary<string, string>()
        ),

            ["deep_forest"] = (
            "Sa läksid liiga sügavale metsa... GAME OVER.",
            new Dictionary<string, string>()
        ),

            ["win_rescue"] = (
            "Hommikul märkasid päästjad sinu lõket. Sa jäid ellu!",
            new Dictionary<string, string>()
        ),

            ["win_call"] = (
            "Sa said levi ja kutsusid abi. Sa jäid ellu!",
            new Dictionary<string, string>()
        )
        };

    public popUp()
    {
        Button startButton = new Button
        {
            Text = "Alusta seiklust",
            HorizontalOptions = LayoutOptions.Center
        };

        startButton.Clicked += StartButton_Clicked;

        Content = new VerticalStackLayout
        {
            Padding = new Thickness(30),
            Spacing = 20,
            Children = { startButton }
        };
    }



private async void StartButton_Clicked(object sender, EventArgs e)
{
    playerName = Preferences.Get("PlayerName", "Seikleja");

    await DisplayAlert("Tere", $"Edu sulle, {playerName}!", "Alusta");

    await PlayScene("start");
}

private async Task PlayScene(string sceneKey)
    {
        var scene = scenes[sceneKey];

        if (scene.options.Count == 0)
        {
            await DisplayAlert("Lõpp", scene.text, "OK");
            return;
        }

        string choice = await DisplayActionSheet(
            scene.text,
            "Loobu",
            null,
            scene.options.Keys.ToArray()
        );

        if (choice == "Loobu")
            return;

        string nextScene = scene.options[choice];

        await PlayScene(nextScene);
    }
}