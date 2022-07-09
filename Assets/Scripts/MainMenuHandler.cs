using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{
    public InputField inputName;
    private string userName;
    // Start is called before the first frame update
    void Start()
    {
        inputName.text = DataBase.Instance.userName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataBase.Instance.userName = inputName.text.ToString();
        
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
