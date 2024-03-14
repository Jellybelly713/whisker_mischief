using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject tomatoSoup;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(3, 50);
        float y = Random.Range(3, 50);
        float z = Random.Range(3, 50);
        //var location = new Vector3(x, y, z);
        var location = new Vector3(5, 5, -125);

        Instantiate(tomatoSoup, location, Quaternion.identity);
        
    }
}
