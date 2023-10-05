using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlySpawnManager : MonoBehaviour
{
    private ChallengeManager challengeManager;
    public GameObject flyPrefab;
    private Rigidbody flyRb;
    public List<AudioClip> numberAudio;
    public AudioSource audSource;
    public GameObject spawnPositions;
    private Vector3 pos1 = new Vector3(-120f, -70f, 0f);
    private Transform newPos;

    //behavior of target movement
    private float jumpX = 15f;
    private float minJumpY = 900f;
    private float maxJumpY = 1000f;

    void Start()
    {
        challengeManager = GameObject.Find("Challenge Manager").GetComponent<ChallengeManager>();
    }

    public void StartSpawn(List<int> fliesToSpawn, int targetFlyNum)
    {
        //audSource.PlayOneShot(numberAudio[challengeManager.targetFlyNum]);
        SpawnFlies(fliesToSpawn, targetFlyNum);
        //challengeManager.spawnedFlyNums.Clear();
        //Debug.Log("target in spawner: " +targetFlyNum) ;
    }

    public void SpawnFlies(List<int> fliesToSpawn, int targetFlyNum)
    {
        //Debug.Log("target in spawner: " +targetFlyNum);
        for (int i = 0; i < 3; i++)
        {
            GameObject fly = Instantiate(flyPrefab);
            fly.transform.position = SpawnPosition(i);
            
            int flyDigit = fliesToSpawn[i];
            //Debug.Log(flyDigit + " flydigit");
            fly.GetComponentInChildren<TextMeshProUGUI>().text = "" + (flyDigit);
            if (flyDigit == targetFlyNum)
            {
                fly.GetComponentInChildren<DestroyOutOfBounds>().isTarget = true;
                
            }
        }
    }

    //public void SpawnFly(int flyNum, int posNum)
    //{
    //    //Debug.Log((int.Parse(fly.GetComponent<TextMeshProUGUI>().text) - 1) + " , " + challengeManager.targetFlyNum);
    //    flyRb = fly.GetComponent<Rigidbody>();
    //    //flyRb.AddForce(RandomForcePos() * GetThrust(level));
    //    //flyRb.AddForce(RandomForcePos(), ForceMode.Force);
    //}

    public Vector2 SpawnPosition(int i)
    {
        //return new Vector2(-120, -70);
        return spawnPositions.gameObject.transform.GetChild(i).transform.position;
    }

    public Vector2 RandomForce()
    {
        return new Vector2(Random.Range(-jumpX, jumpX), Random.Range(minJumpY, maxJumpY));
    }

    //public float GetThrust(float level)
    //{
    //    float thrust = velocity / level;
    //    return Random.Range((thrust - 0.5f), (thrust + 0.5f));
    //}
}
