using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

    // public Vector3 cardVector; //SSC
    // public Vector3 heading; //SSC

    GameObject placeholder = null;
    
    /*
    public void RecordPosition()    //SSC
    {   //SSC
        cardVector = this.transform.position;   //SSC
    }   //SSC
    */
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        // InvokeRepeating("RecordPosition", 0f, 0.3f);    //SSC
    
    }
	
	public void OnDrag(PointerEventData eventData) {
		
		this.transform.position = eventData.position;
        // SSC
        /* heading = (Quaternion.Euler(0, 0, -90) * (this.transform.position - cardVector));

        if ((this.transform.rotation.x <= 0.4f) && (this.transform.rotation.x >= -0.4f) && (this.transform.rotation.y <= 0.4f) && (this.transform.rotation.y >= -0.4f) && (this.transform.rotation.z <= 0.4f) && (this.transform.rotation.z >= -0.4f))
        {
            this.transform.Rotate(heading * Time.deltaTime);
            Debug.Log(this.transform.rotation);
        } 
        */ 
        // SSC
        

        if (placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}
	
	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");
		this.transform.SetParent( parentToReturnTo );
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);

        // CancelInvoke(); //SSC
    }
    public void OnMouseEnter()
    {
        Debug.Log("Hovering?");
        //.sizeDelta = new Vector2(yourWidth, yourHeight);
    }
    
    void update()
    {
        /*  //SSC
        if (this.transform.rotation.x > 0.4f) { this.transform.Rotate(-1, 0, 0); }
        if (this.transform.rotation.x < -0.4f) { this.transform.Rotate(1, 0, 0); }
        if (this.transform.rotation.y > 0.4f) { this.transform.Rotate(0, -1, 0); }
        if (this.transform.rotation.y < -0.4f) { this.transform.Rotate(0, 1, 0); }
        if (this.transform.rotation.z > 0.4f) { this.transform.Rotate(0, 0, -1); }
        if (this.transform.rotation.z < -0.4f) { this.transform.Rotate(0, 0, 1); }
        */  //SSC

    }



}
