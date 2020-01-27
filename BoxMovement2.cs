using UnityEngine;

public class BoxMovement2 : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public bool wireframeMode = false;
    private float F1;
    private Vector3 S1;
    private Vector3 S2;

    void Start()
    {
        this.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        GetComponent<Rigidbody>().mass = 200;
    }

    private void OnMouseUpAsButton()
    {
        this.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);
        GetComponent<Rigidbody>().mass = 10;
    }

    private void OnMouseDown()
    {
        F1 = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        S1 = gameObject.transform.position - MouseDrag();
    }

    private Vector3 MouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = F1;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        transform.position = MouseDrag() + S1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.enabled = false;
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.black);
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().mass = 200;
        }
        else
        {
            
            if (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Move Camera Up
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Move Camera DOWN
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Move Camera RIGHT
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Move Camera LEFT
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Shift Camera UP
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Shift Camera DOWN
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Shift Camera LEFT
            {
                transform.Rotate(Vector3.up, -doubleSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//Shift Camera RIGHT
            {
                transform.Rotate(Vector3.up, doubleSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Delete))//Delete Object
            {
                GameObject.Destroy(gameObject);
            }
        }
        
    }
}