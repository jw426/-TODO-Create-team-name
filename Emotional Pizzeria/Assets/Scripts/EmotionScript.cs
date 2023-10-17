using UnityEngine;

public class EmotionScript : MonoBehaviour
{
    [SerializeField] private GameObject scManager;
    public GameObject[] emotionBtns; 

    // Start is called before the first frame update
    void Start()
    {

        // To implement
        //string wrong = Path.Combine(ScenarioScript.curDir, "WrongEmotions.txt");
        //StreamReader reader = new StreamReader(wrong);
        //wrongEmotions = reader.ReadToEnd().Split("\n");

        int correctIndex = chooseCorrect();
        assignValues(correctIndex);
        
    }

    // chooses the index of the correct button at random 
    private int chooseCorrect() 
    {
        int correctBtn = Random.Range(0, emotionBtns.Length - 1);
        return correctBtn;
    }

    // assigns appropriate values to emotion buttons 
    private void assignValues(int index) 
    {
        // loading the scenario manager 
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        string wrongChosen = "";

        for (int i = 0; i < emotionBtns.Length; i++) 
        {
            Answers asc = emotionBtns[i].GetComponent<Answers>();
            if (i == index) 
            {
                string correct = sc.chosenEmotion.name;
                Debug.Log(correct);
                asc.assignValue(correct, true);
            } 
            else 
            {
                string[] wrongEmotions = sc.chosenEmotion.incorrect; 
                string wrong = "hi"; 
                while ((wrong = wrongEmotions[Random.Range(0, wrongEmotions.Length - 1)]) == wrongChosen);
                wrongChosen = wrong; 
                //Debug.Log(wrongEmotions.Length);
                asc.assignValue(wrong, false);
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
