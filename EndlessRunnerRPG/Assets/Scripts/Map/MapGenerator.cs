using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject[] thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoardUpdater();
    }

    public void BoardUpdater()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + distanceBetween, 0f, transform.position.z);
            Instantiate(thePlatform[Random.Range(0, thePlatform.Length)], transform.position, transform.rotation);
            
        }
    }
}
