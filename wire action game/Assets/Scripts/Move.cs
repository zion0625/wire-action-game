using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Move : MonoBehaviour {
    private Rigidbody2D _rigid;
    [SerializeField]private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] float xAxis;

    private void Start() {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetButtonUp("Horizontal")) {
            var velocity = _rigid.velocity;
            velocity = new Vector2(velocity.normalized.x * 0.0000000001f, velocity.y);
            _rigid.velocity = velocity;
        }
    }

    private void FixedUpdate() {
        xAxis = Input.GetAxisRaw("Horizontal");
        _rigid.AddForce(Vector2.right * (xAxis * speed), ForceMode2D.Impulse);
        _rigid.velocity = new Vector2(Mathf.Clamp(_rigid.velocity.x, -maxSpeed, maxSpeed), _rigid.velocity.y);
    }
}
