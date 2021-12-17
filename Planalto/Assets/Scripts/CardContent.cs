using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContent : MonoBehaviour {

    [SerializeField] private SO_Card card;
    private TMPro.TMP_Text cardText;
    private Image image;
    private TMPro.TMP_Text optionText;

    private ClickAndDrag clickAndDrag;

    void Start() {

        clickAndDrag = GetComponentInParent<ClickAndDrag>();

        image = transform.GetChild(1).GetComponent<Image>();
        cardText = transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
        optionText = transform.GetChild(2).GetComponentInChildren<TMPro.TMP_Text>();
    }

    
    void Update() {

        image.sprite = card.background;
        image.color = Color.white;

        cardText.text = card.content;

        if (clickAndDrag.optionNumber == 1) optionText.text = card.optionText1;
        else if (clickAndDrag.optionNumber == 2) optionText.text = card.optionText2;
    }

    /*
    public void Option1() {
        optionText.text = card.option1;
    }

    public void Option2() {
        optionText.text = card.option2;
    }
    */

}
