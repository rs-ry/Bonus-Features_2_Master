using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;

    public static GameManager instance; // Class member declaration

    public Color TeamColor; // new variable declared

    private void Awake()
    {
        // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float UnderFeedValue(float downRange, float currentX, float min)
    {
        float onePercent = downRange * 0.01f;
        float dynamicRange = currentX - min; // currentXSize - minSize;
        return 100 - dynamicRange / onePercent;
    }

    public float OverFeedValue(float upRange, float max, float currentX)
    {
        float onePercent = upRange * 0.01f;
        float dynamicRange = max - currentX;
        return 100 - dynamicRange / onePercent;
    }


    public void AddLives(int value)
    {
        lives += value;

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            lives = 0;
        }
        Debug.Log("Lives = " + lives);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }
}
