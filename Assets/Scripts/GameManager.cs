using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //target objects
    public List<GameObject> targets; //flies
    private List<string> plainNumberStrings = new List<string> {"nuts’a’", "yuse’lu", "lhihw", "xu’athun", "lhq’etsus","t’xum","tth’a’kwus","te’tsus","toohw","’apun"};

    private int targetNum = 0;
    public float spawnRate = 6f;
    //public int numberButtonSelected;

    private int lastNumber;
    private int targetVal = 0; //prevents xwuyxwiyayu from being the first target spawned in the game

    //UI variables
    public Button startButton;
    public GameObject playScreen;
    public GameObject homeScreen;
    public GameObject titleAudio;
    public GameObject foreground;
    public GameObject frog;

    // public TextMeshProUGUI selectedNumberText;
    public TextMeshProUGUI wordText;
    // public ParticleSystem selectedNumberParticle;
    public Button restartButton;
    
    //game active variables
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int TargetNum()
    {
        lastNumber = targetVal; //sets last target number
        targetVal = Random.Range(0, targets.Count); //sets new target number

        while (targetVal == lastNumber) //compares the last target number and new target number, loops until they aren't equal
        {
            targetVal = Random.Range(0, targets.Count);
        }
        return targetVal; //returns new target val once it's confirmed that it isn't a repeat of the previous number
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            
            targetNum = TargetNum();

            Instantiate(targets[targetNum]);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void SelectedTarget()
    {
        //show number associated with the target
        wordText.text = "" + (targetNum+1) + "  " + plainNumberStrings[targetNum];

        Invoke("HideNumberSelected", 4.0f);
    }

    void HideNumberSelected()
    {
        // selectedNumberText.text = "";
        wordText.text = "";
        // Instantiate(selectedNumberParticle);
    }

    public void GameOver()
    {
        isGameActive = false;
        // playScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        // playScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        frog.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        titleAudio.gameObject.SetActive(false);
        homeScreen.gameObject.SetActive(false);
        foreground.gameObject.SetActive(true);
        StartCoroutine(SpawnTarget());
        // Debug.Log("started coroutine");
        playScreen.gameObject.SetActive(true);
    }
}
