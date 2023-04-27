using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTest : MonoBehaviour
{
    Animator animator;
    Camera camera;
    float originFOV;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        camera = GetComponent<Camera>();
        originFOV = camera.fieldOfView;
    }

    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            camera.fieldOfView = Mathf.Lerp(originFOV, 70, 1f);
        }
        else
        {
            camera.fieldOfView = originFOV;
        }
    }

}
