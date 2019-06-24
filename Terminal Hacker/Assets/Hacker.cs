using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Greetings " + System.Environment.UserName);
    }

    private static void ShowMainMenu(string greeting)
    {
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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "menu")
        {
            ShowMainMenu("Greetings " + System.Environment.UserName);
        }
        else if (input == "dunkey")
        {
            Terminal.WriteLine("Spaghetti and meatballs");
        }
        else
        {
            Terminal.WriteLine("Incorrect input");
        }
    }

    private void StartGame()
    {
        Terminal.WriteLine("You have chosen level "+level);
    }
}
