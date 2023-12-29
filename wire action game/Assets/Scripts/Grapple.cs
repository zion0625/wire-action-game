using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
    [SerializeField] GameObject hook;
    [SerializeField] private new Camera camera;
    private LineRenderer _lineRen;
    private DistanceJoint2D _joint;

    private bool _isHooked;
    [SerializeField] float _hookCd;
    
    void Start() {
        _lineRen = GetComponent<LineRenderer>();
        _joint = GetComponent<DistanceJoint2D>();
        
        _joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isHooked) {
            Vector3 mouse = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mouse - hook.transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            hook.transform.rotation = Quaternion.Euler(0,0,rotZ);
            hook.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Mouse0)) {
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) {
            
        }
    }
}
