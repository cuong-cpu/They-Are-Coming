using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    private float Timer;
    private float maxTime = 2; 
    public float n;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < n; i++)
        {
            Instantiate(Enemy, new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y, transform.position.z + Random.Range(-1f, 1f)), Quaternion.Euler(0, 180, 0), transform);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > maxTime)
        {
            for (int i = 0; i < n; i++)
            {
                Instantiate(Enemy,
                    new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y,
                        transform.position.z + Random.Range(-1f, 1f)), Quaternion.Euler(0, 180, 0), transform);
            }
            Timer = 0;
        }

        Timer += Time.deltaTime;
    }
}
