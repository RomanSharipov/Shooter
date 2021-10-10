using UnityEngine;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        Gameplay.Load();
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnMainMenuButtonClick()
    {
        MainMenu.Load();
    }
}
