using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummaryScript : MonoBehaviour
{
    public int lastAssigned = 0;
    [SerializeField] private GameObject[] spr;
    [SerializeField] private GameObject[] exp;


    // Start is called before the first frame update
    void Start()
    {
        lastAssigned = 0;
    }

    void Awake() {
        lastAssigned = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void assignValue(string sprite, string emotion) 
    {
        if (lastAssigned >= 5) return;

        Debug.Log(lastAssigned);

        spr[lastAssigned].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + sprite);
        spr[lastAssigned].GetComponent<TMP_Text>().text = emotion;
        lastAssigned++;
    }
}
