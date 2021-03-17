using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{

    public DataScriptableObject scriptableObject;

    private void Update()
    {
        Rotate();
    }


    public void Collect()
    {

        scriptableObject.score.score += 5;

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bezier bezier = other.GetComponent<Bezier>();

        if (bezier != null)
        {
            Collect();
        }
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * 150 * Time.deltaTime);
    }
}
