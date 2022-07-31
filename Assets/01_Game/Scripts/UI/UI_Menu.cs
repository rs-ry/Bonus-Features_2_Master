using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{

    public GameObject startUp;
    public GameObject singleSetUpView;
    public GameObject multiSetUpView;
    bool isOn = false;

    [SerializeField] GameObject onStateObj, offStateObj;

    public void StartSinglePlay()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMultiPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void OnToggleButtonClick()
    {
        isOn = !isOn;

        if (isOn)
        {
            singleSetUpView.SetActive(false);
            multiSetUpView.SetActive(true);
        }
        else
        {
            singleSetUpView.SetActive(true);
            multiSetUpView.SetActive(false);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


}
