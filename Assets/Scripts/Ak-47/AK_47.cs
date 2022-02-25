using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_47 : MonoBehaviour
{
    public Transform bullets;
    public GameObject bullet; 
    float timer;

    public float maxtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxtime)
        {
           GameObject tmp = Instantiate(bullet, bullets);
           tmp.transform.position = bullets.position;
            
            timer = 0;
        }

        timer += Time.deltaTime;

    }
}
