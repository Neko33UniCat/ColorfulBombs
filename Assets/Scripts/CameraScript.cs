using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Body;
    public float Speed;
    public float DefaultSpeed;
    public float RelativeRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Speed = Body.GetComponent<BodyControllerScript>().Speed;
        transform.position += new Vector3(0f, 0f, Speed * RelativeRate*Time.deltaTime);
    }
}
