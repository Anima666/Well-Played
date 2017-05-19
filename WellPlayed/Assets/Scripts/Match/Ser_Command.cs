using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Ser_Command : MonoBehaviour {

	void Start ()
    {
       // Begin();
    }

    private void Begin()
    {
        Global2 gl = new Global2();
        gl.Deserilize("Currenteam");

        Command cm = new Command();
        cm.pl = gl.People;
        cm.name = "virtus_pro";
        command.Add(cm);
        cm.name = "natus_vincere";
        command.Add(cm);
        Ser_Comd();
    }

    public List<Command> command = new List<Command>();
    XmlSerializer formatter = new XmlSerializer(typeof(List<Command>));
    void Ser_Comd()
    {
        using (FileStream fs = new FileStream("command.xml", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, command);
            print("Объект сериализован");
            //Console.WriteLine(countbig);
            //Console.WriteLine("Count of player " + man_count);
        }
    }
    public void Com_Deserilize(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        StringReader reader = new StringReader(_xml.ToString());
        command = formatter.Deserialize(reader) as List<Command>;
        reader.Close();
    }
}
