using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string NextSceneName;
    public Text RuleText;
    public string Filename;
    public Text LoadingText;
    private TextAsset Script;
    // Start is called before the first frame update
    void Start()
    {
        Script = new TextAsset();
        Script = Resources.Load<TextAsset>(Filename);
        RuleText.text = Script.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        //Debug.Log("put");
        StartCoroutine(NowLoading(3));
    }
    IEnumerator NowLoading(int n)
    {
        //Debug.Log("load");
        string Message = "Now Loading .........";
        for(int i = 0; i < n; i++)
        {
            LoadingText.text = "";
            for(int j = 0; j < Message.Length; j++)
            {
                LoadingText.text += Message[j];
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(NextSceneName);
    }
}
