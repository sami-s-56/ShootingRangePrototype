using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
   
    [SerializeField]
    GameObject[] placeHolder;

    [SerializeField]
    WeaponsList wList;

    [SerializeField]
    private Text nameText, firepowerText, rangeText, caliberText, capacityText, recoilText;

    private int pos;

    [SerializeField]
    private GameObject selectButton, optionButton, content;

    private void Start()
    {
        InitializeMenu();

        for(int c = 0; c < wList.weapons.Count; c++)
        {
            GameObject ob = Instantiate(optionButton);
            ob.transform.SetParent(content.transform);
            ob.name = wList.weapons[c].weaponName;
            ob.transform.localScale = Vector3.one;
            ob.GetComponentInChildren<Text>().text = ob.name;
            ob.GetComponent<OptionButtonScript>().SetPosition(c);
        }

        DisplayData();

    }

    private void InitializeMenu()
    {
        if (PlayerPrefs.HasKey("Position"))
        {
            WeaponsList.selectedPos = PlayerPrefs.GetInt("Position");
            pos = WeaponsList.selectedPos;
        }
        else
        {
            pos = 0;
            WeaponsList.selectedPos = pos;
        }
    }

    private void DisplayData()
    {
        nameText.text = wList.weapons[pos].weaponName;
        firepowerText.text = "Fire Power: " + wList.weapons[pos].firepower.ToString();
        rangeText.text = "Range: " + wList.weapons[pos].range.ToString();
        caliberText.text = "Caliber: " + wList.weapons[pos].caliber;
        capacityText.text = "Capacity: " + wList.weapons[pos].capacity.ToString();
        recoilText.text ="Recoil: " + wList.weapons[pos].recoil.ToString();
        placeHolder[pos].SetActive(true);
        if(pos == WeaponsList.selectedPos)
        {
            selectButton.SetActive(false);
        }
        else
        {
            if (!selectButton.activeSelf)
            {
                selectButton.SetActive(true);
            }
        }
    }

    public void OnNext()
    {
        placeHolder[pos].SetActive(false);
        pos++;
        if(pos == (wList.weapons.Count))
        {
            pos = 0;
        }
        DisplayData();
    }

    public void OnPrev()
    {
        placeHolder[pos].SetActive(false);
        pos--;
        if (pos == -1)
        {
            pos = wList.weapons.Count-1;
        }
        DisplayData();
    }

    public void OnSelect()
    {
        WeaponsList.selectedPos = pos;
        PlayerPrefs.SetInt("Position", WeaponsList.selectedPos);
        selectButton.SetActive(false);
    }

    public void OnOptionClick(int no)
    {
        placeHolder[pos].SetActive(false);
        pos = no;
        DisplayData();
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
}
