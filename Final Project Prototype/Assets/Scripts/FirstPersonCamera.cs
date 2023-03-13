using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Character looks around without rotating its body
public class FirstPersonCamera : MonoBehaviour
{
    float cameraRotationVert = 0f;
    float cameraRotationHorz = 0f;

    //public float mouseSens = 2.5f;
    public float mouseSens = 10f;

    float inputX;
    float inputY;

    // Update is called once per frame
    void Update()
    {   
        //get input
        inputX = Input.GetAxis("Mouse X") * mouseSens;
        inputY = Input.GetAxis("Mouse Y") * mouseSens;

        //deals with both VERT and HOR movement since the player can't move
        if(SceneManager.GetActiveScene().name == "FirstScene") //used to be Demo Scene
        {
            //make it rotate on the X axis (vertical) and Y axis (vertical)
            cameraRotationVert -= inputY;
            cameraRotationVert = Mathf.Clamp(cameraRotationVert, -90, 90);
     
            cameraRotationHorz += inputX;
            cameraRotationHorz = Mathf.Clamp(cameraRotationHorz, -95, 95);

            transform.localEulerAngles = Vector3.right * cameraRotationVert + Vector3.up * cameraRotationHorz;
        }
        else
        {
            //only rotates on the Y axis since the X axis also rotates the character's body and not only the camera
            cameraRotationVert -= inputY;
            cameraRotationVert = Mathf.Clamp(cameraRotationVert, -90, 90);

            transform.localEulerAngles = Vector3.right * cameraRotationVert;
        }
    }
}
