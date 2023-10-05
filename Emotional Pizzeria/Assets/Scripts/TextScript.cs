using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;

    // We make this static so that we can just modify it 
    // between classes that need to set the speech rate.
    // Could make a getter in future if that's safer 
    public static float timeBtwChars = 0.1f;

    private string txt; 

    /// <summary>
    /// This function chooses a random scenario from the folder "situation" in the given path
    /// </summary>
    /// <param name="path"></param>
    public void SetTextByPath(string path) {
        Debug.Log(path);

        string[] files = Directory.GetFiles(Path.Combine(path, "situation"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        StreamReader reader = new StreamReader(sit_chosen);
        string situation = reader.ReadToEnd();

        //tmp.text = situation;
        tmp.text = "";
        txt = situation;
        StartCoroutine("TypeWriterTMP");
        //TypeWriterTMP(situation);
    }

    /// <summary>
    /// This function sets the text to the given string
    /// </summary>
    /// <param name="text"></param>
    public void SetTextByString(string text) {
        tmp.text = "";
        txt = text;
        StartCoroutine("TypeWriterTMP");
    }

    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in txt)
        {
            tmp.text += c;
            Debug.Log(timeBtwChars);
            yield return new WaitForSeconds(timeBtwChars);
        }
    }
}