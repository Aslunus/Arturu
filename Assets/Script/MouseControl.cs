using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [AddComponentMenu("Camera-Control/MouseControl")]
public class MouseControl : MonoBehaviour
{
    public enum RotationAxes { MouseXandy = 0, MouseX = 1, MouseY = 2};
    public RotationAxes axes = RotationAxes.MouseXandy;
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;

    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    Quaternion originRotation;

    float rotationX = 0f;
    float rotationY = 0f;



    void Start()
    {
        originRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            
        }
        originRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseXandy)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.right); 

            transform.localRotation = originRotation * xQuaternion * yQuaternion;
        }
        else if(axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originRotation * xQuaternion;

        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.right);
            transform.localRotation = originRotation * yQuaternion;

        }
    }
}
