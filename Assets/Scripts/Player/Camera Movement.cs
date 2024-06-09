using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform body;

    private PlayerStats stats;

    private float xRot;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponentInParent<PlayerStats>();
        LockCurser();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        if (!stats.IsDead())
        {
            arms.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
            body.Rotate(new Vector3(0, mouseX, 0));
        }
        else if(Cursor.lockState == CursorLockMode.Locked)
        {
            UnlockCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the cursor lock state
            ToggleCursorState();
        }
    }

    private void LockCurser()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void ToggleCursorState()
    {
        // If currently locked, unlock. If currently unlocked, lock.
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            UnlockCursor();
        }
        else
        {
            LockCurser();
        }
    }
}
