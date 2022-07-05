using UnityEngine;
using TMPro;
using System;

public class CharacterLookAt : MonoBehaviour
{
    [SerializeField]
    Transform character;
    
    // [SerializeField]
    // TMP_Text debugPanelText;

    float mouseX = 0;
    float mouseY = 0;
    float sensitivity = 2;

    void Start()
    {
        
    }

    void Update()
    {
        // Horizontal look
        if(Input.mousePosition.x < 20) // Left limit
        {
            mouseX -= sensitivity / 2;
        }
        else
        if(Input.mousePosition.x > Screen.width-21) // Right limit
        {
            mouseX += sensitivity / 2;
        }
        else // Between limits
        {
            mouseX += Input.GetAxis("Mouse X") * sensitivity;
        }

        // Vertical look
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -30f, 30f);

        // Update camera
        character.localEulerAngles = new Vector3(0, mouseX, 0);
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);

        // ------------------- Debugging -------------------
        // debugPanelText.text =
        //     "X: " + Input.mousePosition.x +
        //     " - " +
        //     "Y: " + Input.mousePosition.y;
    }
}
