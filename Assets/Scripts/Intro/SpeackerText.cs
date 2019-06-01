using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeackerText : MonoBehaviour
{
    string[] texts = { "Welcome on board dear guest",
                        "What an ordinary day...",
                        "Mmh, what is this noise?",
                        "It seems to come from outside...",};
    public int textToDisplay = 0;
    GameObject textDisplay;
    private bool keyPress = false;
    // Start is called before the first frame update
    void Start()
    {
        this.textDisplay = gameObject.transform.Find("Canvas/Dialogue/SpeackerText").gameObject;
        //this.textDisplay.GetComponent<Text>().text = texts[textToDisplay];
        this.textDisplay.GetComponent<Text>().text = texts[0];
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && this.keyPress == false)
        {
            this.keyPress = !this.keyPress;
            this.textToDisplay++;
            try
            {
                this.textDisplay.GetComponent<Text>().text = texts[textToDisplay];
            }
            catch (System.IndexOutOfRangeException e)
            {
                GameObject.Find("IntroSequence").GetComponent<Sequence>().NextSequence();
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyUp("space") && this.keyPress == true)
        {
            this.keyPress = !this.keyPress;
        }
    }

}
