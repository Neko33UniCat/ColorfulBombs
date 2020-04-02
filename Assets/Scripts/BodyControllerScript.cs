using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyControllerScript : MonoBehaviour
{
    public float DefaultSpeed;
    public float Speed;
    public float RateSpeed;
    public float accelMP;
    public GameObject Camera;
    public GameObject[] PartyObj;
    public GameObject ScoreingObject;

    public int MaxHP;
    public int MaxMP;
    public float MPChargeSpeed;
    public float UseMP;

    public Slider HP_Slider;
    public Slider MP_Slider;

    public GameObject Canvas;
    Rigidbody rigidbody;
    int flag = 0;
  // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        SliderSetup();
        Speed = DefaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        if (HP_Slider.value <= 0f)
        {
            DefaultSpeed = 0;
            Speed = 0;
            Canvas.GetComponent<UIScript>().GameOver();
            ScoreingObject.GetComponent<ScoringScript>().isMoving = false;
        }
        if(ScoreingObject.GetComponent<ScoringScript>().isMoving == true)
        {
            Vector3 Vertical = new Vector3();
            Vector3 Horizontal = new Vector3();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Horizontal = new Vector3(Speed, 0f, 0f);
                //transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //transform.position -= new Vector3(Speed * Time.deltaTime, 0f, 0f);
                Horizontal = new Vector3(-Speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < Camera.transform.position.z + 15f)
            {
                //transform.position += new Vector3(0f, 0f, Speed * Time.deltaTime);
                Vertical = new Vector3(0f, 0f, Speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //transform.position -= new Vector3(0f, 0f, Speed * Time.deltaTime);
                Vertical = new Vector3(0f, 0f, -Speed);
            }
            rigidbody.velocity = Horizontal + Vertical;
            if (Input.GetKeyDown(KeyCode.Space) && MP_Slider.value >= UseMP && HP_Slider.value > 0f)
            {
                MP_Slider.value -= UseMP;
                GameObject Inst = (GameObject)Instantiate(PartyObj[Random.Range(0,127)%PartyObj.Length], gameObject.transform.position + new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(Random.value,Random.value,Random.value) * 360f));
                Inst.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value,1f);
                Inst.GetComponent<Rigidbody>().AddForce(0f, 250f, 250f);
            }
            if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && MP_Slider.value > accelMP && HP_Slider.value > 0f)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                MP_Slider.value -= accelMP;
                Speed = DefaultSpeed * RateSpeed;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.gray;
                Speed = DefaultSpeed;
            }
            ControleSlider();
        }
            if (transform.position.z < Camera.transform.position.z + 3f)
        {
            DefaultSpeed = 0;
            Speed = 0;
            Canvas.GetComponent<UIScript>().GameOver();
            ScoreingObject.GetComponent<ScoringScript>().isMoving = false;
        }  }
    public void OnParticleCollision(GameObject other)
    {
        HP_Slider.value -= 1;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal" && flag == 0)
        {
            flag = 1;
            DefaultSpeed = 0;
            Speed = 0;
            ScoreingObject.GetComponent<ScoringScript>().isMoving = false;
            ScoreingObject.GetComponent<ScoringScript>().OutputLastScore();
            Canvas.GetComponent<UIScript>().Scorering();
        }
        else
        {
            if(collision.gameObject.GetComponent<Renderer>().material.color == new Color(51f, 0f, 51f, 1f) / 256f)
            {
                HP_Slider.value -= MaxHP / 4;
            }
            else if(collision.gameObject.GetComponent<Renderer>().material.color == new Color(238f, 91f, 166f, 1f) / 256f)
            {
                HP_Slider.value += MaxHP / 6;
            }
            else if (collision.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
            {
                MP_Slider.value += MaxMP / 8;
            }
        }
    }
    void SliderSetup()
    {
        HP_Slider.fillRect.GetComponent<Image>().color = Color.green;
        HP_Slider.maxValue = MaxHP;
        HP_Slider.value = MaxHP;

        MP_Slider.fillRect.GetComponent<Image>().color = Color.cyan;
    }
    void ControleSlider()
    {   
        if(HP_Slider.value < MaxHP / 6)
        {
            HP_Slider.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if(HP_Slider.value < MaxHP / 2)
        {
            HP_Slider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            HP_Slider.fillRect.GetComponent<Image>().color = Color.green;
        }
        MP_Slider.value += MPChargeSpeed;
    }

}
