using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {

    //Jump Height
    public float JumpHeight;
    //Rigidbody2D
    private Rigidbody2D rigi;

    private void Awake() {
        if (rigi == null) rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigi.velocity = Vector2.zero;
            rigi.AddForce(new Vector2(0, JumpHeight));
        }
            
    }
}
