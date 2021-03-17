using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{

    public static UnityEvent OnDrawIndicator = new UnityEvent();
    public static UnityEvent OnBallMovement = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();



    public static UnityEvent OnShoot = new UnityEvent();
    

}
