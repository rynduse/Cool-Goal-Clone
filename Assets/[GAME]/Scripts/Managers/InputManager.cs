using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public Transform point2, point3;

    private Vector3 firstPosMouse, lastPosMouse;

    private float differenceMouseX, lastX, lastX2, lastX3;

    private float sensitivity = -0.01f;

    private bool isShoot, didShoot;


    private void Update()
    {

        Swipe();

    }
    void Swipe ()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            if (didShoot)
                return;

            UIManager.Instance.SetAlphaValue();

            firstPosMouse = Input.mousePosition;

            //Bezier.Instance.SetActiveIndicator = true;
            EventManager.OnDrawIndicator.Invoke();
            
            isShoot = true;
        }

        if (Input.GetMouseButton(0))
        {
            lastPosMouse = Input.mousePosition;


            differenceMouseX = (lastPosMouse - firstPosMouse).x;

            if (Mathf.Abs(differenceMouseX) <= 400)
            {
                lastX2 = (differenceMouseX * sensitivity);
                lastX3 = (differenceMouseX * sensitivity * .5f);
                point2.position = new Vector3(lastX2, 0, 4.5f);

                point3.position = new Vector3(lastX3, 0, 11);
            }
            else
            {
                lastX = (differenceMouseX * sensitivity * .1f);

                point3.position = new Vector3(lastX3 - lastX * 2f, point3.position.y, point3.position.z);
            }


        }
        else
        {
            if (isShoot)
            {
                EventManager.OnShoot.Invoke();

                Bezier.Instance.SetActiveIndicator = false;

                StartCoroutine(WAitForAnimationShooting());

                isShoot = false;
                didShoot = true;
            }

        }

    }

    IEnumerator WAitForAnimationShooting()
    {
        yield return new WaitForSeconds(.9f);
        EventManager.OnBallMovement.Invoke();


    }


}
