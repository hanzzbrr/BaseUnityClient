using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Scripts.Connection
{
    public class ClientConnectionManager : MonoBehaviour
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";

        public void ConnectionAttempt()
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                    
                byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                    
                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable); // пока данные есть в потоке
                
                Debug.Log(response.ToString());

                // Закрываем потоки
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Debug.Log($"SocketException: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.Log($"Exception: {e.Message}");
            }

            Debug.Log("Запрос завершен...");
            Console.Read();
        }

        void OnGUI()
        {
            if(GUILayout.Button("Connection attempt"))
            {
                ConnectionAttempt();
            }
        }
    }
}

