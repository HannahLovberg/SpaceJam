using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour {

    [SerializeField]
    private PlantDoor plantDoor;
    [SerializeField]
    private BatteryDoor batteryDoor;
    [SerializeField]
    private FoodDoor foodDoor;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip access;
    [SerializeField]
    private AudioClip error;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        string item = col.gameObject.tag;

        switch(item)
        {
            case "plant":
                plantDoor.plantLocked = false;
                source.PlayOneShot(access);
                Destroy(col.gameObject);
                break;

            case "battery":
                batteryDoor.batteryLocked = false;
                source.PlayOneShot(access);
                Destroy(col.gameObject);
                break;

            case "food":
                foodDoor.foodLocked = false;
                source.PlayOneShot(access);
                Destroy(col.gameObject);
                break;

            case "item":
                source.PlayOneShot(error);
                Destroy(col.gameObject);
                break;
        }

    }
}
