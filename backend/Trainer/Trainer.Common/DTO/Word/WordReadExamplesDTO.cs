using System.Collections.Generic;
using Trainer.Common.DTO.Examples;

namespace Trainer.Common.DTO.Word
{
    public sealed class WordReadExamplesDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public ICollection<ExampleReadDTO> Examples { get; set; }
    }
}
