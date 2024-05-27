using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController characterController;
    public float speed = 5f;

    public float mouseSensitivity = 2.0f;
    [HideInInspector]
    public Transform playerBody;

    float horRotation = 0.0f;
    float verRotation = 0.0f;

    private bool moveEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<CharacterController>(out characterController);
        playerBody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEnabled)
        {
            PlayerMovement();
            CameraLock();
        }
    }

    public void SetEnabledMove(bool isEnabled)
    {
        moveEnabled = isEnabled;
    }

    void PlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal") * transform.right;
        var vertical = Input.GetAxisRaw("Vertical") * transform.forward;
        var dir = horizontal + vertical;

        Vector3 moveVec = dir * speed * Time.deltaTime;
        
        characterController.Move(moveVec);
    }

    void CameraLock()
    {
        var horizontal = Input.GetAxisRaw("Mouse X");
        var vertical = -Input.GetAxisRaw("Mouse Y");

        horRotation += horizontal;
        horRotation = Mathf.Clamp(horRotation, -90.0f, 90.0f);
        verRotation += vertical;
        verRotation = Mathf.Clamp(verRotation, -90.0f, 90.0f);

        // Camera.main.transform.eulerAngles= new Vector3(verRotation, horRotation, 0);
        Camera.main.transform.localEulerAngles = Vector3.right * horRotation;
        playerBody.Rotate(Vector3.up * horizontal);
    }
}
