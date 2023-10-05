using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FliesInChallenge : MonoBehaviour
{
    private ChallengeManager challengeManager;

    //target property
    private Rigidbody flyRb;

    //Effect components
    public GameObject xOnFly;


    //behavior of target movement
    private float jumpX = 15f;
    private float minJumpY = 900f;
    private float maxJumpY = 1000f;

    // Start is called before the first frame update
    void Awake()
    {
        flyRb = GetComponent<Rigidbody>();
        challengeManager = GameObject.Find("Challenge Manager").GetComponent<ChallengeManager>();
        flyRb = gameObject.GetComponent<Rigidbody>();
        flyRb.AddForce(RandomForce(), ForceMode.Impulse);
    }

    //when the mouse is clicked at the same location as the target's collider....
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        if (int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text) != challengeManager.targetFlyNum)
        {
            challengeManager.Strikes();
            xOnFly.transform.position = gameObject.transform.position;
            xOnFly.SetActive(true);
        }

        else if(int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text) == challengeManager.targetFlyNum)
        {
            challengeManager.IncreaseScore();
        }

        //target is frozen in space (ie. frozen pos and rotation, and gravity is suspended)
        flyRb.constraints = RigidbodyConstraints.FreezeAll;

        challengeManager.SelectedTarget();
        StartCoroutine("NewTargets");
    }
    public Vector2 RandomForce()
    {
        return new Vector2(Random.Range(-jumpX, jumpX), Random.Range(minJumpY, maxJumpY));
    }

    public IEnumerator NewTargets()
    {
        yield return new WaitForSeconds(4.0f);
        challengeManager.ClearFlies();
        yield return new WaitForSeconds(1.0f);
        challengeManager.SpawnTargets();
    }
}
