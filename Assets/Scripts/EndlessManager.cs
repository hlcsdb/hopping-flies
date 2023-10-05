using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class EndlessManager : MonoBehaviour
{
    //target objects
    public List<GameObject> targets; //flies
    private List<string> plainNumberStrings = new List<string> {"nuts’a’", "yuse’lu", "lhihw", "xu’athun", "lhq’etsus", "t’xum", "tth’a’kwus", "te’tsus", "toohw", "’apun" };

    private int targetNum = 0;
    public float spawnRate = 6f;

    private int lastNumber;
    private int targetVal = 0; //prevents xwuyxwiyayu from being the first target spawned in the game

    public TextMeshProUGUI wordText;

    public void Start()
    {
        StartGame();
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
        while(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Endless")){
            targetNum = TargetNum();

            Instantiate(targets[targetNum]);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void SelectedTarget()
    {
        //show number associated with the target
        wordText.text = "" + (targetNum + 1) + "  " + plainNumberStrings[targetNum];

        Invoke("HideNumberSelected", 4.0f);
    }

    void HideNumberSelected()
    {
        wordText.text = "";
    }

    public void StartGame()
    {
        StartCoroutine(SpawnTarget());
    }

}
