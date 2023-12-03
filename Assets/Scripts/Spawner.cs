using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    private float spawnX;
    private float spawnY;

    public GameObject small;

    
    // Start is called before the first frame update
    void Start(){
        InvokeRepeating(nameof(Summon), 5, 3);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Summon(){
        spawnY = Random.Range(1, 3);
        spawnX = Random.Range(-15, 15);
        
        if(spawnY == 1){
            var rotation = Random.Range(-70, 70);
            Instantiate(small, new Vector2(spawnX, -9), Quaternion.Euler(0, 0, rotation));


        }
        if(spawnY == 2){
            var rotation = Random.Range(-120, -240);
            Instantiate(small, new Vector2(spawnX, 9), Quaternion.Euler(0, 0, rotation));


        }

    }
}
