using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasUtilityFunctionsScript : MonoBehaviour
{
    public TextMeshProUGUI codeText1;
    public TextMeshProUGUI codePriceText1;
    public TextMeshProUGUI codeText2;
    public TextMeshProUGUI codePriceText2;
    public TextMeshProUGUI codeText3;
    public TextMeshProUGUI codePriceText3;
    public TextMeshProUGUI codeText4;
    public TextMeshProUGUI codePriceText4;

    private List<TextMeshProUGUI> codeTextList = new List<TextMeshProUGUI>();
    // Start is called before the first frame update
    void Start()
    {
        codeTextList.Add(codeText1);
        codeTextList.Add(codePriceText1);
        codeTextList.Add(codeText2);
        codeTextList.Add(codePriceText2);
        codeTextList.Add(codeText3);
        codeTextList.Add(codePriceText3);
        codeTextList.Add(codeText4);
        codeTextList.Add(codePriceText4);

        // clear all code text
        foreach(TextMeshProUGUI guiText in codeTextList)
        {
            guiText.text = "";
        }
    }

    public void SetCodeTextsNextToSlots(int slotNumber, string codeName, int aminoCost, int nucleCost)
    {
        int baseIndex = slotNumber * 2; // magic to map slotNumber to codeTextList items
        codeTextList[baseIndex].text = codeName;
        codeTextList[baseIndex + 1].text = aminoCost + " / " + nucleCost;
    }
}
