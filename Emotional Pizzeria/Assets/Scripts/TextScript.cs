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
    [SerializeField] float timeBtwChars = 0.1f;

    private string txt; 

    public void SetText(string path) {
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

    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in txt)
        {
            tmp.text += c;
            yield return new WaitForSeconds(timeBtwChars);
        }
    }
}
