using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    private Image barImage;
    public static Rage rage;
    
    private void Awake() {
       barImage = transform.Find("bar").GetComponent<Image>();
       rage = new Rage();
    }
    private void Update(){
        rage.Update();

        barImage.fillAmount = rage.GetRageNormalized();
    }

}
public class Rage {
    public const int RAGE_MAX = 100;

    private float rageAmount;
    private float rageRegenAmount;


    public Rage(){
        rageAmount = 0;
        rageRegenAmount = 15f;
    }

    public void Update (){
        rageAmount += rageRegenAmount * Time.deltaTime;
        rageAmount = Mathf.Clamp(rageAmount, 0f, RAGE_MAX);
    }

    public void TrySpendRage(int amount) {
        if(rageAmount >= amount){
            rageAmount -= amount;
        }
    }

    public float GetRageNormalized(){
        return rageAmount / RAGE_MAX;
    }
}
