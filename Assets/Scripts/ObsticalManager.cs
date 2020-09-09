using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalManager : MonoBehaviour {
    //Obstetrical Object
    public GameObject Obsticals;
    //Spawn Rate
    public float SpawnRate;
    public bool CanSpawn = false;

    private List<GameObject> obsticalList = new List<GameObject>();
    private float delta = 0;

    // Update is called once per frame
    void Update() {
        //if pipes can not spawn
        if (!CanSpawn) return;
        //adds time
        delta += Time.deltaTime;
        //if it is time to spawn an object
        if(delta >= SpawnRate) {
            delta = 0;
            GameObject temp = Instantiate(Obsticals, new Vector3(10, 0, 0), Quaternion.identity,transform);
            obsticalList.Add(temp);
        }
    }
    //Removes the object from the list
    public void RemoveObstical(GameObject g) { obsticalList.Remove(g); }
    //removes all objects
    public void ResetObsticalManager() { 
        while (obsticalList.Count > 0) obsticalList[0].GetComponent<Obstical>().RemoveObstical();
        //reset the time
        delta = 0;
        CanSpawn = false;
    }

}
