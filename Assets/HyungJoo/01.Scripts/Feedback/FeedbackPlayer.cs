using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour{
    [SerializeField]
    public List<Feedback> feedbackList = new List<Feedback>();

    public void PlayFeedback(){
        feedbackList.ForEach(f => f.CreateFeedback());
    }

    public void FinishFeedback(){
        feedbackList.ForEach(f => f.CompleteFeedback());
    }
}
