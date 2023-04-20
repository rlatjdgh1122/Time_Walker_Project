using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator[] anim;
    public int openCnt;
    public int closeCnt;

    private void Awake()
    {
        openCnt = 0;
        closeCnt = 0;
    }

    public void OpenDoor()
    {
        anim[openCnt].SetBool("character_nearby", true);
    }

    public void CloseDoor()
    {
        anim[closeCnt].SetBool("character_nearby", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenDoor();
            openCnt++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            CloseDoor();
            closeCnt++;
        }
    }  
}
