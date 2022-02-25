using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject gob;
    public Transform movePoint;
    private int SpawnQuatity;
    // Start is called before the first frame update
    void Start()
    {
       /* for (int i = 0; i < 3; i++)
        {
            GameObject newgob0 =  Instantiate(gob, movePoint.position,Quaternion.Euler(0,35,0),transform);
            Vector3 tmp = new Vector3(Random.Range(-0.5f, 0.5f), 0,
                Random.Range(-0.5f, 0.5f));
            newgob0.transform.localPosition = tmp;
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnQuatity> 0)
        {
            GameObject newgob = Instantiate(gob, movePoint.position,Quaternion.Euler(0,35,0));
            
            newgob.transform.parent = GameObject.Find("movePoint").transform;
            Vector3 tmp = new Vector3(Random.Range(-0.5f, 0.5f), 0,
                Random.Range(-0.5f, 0.5f));
            newgob.transform.localRotation = Quaternion.Euler(0, 35, 0);    
            newgob.transform.localPosition = tmp;
            SpawnQuatity--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "+10")
        {
            SpawnQuatity = 10;
            Destroy(other.transform.gameObject);
        }

        if (other.tag == "x2")
        {
           GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
           SpawnQuatity += players.Length;
           Destroy(other.transform.gameObject);
        }
    }
}
