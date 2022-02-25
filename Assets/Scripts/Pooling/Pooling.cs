using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling instance;

    private Dictionary<string, Queue<GameObject>> everything = new Dictionary<string, Queue<GameObject>>();
    
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    public void Push(string key, GameObject gob)
    {
        if (!everything.ContainsKey(key))
        {
            everything.Add(key,new Queue<GameObject>());
        }
        everything[key].Enqueue(gob);
    }

    public GameObject _Pull(string key)
    {
        string path = "";
        if (key == "Enemy") path = "Prefabs/Enemy";
        if (key == "Player") path = "Prefabs/Player";
        if (everything.ContainsKey(key))
        {
            if (everything[key].Count > 0)
            {
                return everything[key].Dequeue();
            }
            else
            {
                GameObject gobCopy = Instantiate(Resources.Load<GameObject>(path));
                return gobCopy;
            }
        }
        else
        {
            GameObject gobCopy = Instantiate(Resources.Load<GameObject>(path));
            return gobCopy;

        }
    }
}
