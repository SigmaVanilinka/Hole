using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Hole : MonoBehaviour
{
    public float FoodScore;
    public float StarvationRate;
    [SerializeField] private UIController uc;
    public float MaxFoodScore;
    [SerializeField] private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    private void Eat(float change)
    {
        FoodScore += change;
        if (FoodScore < 1||transform.localScale.x<1)
        {
            uc.LoseGame();
        }
        else tmp.text = (System.Math.Floor(FoodScore)).ToString();
        transform.localScale += new Vector3(change/2, change/2, change/2);


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (FoodScore > 0&&!uc.IsPaused)
        {
            var StarveValue = FoodScore * StarvationRate;
            Eat(-StarveValue);
        }
    }
}
