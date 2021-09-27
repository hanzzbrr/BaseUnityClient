using UnityEngine;
using Scripts.Connection;
using System.IO;

namespace Scripts.Objects
{
    public class BaseBehaviour : MonoBehaviour
    {
        [SerializeField]
        private int _id;

        [SendAttribute]
        public int Id { get => _id; }
        [SendAttribute]
        public string Name { get => transform.name; }
        [SendAttribute]
        public Vector3 Position { get => transform.position; }
        [SendAttribute]
        public Vector3 Rotation { get => transform.rotation.eulerAngles; }


        public byte[] Serialize()
        {
            using MemoryStream memoryStream = new();
            using BinaryWriter binaryWriter = new(memoryStream);
            binaryWriter.Write(Id);
            binaryWriter.Write(Name);
            return memoryStream.ToArray();
        }

        public static BaseBehaviour Deserialize(byte[] data)
        {
            BaseBehaviour result = new();
            using MemoryStream memoryStream = new(data);
            using BinaryReader binaryReader = new(memoryStream);
            return result;
        }

        // base methods for all monobehaviours

    }
}