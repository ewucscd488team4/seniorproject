using System.IO;
using System.IO.Pipes;
using UnityEngine;

public class Client : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            using (PipeStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, args[0]))
            {
                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    string temp;

                    do
                    {
                        temp = sr.ReadLine();
                    }
                    while (!temp.StartsWith("SYNC"));

                    while ((temp = sr.ReadLine()) != null)
                    {
                    }
                }
            }
        }
    }
}