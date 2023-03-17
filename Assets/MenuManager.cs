using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject Loader;
    public Button[] buttons;
    public AudioSource[] aud;
    bool ha = false;

    public void Jogar()
    {
        StartCoroutine(fazerLoad("Jogar"));
    }

    public void Quit()
    {
        StartCoroutine(fazerLoad("Quit"));
    }


    public void Update()
    {
        if(ha)
        {
                foreach(AudioSource i in aud)
        {
            i.volume = i.volume-0.005f;
        }
        }
        else
        {
                            foreach(AudioSource i in aud)
                {
                    if(i.volume < 0.55f)
                    {
                        i.volume = i.volume+0.005f;
                    }
                }
        }
    }

    public IEnumerator fazerLoad(string acao)
    {
        ha=true;
                foreach(Button b in buttons)
        {
            b.interactable = false;
        }
        Loader.SetActive(true);
        yield return new WaitForSeconds(2f);
        if(acao == "Jogar")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(acao=="Quit")
        {
            Application.Quit();
        }
    }
}
