using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipManager : MonoBehaviour
{
    public bool ShowingTip;
    public TMP_Text text;
    public Animator anim;

    public void ShowTip(string tipstr)
    {
        StopCoroutine(comecar(1f, tipstr));
        StartCoroutine(comecar(1f, tipstr));
    }

    public IEnumerator comecar(float sec, string tipstr)
    {
        yield return new WaitForSeconds(sec);
        StopCoroutine(voltar());
        this.gameObject.GetComponent<AudioSource>().Play();
        text.text=tipstr;
        ShowingTip = true;
        StartCoroutine(voltar());
    }

    public void Update()
    {
        anim.SetBool("Active", ShowingTip);
    }

    public IEnumerator voltar()
    {
        yield return new WaitForSeconds(2.5f);
        ShowingTip=false;
        StopCoroutine(voltar());
    }
}
