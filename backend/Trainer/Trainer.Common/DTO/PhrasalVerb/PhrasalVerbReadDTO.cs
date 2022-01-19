using System;
using System.Collections.Generic;
using Trainer.Common.DTO.Examples;

namespace Trainer.Common.DTO
{
    public sealed class PhrasalVerbReadDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
        public ICollection<ExampleReadDTO> Examples { get; set; }
    }
}
