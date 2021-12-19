namespace Trainer.Domain.Abstract
{
    public abstract class EntityExample : BaseEntity
    {
        public string Phrase { get; set; }
        public string Translation { get; set; }
    }
}
