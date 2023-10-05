using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float yOut = -75.0f;
    private ChallengeManager challengeManager;
    internal bool isTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Challenge"))
        {
            challengeManager = GameObject.Find("Challenge Manager").GetComponent<ChallengeManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < yOut)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Challenge"))
            {
                challengeManager.OOB();
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
