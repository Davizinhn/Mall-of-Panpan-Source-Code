using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool canSeguirJogador;
    public NavMeshAgent agent;
    public GameObject Player;

    void Update()
    {
        if(canSeguirJogador)
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}
