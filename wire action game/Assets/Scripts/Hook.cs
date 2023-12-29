using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
    [SerializeField] private float originSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private GameObject parent;
    private Grapple grapple;

    private void Start() {
        grapple = parent.GetComponent<Grapple>();
    }

    private void OnEnable() {
        transform.position = parent.transform.position;
        currentSpeed = originSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.right * (currentSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentSpeed = 0;
        grapple.SetAnchor(transform.position);
        grapple.isHooked = true;
    }
}
