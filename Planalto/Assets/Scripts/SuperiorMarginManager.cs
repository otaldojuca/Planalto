using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperiorMarginManager : MonoBehaviour {

    [SerializeField] private SO_Card card;

    private List<Image> greenArcImages = new List<Image>();
    [SerializeField] private List<int> currentValue = new List<int>();

    private int imageFillMaxValue = 20;


    [SerializeField] private ClickAndDrag clickAndDrag;


    void Start() {

        for (int i = 0; i < this.transform.childCount; i++) greenArcImages.Add(this.transform.GetChild(i).GetChild(0).GetComponent<Image>());
    }


    void Update() {


        /*
        if (clickAndDrag.alreadySwiped) {

            IncrementMeters();

        }

        for (int i = 0; i < this.transform.childCount; i++) {

            if      (clickAndDrag.optionNumber == 1) greenArcImages[i].fillAmount += currentValue[i] * (1f / imageFillMaxValue);
            else if (clickAndDrag.optionNumber == 2) greenArcImages[i].fillAmount += currentValue[i] * (1f / imageFillMaxValue);

        }
        */
        

    }

    /*
    void IncrementMeters() {

        for (int i = 0; i < this.transform.childCount; i++) {

            if      (clickAndDrag.optionNumber == 1) currentValue[i] = card.valuesChange1[i];
            else if (clickAndDrag.optionNumber == 2) currentValue[i] = card.valuesChange2[i];

        }

    }
    */

}
