using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject ScoringObject;
    public Text GameOverText;
    public Text Score;
    public Text Bonus;
    public Text TimeScore;
    public Text TotleScore;
    public GameObject RestartButton;
    public float Speed;
    ScoringScript script;

    public int UIMoving;
    // Start is called before the first frame update
    void Start()
    {
        UIMoving = 0;
        script = ScoringObject.GetComponent<ScoringScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIMoving == 1)
        {
            Score.transform.position -= new Vector3(Speed, 0f, 0f) * Time.deltaTime;
            Bonus.transform.position -= new Vector3(Speed, 0f, 0f) * Time.deltaTime;
            TimeScore.transform.position -= new Vector3(Speed, 0f, 0f) * Time.deltaTime;
            if(Score.rectTransform.position.x < -300f)
            {
                TotleScore.color = Color.red;
                UIMoving++;
            }
        }
        if(UIMoving == 2)
        {
            TotleScore.transform.position += new Vector3(0, Speed, 0f) * Time.deltaTime;
            if(TotleScore.rectTransform.localPosition.y > 0f)
            {
                UIMoving++;
                Debug.Log(TotleScore.rectTransform.position.y);
            }
            else
            {
                RestartButton.SetActive(true);
            }
        }
    }
    public void GameOver()
    {
        GameOverText.text = "<size=27><color=red>Game\nOver</color></size>";
    }
    public void Scorering()
    {
        script.OutputLastScore();
        StartCoroutine(ShowScore(1f,1f,1f));
    }
    IEnumerator ShowScore(float a=0f,float b=0f,float c=0f,float d=0f)
    {
        Score.text = "Score : ";
        yield return new WaitForSeconds(a);
        string s = "";
        for (int i = 0; i < (int)script.Score/10; i++)
        {
            s = ((i+1)*10).ToString("F2");
            yield return new WaitForSeconds(0.02f);
            Score.text = "Score : " + s;
        }
        Bonus.text = "Bonus : ";
        yield return new WaitForSeconds(b);
        string t = "";
        for(int i = 0; i < script.BonusScore / 10; i++)
        {
            t = ((i + 1) * 10).ToString("F2");
            yield return new WaitForSeconds(0.02f);
            Bonus.text = "Bonus : " + t;
        }
        TimeScore.text = "TimeScore : ";
        yield return new WaitForSeconds(c);
        string u = "";
        for (int i = 0; i < script.TimeScore; i++)
        {
            //u = ((i + 1) * 10).ToString("F2") + (((script.TimeScore * 100)%100)/100f).ToString();
            float under = Mathf.Round(script.TimeScore * 100f) % 100 / 100f;
            u = (i + 1 + under).ToString();
            yield return new WaitForSeconds(0.0001f);
            TimeScore.text = "TimeScore : " + u;
        }
        float total = float.Parse(s) + float.Parse(t) + float.Parse(u);
        Debug.Log(total);
        TotleScore.text = "TotalScore : ";
        for(int i = 0; i < total.ToString().Length; i++)
        {
            TotleScore.text += total.ToString()[i];
            yield return new WaitForSeconds(0.1f);
        }
        //Score.text = "score : " + script.Score.ToString("F2");
        UIMoving = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Title");
    }
}
