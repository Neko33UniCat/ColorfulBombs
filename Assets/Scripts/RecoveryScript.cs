using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryScript : MonoBehaviour
{   public enum RecoverType
    {
        HP_Recover,
        MP_Recover
    }
    public RecoverType Type;

    // Start is called before the first frame update
    void Start()
    {
        if(Type == RecoverType.HP_Recover)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(238f, 91f, 166f, 1f) / 256f;
        }
        else if(Type == RecoverType.MP_Recover)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Stage")
        {
            Destroy(gameObject);
        }
    }
}
