using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject newPrize;
    // Start is called before the first frame update
    void Start()
    {
        //invoke function Spawn first time after 1sec and every other 1 sec
        InvokeRepeating("Spawn",1,1);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        //instantiate new prize from Prize prefab
        newPrize = Instantiate(Resources.Load<GameObject>("Prefab/Prize"));
    }
    
}
