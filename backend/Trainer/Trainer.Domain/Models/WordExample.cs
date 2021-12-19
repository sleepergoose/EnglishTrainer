using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public class WordExample : EntityExample
    {
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
