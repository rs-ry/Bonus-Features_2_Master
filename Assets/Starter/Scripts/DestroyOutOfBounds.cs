using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    #region Added for Medium Challenge
    private float sideBound = 30;
    #endregion

    #region Added for Hard Challenge
    private GameManager gameManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Added for Hard Challenge
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            #region Added for Hard Challenge
            gameManager.AddLives(-1);
            #endregion

            Destroy(gameObject);
        }
        #region Add for Medium Challenge
        //Check if we are off the screen to the right
        else if (transform.position.x > sideBound)
        {
            #region Added for Hard Challenge
            gameManager.AddLives(-1);
            #endregion

            Destroy(gameObject);
        }
        //Check if we are off the screen to the left
        else if(transform.position.x < -sideBound)
        {
            #region Added for Hard Challenge
            gameManager.AddLives(-1);
            #endregion

            Destroy(gameObject);
        }
        #endregion
    }
}


