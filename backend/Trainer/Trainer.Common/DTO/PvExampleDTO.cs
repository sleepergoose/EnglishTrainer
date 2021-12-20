using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.Common.DTO
{
    public sealed class PvExampleDTO
    {
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
