using System;
using System.Xml.Serialization;

namespace X.Web.Sitemap
{
    [Serializable]
    [XmlRoot("url")]
    [XmlType("url")]
    public class Url
    {
        [XmlElement("loc")]
        public String Location { get; set; }

        [XmlIgnore]
        public DateTime? TimeStamp { get; set; }

        /// <summary>
        /// Please do not use this property change last modification date. 
        /// Use TimeStamp instead.
        /// </summary>
        [XmlElement("lastmod")]
        public string LastMod
        {
            get { return TimeStamp.Value.ToString("yyyy-MM-dd"); }
            set
            {
                TimeStamp = DateTime.Parse(value);
                //throw new NotSupportedException("Setting the LastMod property is not supported");
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public bool LastModSpecified { get { return this.TimeStamp.HasValue; } }


        [XmlElement("changefreq")]
        public E_ChangeFrequency? ChangeFrequency { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public bool ChangeFrequencySpecified { get { return this.ChangeFrequency.HasValue; } }

        [XmlElement("priority")]
        public double? Priority { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public bool PrioritySpecified { get { return this.Priority.HasValue; } }

        public Url()
        {
        }

        public static Url CreateUrl(string location)
        {
            return CreateUrl(location, DateTime.Now);
        }

        public static Url CreateUrl(string url, DateTime timeStamp)
        {
            return new Url
                       {
                           Location = url,
                           ChangeFrequency = E_ChangeFrequency.Daily,
                           Priority = 0.5d,
                           TimeStamp = timeStamp,
                       };
        }
    }
}
