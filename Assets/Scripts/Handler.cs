using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    public GameObject info, back;
    
    public void Retry()
    {
        SceneManager.LoadScene("MatchScene");
    }

    public void Play()
    {
        Starter s = GameObject.Find("Fader").GetComponent<Starter>();
        s.StartGame();
    }

    public void GoInfo()
    {
       info.SetActive(true);
       back.SetActive(true);
    }

    public void GoBack()
    {
        info.SetActive(false);
        back.SetActive(false);
    }
}
