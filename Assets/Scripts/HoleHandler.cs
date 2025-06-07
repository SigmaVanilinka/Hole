using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoleHandler : MonoBehaviour
{
    public int NormalSphereLayer, FallingSphereLayer;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI ast;
    [SerializeField] private GameObject hole;
    public int FoodScore;
    public int MaxFoodScore;
    private bool IsHungry = true;
    private float cf;
    [SerializeField] private UIController uc;

    private void Start()
    {
        tmp.text = "1";
        cf = 5;

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(hole.transform.position.x,transform.position.y,hole.transform.position.z);
    }

    private void Update()
    {
        if(IsHungry&& uc.IsPaused == false)
        {
            StartCoroutine(Hunger());
        }
        if(cf<=1)
        {
            Destroy(hole);
        }
    }
    private IEnumerator Hunger()
    {
        IsHungry=false;
        hole.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
        cf*=0.9f;
        tmp.text = (System.Math.Round(cf)).ToString();
        yield return new WaitForSeconds(2f);
        IsHungry = true;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("!");
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
            tmp.text = (int.Parse(tmp.text)+objectFood.scoreValue).ToString();
            FoodScore+=objectFood.scoreValue;
            hole.transform.localScale += new Vector3(objectFood.foodValue, 0, objectFood.foodValue);
            ast.text = "+" + objectFood.foodValue;
        }
    }
}
