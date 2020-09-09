using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Singleton
    public static GameManager GM;
    //Game State
    public enum GameState {
        menue,
        play,
        idle,
        dead
    }
    //Current State
    public GameState CurrentState;

    //Player Object
    public GameObject player;
    private GameObject playerObject;

    //Pipe Manager
    public ObsticalManager OM;

    private void Awake() {
        //sets up Singleton
        if (GM == null) GM = this;
        else if (GM != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        CurrentState = GameState.play;
    }

    // Update is called once per frame
    void Update() {
        switch (CurrentState) {
            case GameState.menue:
                break;
            case GameState.play:
                //Makes the player
                if (playerObject == null) playerObject = Instantiate(player);
                //Sets the variables
                playerObject.GetComponent<Player>().SetPlayerActive(true);
                OM.CanSpawn = true;
                CurrentState = GameState.idle;
                break;
                //Idle State
            case GameState.idle:
                break;
            case GameState.dead:
                //resets all of the objects
                playerObject.GetComponent<Player>().Reset();
                OM.ResetObsticalManager();
                CurrentState = GameState.play;
                break;
            default:
                break;
        }
    }
}