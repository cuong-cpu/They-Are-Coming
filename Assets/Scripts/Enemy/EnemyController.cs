using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Playes; 
    private Animator anim;
    private GameObject [] Playerlist ;
    private float NearesplayerDistance, EnemyToPlayerDis = Mathf.Infinity;
    private NavMeshAgent agent;
    private GameObject Player;
    private int NearestPlayerIndex;
   // public Transform goal;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {   
        
        FindNearestPlayer();
        if (NearesplayerDistance < EnemyToPlayerDis)
        {
            agent.SetDestination(Playerlist[NearestPlayerIndex].transform.position);
        }

        if ((GameObject.Find("Robot_Soldier_Blue(Clone)") == null) && (GameObject.Find("Robot_Soldier_Blue")) == null)
        {
            Time.timeScale = 0;
        }
    }

    private void FindNearestPlayer()
    {
        NearesplayerDistance = EnemyToPlayerDis;
        Playerlist = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Playerlist.Length; i++)
        {
            if (Vector3.Distance(transform.position, Playerlist[i].transform.position) < NearesplayerDistance )
            {
                NearesplayerDistance = Vector3.Distance(transform.position, Playerlist[i].transform.position);
                NearestPlayerIndex = i;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "player")
        {
            anim.SetInteger("Zombie",2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(collision.collider.transform.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
