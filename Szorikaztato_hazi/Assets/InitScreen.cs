using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitScreen : MonoBehaviour
{
    public TextMeshProUGUI codeText1;
    public TextMeshProUGUI codePriceText1;
    public TextMeshProUGUI codeText2;
    public TextMeshProUGUI codePriceText2;
    public TextMeshProUGUI codeText3;
    public TextMeshProUGUI codePriceText3;
    public TextMeshProUGUI codeText4;
    public TextMeshProUGUI codePriceText4;
    // Start is called before the first frame update
    void Start()
    {
        codeText1.text = "";
        codePriceText1.text = "";
        codeText2.text = "";
        codePriceText2.text = "";
        codeText3.text = "";
        codePriceText3.text = "";
        codeText4.text = "";
        codePriceText4.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
