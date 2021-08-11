using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MadeInHouse.Translate;

public class TranslateDropdown : MonoBehaviour
{
    public Dropdown m_Dropdown;

    private void Start()
    {
        string saveLang = PlayerPrefs.GetString(LanguageManager.SaveLanguageKey);

        int i;

        for (i = 0; i < 5; i++)
        {
            if (saveLang == LanguageManager.languageOptions[i])
            {
                break;
            }
        }

        m_Dropdown.value = i;
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
    }

    private void DropdownValueChanged(Dropdown change)
    {
        Debug.Log(change.value);
        LanguageManager.LoadLocazidedText(LanguageManager.languageOptions[change.value]);
    }
}
