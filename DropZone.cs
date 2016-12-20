using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    
    GameObject DroppedWhere;

    // GameObject CardUV = (GameObject)Instantiate(Resources.Load("CardBackground"));
    // GameObject CardDK = (GameObject)Instantiate(Resources.Load("DeathKnight"));
    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("OnPointerEnter");

        //CardUV.GetComponent<Image>() = Resources.Load("Card_portrait");
        

        if (eventData.pointerDrag == null)
                return;

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null) {
                d.placeholderParent = this.transform;
            }
        
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        DroppedWhere = GameObject.Find("PlayField");

        if (DroppedWhere.name == gameObject.name)   //Om du spelar kortet.
        {
            
            Debug.Log("Här ska bildrammen försvinna"); //TODO Ta bord rammen när kortet läggs på plan.
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.parentToReturnTo = this.transform;
                
            
            
        }

	}
    void update()
    {
        /* if (IsPlayed == true)
        {
            Debug.Log("BOOM");
        }
        */
    }
}
