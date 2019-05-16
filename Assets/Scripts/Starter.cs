using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    public Transform target;
    
    public void StartGame()
    {
        gameObject.SetActive(true);
        StartCoroutine(Begin());
    }

    private IEnumerator Begin()
    {
        for (int i = 0; i < 150; i++)
        {
            target.Translate(0, 0.01f, 0);
            yield return new WaitForSeconds(0.003f);
        }

        GetComponent<Image>().enabled = true;
        
        for (int i = 0; i < 100; i++)
        {
            GetComponent<Image>().color += Color.black * i * 0.01f;
            yield return new WaitForSeconds(0.005f);
        }

        SceneManager.LoadScene("MatchScene");
    }
}
