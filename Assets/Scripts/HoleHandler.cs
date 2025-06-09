using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoleHandler : MonoBehaviour
{
    public int NormalSphereLayer, FallingSphereLayer;
    [SerializeField] private TextMeshProUGUI ast;
    [SerializeField] private GameObject hole;
    [SerializeField] private Hole holeScript;
    [SerializeField] private UIController uc;
    [SerializeField] private TextMeshProUGUI Mtmp;
    [SerializeField] private TextMeshProUGUI tmp;


    private void FixedUpdate()
    {
        transform.position = new Vector3(hole.transform.position.x, transform.position.y, hole.transform.position.z);
        uc.IsGameOver();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == NormalSphereLayer)
        {
            other.gameObject.layer = FallingSphereLayer;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FallingSphereLayer)
        {
            other.gameObject.layer = NormalSphereLayer;
        }

        if(other.tag == "Eatable"&& (other.gameObject.transform.position.y<transform.position.y))
        {
            Destroy(other.gameObject);
            Food objectFood = other.GetComponent<Food>();
            if (!uc.IsPaused)
            {
                holeScript.FoodScore += objectFood.scoreValue;
                hole.transform.localScale += new Vector3(objectFood.foodValue / 2, objectFood.foodValue / 2, objectFood.foodValue / 2);
            }
            tmp.text = System.Math.Floor(holeScript.FoodScore).ToString();
            if (holeScript.FoodScore > holeScript.MaxFoodScore)
            {
                holeScript.MaxFoodScore = (float)System.Math.Floor(holeScript.FoodScore);
                Mtmp.text = holeScript.MaxFoodScore.ToString();
            }
            uc.IsGameOver();
            ast.text = "+" + objectFood.foodValue;
        }
    }
}
