using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1;
    void Start()
    {
        Debug.Log("strt");
        StartCoroutine(DrawPath());
        Debug.Log("end");
    }

    IEnumerator DrawPath()
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
