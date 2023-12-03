using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Spawner : MonoBehaviour
{
    public GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Duplicate), 5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Duplicate(){

        Instantiate(spawner, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
    }
}
