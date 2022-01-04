using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get{return isPlaceable;}}
    [SerializeField] Tower tower;

    
    void Start()
    {
    
    }
    void OnMouseDown(){
        if(isPlaceable){
            isPlaceable = !tower.BuildTower(this.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
