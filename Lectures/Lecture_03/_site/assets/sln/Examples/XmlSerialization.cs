using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Examples
{
    [XmlRoot("StepList")]
    public class StepList
    {
        [XmlElement("Step")]
        public List<Step> Steps { get; set; }
    }

    public class Step
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Desc")]
        public string Desc { get; set; }
    }

    public class XmlSerialization
    {
        public static void Main()
        {
            var testData = @"<StepList>
                        <Step>
                            <Name>Name1</Name>
                            <Desc>Desc1</Desc>
                        </Step>
                        <Step>
                            <Name>Name2</Name>
                            <Desc>Desc2</Desc>
                        </Step>
                    </StepList>";

            var serializer = new XmlSerializer(typeof(StepList));
            using (TextReader reader = new StringReader(testData))
            {
                var result = (StepList)serializer.Deserialize(reader);
            }
        }
    }
}