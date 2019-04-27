using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeackerText : MonoBehaviour
{
    string[] texts = { "Welcome on bord dear guest",
                        "Lorem Ipsum",
                        "Dolores ipsaem",
                        "Tanatinus oratem patchiss\nOrolem jistatum",};
    public int textToDisplay = 0;
    GameObject textDisplay;
    private bool keyPress = false;
    // Start is called before the first frame update
    void Start()
    {
        this.textDisplay = gameObject.transform.Find("Canvas/SpeackerText").gameObject;
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
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyUp("space") && this.keyPress == true)
        {
            this.keyPress = !this.keyPress;
        }
    }

}
