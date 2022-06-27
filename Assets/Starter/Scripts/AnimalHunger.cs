using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Added for Expert Challenge
public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;

    private int currentFedAmount = 0;
    private GameManager gameManager;

    void Start()
    {
        //Set the max value to that off the total amount this animal will need to be fed
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        //Disable the fillRect as we currently have a fed amount of 0
        hungerSlider.fillRect.gameObject.SetActive(false);

        //Set up the Game Manger reference
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;

        //Enable the fill rect to display the fed value
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;

        //Check if the animal has been fed enough
        if (currentFedAmount >= amountToBeFed)
        {
            gameManager.AddScore(amountToBeFed);
            Destroy(gameObject, 0.1f);
        }
    }
}
#endregion