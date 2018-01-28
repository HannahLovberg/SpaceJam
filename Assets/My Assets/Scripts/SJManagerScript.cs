using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJManagerScript : MonoBehaviour
{

    [SerializeField]
    private Canvas helpUI;
    [SerializeField]
    private Text investigate;
    [SerializeField]
    private Text pickUp;

    [SerializeField]
    private GameObject player;
    private Camera pCamera;

    [SerializeField]
    private PickUpScript pick;

    private int x;
    private int y;

    private Ray ray;

    void Start()
    {
        pCamera = player.GetComponent<Camera>();
        x = Screen.width / 2;
        y = Screen.height / 2;
        ray = pCamera.ScreenPointToRay(new Vector3(x, y));

        pickUp.text = "";
    }
    
    void Update()
    {
        ray = pCamera.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Pickupable p = hit.collider.GetComponent<Pickupable>();
            if (p != null && Vector3.Distance(hit.collider.gameObject.transform.position, pCamera.transform.position) < 2.5f && !pick.carrying)
            {
                pickUp.text = "Click to Pick Up";
            }
            else
            {
                pickUp.text = "";
            }
        }
    }
}
