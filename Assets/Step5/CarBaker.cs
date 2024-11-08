using Unity.Entities;
using UnityEngine;

namespace Jobs_Demo.Step5
{
    class CarBaker : MonoBehaviour
    {
        public float Speed;
        public float SeekRadius;
    }

    class CarBakerBaker : Baker<CarBaker>
    {
        public override void Bake(CarBaker authoring)
        {
            var bakedEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<MoveData>(bakedEntity, new MoveData { Speed = authoring.Speed });
            AddComponent<SeekData>(bakedEntity, new SeekData { SeekRadius = authoring.SeekRadius });
            AddComponent<CarTag>(bakedEntity);
        }
    }
}