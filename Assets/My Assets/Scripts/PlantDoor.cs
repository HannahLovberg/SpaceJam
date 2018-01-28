using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDoor : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private float distanceToOpen = 3;

    public bool plantLocked = true;

    private bool played = false;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip openSound;

    [SerializeField]
    private Light light;


    private int characterNearbyHash = Animator.StringToHash("character_nearby");


    void Start()
    {
        anim = GetComponent<Animator>();
        light.color = Color.red;
    }


    void Update()
    {
        if(!plantLocked)
        {
            light.color = Color.green;
        }

        float distance = Vector3.Distance(transform.position, character.transform.position);

        if (distanceToOpen >= distance && !plantLocked)
        {
            if (!played)
            {
                source.PlayOneShot(openSound);
                played = true;
            }
            anim.SetBool(characterNearbyHash, true);
        }
        else
        {
            anim.SetBool(characterNearbyHash, false);
            played = false;
        }
    }
}
