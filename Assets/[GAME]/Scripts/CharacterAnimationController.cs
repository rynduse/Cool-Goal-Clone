using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }


    private void OnEnable()
    {
        EventManager.OnShoot.AddListener(() => Animator.SetTrigger("Shoot"));
    }
    private void OnDisable()
    {
        EventManager.OnShoot.RemoveListener(() => Animator.SetTrigger("Shoot"));

    }




}
