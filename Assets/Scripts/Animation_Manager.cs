using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string active = "current";

    void Start()
    {
        In();
    }

    public void Out(string menu)
    {
        if (active == menu)
        {
            return;
        }

        animator.Play(active + "_out");
        active = menu;
    }

    public void In()
    {
        animator.Play(active + "_in");
    }
}
