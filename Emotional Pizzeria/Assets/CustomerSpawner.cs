using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] GameObject customer;
    [SerializeField] GameObject scenario;
    [SerializeField] GameObject greetings;
    [SerializeField] Transform SpriteCanvas;
    [SerializeField] float timer;
    [SerializeField] int customerLimit;

    int numCustomer = 0;
    bool hasNextCustomer = false;

    GameObject currCustomer;
    GameObject body;
    GameObject expression;
    GameObject speechBubble;

    IEnumerator CustomerCoroutine()
    {
        /* Gets children of Customer Game Object */
        body = currCustomer.transform.GetChild(0).GetChild(0).gameObject;
        expression = currCustomer.transform.GetChild(0).GetChild(1).gameObject;
        speechBubble = currCustomer.transform.GetChild(1).gameObject;

        /* Renders Customer after some time */
        yield return new WaitForSecondsRealtime(timer);
        body.GetComponent<CharacterScript>().Render();
        ScenarioScript.Emotion emotion = scenario.GetComponent<ScenarioScript>().getChosenEmotion();
        expression.GetComponent<ExpressionScript>().SetExpressionByFile("Sprites/" + emotion.sprite);

        /* Renders Speech Bubble after some time */
        yield return new WaitForSecondsRealtime((float)(timer + 0.5));
        speechBubble.SetActive(true);

    }

    public void HasNextCustomer()
    {
        hasNextCustomer = true;
    }

    void Update()
    {

        if (numCustomer == customerLimit)
        {
            hasNextCustomer = false;
        }

        /* Creates next customer */
        if (hasNextCustomer)
        {
            if (currCustomer != null)
            {
                Destroy(currCustomer);
            }
            currCustomer = Instantiate(customer, SpriteCanvas, false);
            StartCoroutine(CustomerCoroutine());
            hasNextCustomer = false;
            numCustomer++;
        }
        

        //if Hello is done

        //if scenario is done

    }




}
