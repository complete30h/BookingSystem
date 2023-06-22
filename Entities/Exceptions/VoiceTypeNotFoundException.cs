using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class VoiceTypeNotFoundException: NotFoundException
    {
        public VoiceTypeNotFoundException(int voiceTypeId): base($"The voice type with id: {voiceTypeId} doesn't exists in the database.")
        {

        }
    }
}
