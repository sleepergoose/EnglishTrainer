using System.Collections.Generic;

namespace Trainer.Common.DTO.Trainer
{
    public sealed class TrainerWordDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
        public ICollection<ExampleDTO> Examples { get; set; }
    }
}


