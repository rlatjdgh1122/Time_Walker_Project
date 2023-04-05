using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour{
    public abstract void CompleteFeedback();
    public abstract void CreateFeedback();
    
    protected virtual void OnDestroy(){
        CompleteFeedback();
    }

    protected virtual void OnDisable(){
        CompleteFeedback();
    }


}
