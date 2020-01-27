using System.Collections;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public Camera MainCamera, Camera2;
    public int availableBox;
    public int availableCrate;
    public int availableCylinder;
    private int imgCount = 0;

    void Start()
    {
        MainCamera.gameObject.SetActive(true);
        GameObject.Find("Camera2").transform.position = new Vector3(17.24574f, 169.3583f, -14.95312f);//(0.88f, 13.60f, -1.63f);//Still need to find best position

        Camera2.gameObject.SetActive(false);

        availableBox = 0;
        availableCrate = 0;
        availableCylinder = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//switch cameras to MainCamera
        {
            MainCamera.gameObject.SetActive(true);//Left Shift + Z 
            Camera2.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.X) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//switch cameras to Camera2
        {
            MainCamera.gameObject.SetActive(false);//Left Shift + X
            Camera2.gameObject.SetActive(true);
        }

      /*  if (Input.GetKey(KeyCode.N) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            availableBox++;
        }
        if (Input.GetKey(KeyCode.L) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))//Left CTRL + L to create Crate
        {
            availableCrate++;
        }
        if (Input.GetKey(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))//Left CTRL + C to create Cylinder
        {
            availableCylinder++;
        }*/
        if (Input.GetKey(KeyCode.Equals) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Minus) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.right, -doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.right, doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, -doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.H) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(1f, 23f, 65f);
            MainCamera.transform.rotation = Quaternion.Euler(10f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.G) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            GameObject.Find("Camera2").transform.position = new Vector3(17.3f, 166.9f, 23.5f);
            Camera2.transform.rotation = Quaternion.Euler(92.03198f, 1.095993f, 181.01f);
        }

    }

  
}