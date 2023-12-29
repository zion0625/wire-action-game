using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
    [SerializeField] GameObject hook;
    [SerializeField] private new Camera camera;
    private LineRenderer _lineRen;
    private DistanceJoint2D _joint;

    public bool isHooked;
    [SerializeField] float hookCd;
    
    void Start() {
        _lineRen = GetComponent<LineRenderer>();
        _joint = GetComponent<DistanceJoint2D>();
        
        _joint.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 mouse = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mouse - hook.transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            hook.transform.rotation = Quaternion.Euler(0,0,rotZ);
            hook.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) {
            hook.SetActive(false);
            _joint.enabled = false;
            _lineRen.enabled = false;
            isHooked = false;
            hook.transform.position = transform.position;
        }

        if (_lineRen.enabled) {
            _lineRen.SetPosition(1,transform.position);
        }
    }

    public void SetAnchor(Vector2 pos) {
        _lineRen.SetPosition(0, pos);
        _lineRen.SetPosition(1, transform.position);
        _joint.connectedAnchor = pos;
        _joint.enabled = true;
        _lineRen.enabled = true;
    }
}
