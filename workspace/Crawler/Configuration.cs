using System;
using System.IO;
using System.Xml.Serialization;
using Common;
using Crawler.Model;

namespace Crawler
{
    public static class Configuration
    {
        private static readonly ILog log = new MyLog();

        public static T Read<T>(string configurationPath)
        {
            string xmlContent = GetFileContent(configurationPath);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var stringReader = new StringReader(xmlContent))
                {
                    return (T)serializer.Deserialize(stringReader);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return default(T);
        }

        private static string GetFileContent(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        return sr.ReadToEnd();
                    }
                }
                else
                {
                    log.Error($"File {path} not found", new FileNotFoundException($"File {path} not found"));
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return null;
        }
    }
}
