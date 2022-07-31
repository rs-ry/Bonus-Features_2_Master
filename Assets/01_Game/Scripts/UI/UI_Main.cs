using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
