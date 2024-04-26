using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class CardsText : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro red;
    public TextMeshPro blue;
    public string prompt;
    public string[] answers;
    public Animator r,b;
    public Image nextButton;

    // Start is called before the first frame update
    void Start()
    {


        string readFromFilePath = Application.streamingAssetsPath + "/Text/" + "Prompts" + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        int random = Random.Range(1, fileLines.Count/2+1);
        prompt = fileLines[random*2-2];
        answers = fileLines[random * 2-1].Split(',');
        int R_rand = Random.Range(0,answers.Length);
        int B_rand = Random.Range(0, answers.Length);
        red.text = answers[R_rand];
        while (B_rand == R_rand)
        {
            B_rand = Random.Range(0, answers.Length);
        }
        blue.text = answers[B_rand];

        text.text = prompt;
        StartCoroutine(waitForSides());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitForSides()
    {
        yield return new WaitForSeconds(6);
        r.SetBool("Open", true);
        b.SetBool("Open", true);

        yield return new WaitForSeconds(5);

        nextButton.GetComponent<Animator>().SetBool("Open", true);
    }
}
