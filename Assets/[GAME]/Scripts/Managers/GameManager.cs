using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DataScriptableObject scriptableObject;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != scriptableObject.levelNum.levelNum)
        {
            SceneManager.LoadSceneAsync(scriptableObject.levelNum.levelNum);
        }
    }


    public string lastScene;


    public void LoadNextScene()
    {

        scriptableObject.levelNum.levelNum = SceneManager.GetActiveScene().buildIndex + 1;

        UIManager.Instance.BackSuccesPanel();

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            scriptableObject.levelNum.levelNum = 0;

            SceneManager.LoadScene(scriptableObject.levelNum.levelNum);
        }

        SceneManager.LoadScene(scriptableObject.levelNum.levelNum);

    }

    public void LoadCurrentScene()
    {

        scriptableObject.levelNum.levelNum = SceneManager.GetActiveScene().buildIndex;


        UIManager.Instance.BackFailPanel();

        SceneManager.LoadScene(scriptableObject.levelNum.levelNum);


    }







}
