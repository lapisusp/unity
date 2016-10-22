using UnityEngine;
using System.Collections;

public class selecionarObjetos : MonoBehaviour{

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown(){
        if (this.tag == "Selecionavel"){ // verifica se o objeto tem a tag "Selecionável"
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag(){
        if (this.tag == "Selecionavel"){
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }
    
}
