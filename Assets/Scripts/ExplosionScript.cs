using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    public void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        GameObject G = Instantiate(Particle,gameObject.transform.position,Quaternion.identity);
        G.GetComponent<ParticleSystem>().Play();
        foreach (Collider obj in hitColliders)
        {
            if (obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().AddExplosionForce(250f, transform.position, 3f);
            }
        }
        Destroy(gameObject);
    }
}
