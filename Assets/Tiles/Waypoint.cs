using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get{return isPlaceable;}}
    [SerializeField] GameObject tower;

    void OnMouseDown(){
        if(isPlaceable){
            Instantiate(tower, transform.position , Quaternion.identity);
            isPlaceable = false;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
