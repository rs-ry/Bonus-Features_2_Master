using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager instance;

    public static UI_Manager Instance
    {
        get { return instance; }
    }

    [SerializeField] TMP_Text scoreValue;
    [SerializeField] TMP_Text highScoredd;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       //SetHighScore(GameManager.instance.HighScore);
    }

    private int score = 0;
    TMP_Text highScore;

    private int totalSpawns;
    public TMP_Text totalSpawnsTxt;

    int givenFeeds;
    public TMP_Text givenFeedsTxt;

    public int currentlyToFeed;
    public TMP_Text currentlyToFeedTxt;

    private int successfullFeeds;
    public TMP_Text successfullFeedsTxt;

    private int wastedFeeds;
    public TMP_Text wastedFeedsTxt;

    public string playersTag;
    void Start()
    {
        givenFeeds = 0;
        successfullFeeds = 0;
    }
    private void Update()
    {
        currentlyToFeedTxt.text = "Animals to feed " + currentlyToFeed.ToString();

    }

    public void GivenFeeds(int value)
    {
        givenFeeds += value;
        givenFeedsTxt.text = "Food sent out " + givenFeeds.ToString();

    }

    public void WastedFeeds(int wasted)
    {
        wastedFeeds += wasted;
        wastedFeedsTxt.text = "Foodwaste " + wastedFeeds.ToString();

    }

    public void SuccessFeeds(int success)
    {
        successfullFeeds += success;
        successfullFeedsTxt.text = "Success feeds " + successfullFeeds.ToString();

    }

    public void SpwnwedInWholePlay(int aSpawn)
    {
        totalSpawns += aSpawn;
        totalSpawnsTxt.text = "Total Spawns " + totalSpawns.ToString();
    }



    public void UpdateScore(int score)
    {
        scoreValue.text = score.ToString();
    }

    public void SetHighScore(int score)
    {
        highScoredd.text = score.ToString();
    }


    // Back to MENU scene
public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}


