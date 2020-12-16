using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform PlayerBody;
    float x_rotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouse_x);
    }
}
