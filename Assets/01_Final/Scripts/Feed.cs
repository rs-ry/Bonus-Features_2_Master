using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private float zBound = 145;

    private float xBound = 145;

    public float projectileSpeed;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileForwardMovement();

        OutOfBondDestroyer();

    }

    void OutOfBondDestroyer()
    {
        if (transform.position.z > zBound)  // If an object goes past the players view in the game, remove that object
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zBound)
        {
            gameManager.AddLives(-1);

            Destroy(gameObject);
        }
        else if (transform.position.x > xBound)        //Check if we are off the screen to the right
        {
            gameManager.AddLives(-1);

            Destroy(gameObject);
        }
        else if (transform.position.x < -xBound)        //Check if we are off the screen to the left
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }

    void ProjectileForwardMovement()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);

    }
}


