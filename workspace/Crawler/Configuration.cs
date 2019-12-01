using System;
using System.IO;
using System.Xml.Serialization;
using Common;
using Crawler.Model;

namespace Crawler
{
    public static class Configuration
    {
        public static T Read<T>(string configurationPath, ILog logger)
        {
            string xmlContent = GetFileContent(configurationPath, logger);
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
                logger.Error(e.Message, e);
            }
            return default(T);
        }

        private static string GetFileContent(string path, ILog logger)
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
                    logger.Error($"File {path} not found", new FileNotFoundException($"File {path} not found"));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
            }
            return null;
        }
    }
}
