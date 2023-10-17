using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using TMPro;
using UnityEngine.UI;
using System.Collections;
>>>>>>> fixed_typing

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
<<<<<<< HEAD
=======
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private GameObject promptManager;
    [SerializeField] private GameObject pizzaSprite;
    private Image pizzaImage; 

    // for shaking animation (position)
    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    
    // for shaking animation (speed, time)
    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.3f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

>>>>>>> fixed_typing
    public QuizManager quizManager;

    /// <summary>
    /// reads isCorrect and generates new question through correct()
    /// </summary>
<<<<<<< HEAD
=======

    // set details for shaking movement 
    private void Awake()
    {
        pizzaImage = pizzaSprite.GetComponent<Image>();
        _startPos = pizzaImage.transform.position;
    }

    public void assignValue(string option, bool correct) {
        isCorrect = correct;

        // changing disabled color 
        if (correct) 
        {
            ColorBlock cb = pizzaSprite.GetComponent<Button>().colors;
            cb.disabledColor = new Color(227, 204, 100, 255);
            pizzaSprite.GetComponent<Button>().colors = cb;
        }
        //EmotionScript sc = promptManager.GetComponent<EmotionScript>();
        tmp.text = option; 
    }

>>>>>>> fixed_typing
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Incorrect Answer");
            pizzaSprite.GetComponent<Button>().interactable = false; 
            IncorrectAnimation();
            quizManager.wrong();
        }
    }
 
    public void IncorrectAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
 
    private IEnumerator Shake()
    {
        _timer = 0f;
    
        while (_timer < _time)
        {
            _timer += Time.deltaTime;
    
            _randomPos = _startPos + (Random.insideUnitSphere * _distance);
    
            pizzaImage.transform.position = _randomPos;
    
            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
    
        pizzaImage.transform.position = _startPos;
    }
 
}
