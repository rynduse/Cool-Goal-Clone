using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool isSuccess;

    private void Update()
    {
        if (Bezier.Instance.isBallMove)
        {
            StartCoroutine(WaitForTheFailState());
        }
    }


    IEnumerator WaitForTheFailState()
    {

        yield return new WaitForSeconds(4f);


        if (!isSuccess)
            EventManager.OnLevelFail.Invoke();
    }






}
