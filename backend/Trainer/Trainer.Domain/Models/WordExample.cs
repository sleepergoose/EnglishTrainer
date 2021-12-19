using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public class WordExample : EntityExample
    {
        public Word Word { get; set; }
    }
}
