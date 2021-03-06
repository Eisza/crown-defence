using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class PathFinder : MonoBehaviour
{

    Enemy enemyScript;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)] float speed = 1;
    void OnEnable()
    {
        enemyScript = FindObjectOfType<Enemy>();

        DrawPath();
        MoveToStart();

        StartCoroutine(FollowPath());
    }

    void MoveToStart()
    {
        transform.position = path[0].transform.position;
    }

    void DrawPath()
    {
        path.Clear();
        GameObject waypoints = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in waypoints.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(child.GetComponent<Waypoint>());
            }
        }
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {

            float percent = 0f;
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            transform.LookAt(endPos);
            while (percent < 1f)
            {

                percent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, percent);
                yield return new WaitForEndOfFrame();

            }

        }
        FinishPath();

    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemyScript.Penalty();
    }
}
