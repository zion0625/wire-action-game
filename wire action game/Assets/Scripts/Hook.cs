using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] GameObject parent;

    void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }
}
