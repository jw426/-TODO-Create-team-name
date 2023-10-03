using UnityEngine;

public class EmotionScript : MonoBehaviour
{
    [SerializeField] private GameObject scManager;
    public GameObject[] emotionBtns; 
    public string correct; 
    public string[] wrongEmotions;

    // Start is called before the first frame update
    void Start()
    {
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        correct = sc.chosenEmotion.name;
        Debug.Log(correct);

        int correctBtn = Random.Range(0, emotionBtns.Length - 1);
        Debug.Log(correctBtn);

        // To implement
        //string wrong = Path.Combine(ScenarioScript.curDir, "WrongEmotions.txt");
        //StreamReader reader = new StreamReader(wrong);
        //wrongEmotions = reader.ReadToEnd().Split("\n");
    

        for (int i = 0; i < emotionBtns.Length; i++) {
        Answers asc = emotionBtns[i].GetComponent<Answers>();
            if (i == correctBtn) {
                asc.assignValue(correct, true);
            } else {
                string wrongEmotion = "Sample"; 
                asc.assignValue(wrongEmotion, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
