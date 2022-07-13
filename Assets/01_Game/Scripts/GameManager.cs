
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Class member declaration

    private void Awake()
    {                               // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }                           // end of new code
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int score = 0;
    TMP_Text highScore;

    private int totalSpawns;
    public TMP_Text totalSpawnsTxt;

    int givenFeeds;
    public TMP_Text givenFeedsTxt;

    public int  currentlyToFeed;
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














    public float DownScaleValue(float downRange, float currentX, float min)
    {
        float onePercent = downRange * 0.01f;
        float dynamicRange = currentX - min; // currentXSize - minSize;
        return 100 - dynamicRange / onePercent;
    }

    public float UpScaleValue(float upRange, float max, float currentX)
    {
        float onePercent = upRange * 0.01f;
        float dynamicRange = max - currentX;
        return 100 - dynamicRange / onePercent;
    }






















    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }
}
