using Microsoft.Maui.Storage;

namespace PopUpEE;

public partial class popUp : ContentPage
{
    string playerName;

    Dictionary<string, (string text, Dictionary<string, string> options)> scenes =
        new Dictionary<string, (string, Dictionary<string, string>)>()
        {

            // ---------- METS ----------

            ["forest_start"] = (
            "Sa oled metsas ja hakkab pimedaks minema. Mida sa teed?",
            new Dictionary<string, string>
            {
                {"Teha lõke", "fire"},
                {"Kõndida edasi", "walk"},
                {"Helistada abi saamiseks", "call"}
            }
            ),

            ["fire"] = (
            "Sa tegid lõkke ja nüüd on sul soe.",
            new Dictionary<string, string>
            {
                {"Magada lõkke juures", "win_rescue"},
                {"Kõndida pimedasse metsa", "lost"},
                {"Vaadata ümbrust", "bag"}
            }
            ),

            ["walk"] = (
            "Sa kõndisid metsas ja leidsid vana maja.",
            new Dictionary<string, string>
            {
                {"Siseneda majja", "house"},
                {"Minna mööda", "deep_forest"}
            }
            ),

            ["call"] = (
            "Telefonil ei ole levi.",
            new Dictionary<string, string>
            {
                {"Otsida kõrgemat kohta", "hill"},
                {"Teha lõke", "fire"}
            }
            ),

            ["house"] = (
            "Majast on väga vaikne...",
            new Dictionary<string, string>
            {
                {"Avada kast", "key"},
                {"Minna välja", "deep_forest"}
            }
            ),

            ["bag"] = (
            "Sa leidsid metsast koti.",
            new Dictionary<string, string>
            {
                {"Avada kott", "map"},
                {"Jätta see ja minna edasi", "deep_forest"}
            }
            ),

            ["hill"] = (
            "Sa ronisid mäe tippu.",
            new Dictionary<string, string>
            {
                {"Proovida uuesti helistada", "win_call"},
                {"Minna tagasi alla", "deep_forest"}
            }
            ),

            ["map"] = (
            "Kotis oli kaart! Sa leidsid tee linna.",
            new Dictionary<string, string>()
            ),

            ["key"] = (
            "Kastis oli vana telefon ja võti. Sa kutsusid abi!",
            new Dictionary<string, string>()
            ),

            ["lost"] = (
            "Sa eksisid pimedas metsas ära... MÄNG LÄBI.",
            new Dictionary<string, string>()
            ),

            ["deep_forest"] = (
            "Sa läksid liiga sügavale metsa... MÄNG LÄBI.",
            new Dictionary<string, string>()
            ),

            ["win_rescue"] = (
            "Hommikul märkasid päästjad sinu lõket. Sa jäid ellu!",
            new Dictionary<string, string>()
            ),

            ["win_call"] = (
            "Sa said levi ja kutsusid abi. Sa jäid ellu!",
            new Dictionary<string, string>()
            ),

            // ---------- ZOMBID ----------

            ["zombie_start"] = (
            "Sa ärkasid tühjas linnas. Kõikjal kostavad kummalised helid... zombi-apokalüpsis on alanud.",
            new Dictionary<string, string>
            {
                {"Joosta mööda tänavat", "zombie_run"},
                {"Peituda poodi", "zombie_shop"},
                {"Vaadata autot", "zombie_car"}
            }
            ),

            ["zombie_run"] = (
            "Sa jooksid mööda tänavat ja nägid zombide hulka.",
            new Dictionary<string, string>
            {
                {"Joosta trepikotta", "zombie_house"},
                {"Joosta edasi", "zombie_caught"}
            }
            ),

            ["zombie_shop"] = (
            "Sa peitusid poes. Seal on toitu.",
            new Dictionary<string, string>
            {
                {"Võtta toitu", "zombie_escape"},
                {"Otsida relva", "zombie_weapon"}
            }
            ),

            ["zombie_car"] = (
            "Autos on võtmed.",
            new Dictionary<string, string>
            {
                {"Proovida ära sõita", "zombie_drive"},
                {"Anda signaali", "zombie_noise"}
            }
            ),

            ["zombie_house"] = (
            "Sa ootasid öö trepikojas. Hommikul päästsid sind sõdurid!",
            new Dictionary<string, string>()
            ),

            ["zombie_escape"] = (
            "Toiduga suutsid linnast põgeneda. Sa jäid ellu!",
            new Dictionary<string, string>()
            ),

            ["zombie_weapon"] = (
            "Sa leidsid pesapallikurika ja kaitsesid end zombide eest. Sa pääsesid!",
            new Dictionary<string, string>()
            ),

            ["zombie_drive"] = (
            "Sa käivitasid auto ja sõitsid linnast minema. Sa pääsesid!",
            new Dictionary<string, string>()
            ),

            ["zombie_noise"] = (
            "Zombid kuulsid auto signaali... MÄNG LÄBI.",
            new Dictionary<string, string>()
            ),

            ["zombie_caught"] = (
            "Zombid said sind kätte... MÄNG LÄBI.",
            new Dictionary<string, string>()
            ),

            // ---------- KOOL ----------

            ["school_start"] = (
            "Sa sattusid öösel mahajäetud kooli. Koridorid on pimedad ja vaiksed.",
            new Dictionary<string, string>
            {
                {"Minna klassiruumi", "school_class"},
                {"Minna keldrisse", "school_basement"},
                {"Minna katusele", "school_roof"}
            }
            ),

            ["school_class"] = (
            "Vanades klassiruumides on tolmused pingid ja tahvel.",
            new Dictionary<string, string>
            {
                {"Uurida õpetaja lauda", "school_key"},
                {"Tagasi koridori", "school_hall"}
            }
            ),

            ["school_basement"] = (
            "Sa läksid keldrisse. Seal on väga külm.",
            new Dictionary<string, string>
            {
                {"Avada vana uks", "school_ghost"},
                {"Tagasi üles", "school_hall"}
            }
            ),

            ["school_roof"] = (
            "Sa jõudsid kooli katusele.",
            new Dictionary<string, string>
            {
                {"Valgustada taskulambiga ümbrust", "school_rescue"},
                {"Tagasi alla", "school_hall"}
            }
            ),

            ["school_hall"] = (
            "Sa oled jälle pikas pimedas koolikoridoris.",
            new Dictionary<string, string>
            {
                {"Minna klassiruumi", "school_class"},
                {"Minna keldrisse", "school_basement"},
                {"Minna katusele", "school_roof"}
            }
            ),

            ["school_key"] = (
            "Sa leidsid lauast võtme ja pääsesid koolist välja. Sa pääsesid!",
            new Dictionary<string, string>()
            ),

            ["school_rescue"] = (
            "Inimesed märkasid sinu taskulampi ja aitasid sind välja. Sa pääsesid!",
            new Dictionary<string, string>()
            ),

            ["school_ghost"] = (
            "Ukse taga oli tume koridor ja kummaline vari... MÄNG LÄBI.",
            new Dictionary<string, string>()
            )

        };

    public popUp()
    {
        Button forestButton = new Button
        {
            Text = "Seiklus metsas",
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 220,
            HeightRequest = 55,
            BackgroundColor = Colors.ForestGreen,
            TextColor = Colors.White,
            FontSize = 18,
            CornerRadius = 15
        };

        Button zombieButton = new Button
        {
            Text = "Zombi lugu",
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 220,
            HeightRequest = 55,
            BackgroundColor = Colors.DarkRed,
            TextColor = Colors.White,
            FontSize = 18,
            CornerRadius = 15
        };

        Button schoolButton = new Button
        {
            Text = "Mahajäetud kool",
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 220,
            HeightRequest = 55,
            BackgroundColor = Colors.DarkSlateBlue,
            TextColor = Colors.White,
            FontSize = 18,
            CornerRadius = 15
        };

        forestButton.Clicked += ForestButton_Clicked;
        zombieButton.Clicked += ZombieButton_Clicked;
        schoolButton.Clicked += SchoolButton_Clicked;

        Content = new VerticalStackLayout
        {
            Padding = new Thickness(30),
            Spacing = 25,
            VerticalOptions = LayoutOptions.Center,
            Children = { forestButton, zombieButton, schoolButton }
        };
    }

    private async void ForestButton_Clicked(object sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Reisija");

        await DisplayAlert("Tere", $"Edu sulle, {playerName}!", "Alusta");

        await PlayScene("forest_start");
    }

    private async void ZombieButton_Clicked(object sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Reisija");

        await DisplayAlert("Tere", $"{playerName}, valmistu zombi-apokalüpsiseks!", "Alusta");

        await PlayScene("zombie_start");
    }

    private async void SchoolButton_Clicked(object sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Reisija");

        await DisplayAlert("Tere", $"{playerName}, sa oled mahajäetud koolis...", "Alusta");

        await PlayScene("school_start");
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
            "Tühista",
            null,
            scene.options.Keys.ToArray()
        );

        if (choice == "Tühista")
            return;

        string nextScene = scene.options[choice];

        await PlayScene(nextScene);
    }
}