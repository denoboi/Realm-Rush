using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    Bank bank;

    public Bank Bank => bank == null ? bank = GetComponent<Bank>() : bank;
    public TextMeshProUGUI TextMeshProUGUI => textMesh == null ? textMesh = GetComponentInChildren<TextMeshProUGUI>() : textMesh;

    private void Update()
    {
        GoldText();
    }

    void GoldText()
    {
        TextMeshProUGUI.text = "Gold : " + Bank.CurrentBalance.ToString();
    }
}
