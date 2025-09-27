using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] new Transform camera;
    [SerializeField] Vector2 Sensibility; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor * Sensibility.x);
        }

        if (ver != 0)
        {
            float angle = (camera.localEulerAngles.x - ver * Sensibility.y + 360) % 360;
            if (angle > 180) angle -= 360;
            angle = Mathf.Clamp(angle, -80, 80);

            camera.localEulerAngles = Vector3.right * angle;
        }

    }
}
