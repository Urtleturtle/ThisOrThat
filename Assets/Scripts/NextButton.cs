using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextButton : MonoBehaviour
{
    public Animator prompt;
    public Animator red;
    public Animator blue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void next()
    {
        red.SetBool("Open", false);
        blue.SetBool("Open", false);
        prompt.SetBool("Open", false);
        GetComponent<Animator>().SetBool("Open", false);
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
