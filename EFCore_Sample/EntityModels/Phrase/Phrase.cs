using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Sample.EntityModels.Phrase
{
    [Table("Phrases")]
    public class Phrase
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}
