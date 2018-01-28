#pragma strict

private var anim : Animator;
var character : GameObject;
var distanceToOpen:float = 5;
private var characterNearbyHash: int = Animator.StringToHash("character_nearby");

private var played: boolean = false;

var source: AudioSource;
var doorSound: AudioClip;

function Start () 
{
    anim = GetComponent("Animator");
}


function Update () 
{
	var distance = Vector3.Distance(transform.position,character.transform.position);
	
    if (distanceToOpen >= distance)
    {
        if (!played)
        {
            source.PlayOneShot(doorSound);
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