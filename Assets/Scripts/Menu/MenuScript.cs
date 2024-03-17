using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSourse;

    [SerializeField]
    private Sprite mute;

    [SerializeField]
    private Sprite unMute;

    [SerializeField]
    AudioMixer audioMixer;

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
        {
            Wallet.SetBalanse(YandexGame.savesData.money);
            var _shopItems = ShopItems.getInstance();
           

        }

        DontDestroyOnLoad(_audioSourse);

        var _newAudio = GameObject.FindGameObjectsWithTag("MainMusic").ToList();

        if (_newAudio.Count > 1)
        {
            for (int i = 1; i < _newAudio.Count; i++)
            {
                Destroy(_newAudio[i]);
            }
        }
    }


    public void HowToPlayClick()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
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

    public void MuteUnmute(Button button) {
        if (_audioSourse.mute)
        {
            _audioSourse.mute = false;
            button.GetComponent<Image>().sprite = unMute;
        }
        else
        {
            _audioSourse.mute = true;
            button.GetComponent<Image>().sprite = mute;
        }


    }

}
