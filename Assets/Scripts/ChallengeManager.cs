using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    //target objects
    private List<string> plainNumberStrings = new List<string> {"zero", "nuts’a’", "yuse’lu", "lhihw", "xu’athun", "lhq’etsus", "t’xum", "tth’a’kwus", "te’tsus", "toohw", "’apun" };
    internal int NUM_TO_SPAWN = 3;
    internal List<int> arrayIndex = new List<int>();
    internal List<int> spawnedFlyNums = new List<int>();
    internal int targetFlyNum = 0;

    public TextMeshProUGUI wordText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    private float score = 0.0f;
    public GameObject xS;
    public GameObject gameOverScreen;

    private bool isGameActive = false;
    private int numStrikes = -1;

    internal FlySpawnManager spawnFliesScript;
    internal List<int> fliesToSpawn;

    public void Start()
    {
        spawnFliesScript = GameObject.Find("Spawn Manager").GetComponent<FlySpawnManager>();
        StartGame();
    }

    public List<int> TargetNums()
    {
        arrayIndex = new List<int> {0,1,2,3,4,5,6,7,8,9,10};

        for (int i = 0; i < NUM_TO_SPAWN; i++)
        {
            int spawningFly = Random.Range(1, arrayIndex.Count); //sets new target number
            spawnedFlyNums.Add(arrayIndex[spawningFly]);
            arrayIndex.RemoveAt(spawningFly);
        }

        targetFlyNum = spawnedFlyNums[Random.Range(0,2)];
        Debug.Log("target fly num:" + targetFlyNum);
        return spawnedFlyNums; //returns new target val once it's confirmed that it isn't a repeat of the previous number
    }

    public void SpawnTargets()
    {
        if (isGameActive)
        {
            fliesToSpawn = TargetNums();
            Debug.Log("first: " + fliesToSpawn[0] + " second: " + fliesToSpawn[1] + " third: " + fliesToSpawn[2]);
            spawnFliesScript.StartSpawn(fliesToSpawn, targetFlyNum);

            //StartCoroutine(spawnFliesScript.SpawnFlies(fliesToSpawn, GetLevel(score)));
            spawnedFlyNums.Clear();
        }
    }

    public void SelectedTarget()
    {
        //show number associated with the target
        wordText.text = "" + plainNumberStrings[targetFlyNum];

        Invoke("HideNumberSelected", 4.0f);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "" + score;
        GetLevel(score);
    }

    public float GetLevel(float score)
    {
        return (score / 10.0f)+1;
    }

    public void HideNumberSelected()
    {
        wordText.text = "";
    }

    public void StartGame()
    {
        isGameActive = true;
        SpawnTargets();
    }

    public void OOB()
    {
        ClearFlies();
        Strikes();
        SpawnTargets();
    }

    public void Strikes()
    {
        numStrikes++;
        Debug.Log("strikes: " + numStrikes);
        //play oops audio
        Color color1 = new Color(0.58f, 0.19f, 0.13f);
        Color color2 = new Color(0.71f, 0.54f, 0.52f);
        xS.gameObject.transform.GetChild(numStrikes).gameObject.GetComponent<TextMeshProUGUI>().colorGradient = new VertexGradient(color2, color2, color1, color1);

        if (numStrikes == 2)
        {
            GameOver();
        }
    }

    public void ClearFlies()
    {
        GameObject[] taggedFlies = GameObject.FindGameObjectsWithTag("Fly");
        foreach (GameObject fly in taggedFlies)
        {
            fly.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(fly, 0.2f);
        }
        HideNumberSelected();
    }

    public void GameOver()
    {
        finalScoreText.text = ""+score;
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Challenge");
    }
}
