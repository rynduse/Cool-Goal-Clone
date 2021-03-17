using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public DataScriptableObject scriptableObject;

    private void Awake()
    {
        Instance = this;
    }

    public RectTransform failPanelRect, successPanelRect;
    public Image indicatorImage, confirmImage;
    public Button nextLevelButton, restartLevelButton;
    public Text currentLevelNumText, nextLevelNumText, failScoreText, successScoreText;


    private void OnEnable()
    {
        EventManager.OnLevelSuccess.AddListener(SetConfirmImage);
        EventManager.OnLevelFail.AddListener(()=> StartCoroutine(BringrFailPanel()));
    }
    private void OnDisable()
    {
        EventManager.OnLevelSuccess.RemoveListener(SetConfirmImage);
        EventManager.OnLevelFail.RemoveListener(() => StartCoroutine(BringrFailPanel()));
    }

    private void Update()
    {
        currentLevelNumText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        nextLevelNumText.text = (SceneManager.GetActiveScene().buildIndex + 2).ToString();
    }



    public void SetAlphaValue()
    {
        indicatorImage.gameObject.SetActive(false);
    }

    void SetConfirmImage()
    {
        confirmImage.gameObject.SetActive(true);

        scriptableObject.score.score += 50;

        StartCoroutine(BringSuccessPanel());
    }
    IEnumerator BringSuccessPanel()
    {
        yield return new WaitForSeconds(1f);

        successScoreText.text = "Score: " + scriptableObject.score.score.ToString();

        successPanelRect.DOAnchorPos(Vector2.zero, .01f);
    }
    public void BackSuccesPanel()
    {
        successPanelRect.DOAnchorPos(new Vector2(-1080, 0), .01f);
    }
    public void BackFailPanel()
    {
        successPanelRect.DOAnchorPos(new Vector2(1080, 0), .01f);
    }
    IEnumerator BringrFailPanel()
    {
        yield return new WaitForSeconds(1f);

        failScoreText.text = "Score: " + scriptableObject.score.score.ToString();

        failPanelRect.DOAnchorPos(Vector2.zero, .01f);
    }


    public void PressNextLevelButton()
    {
        GameManager.Instance.LoadNextScene();


        SetLevelNumsToTexts();
    }
    public void PressRestartLevelButton()
    {
        GameManager.Instance.LoadCurrentScene();

        SetLevelNumsToTexts();
    }


    void SetLevelNumsToTexts()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;

        currentLevelNumText.text = sceneNum.ToString();
        nextLevelNumText.text = (sceneNum + 1).ToString();
    }



}
