using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeHp : MonoBehaviour
{
    [SerializeField] int HpBar;
    [SerializeField] GameObject Health;
    [SerializeField] GameObject HealthAmount;

    // Start is called before the first frame update
    void Start()
    {
        //Health.transform.localScale = new Vector3(0.5f, 1f);
    }
    public void SetHp(float HpNormal)
    {
        Health.transform.localScale = new Vector3(HpNormal, 1f);
    }
    
    public IEnumerator SmoothHp(float newHP)
    {
        float CurrentHP = Health.transform.localScale.x;
        float ChangeAmount = CurrentHP - newHP;

        Health.transform.localScale = new Vector3(newHP, 1);
        
        while(CurrentHP - newHP > Mathf.Epsilon)
        {
            CurrentHP -= ChangeAmount * Time.deltaTime * 0.5f;
            HealthAmount.transform.localScale = new Vector3(CurrentHP, 1f);
            yield return null;
        }
        HealthAmount.transform.localScale = new Vector3(newHP, 1f);
    }
    
}
