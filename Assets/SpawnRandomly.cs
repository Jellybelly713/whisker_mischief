using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject item;
    public int numToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numToSpawn; i++)
        {
            float x = Random.Range(-61, 71);
            float y = Random.Range(5, 5);
            float z = Random.Range(-37, -163);
            //var location = new Vector3(x, y, z);
            var location = new Vector3(x, y, z);

            Instantiate(item, location, Quaternion.identity);
        }
        
        
    }
}
