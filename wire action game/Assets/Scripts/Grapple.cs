using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
    [SerializeField] GameObject hook;
    private LineRenderer _lineRen;
    private DistanceJoint2D _joint;
    
    void Start() {
        _lineRen = GetComponent<LineRenderer>();
        _joint = GetComponent<DistanceJoint2D>();
        
        _joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            
        }
    }
}
