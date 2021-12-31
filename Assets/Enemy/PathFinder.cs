using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)] float speed = 1;
    void Start()
    {
        StartCoroutine(DrawPath());
    }

    IEnumerator DrawPath()
    {
        foreach(Waypoint waypoint in path){

            float percent = 0f;
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            transform.LookAt(endPos);
            while(percent < 1f){

                percent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPos, endPos , percent);
                yield return new WaitForEndOfFrame();

            }

        }

    }
}
