using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class EnemyAI : MonoBehaviour
{
    public bool canSeguirJogador;
    public NavMeshAgent agent;
    public GameObject Player;
    public AudioSource aud;
    public AudioClip[] chases;
    bool toqueiChase;
    public Animator anim;

    void Update()
    {
                    anim.SetBool("IsWalking", canSeguirJogador);
        if(canSeguirJogador)
        {
            agent.SetDestination(Player.transform.position);
            if(aud.volume < 0.75f)
            {
                aud.volume= aud.volume+0.05f;
            }
        }
        else
        {
            agent.Stop();
            if(aud.volume > 0f)
            {
                aud.volume= aud.volume-0.05f;
            }
        }
        ChaseAudioControl();
    }

    void Start()
    {
    }

    void ChaseAudioControl()
    {
        if(canSeguirJogador)
        {
            if(!aud.isPlaying && !toqueiChase)
            {
                aud.clip=chases[0];
                aud.Play();
                aud.loop=false;
                toqueiChase=true;
            }else if(!aud.isPlaying && toqueiChase)
            {
                if(agent.remainingDistance > 15)
                {
                    aud.clip=chases[1];
                }
                else if(agent.remainingDistance < 15 && agent.remainingDistance > 10)
                {
                    aud.clip=chases[2];
                }
                else if(agent.remainingDistance < 10)
                {
                    aud.clip=chases[3];
                }
                aud.Play();
            }
        }
    }
}
