using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private bool carrying;
    private GameObject carriedObject;
    public float distance;
    public float smooth;
    public float throwForce;

    void Start()
    {

    }


    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
            checkThrow();
        }
        else
        {
            pickUp();
        }
    }

    private void carry(GameObject obj)
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, camera.transform.position + camera.transform.forward * distance, Time.deltaTime * smooth);
        //obj.transform.rotation = Quaternion.identity;
    }

    private void checkDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dropObject();
        }
    }

    private void checkThrow()
    {
        if(Input.GetMouseButtonDown(1))
        {
            throwObject();
        }
    }

    private void pickUp()
    {
        Ray ray = new Ray();
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            //ray = camera.ScreenPointToRay(Input.mousePosition);
            ray = camera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null && Vector3.Distance(hit.collider.gameObject.transform.position, camera.transform.position) < 2.5f)
                {
                    carrying = true;
                    carriedObject = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                }
            }
        }
    }

    private void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Collider>().enabled = true;

        carriedObject = null;
    }

    private void throwObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Collider>().enabled = true;
        carriedObject.GetComponent<Rigidbody>().AddForce(camera.transform.forward * throwForce);
        carriedObject = null;
    }
}
