using Microsoft.Maui.Storage;

namespace PopUpEE;

public partial class popUpENG : ContentPage
{
    string playerName = "";

    Dictionary<string, (string text, Dictionary<string, string> options)> scenes =
        new Dictionary<string, (string, Dictionary<string, string>)>()
        {

            // ---------- ЛЕС ----------

            ["forest_start"] = (
            "Ты в лесу, начинает темнеть. Что ты будешь делать?",
            new Dictionary<string, string>
            {
                {"Разжечь костёр", "fire"},
                {"Идти дальше", "walk"},
                {"Позвонить за помощью", "call"}
            }
            ),

            ["fire"] = (
            "Ты развёл костёр и теперь тебе тепло.",
            new Dictionary<string, string>
            {
                {"Спать у костра", "win_rescue"},
                {"Идти в тёмный лес", "lost"},
                {"Осмотреть окрестности", "bag"}
            }
            ),

            ["walk"] = (
            "Ты пошёл по лесу и нашёл старый дом.",
            new Dictionary<string, string>
            {
                {"Зайти в дом", "house"},
                {"Идти мимо", "deep_forest"}
            }
            ),

            ["call"] = (
            "В телефоне нет сигнала.",
            new Dictionary<string, string>
            {
                {"Искать возвышенность", "hill"},
                {"Разжечь костёр", "fire"}
            }
            ),

            ["house"] = (
            "В доме очень тихо...",
            new Dictionary<string, string>
            {
                {"Открыть коробку", "key"},
                {"Выйти наружу", "deep_forest"}
            }
            ),

            ["bag"] = (
            "Ты нашёл сумку в лесу.",
            new Dictionary<string, string>
            {
                {"Открыть сумку", "map"},
                {"Оставить и идти дальше", "deep_forest"}
            }
            ),

            ["hill"] = (
            "Ты поднялся на вершину холма.",
            new Dictionary<string, string>
            {
                {"Попробовать снова позвонить", "win_call"},
                {"Спуститься обратно", "deep_forest"}
            }
            ),

            ["map"] = (
            "В сумке была карта! Ты нашёл путь к городу.",
            new Dictionary<string, string>()
            ),

            ["key"] = (
            "В коробке был старый телефон и ключ. Ты вызвал помощь!",
            new Dictionary<string, string>()
            ),

            ["lost"] = (
            "Ты заблудился в тёмном лесу... ИГРА ОКОНЧЕНА.",
            new Dictionary<string, string>()
            ),

            ["deep_forest"] = (
            "Ты зашёл слишком глубоко в лес... ИГРА ОКОНЧЕНА.",
            new Dictionary<string, string>()
            ),

            ["win_rescue"] = (
            "Утром спасатели заметили твой костёр. Ты выжил!",
            new Dictionary<string, string>()
            ),

            ["win_call"] = (
            "Ты поймал сигнал и вызвал помощь. Ты выжил!",
            new Dictionary<string, string>()
            ),

            // ---------- ЗОМБИ ----------

            ["zombie_start"] = (
            "Ты проснулся в пустом городе. Повсюду раздаются странные звуки... начался зомби-апокалипсис.",
            new Dictionary<string, string>
            {
                {"Бежать по улице", "zombie_run"},
                {"Спрятаться в магазине", "zombie_shop"},
                {"Осмотреть машину", "zombie_car"}
            }
            ),

            ["zombie_run"] = (
            "Ты побежал по улице и увидел толпу зомби.",
            new Dictionary<string, string>
            {
                {"Забежать в подъезд", "zombie_house"},
                {"Бежать дальше", "zombie_caught"}
            }
            ),

            ["zombie_shop"] = (
            "Ты спрятался в магазине. Там есть еда.",
            new Dictionary<string, string>
            {
                {"Взять еду", "zombie_escape"},
                {"Искать оружие", "zombie_weapon"}
            }
            ),

            ["zombie_car"] = (
            "В машине есть ключи.",
            new Dictionary<string, string>
            {
                {"Попробовать уехать", "zombie_drive"},
                {"Посигналить", "zombie_noise"}
            }
            ),

            ["zombie_house"] = (
            "Ты переждал ночь в подъезде. Утром тебя спасли военные!",
            new Dictionary<string, string>()
            ),

            ["zombie_escape"] = (
            "С едой ты смог выбраться из города. Ты выжил!",
            new Dictionary<string, string>()
            ),

            ["zombie_weapon"] = (
            "Ты нашёл биту и отбился от зомби. Ты спасся!",
            new Dictionary<string, string>()
            ),

            ["zombie_drive"] = (
            "Ты завёл машину и уехал из города. Ты спасся!",
            new Dictionary<string, string>()
            ),

            ["zombie_noise"] = (
            "Зомби услышали сигнал машины... ИГРА ОКОНЧЕНА.",
            new Dictionary<string, string>()
            ),

            ["zombie_caught"] = (
            "Зомби догнали тебя... ИГРА ОКОНЧЕНА.",
            new Dictionary<string, string>()
            ),

            // ---------- ШКОЛА ----------

            ["school_start"] = (
            "Ты оказался ночью в заброшенной школе. В коридорах темно и тихо.",
            new Dictionary<string, string>
            {
                {"Пойти в класс", "school_class"},
                {"Спуститься в подвал", "school_basement"},
                {"Подняться на крышу", "school_roof"}
            }
            ),

            ["school_class"] = (
            "В старом классе стоят пыльные парты и доска.",
            new Dictionary<string, string>
            {
                {"Осмотреть стол учителя", "school_key"},
                {"Вернуться в коридор", "school_hall"}
            }
            ),

            ["school_basement"] = (
            "Ты спустился в подвал. Там очень холодно.",
            new Dictionary<string, string>
            {
                {"Открыть старую дверь", "school_ghost"},
                {"Подняться обратно", "school_hall"}
            }
            ),

            ["school_roof"] = (
            "Ты поднялся на крышу школы.",
            new Dictionary<string, string>
            {
                {"Посветить фонариком вокруг", "school_rescue"},
                {"Спуститься обратно", "school_hall"}
            }
            ),

            ["school_hall"] = (
            "Ты снова в длинном тёмном коридоре школы.",
            new Dictionary<string, string>
            {
                {"Пойти в класс", "school_class"},
                {"Спуститься в подвал", "school_basement"},
                {"Подняться на крышу", "school_roof"}
            }
            ),

            ["school_key"] = (
            "В столе ты нашёл ключ от выхода и смог выбраться из школы. Ты спасся!",
            new Dictionary<string, string>()
            ),

            ["school_rescue"] = (
            "Твой свет заметили люди на улице и помогли тебе выбраться. Ты спасся!",
            new Dictionary<string, string>()
            ),

            ["school_ghost"] = (
            "За дверью оказался тёмный коридор... и странная тень. ИГРА ОКОНЧЕНА.",
            new Dictionary<string, string>()
            )

        };

    public popUpENG()
    {

        Button forestButton = new Button
        {
            Text = "Приключение в лесу",
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
            Text = "История про зомби",
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
            Text = "Заброшенная школа",
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

    private async void ForestButton_Clicked(object? sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Путешественник");

        await DisplayAlertAsync("Привет", $"Удачи тебе, {playerName}!", "Начать");

        await PlayScene("forest_start");
    }

    private async void ZombieButton_Clicked(object? sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Путешественник");

        await DisplayAlertAsync("Привет", $"{playerName}, приготовься к зомби-апокалипсису!", "Начать");

        await PlayScene("zombie_start");
    }

    private async void SchoolButton_Clicked(object? sender, EventArgs e)
    {
        playerName = Preferences.Get("PlayerName", "Путешественник");

        await DisplayAlertAsync("Привет", $"{playerName}, ты оказался в заброшенной школе...", "Начать");

        await PlayScene("school_start");
    }

    private async Task PlayScene(string sceneKey)
    {
        var scene = scenes[sceneKey];

        if (scene.options.Count == 0)
        {
            await DisplayAlertAsync("Конец", scene.text, "OK");
            return;
        }

        string choice = await DisplayActionSheetAsync(
            scene.text,
            "Отмена",
            null,
            scene.options.Keys.ToArray()
        );

        if (choice == "Отмена")
            return;

        string nextScene = scene.options[choice];

        await PlayScene(nextScene);
    }
}