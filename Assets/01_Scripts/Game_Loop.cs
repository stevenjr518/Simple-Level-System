using UnityEngine.UI;
using UnityEngine;
using Level;

public class Game_Loop : MonoBehaviour
{
    Level_Lun lun;
    public Text lvText;
    public Text expText;
    public Text atkText;
    public Text hpText;
    public Text mpText;

    void Start()
    {
        int exp = PlayerPrefs.GetInt("EXP_Lun", 0);
        lun = new Level_Lun(exp);
        UpdateUIInfo();
    }

    public void AddExp(int value)
    {
        lun.AddExp(value);
        UpdateUIInfo();
    }

    private void UpdateUIInfo()
    {
        expText.text = "Exp:" + lun.GetExp().ToString();
        atkText.text = "Atk:" + lun.GetAtkBaseValue().ToString();
        lvText.text = "Lv:" + lun.GetLv().ToString();
        hpText.text = "HP:" + lun.GetHPBaseValue().ToString();
        mpText.text = "MP:" + lun.GetMPBaseValue().ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("EXP_Lun", lun.GetExp());
    }
}


