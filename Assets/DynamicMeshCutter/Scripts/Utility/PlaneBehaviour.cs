
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;
        public void Cut(Vector3 to, Vector3 from)
        {
            var target = this.gameObject.transform.Find("DSC_Man").GetComponent<MeshTarget>();

            Cut(target, to ,from, null, OnCreated);
        }
        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }

    }
}