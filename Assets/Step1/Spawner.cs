using Unity.VisualScripting;
using UnityEngine;

namespace Jobs_Demo.Step1
{
    public class Spawner : MonoBehaviour
    {
        [HideInInspector]
        public static Transform[] TargetTransforms;

        public GameObject SeekerPrefab;
        public GameObject TargetPrefab;

        public int NumberOfSeekers;
        public int NumberOfTargets;

        public Vector2 Bound;

        public void Start()
        {
            Random.InitState(42);

            for (int i = 0; i < NumberOfSeekers; i++)
            {
                GameObject go = GameObject.Instantiate(SeekerPrefab);

                var mover = go.GetComponent<Mover>();
                Vector2 direction = Random.insideUnitCircle;
                mover.Direction = new Vector3(direction.x, 0, direction.y);

                go.transform.position = new Vector3(Random.Range(-Bound.x, Bound.x), 0, Random.Range(-Bound.y, Bound.y));
            }
            
            TargetTransforms = new Transform[NumberOfTargets];

            for (int i = 0; i < NumberOfTargets; i++)
            {
                GameObject go = GameObject.Instantiate(TargetPrefab);

                var mover = go.GetComponent<Mover>();
                Vector2 direction = Random.insideUnitCircle;
                mover.Direction = new Vector3(direction.x, 0, direction.y);

                go.transform.position = new Vector3(Random.Range(-Bound.x, Bound.x), 0, Random.Range(-Bound.y, Bound.y));

                TargetTransforms[i] = go.transform;
            }
        }

        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLineList(new Vector3[] {
                new Vector3(-Bound.x, 0, -Bound.y),
                new Vector3(-Bound.x, 0, Bound.y),
                new Vector3(-Bound.x, 0, Bound.y),
                new Vector3(Bound.x, 0, Bound.y),
                new Vector3(Bound.x, 0, Bound.y),
                new Vector3(Bound.x, 0, -Bound.y),
                new Vector3(Bound.x, 0, -Bound.y),
                new Vector3(-Bound.x, 0, -Bound.y),
            });
        }
    }
}