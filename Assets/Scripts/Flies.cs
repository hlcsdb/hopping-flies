using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : MonoBehaviour
{
    private EndlessManager endlessManager;

    //target property
    private Rigidbody targetRb;

    //behavior of target movement
    private float spawnX = 5.9f;
    private float ySpawnPos = -3.0f;
    private float zSpawnPos = -1f;
    private float minJumpX = 0.5f;
    private float maxJumpX = -0.5f;
    private float minJumpY = 11.0f;
    private float maxJumpY = 12.5f;

    //Effect components
    public ParticleSystem popParticle;
    public AudioSource targetNumberSound;

    // Start is called before the first frame update
    void Awake()
    {
        endlessManager = GameObject.Find("Endless Manager").GetComponent<EndlessManager>();

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        transform.position = spawnRandomPos(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when the mouse is clicked at the same location as the target's collider....
    private void OnMouseDown()
    {
        //target is frozen in space (ie. frozen pos and rotation, and gravity is suspended)
        targetRb.constraints = RigidbodyConstraints.FreezeAll;

        //play audio clip in audio source of prefab(audio source attached to this target script in prefab as public audio source var)
        targetNumberSound.Play();//audio source manually set 'loop' = false in each target prefab

        //After delay of 2.0f, triggers DestroyObject() function (note that
        Invoke("DestroyTarget", 4.0f);

        //...then if the game object isn't bad, it'll trigger the SelectedCorrectTarget function in GameManager.cs
            //target num not passed in bc the variable is already local to GameManager.cs
        endlessManager.SelectedTarget();
    }

    void DestroyTarget()
    {
        Instantiate(popParticle, transform.position, popParticle.transform.rotation);
        Destroy(gameObject);
    }

    //generates random force at which the target will spawn upward in the game window
    Vector3 RandomForce()
    {
        return new Vector3(Random.Range(minJumpX, maxJumpX), Random.Range(minJumpY, maxJumpY), 0.0f);
    }

    //generates random x position at which the target will spawn at the y and z spawn pos
    Vector3 spawnRandomPos()
    {
        return new Vector3(Random.Range(-spawnX, spawnX), ySpawnPos, zSpawnPos);
    }
}
