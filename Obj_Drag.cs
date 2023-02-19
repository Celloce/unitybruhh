using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Obj_Drag : MonoBehaviour
{
    [HideInInspector]public Vector2 SavePosisi;
    [HideInInspector]public bool IsDiAtasObj;

    Transform SaveObj;

    public int ID;
    public Text Teks;

    [Space]

    public UnityEvent OnDragBenar;

    // Start is called before the first frame update
    void Start()
    {
      SavePosisi = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
     
    }

    private void OnMouseUp()
    {
   
     if (IsDiAtasObj)
     {
      int ID_TempatDrop = SaveObj.GetComponent<Tempat_Drop>().ID;

      if(ID == ID_TempatDrop)
      {
      transform.SetParent(SaveObj);
      transform.localPosition = Vector3.zero;
      transform.localScale = new Vector2(0.7127261f, 0.8183788f); 
      
      SaveObj.GetComponent<SpriteRenderer>().enabled = false;

      SaveObj.GetComponent<Rigidbody2D>().simulated = false;
      SaveObj.GetComponent<BoxCollider2D>().enabled = false;

      gameObject.GetComponent<BoxCollider2D>().enabled = false;

      OnDragBenar.Invoke();

      GameSystem.instance.DataSaatIni++;
      GameSystem.instance.DataScore += 20;
      }
      else
      {
         transform.position = SavePosisi;
         GameSystem.instance.DataScore -= 10;
      }
      
     }
     else
     {
        transform.position = SavePosisi;
     }
     
     
  }
   private void OnMouseDrag()
  {
    Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = Pos;
  }
  private void OnTriggerStay2D(Collider2D trig)
  {
     if(trig.gameObject.CompareTag("Drop"))
     {
       IsDiAtasObj = true;
       SaveObj = trig.gameObject.transform;
     }
  }
   private void OnTriggerExit2D(Collider2D trig)
   {
    if(trig.gameObject.CompareTag("Drop"))
     {
       IsDiAtasObj = false;
     }
   }
}


 
    