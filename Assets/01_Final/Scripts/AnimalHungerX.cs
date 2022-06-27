using System;
using UnityEngine;
using UnityEngine.UI;


public class AnimalHungerX : MonoBehaviour
{
    public Transform sliderPos;
    public GameObject sliderCanvasPref;
    public string healthSliderName = "HealthSlider-";
    public Vector3 originalScale;

    DetectCollisionsX health;

    public GameObject[] players;

    //   public Canvas[] allCanvas;
    int playerQTY;


    private void Start()
    {
        health = GetComponent<DetectCollisionsX>();



        players = GameObject.FindGameObjectsWithTag("Player");
        playerQTY = players.Length;
        Debug.Log("Playerqty is " + playerQTY);
        if (playerQTY > 0)
        {

            for (int i = 0; i < playerQTY; i++)
            {
                Vector3 canvasPos = new Vector3(sliderPos.transform.position.x, sliderPos.transform.position.y, sliderPos.transform.position.z);
                GameObject instSliderCanvas = Instantiate(sliderCanvasPref, canvasPos, Quaternion.identity) as GameObject;

                // register the original scale of canvas
                originalScale = new Vector3(instSliderCanvas.transform.localScale.x, instSliderCanvas.transform.localScale.y, instSliderCanvas.transform.localScale.z);

                instSliderCanvas.transform.SetParent(gameObject.transform);  // to stay with parent   

                string sliderCanvasName = healthSliderName + i.ToString();
                instSliderCanvas.name = sliderCanvasName;                  // Name it

                int layerNr = 10 + i;
                instSliderCanvas.layer = layerNr; // apply the right layer 


                // SLIDER stuff
                GameObject UnderGrowthSlider = instSliderCanvas.transform.Find("UnderGrowthSlider").gameObject;
                Slider minSlider = UnderGrowthSlider.GetComponent<Slider>();
                minSlider.maxValue = 100f;
                minSlider.value = 0;

                GameObject OverGrowthSlider = instSliderCanvas.transform.Find("OverGrowthSlider").gameObject; // find slide
                Slider maxSlider = OverGrowthSlider.GetComponent<Slider>();   // and get slider component
                maxSlider.maxValue = 100;
                maxSlider.value = 0;

                // CAMERA section
                Transform obj = players[i].transform.Find("Camera");
                if (obj == true)
                {
                    Camera cam = obj.GetComponent<Camera>();
                    string layerN = "Canvas" + i.ToString();
                    cam.cullingMask = (1 << layerNr);
                    cam.cullingMask |= 1 << LayerMask.NameToLayer("Default");
                }
                else
                    Debug.Log("No camera found on plater" + i + "</br> 1) Check if camera object is named as n\"Camera\"");
            }
        }
        else
            Debug.Log("No platers found  </br> 1) Check if all players have n\"Player\" tag on them");
    }

    private void Update()
    {
        for (int i = 0; i < playerQTY; i++)
        {
            string sliderCanvasName = healthSliderName + i.ToString();
            Transform sliderRotation = gameObject.transform.Find(sliderCanvasName);

            Transform thisPlayersPos = players[i].GetComponent<Transform>();

            sliderRotation.LookAt(thisPlayersPos);

            // rescaling part
            Vector3 currentScale = new Vector3(sliderRotation.transform.localScale.x, sliderRotation.transform.localScale.y, sliderRotation.transform.localScale.z);
            currentScale = originalScale;


            // Debug.Log("Min=> " + health.underFeedSliderVal + "   Max=> " + health.overFeedSliderVal);

            string underSlider = "HealthSlider-" + i.ToString() + "/UnderGrowthSlider";
            GameObject underGrowthSlider = gameObject.transform.Find(underSlider).gameObject;
            if (underGrowthSlider == true)
            {
                Slider minSlider = underGrowthSlider.GetComponent<Slider>();   // and get slider component
                if ((health.currentXSize < health.maxSize) && (health.currentXSize > health.minSize))
                {
                    minSlider.value = health.underFeedSliderVal;
                }
            }
            else
                Debug.Log("underGrowthSlider slider havn't been found");

            string overSlider = "HealthSlider-" + i.ToString() + "/OverGrowthSlider";
            GameObject overGrowthSlider = gameObject.transform.Find(overSlider).gameObject;
            if (overGrowthSlider == true)
            {
                Slider maxSlider = overGrowthSlider.GetComponent<Slider>();   // and get slider component
                if ((health.currentXSize < health.maxSize) && (health.currentXSize > health.minSize))
                {
                    maxSlider.value = health.overFeedSliderVal;
                }
            }
            else
                Debug.Log("OverGrowthSlider slider havn't been found");

        }
    }
}
