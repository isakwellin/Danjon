using UnityEngine;

public class weaponChoiceUI : MonoBehaviour
{
    public bow playerBow; 

    public void ChooseMelee()
    {
        playerBow.SetMelee(1);
        CloseUI();
    }

    public void ChooseRanged()
    {
        playerBow.SetMelee(2);
        CloseUI();
    }

    void CloseUI()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
