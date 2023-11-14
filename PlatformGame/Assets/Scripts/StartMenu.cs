using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] AudioSource buttonSound;
    private float speedButton = .1f;

    public void StartLevel()
    {
        buttonSound.Play();
        Cursor.visible = false;
        Invoke(nameof(LoadLevel), speedButton);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Level" + levelNumber.ToString());
    }

    public void QuitGame()
    {
        buttonSound.Play();
        Application.Quit();
    }

    public void MainMenu()
    {
        buttonSound.Play();
        Invoke(nameof(LoadMainMenu), speedButton);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
