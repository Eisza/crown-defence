using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    // Start is called before the first frame update

    Transform turret;
    Transform target;
    void Start()
    {
        turret = transform.Find("BallistaTopMesh").transform;
        target = FindObjectOfType<PathFinder>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        turret.LookAt(target);
    }
}
