using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonScript : MonoBehaviour
{
    private int p;
    private Button itemButton;
    [SerializeField]
    private GameObject menuMngr;

    public void SetPosition(int a)
    {
        p = a;
    }

    private void Start()
    {
        itemButton = GetComponent<Button>();
        menuMngr = GameObject.Find("Canvas");
        if (menuMngr != null)
        {
            itemButton.onClick.AddListener(() => menuMngr.GetComponent<MenuManager>().OnOptionClick(p));
        }
    }

}
