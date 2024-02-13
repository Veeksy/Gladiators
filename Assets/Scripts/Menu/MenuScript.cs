using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSourse;

    private void Awake()
    {
        DontDestroyOnLoad(_audioSourse);

        var _newAudio = GameObject.FindGameObjectsWithTag("MainMusic").ToList();

        if (_newAudio.Count > 1)
        {
            for (int i = 1; i < _newAudio.Count; i++)
            {
                Destroy(_newAudio[i]);
            }
        }
        Wallet.SetBalanse(PlayerPrefs.GetInt("Wallet"));
    }

    public void HowToPlayClick()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Arena()
    {
        var _newAudio = GameObject.FindGameObjectsWithTag("MainMusic").ToList();

        foreach (var item in _newAudio)
        {
            Destroy(item);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Arena");
    }
}
