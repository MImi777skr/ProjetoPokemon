using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDdaBataia : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text LevelText;
    [SerializeField] BarraDeHp HpBar;
    [SerializeField] Text HpText;
    [SerializeField] int HpAntes;

    Pokemongol _Pokemongol; 
    public void SetData(Pokemongol pokemongol)
    {
        _Pokemongol = pokemongol;
        NameText.text = pokemongol.Base.Nome;
        LevelText.text = "Lvl " + pokemongol.Level;
        HpBar.SetHp((float)pokemongol.HP / pokemongol.MaxHP);
        HpText.text = pokemongol.HP.ToString() + "/" + pokemongol.MaxHP.ToString();
    }
    public IEnumerator UpdateHP()
    {
        StartCoroutine (HpCounter2());
        yield return HpBar.SmoothHp((float)_Pokemongol.HP / _Pokemongol.MaxHP);
        //HpText.text = _Pokemongol.HP.ToString() + "/" + _Pokemongol.MaxHP.ToString();
    }
    
    public void HpCounter1()
    {
        HpAntes = _Pokemongol.HP;
        
    }
    public IEnumerator HpCounter2()
    {
        int CurrentHp;
        CurrentHp = _Pokemongol.HP;
        while( HpAntes > CurrentHp)
        {
            HpAntes -= 1;
            HpText.text = HpAntes.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        HpAntes = CurrentHp;
    }
}
