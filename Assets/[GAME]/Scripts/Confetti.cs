using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public static Confetti Instance;

    private void Awake()
    {
        Instance = this;
    }


    public GameObject confetti1, confetti2;



    public void SetActiveConfetties()
    {
        confetti1.SetActive(true);
        confetti2.SetActive(true);

        confetti1.GetComponent<ParticleSystem>().Play();
        confetti2.GetComponent<ParticleSystem>().Play();




    }


}
