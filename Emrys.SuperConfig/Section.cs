using Emrys.SuperConfig.Exceptions;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace Emrys.SuperConfig
{

    /// <summary>
    /// �����ļ���ϵĽڵ�
    /// </summary>
    public class Section : ConfigurationSection
    {
        /// <summary>
        /// �����ļ���xml
        /// </summary>

        public XElement XElement { get; set; }

        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="reader"></param>
        protected override void DeserializeSection(XmlReader reader)
        {
            XElement = XElement.Load(reader);
        }

        public static explicit operator XElement(Section section)
        {
            if (section.XElement == null)
                throw new SuperConfigException($"δ�������ļ����ҵ� section '{section.SectionInformation.Name}'��");

            return section.XElement;
        }
    }
}