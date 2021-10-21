using System.IO;
using System.Xml;

namespace Task3_MissingOpeningInvoices.Helpers
{
    public static class Config
    {
        public static string Get(string key)
        {
            string ans = null;
            using (var reader = new StreamReader(@"C:\CRMApplications\GSconfig.xml"))

            // using (var reader = new StreamReader(@"C:\CRMApplications\GSconfig.xml"))
            {
                var xml = new XmlDocument();
                xml.Load(reader);
                var values = xml["GSconfig"];
                if (values != null && key != null && values[key] != null)
                    return values[key].InnerText;
            }
            return ans;
        }
    }
}

