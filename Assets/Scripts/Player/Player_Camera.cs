using UnityEngine;
using System.Collections;

public class Player_Camera : MonoBehaviour
{

    public float rotationSpeed_Y = 50.0F;
    public float a;

    private void FixedUpdate()
    {
        float mouse_y = Input.GetAxis("Mouse Y");
        float rotacion = transform.localEulerAngles.x;
        if (rotacion >= -30.0f && rotacion <= 40.0f)
            transform.Rotate(-Mathf.Lerp(0, mouse_y * rotationSpeed_Y, Time.deltaTime), 0, 0);
        else if (rotacion >= -30.0f && mouse_y > 0.0f)
            transform.Rotate(-Mathf.Lerp(0, mouse_y * rotationSpeed_Y, Time.deltaTime), 0, 0);
        else if (rotacion <= 40.0f && mouse_y < 0.0f)
            transform.Rotate(-Mathf.Lerp(0, mouse_y * rotationSpeed_Y, Time.deltaTime), 0, 0);
    }
}