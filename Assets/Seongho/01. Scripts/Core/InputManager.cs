using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.Instance.SoundPanel_SetActive(!SoundManager.Instance.soundPanel.activeSelf);
        }
    }
}
