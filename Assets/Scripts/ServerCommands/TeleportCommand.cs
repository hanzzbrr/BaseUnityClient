
using UnityEngine;

namespace Scripts.ServerCommands
{
    class TeleportCommand
    {
        public void Request(Vector3 position)
        {

        }
        public void Perform(Vector3 position, Transform transform)
        {
            transform.position = position;
        }
    }
}
