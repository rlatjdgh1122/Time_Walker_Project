
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;

        /*PlaneBehaviour pb;

        private void Awake()
        {
            pb = this;
        }
        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.C))
                OnHit();
        }
        public void OnHit()
        {
            pb.Cut();
        }
*/
        public void Cut()
        {
            //UnityEngine.Debug.Log(pb.name);

            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var target = this.gameObject.GetComponentInChildren<MeshTarget>();

                Cut(target, transform.position, transform.forward, null, OnCreated);
            }
            UnityEngine.Debug.Log("Â©¸²");
        }

        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }

    }
}