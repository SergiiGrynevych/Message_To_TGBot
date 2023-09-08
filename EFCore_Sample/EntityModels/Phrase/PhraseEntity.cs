using EFCore_Sample.Models;

namespace EFCore_Sample.EntityModels.Phrase
{
    public class PhraseEntity
    {
        public AppDBContext Context { get; }
        public PhraseEntity(AppDBContext context)
        {
            Context = context;
        }
        public List<Phrase> GetData()
        {
            return Context.Phrases.ToList();
        }
    }
}
