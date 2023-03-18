using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaControler : MonoBehaviour
{
    public int precisodesse;
    public int tenhoesses;
    bool A = true;
    public bool canAdd = true;
    public AudioSource tummmm;
    public GameObject portaparapoder;
    public Animator anim;
    public bool jato;
    public GameObject brownCard;

    public void Update()
    {   
        if(precisodesse==tenhoesses && A==true)
        {
            A = false;
            jato = true;
            StartCoroutine(abrirportinha());
        }
    }

    IEnumerator abrirportinha()
    {
                yield return new WaitForSeconds(2.75f);
                anim.SetTrigger("Cuspir");
        yield return new WaitForSeconds(3f);
        // coisas
        portaparapoder.tag="Porta";
        //this.gameObject.GetComponent<EnemyAI>().canSeguirJogador=true;
        GameObject.Find("TipManager").GetComponent<TipManager>().ShowItem("Brown KeyCard x1");
        this.gameObject.tag="Untagged";
                new WaitForSeconds(0.75f);
                brownCard.active=false;
                
        StopCoroutine(abrirportinha());
    }

    public void AddComida()
    {
        canAdd=false;
        tummmm.Play();
        anim.SetTrigger("Comer");
        tenhoesses = tenhoesses+1;
        StartCoroutine(podeVoltar());
    }

    IEnumerator podeVoltar()
    {
        yield return new WaitForSeconds(2.25f);
        canAdd = true;
        StopCoroutine(podeVoltar());
    }
}
