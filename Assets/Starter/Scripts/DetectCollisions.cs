using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the other tag was the Player, if it was remove a life
        #region Added for Medium Challenge
        if (other.CompareTag("Player"))
        {
            #region Add for Hard Challenge
            gameManager.AddLives(-1);
            #endregion
            Destroy(gameObject);
        }
        #endregion
        //Check if the other tag was an Animal, if so add points to the score
        #region Added for Hard Challenge
        else if (other.CompareTag("Animal"))
        {
            #region Added for Expert Challenge
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            #endregion
            Destroy(gameObject);
        }
        #endregion
    }
}
