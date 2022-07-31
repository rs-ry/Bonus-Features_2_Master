
using UnityEngine;
using TMPro;
using UnityEditor;

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


/*
    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }
*/
}
