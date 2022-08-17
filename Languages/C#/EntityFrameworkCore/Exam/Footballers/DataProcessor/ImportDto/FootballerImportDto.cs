using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required(AllowEmptyStrings = false)]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required(AllowEmptyStrings = false)]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required(AllowEmptyStrings = false)]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required(AllowEmptyStrings = false)]
        public int PositionType { get; set; }
    }
}
