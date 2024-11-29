using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class MainMenu : MonoBehaviour, IPointerClickHandler
{
    public Canvas mainMenuCanvas;  // Canvas del menú principal
    public Canvas helpCanvas;      // Canvas del centro de ayuda
    public Canvas settingsCanvas;  // Canvas de los ajustes (si lo tienes)
    public Canvas aboutCanvas;  // Panel de Acerca de (si lo tienes)


    public void StartGame()
    {
        SceneManager.LoadScene("volleyballScene");  // Cambia a la escena del juego, cambia "GameScene" al nombre de tu escena
    }

    public void ShowSettings()
    {
        settingsCanvas.gameObject.SetActive(true);   // Activa el Canvas de ajustes
    }

    public void ShowHelpCanvas()
    {
        helpCanvas.gameObject.SetActive(true);       // Activa el Canvas del centro de ayuda
    }


    public void ShowAbout()
    {
       aboutCanvas.gameObject.SetActive(true);   // Activa el Panel de "Acerca de"
    }


    public void QuitGame()
    {
        Application.Quit();  // Sale del juego
    }

    public void JumpToMain()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Aquí puedes ejecutar el método que corresponda al botón
        Debug.Log("Botón presionado: " + gameObject.name);

        // Llama al método correspondiente según el nombre del botón
        if (gameObject.name == "StartButton")
        {
            StartGame();
        }
        else if (gameObject.name == "SettingsButton")
        {
            ShowSettings();
        }
        else if (gameObject.name == "HelpButton")
        {
            ShowHelpCanvas();
        }
        else if (gameObject.name == "AboutButton")
        {
            ShowAbout();
        }
        else if (gameObject.name == "QuitButton")
        {
            QuitGame();
        }
        else if(gameObject.name == "MenuButton")
        {
            JumpToMain();
        }
    }

}
