using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConrtoller : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetvalue;
    public float rotationSpeed = 0.0f;
    public Transform pivot;
    public float maxViewAngle;
    public float minviewAngle;
    public bool invertY;
    
    

    void Start()
    {
        if(!useOffsetvalue){
            offset = target.position - transform.position;
        }
        pivot.position = target.transform.position;
        pivot.transform.parent =target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(0 ,horizontal, 0);



        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
        pivot.Rotate(-vertical ,0, 0);

        if(pivot.rotation.eulerAngles.x >  maxViewAngle && pivot.rotation.eulerAngles.x < 180f){
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x >  180f && pivot.rotation.eulerAngles.x < 360f + minviewAngle){
            pivot.rotation = Quaternion.Euler(360f + minviewAngle, 0, 0);
        }

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        if(transform.position.y < target.position.y){
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
