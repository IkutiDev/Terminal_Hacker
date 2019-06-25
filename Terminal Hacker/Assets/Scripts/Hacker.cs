using UnityEngine;

public class Hacker : MonoBehaviour
{
    private const string MenuHint="Type menu to go back";
    private string[] level1Passwords = { "bed", "chair", "sofa", "table", "lamp" };
    private string[] level2Passwords = { "artwork", "artist", "gallery", "museum", "canvas" };
    private string[] level3Passwords = { "biology", "scientific", "nucleotide", "genetics", "molecular" };

    private int level;
    private string password;
    private enum Screen { MainMenu,Password,Win}

    private Screen currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Greetings " + System.Environment.UserName);
    }

    private void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Choose which place you would like to\nhack:");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the Furniture Shop");
        Terminal.WriteLine("Press 2 for the Art Gallery");
        Terminal.WriteLine("Press 3 for the Secret Laboratory");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter the number:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Greetings " + System.Environment.UserName);
        }
        else if (currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(MenuHint);
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
      .-=""""""""""""""""""""""=-.
     | . . . . . . . |
     | .'.'.'.'.'.'. |
    ()_______________()
    ||_______________||
     W               W
");
                Terminal.WriteLine("You got a free sofa");
                break;
            case 2:
                
                Terminal.WriteLine(@"
     .-""````""-.     
    /  _.._    `\     
   / /`    `-.   ; . .
   | |__  __  \   |   
.-.| | e`/e`  |   |   
   | |  |     |   |'--
   | |  '-    |   |   
   |  \ --'  /|   |   
   |   `;---'\|   |   
");
                Terminal.WriteLine("You got a free ascii Mona Lisa face");
                break;
            case 3:
                Terminal.WriteLine(@"
O---o
 O-o
  O
 o-O
o---O
 O-o
  O
 o-O
o---O");
                Terminal.WriteLine("You got some free DNA");
                break;
            default:
                Debug.LogError("Unknown level");
                break;
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input =="1"||input=="2"||input=="3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "dunkey")
        {
            Terminal.WriteLine("Spaghetti and meatballs");
        }
        else
        {
            Terminal.WriteLine("Incorrect input");
            Terminal.WriteLine(MenuHint);
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(MenuHint);
        Terminal.WriteLine("Enter your password, hint: "+password.Anagram());
    }

    private void SetRandomPassword()
    {
        int index;
        switch (level)
        {
            case 1:
                index = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index];
                break;
            case 2:
                index = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index];
                break;
            case 3:
                index = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index];
                break;
            default:
                Debug.LogError("Unknown level");
                break;
        }
    }


    private void CheckPassword(string input)
    {
        if (input == password)
        {
            currentScreen = Screen.Win;
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

}
