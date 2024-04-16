using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSens : MonoBehaviour
{
    public Camera camer;
    public float ySens = 30f;
    public float xSens = 30f;
    private float xrotation = 0f;

    public void Lookaround(Vector2 input)
    {
        float Xmouse = input.x;
        float Ymouse = input.y;
        xrotation -= (Ymouse * Time.deltaTime) * ySens;
        xrotation = Mathf.Clamp(xrotation, -80f, 80f);
        camer.transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        transform.Rotate(Vector3.up * (Xmouse * Time.deltaTime) * xSens);
    }
}
