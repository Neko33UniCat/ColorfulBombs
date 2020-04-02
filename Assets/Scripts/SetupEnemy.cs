using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnemy : MonoBehaviour
{
    public GameObject[] Type1s ;
    public GameObject[] Type2s ;
    public GameObject[] Type3s ;
    // Start is called before the first frame update
    void Start()
    {
        Type1s = Resources.LoadAll<GameObject>("EnemyFormats/Type1");
        Type2s = Resources.LoadAll<GameObject>("EnemyFormats/Type2");
        Type3s = Resources.LoadAll<GameObject>("EnemyFormats/Type3");
        for(int i = 1; i <= 6 * 3; i++)
        {
            int r = (int)(Random.value * 10000 % 12);
            if(i % 6 == 3)
            {
                Instantiate(Type3s[r], new Vector3(0f, 0f, 6f * i), Quaternion.identity);
            }
            else if (i % 6 == 0)
            {
                Instantiate(Type2s[r], new Vector3(0f, 0f, 6f * i), Quaternion.identity);
            }
            else
            {
                Instantiate(Type1s[r], new Vector3(0f, 0f, 6f * i), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
