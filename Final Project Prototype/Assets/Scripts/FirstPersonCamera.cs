using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    float cameraRotationVert = 0f;
    float cameraRotationHorz = 0f;

    public float mouseSens = 2.5f;

    float inputX;
    float inputY;

    // Update is called once per frame
    void Update()
    {      
        //get input
        inputX = Input.GetAxis("Mouse X") * mouseSens;
        inputY = Input.GetAxis("Mouse Y") * mouseSens;

        //make it rotate on the X axis (vertical) and Y axis (vertical)
        cameraRotationVert -= inputY;
        cameraRotationVert = Mathf.Clamp(cameraRotationVert, -90, 90);
     
        cameraRotationHorz += inputX;
        cameraRotationHorz = Mathf.Clamp(cameraRotationHorz, -90, 90);

        transform.localEulerAngles = Vector3.right * cameraRotationVert + Vector3.up * cameraRotationHorz;
    }
}
