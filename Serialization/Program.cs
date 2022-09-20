// Binary
// pack up an object fields, ame, and the containing assembly

// must be public

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

string outputPath = @"C:\Users\hello\source\repos\Serialization\output.bin";

IFormatter binFormatter = new BinaryFormatter();
MyObject obj = new MyObject();

using (Stream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
{
    binFormatter.Serialize(stream, obj);
}

using(Stream unStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
{
    MyObject deserialObject = (MyObject)binFormatter.Deserialize(unStream);

    Console.WriteLine($"Deserialized object with name {deserialObject.Name} and ahe" +
        $"{deserialObject.Age}");
}

    [Serializable]
    public class MyObject
{
    public string Name = "Objy";
    public int Age = 502;
}