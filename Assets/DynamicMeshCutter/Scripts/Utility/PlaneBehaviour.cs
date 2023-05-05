
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;
        public void Cut()
        {
            UnityEngine.Debug.Log("Â©¸²");
            var target = this.gameObject.transform.Find("DSC_Man").GetComponent<MeshTarget>();

            Cut(target, transform.position, transform.forward, null, OnCreated);
        }
        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }

    }
}