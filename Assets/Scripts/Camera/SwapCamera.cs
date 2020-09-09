using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;
    public bool inFirstPerson = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the C key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            //swap cameras
            inFirstPerson = !inFirstPerson;
            firstPersonCamera.gameObject.SetActive(inFirstPerson);
            thirdPersonCamera.gameObject.SetActive(!inFirstPerson);
        }
        //if we are in first person
        if (inFirstPerson)
        {
            //we need camera movement code, creature detection code, photo capture code

            //temp mouse lock code
            if (Input.GetKeyDown(KeyCode.V))
            {
                Cursor.lockState = CursorLockMode.Locked;

            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }
}
