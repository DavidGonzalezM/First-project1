using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    private Transform followTransform;

    public Vector3 offset = new Vector3(0.0f, 0.5f, -2.5f);
    public Vector3 offset_rotation = new Vector3(0.0f, 0.0f, 0.0f);
    float moveSpeed = 10;
    float turnSpeed = 3;

    Vector3 goalPos;

    void Start()
    {
        if (!followTransform)
            followTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (!followTransform)
            this.enabled = false;
        
    }

    void LateUpdate()
    {
        goalPos = followTransform.position + followTransform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, goalPos, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, followTransform.rotation, Time.deltaTime * moveSpeed);
    }
}
/*using UnityEngine;
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
}*/
