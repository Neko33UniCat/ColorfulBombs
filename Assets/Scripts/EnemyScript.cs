using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float HP;
    public ScoringScript ScoringObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().GetComponent<Renderer>().material.color = new Color(51f, 0f, 51f, 1f) / 256f;
        ScoringObject = GameObject.Find("ScoringObject").GetComponent<ScoringScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0f)
        {
            Destroy(gameObject);
            ScoringObject.Score += 100.0f;

        }
    }
    public void OnParticleCollision(GameObject other)
    {
        HP -= 1f;
    }
}
