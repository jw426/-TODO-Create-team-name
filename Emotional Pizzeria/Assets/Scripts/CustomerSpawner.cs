using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] GameObject customer;
    [SerializeField] Transform SpriteCanvas;
    [SerializeField] float timer;

    bool hasNextCustomer = false;

    Transform character;
    GameObject currCustomer;
    GameObject body;
    GameObject expression;
    GameObject scenario;
    GameObject speechBubble;
    GameObject speechBubbleText;


    IEnumerator CustomerCoroutine()
    {
        /* Gets children of Customer Game Object */
        character = currCustomer.transform.GetChild(0);
        body = character.GetChild(0).gameObject;
        expression = character.GetChild(1).gameObject;
        speechBubble = currCustomer.transform.GetChild(1).gameObject;
        scenario = currCustomer.transform.GetChild(3).gameObject;

        /* Renders Customer after some time */
        yield return new WaitForSecondsRealtime(timer);
        body.GetComponent<CharacterScript>().Render();
        ScenarioScript.Emotion emotion = scenario.GetComponent<ScenarioScript>().getChosenEmotion();
        expression.GetComponent<ExpressionScript>().SetExpressionByFile("Sprites/" + emotion.sprite);

        /* Renders Speech Bubble after some time */
        yield return new WaitForSecondsRealtime((float)(timer + 0.25));
        speechBubble.SetActive(true);

        /* Time to say Hello */

        //speechBubbleText = speechBubble.transform.GetChild(0).gameObject;
        //speechBubbleText.GetComponent<TextScript>().InitializeByString("Hello.");

    }

    public void HasNextCustomer()
    {
        hasNextCustomer = true;
    }

    public GameObject GetCurrentCustomer()
    {
        return currCustomer;
    }

    void Update()
    {

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
        }
        

        /* Time to Talk */

        /* Time to say Goodbye */

    }




}
