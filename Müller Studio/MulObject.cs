using System.Text.Json.Serialization;

namespace Müller_Studio
{
    public class MulObject
    {
        public MulObject(string fileName,string name, int repeat)
        {
            FileName = fileName;
            Name = name;
            Repeat = repeat;
        }
        
        public string FileName { get; set; }
        public string Name { get; set; }
        public int Repeat { get; set; }
    }
}
