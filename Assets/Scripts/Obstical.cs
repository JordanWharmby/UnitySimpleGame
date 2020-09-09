using UnityEngine;

public class Obstical : MonoBehaviour {
    public float Speed;

    private Vector3 target = new Vector3(-15, 0, 0);
    void Update() {
        //Moves the object
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        //if it has passed off screen
        if(transform.position.x <= -12) {
            RemoveObstical();
        }
    }
    public void RemoveObstical() {
        //Removes it from the list
        transform.parent.GetComponent<ObsticalManager>().RemoveObstical(gameObject);
        //destroys the game object
        Destroy(gameObject);
    }
}
