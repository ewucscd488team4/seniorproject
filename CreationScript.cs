using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationScript : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public int availableBox;
    public int availableCrate;
    public int availableCylinder;
    private int imgCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.N) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
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
        }
        if (Input.GetKey(KeyCode.F12))//Puts .jpg in project folder. 
        {
            ScreenCapture.CaptureScreenshot("ScreenCaps/UnityProj" + imgCount + ".jpg");
            //Rect notice = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
            //GUI.Box(notice, "Screen Capture Recorded and Placed in Child_Data Folder");
            imgCount = imgCount + 1;
            Debug.Log(imgCount);
        }
        if (availableBox == 1)
        {
            CreateObject(10, 10, 20);
            StartCoroutine(Waiter());
        }
        if (availableCrate == 1)
        {
            CreateCrate(20, 20, 20);
            StartCoroutine(Waiter());
        }
        if (availableCylinder == 1)
        {
            CreateCylinder(10, 10, 10);
            StartCoroutine(Waiter());
        }

    }

    public void CreateObject(float width, float height, float length) //Create box with input
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
        cube.GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        cube.transform.localScale = new Vector3(width, height, length);
        cube.transform.position = new Vector3(0, height / 2, 0);
    }

    public void CreateCylinder(float width, float height, float length)//create standard Cylinder
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
        cube.GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        cube.transform.localScale = new Vector3(width, height, length);
        cube.transform.position = new Vector3(0, height / 2, 0);
    }

    public void CreateCrate(float width, float height, float length)//create standard Crate
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
        cube.transform.localScale = new Vector3(width, height, length);
        cube.transform.position = new Vector3(0, height / 2, 0);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        availableBox = 0;
        availableCrate = 0;
        availableCylinder = 0;
    }
}
