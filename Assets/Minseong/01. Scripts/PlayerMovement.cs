using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void OnMovement(Vector3 Movedir)
    {
        this.transform.Translate(Movedir);
    }
}
