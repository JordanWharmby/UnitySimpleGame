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
        //gets the Rigidbody2D
        if (rigi == null) rigi = GetComponent<Rigidbody2D>();
        //Sets the active state
        SetPlayerActive(false);
        //sets the position
        transform.position = Vector3.zero;
    }
    //Rests the player
    public void Reset() {
        transform.position = Vector3.zero;
        SetPlayerActive(false);
    }
    //sets the object to be active or inactive
    public void SetPlayerActive(bool b) {
        if (b) {
            rigi.gravityScale = 1;
        }
        else {
            rigi.gravityScale = 0;
        }
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigi.velocity = Vector2.zero;
            rigi.AddForce(new Vector2(0, JumpHeight));
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        //if the player gets hit
        GameManager.GM.CurrentState = GameManager.GameState.dead;
    }
}
