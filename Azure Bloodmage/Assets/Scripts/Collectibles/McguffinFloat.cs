using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McguffinFloat : MonoBehaviour
{
    public float fps = 10.0f;
    public float amp = 0.5f;
    public float frequency = 1f;

    Vector3 movePos = new Vector3();
    Vector3 curPos = new Vector3();
    void Start()
    {
        movePos = transform.position;
    }
    
    void Update()
    {
       
        transform.Rotate(new Vector3(0f, Time.deltaTime * fps, 0f), Space.World);

        curPos = movePos;
        curPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amp;

        transform.position = curPos;
    }
}
