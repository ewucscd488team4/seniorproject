using UnityEngine;

public class Floor : MonoBehaviour
{
    public float x = 1f; //These are the original starting numbers
    public float y = 0.1f;
    public float z = 1f;

    void Start()
    {
        var planeRenderer = gameObject.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", Color.grey);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) //increase X & Z by one 
        {
            transform.localScale += new Vector3(1f, 0f, 1f);
        }

        if (Input.GetKey(KeyCode.E) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) //decrease X & Y by one
        {
            transform.localScale += new Vector3(-1f, 0f, -1f);
        }
    }
}