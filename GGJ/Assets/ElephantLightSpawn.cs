using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantLightSpawn : MonoBehaviour
{
    public GameObject lightToSpawn;
    public float secondsBetweenDrops;
    public bool spawnLights = true;
    float t;

    private void Update()
    {
        if (spawnLights)
        {
            if (t <= secondsBetweenDrops)
            {
                t += Time.deltaTime;
            }
            else
            {
                t = 0;
				var pos = transform.position;
                Instantiate(lightToSpawn,pos,transform.rotation);
            }
        }
    }
}
