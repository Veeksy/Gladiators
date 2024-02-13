using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;


    public void PauseGame()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }

    public void ContinueGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}