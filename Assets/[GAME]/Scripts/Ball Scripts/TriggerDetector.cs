using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Vector3 provideOldForce;

        if (other.gameObject.name == "Line")
        {
            provideOldForce = transform.parent.gameObject.GetComponent<Rigidbody>().velocity;

            Bezier.Instance.turn = true;

            //transform.parent.GetComponent<Rigidbody>().AddForce(provideOldForce * 1.5f);
            transform.parent.GetComponent<Rigidbody>().AddForce((Bezier.Instance.point2.transform.position - transform.parent.position).normalized * 2500 * Time.deltaTime);
        }



        if (other.gameObject.name == "GoalLine")
        {

            Confetti.Instance.SetActiveConfetties();


            BallManager.Instance.isSuccess = true;

            EventManager.OnLevelSuccess.Invoke();

        }
    }
}
