using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XSD_Application
{
    class Program
    {
        private static void Main(string[] args)
        {
            Appointment appointment = new Appointment
            {
                AppointmentId = 1,
                CreatedBy = 1,
                Response = new Response[12],
                Type = 11,
                GoTo = 13,
                
            };
            Response response = new Response();
            Address address = new Address
            {
                Country = "India",
                State = "Odisha",
                District = "Balasore",
                Post = "Post",
                ItemElementName = ItemChoiceType.City,
                Item = "Item",
            };
            response.Address = address;
            appointment.Response[0] = response;
            appointment.CreatedDate = response.CreatedDate = DateTime.Now;
            Convert(appointment);
            XmlToClass();
        }

        public static String Convert(Appointment Input)
        {
            String data = (String)System.Convert.ChangeType(ClassToXml(Input), typeof(String));
            return data;
        }
        public static string ClassToXml(Object obj)
        {
            StringBuilder sbResponse = new StringBuilder();
            using (TextWriter writer = new StringWriter(sbResponse))
            {
                new XmlSerializer(obj.GetType()).Serialize(writer, obj);
            }
            
            return sbResponse.ToString();
        }
        private static void XmlToClass()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Appointment));
            string xml = File.ReadAllText("../../data.xml");
            using (TextReader reader = new StringReader(xml))
            {
                Appointment appointment = serializer.Deserialize(reader) as Appointment;

                Console.WriteLine(appointment);
                WriteDataToFile(appointment);

            }
            ReadDataFromFile();
        }

        private static void WriteDataToFile(dynamic data)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            FileStream file = File.Create(path);
            XmlSerializer xmlSerializer=new XmlSerializer(data.GetType());
            xmlSerializer.Serialize(file,data);
            file.Flush();
            file.Close();
        }

        private static bool ValidateXmlSchema()
        {
            XmlSchemaSet schemaSet=new XmlSchemaSet();
            schemaSet.CompilationSettings.EnableUpaCheck = true;
            schemaSet.Add("http://tempuri.org/Data.xsd", "../../Data.xsd");
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            XDocument xDocument=XDocument.Load(path);
            xDocument.Validate(schemaSet,null);
            return false;
        }
        private static void ReadDataFromFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            string xml = File.ReadAllText(path);
            using (TextReader reader=new StringReader(xml))
            {
                Appointment appointment=new XmlSerializer(typeof(Appointment)).Deserialize(reader) as Appointment;
                ModifyAppointment(appointment);
            }
        }

        private static void ModifyAppointment(Appointment appointment)
        {
            appointment.CreatedBy = 10;
            appointment.CreatedDate=DateTime.Now;
            appointment.ModifiedBy = 11;
            appointment.Type = 15;
            appointment.GoTo = 11;
            appointment.ModifiedDate=DateTime.Now;
            appointment.ModifiedBySpecified = appointment.ModifiedDateSpecified = true;
            appointment.Response[0].ModifiedBy = 33;
            appointment.Response[0].ModifiedDate=DateTime.Now;
            appointment.Response[0].ModifiedDateSpecified = appointment.Response[0].ModifiedBySpecified = true;
            appointment.Response[0].Address.Post = "Post";
            appointment.Response[0].Address.ItemElementName=ItemChoiceType.City;
            appointment.Address = appointment.Response[0].Address;
            WriteDataToFile(appointment);
            ValidateXmlSchema();
            Environment.Exit(200);
        }
    }
}
