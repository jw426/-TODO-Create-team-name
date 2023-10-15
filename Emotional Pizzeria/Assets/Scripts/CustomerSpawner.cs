using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] GameObject customer;
    [SerializeField] AudioSource customerIn;
    [SerializeField] AudioSource customerOut;
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
        yield return new WaitUntil(() => customerOut.isPlaying == false);
        yield return new WaitForSecondsRealtime(timer);
        customerIn.Play();
        yield return new WaitUntil(() => customerIn.isPlaying == false);
        body.GetComponent<CharacterScript>().Render();
        
        /* Renders Speech Bubble after some time */
        //yield return new WaitForSecondsRealtime((float)(timer));
        speechBubbleText = speechBubble.transform.GetChild(0).gameObject;
        //speechBubbleText.GetComponent<TextScript>().InitializeByString("Hello.");
        speechBubble.SetActive(true);
        ScenarioScript.Emotion emotion = scenario.GetComponent<ScenarioScript>().getChosenEmotion();
        Debug.Log("emotion " + emotion);
        expression.GetComponent<ExpressionScript>().SetExpressionByFile("Sprites/" + emotion.sprite);

    }

    public void HasNextCustomer()
    {
        hasNextCustomer = true;
    }

    public void HasNoCustomer()
    {
        hasNextCustomer = false;
        customerIn.Stop();
        customerOut.Stop();
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
                customerOut.Play();
            }

            currCustomer = Instantiate(customer, SpriteCanvas, false);
            StartCoroutine(CustomerCoroutine());
            hasNextCustomer = false;
        }
        

        /* Time to Talk */

        /* Time to say Goodbye */

    }

    public bool customerOutStopped()
    {
        return !customerOut.isPlaying;
    }

    public void RemoveCurrCustomer()
    {

        if (currCustomer != null)
        {
            Debug.Log("not null customer");
            Destroy(currCustomer);
            customerOut.Play();
        } else
        {
            Debug.Log("null customer");
        }
        
    }


}
